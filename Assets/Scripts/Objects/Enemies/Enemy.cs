using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Controller
{


    private MobMovement movement;
    private EnemyDamageability damageability;
    private Animation animation;
    private Attack attack;


    protected int direction;
    private Cooldown changeDirectionCooldown;


    public MobMovement Movement { get => movement; set => movement = value; }
    public EnemyDamageability Damageability { get => damageability; set => damageability = value; }
    public Animation Animation { get => animation; set => animation = value; }
    public Attack Attack { get => attack; set => attack = value; }

    /*
    protected override void Init()
    {

        movement = GetComponent<MobMovement>();
        damageability = GetComponent<Damageability>();
        animation = GetComponent<Animation>();
        attack = GetComponent<EnemyAttack>();


    }

    protected override void Tick()
    {

        if (!damageability.Alive)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

            animation.Code = 1;
            attack.active = false;
            movement.goLeftFlag = false;
            movement.goRightFlag = false;
            return;
        }
        BasicAI();
        SetFlags();

    }
    */

    public void Start()
    {

        movement = GetComponent<MobMovement>();
        damageability = GetComponent<EnemyDamageability>();
        animation = GetComponent<Animation>();
        attack = GetComponent<EnemyAttack>();



    }

    public void FixedUpdate()
    {

        if (!damageability.Alive)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            animation.Code = 1;
            attack.active = false;
            movement.GoLeftFlag = false;
            movement.GoRightFlag = false;
            return;
        }
        BasicAI();
        SetFlags();

    }


    // basic AI
    protected virtual void BasicAI()
    {

        if (movement.minSpeed==0)
            return;

        if (movement.Direction == 0)
        {
            if (attack.AttackedFlag ||(GetchangeDirectionCooldown().Control() &&
                CONSTANTS.ContainsList(movement.LeftBound.contacts, CONSTANTS.ENEMY_CHANGE_DIRECTION_LIST)))
            {
                direction = 1;
                attack.AttackedFlag = false;
            }
        }
        else
        {
            if (attack.AttackedFlag || (GetchangeDirectionCooldown().Control() &&
                CONSTANTS.ContainsList(movement.RightBound.contacts, CONSTANTS.ENEMY_CHANGE_DIRECTION_LIST)))
            {
                direction = 0;
                attack.AttackedFlag = false;
            }

        }


    }

    protected virtual void SetFlags()
    {

        if (direction == 0)
        {
            movement.GoLeftFlag = true;
        }
        else if (direction == 1)
        {
            movement.GoRightFlag = true;
        }

    }

    /* Set Get */
    protected Cooldown GetchangeDirectionCooldown()
    {
        if (changeDirectionCooldown == null)
        {
            changeDirectionCooldown = new Cooldown(150);
        }

        return changeDirectionCooldown;

    }

}
