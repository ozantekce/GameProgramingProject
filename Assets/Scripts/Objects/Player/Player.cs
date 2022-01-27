using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : Controller
{
    

    private PlayerMovement movement;
    private PlayerDamageability damageability;
    private PlayerAnimation animation;





    //--------Cooldowns-------

    private float cdJump = 200;
    private Cooldown jumpCooldown;


    //-----------------


    public void Start()
    {
        
        jumpCooldown = new Cooldown(cdJump);
        movement = GetComponent<PlayerMovement>();
        damageability = GetComponent<PlayerDamageability>();
        animation = GetComponent<PlayerAnimation>();

        damageability.currentHp = StaticVariables.PlayerCurrentHP;
        print(damageability.currentHp);
        UpdateHpBar();

    }  
    public void FixedUpdate()
    {
        AnimatorMethod();

        if (damageability.Alive == false)
        {

            return;
            
        }
            

        if (damageability.DamagedFlag )
        {
            UpdateHpBar();
        }

    }

    


    // This method getting input from player
    public void InputMethod()
    {

        if (Input.GetKey("a")) 
            movement.GoLeftFlag = true;
        if (Input.GetKey("d")) 
            movement.GoRightFlag = true;
        if (Input.GetKeyDown("space") && GetJumpCooldown().Control()) 
            movement.JumpFlag = true;
        if (Input.GetKeyDown("escape"))
            HUD.GETHUD().PopUpMenuControl();

    }


    //This method control PlayerAnimator class
    public void AnimatorMethod() {

        if (!damageability.Alive) 
            animation.Code = 4;
        else if (!movement.DownBound.contactWithGround)
            animation.Code = 2;
        else if (movement.DownBound.contactWithGround &&
            Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 0.05f) 
            animation.Code = 1;
        else 
            animation.Code = 0;

    }


    // CAMERA SETTINGS
    public static float dampTime = 0.15f;
    private static Vector3 velocity = Vector3.zero;
    public static Camera camera;

    private void Update()
    { 
        // leaves camera tracking
        if (!damageability.Alive)
            return;

        InputMethod();

        if (camera == null)
            camera = Camera.current;
        else
        {
            Transform transform = camera.transform;
            Transform target = this.transform;
            if (target)
            {
                Vector3 point = camera.WorldToViewportPoint(target.position);
                Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                Vector3 destination = transform.position + delta;
                destination.y += 0;
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            }
        }

    }


    private void UpdateHpBar(){HUD.GETHUD().UpdateHpBar(damageability);}


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!damageability.Alive)
            return;

        int layer = collision.gameObject.layer;
        string tag = collision.gameObject.tag;
        
        if(layer == CONSTANTS.ITEM_LAYER)
        {

            OnTriggerWithItem(collision);
        }


        if (tag == "Finish")
        {
            InfoScene.NextSceneIndex = SceneManager.GetActiveScene().buildIndex+1;
            if (CONSTANTS.INFO_SCENE_INDEX == InfoScene.NextSceneIndex)
            {
                InfoScene.InfoText = "YOU WIN";
                InfoScene.NextSceneIndex = CONSTANTS.SENDSCORE_SCENE_INDEX;
            }
            else
                InfoScene.InfoText = "Level " + (InfoScene.NextSceneIndex);

            Destroy(collision.gameObject);
            InfoScene.WaitTime = 1.5f;
            Music.GETMUSIC().WinEffect(transform.position);
            IEnumerator coroutine = CONSTANTS.WaitAndLoad(0.9f, CONSTANTS.INFO_SCENE_INDEX);
            StartCoroutine(coroutine);
        }

    }






    private void OnTriggerWithItem(Collider2D collision)
    {

        string tag = collision.gameObject.tag;
        if (tag == CONSTANTS.HEART_TAG && damageability.CurrentHp!=damageability.MaxHp)
        {
            StaticVariables.ChangeHp(StaticVariables.PlayerCurrentHP + 1);
            Destroy(collision.gameObject);
            Music.GETMUSIC().TakeItemEffect1(transform.position);
            return;
        }

        if (tag == CONSTANTS.ACORN_TAG)
        {
            StaticVariables.IncreaseScore(CONSTANTS.ACORN_SCORE);
            Destroy(collision.gameObject);
            Music.GETMUSIC().TakeItemEffect1(transform.position);
            return;
        }

    }
    


    //---------Getter Setter

    public PlayerMovement Movement { get => movement; set => movement = value; }
    public PlayerAnimation Animation { get => animation; set => animation = value; }
    public PlayerDamageability Damageability { get => damageability; set => damageability = value; }


    private Cooldown GetJumpCooldown()
    {
        if (jumpCooldown == null)
            jumpCooldown = new Cooldown(cdJump);
        return jumpCooldown;
    }



    //--------------



}
