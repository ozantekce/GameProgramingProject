using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack :MonoBehaviour, Feature
{



    //---------Attributes--------------
    public bool  active = true;
    public float tossingTargetHorizontal;
    public float tossingTargetUp;
    public int   attackPower;
    public float cooldown = 1000;
    //---------------------------------



    /*  Cooldowns */

    private Cooldown attackCooldown;

    /* end Cooldowns */


    /*  Flags   */

    private bool attackedFlag;



    /* end Flags   */


    
    public void Start()
    {

        attackCooldown = new Cooldown(cooldown);

    }


    
    
    public void FixedUpdate()
    {

    }

   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!active)
            return;

        int layer = collision.gameObject.layer;
        string tag = collision.gameObject.tag;
        if (CanGiveDamage(layer,tag))
        {
            Damageability damageability = collision.gameObject.GetComponent<Damageability>();
            AttackWithContact(damageability);
        }

    } 


    // This method check that it can attack the parameter
    protected abstract bool CanGiveDamage(int layer, string tag);

    // This method does damage to destination
    protected virtual void AttackWithContact(Damageability destination)
    {

        if (GetAttackCooldown().Control())
        {

            destination.TakeDamage(attackPower);

            Movement movement = destination.gameObject.GetComponent<Movement>();
            float temp = transform.position.x - movement.transform.position.x;

            if (temp > 0)
            {
                movement.SetVelocity(0, tossingTargetHorizontal);
            }
            else
            {
                movement.SetVelocity(1, tossingTargetHorizontal);
            }

            movement.SetVelocity(3,tossingTargetUp);
            attackedFlag = true;
        }
            


    }



    
    



    
    //----------Get-Set----------

    protected Cooldown GetAttackCooldown()
    {
        if (attackCooldown == null)
        {
            attackCooldown = new Cooldown(cooldown);
        }

        return attackCooldown;

    }

    public bool AttackedFlag { get => attackedFlag; set => attackedFlag = value; }

   
    
    //-----------------------------



}
