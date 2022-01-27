using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAttack : Attack
{



    public void Start()
    {
        base.Start();
    }

    

    public void FixedUpdate()
    {
        base.FixedUpdate();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (active)
        {
            int layer = collision.gameObject.layer;
            string tag = collision.gameObject.tag;
            if (CanGiveDamage(layer,tag))
            {
                Damageability damageModule = collision.gameObject.GetComponent<Damageability>();
                AttackWithContact(damageModule);
            }
        }

    }



    protected void AttackWithContact(Damageability destination)
    {

        MobMovement movement = destination.gameObject.GetComponent<MobMovement>();
        float temp = this.transform.position.x - movement.transform.position.x;

        if (temp > 0)
        {
            movement.SetVelocity(0, tossingTargetHorizontal);
        }
        else
        {
            movement.SetVelocity(1, tossingTargetHorizontal);
        }

        movement.SetVelocity(3, tossingTargetUp);


        if (GetAttackCooldown().Control())
        {
            destination.TakeDamage(attackPower);
        }



    }

    protected override bool CanGiveDamage(int layer, string tag)
    {
        return tag == "Player";
    }


}
