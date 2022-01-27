using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenBlock : MonoBehaviour
{


    private Cooldown dropCooldown;
    private Cooldown destroyCooldown;

    public void Start()
    {
        
    }

    private bool drop;

    // it shake and drop when player detected then destroy itself
    public void FixedUpdate()
    {

        if (playerDetected)
        {

            if (!drop)
            {

                if (GetDropCooldown().Control())
                {
                    drop = true;
                }
                else
                {
                    Shake();
                }

            }
            else
            {
                Drop();
                if (GetDestroyCooldownn().Control())
                    Destroy(this.gameObject);
            }


        }

    }


    private float shakeSpeed = 0.012f;
    
    // shaking until drop
    private void Shake()
    {
        transform.position = new Vector2(transform.position.x + shakeSpeed, transform.position.y);
        shakeSpeed *= -1;
    }

    private float dropSpeed = 0.1f;

    //drop when cd is over
    private void Drop()
    {
        transform.position = new Vector2(transform.position.x,transform.position.y-dropSpeed);
    }



    private bool playerDetected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == CONSTANTS.PLAYER_TAG)
            playerDetected = true;
    }



    /* get-set */
    private Cooldown GetDropCooldown()
    {
        if (dropCooldown == null)
            dropCooldown = new Cooldown(1500);
        return dropCooldown;
    }

    private Cooldown GetDestroyCooldownn()
    {
        if (destroyCooldown == null)
            destroyCooldown = new Cooldown(4000);
        return dropCooldown;
    }

    /* end get-set */

}
