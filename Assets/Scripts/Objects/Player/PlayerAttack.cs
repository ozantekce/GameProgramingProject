using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Attack
{


    private DownBound downBound;
    private PlayerMovement playerMovement;
    private PlayerDamageability damageability;


    public void Start()
    {
        base.Start();
        downBound = GetComponentInChildren<DownBound>();
        playerMovement = GetComponent<PlayerMovement>();
        damageability = GetComponent<PlayerDamageability>();
    }
    public void FixedUpdate()
    {
        if (damageability.Alive)
            base.FixedUpdate();

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (!damageability.Alive)
            return;
        

        if (CONSTANTS.ContainsList(CONSTANTS.PLAYER_GIVE_DAMAGE_LIST,downBound.contacts))
        {

            Damageability damageability = collision.gameObject.GetComponent<Damageability>();
            if (damageability == null)
            {
                return;
            }
            if (!damageability.Alive)
                return;

            AttackWithContact(damageability);
            playerMovement.SetVelocity(3, playerMovement.jump);


            if (damageability.currentHp == 0)
                StaticVariables.IncreaseScore(100);

            /*
            int layer = collision.gameObject.layer;
            string tag = collision.gameObject.tag;
            if (CONSTANTS.PLAYER_GIVE_DAMAGE_LIST.Contains(layer) 
                || CONSTANTS.PLAYER_GIVE_DAMAGE_LIST.Contains(tag))
            {

                Damageability damageability = collision.gameObject.GetComponent<Damageability>();
                if (!damageability.Alive)
                    return;

                AttackWithContact(damageability);
                playerMovement.SetVelocity(3,playerMovement.jump);

                
                if(damageability.currentHp==0)
                    HUD.UpdateScore(100);
                
            }
        */


        }


    }

    protected override bool CanGiveDamage(int layer, string tag)
    {
        return CONSTANTS.PLAYER_GIVE_DAMAGE_LIST.Contains(layer) || CONSTANTS.PLAYER_GIVE_DAMAGE_LIST.Contains(tag);
    }

}
