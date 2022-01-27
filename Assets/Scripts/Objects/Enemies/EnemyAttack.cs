using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Attack
{


    public void Start()
    {
        //Init();
        base.Start();
    }


    public void FixedUpdate()
    {
        //Tick();
        base.FixedUpdate();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (active)
        {
            int    layer = collision.gameObject.layer;
            string tag = collision.gameObject.tag;
            if (CanGiveDamage(layer,tag) &&
                !GetComponent<MobMovement>().UpBound.contacts.Contains("Player"))
            {
                Damageability damageability = collision.gameObject.GetComponent<Damageability>();
                AttackWithContact(damageability);
                GetComponent<Movement>().SetVelocity(0, 0);
            }


        }


    }


    protected override bool CanGiveDamage(int layer, string tag)
    {
        return tag == "Player";
    }


}
