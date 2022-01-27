using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{

    public float spinSpeed;
    public float velocityVertical;
    public float velocityHorizontal;

    private bool changeDir;
    public bool directionLeft = true;
    public bool directionUp = true;

    private Movement movement;
    private Cooldown changeDirectionCooldown;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    private void FixedUpdate()
    {

        transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z+spinSpeed);

        if (changeDir && GetchangeDirectionCooldown().Control())
        {
            directionLeft = !directionLeft;
            directionUp = !directionUp;
            changeDir = false;
        }

        if (directionLeft)
            movement.SetVelocity(0, velocityHorizontal);
        else
            movement.SetVelocity(1, velocityHorizontal);

        if (directionUp)
            movement.SetVelocity(3, velocityVertical);
        else
            movement.SetVelocity(2, velocityVertical);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        if (CONSTANTS.BLADE_CHANGE_DIRECTION_LIST.Contains(tag))
        {
            changeDir = true;
        }

    }


    protected Cooldown GetchangeDirectionCooldown()
    {
        if (changeDirectionCooldown == null)
        {
            changeDirectionCooldown = new Cooldown(50);
        }

        return changeDirectionCooldown;

    }

}
