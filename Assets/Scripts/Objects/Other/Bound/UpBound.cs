using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBound : Bound
{
    
    private void Start()
    {

    }

    private void Update()
    {

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == CONSTANTS.GROUND_LAYER
            || collision.gameObject.layer == CONSTANTS.ENEMY_LAYER)
            contactWithGround = true;

        if (!contacts.Contains(collision.gameObject.tag))
        {
            contacts.Add(collision.gameObject.tag); 
        }

        if (!contacts.Contains(collision.gameObject.layer))
        {
            contacts.Add(collision.gameObject.layer);
        }
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.layer == CONSTANTS.GROUND_LAYER
            || collision.gameObject.layer == CONSTANTS.ENEMY_LAYER)
            contactWithGround = true;

        if (!contacts.Contains(collision.gameObject.tag))
        {
            contacts.Add(collision.gameObject.tag);
        }

        if (!contacts.Contains(collision.gameObject.layer))
        {
            contacts.Add(collision.gameObject.layer);
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.layer == CONSTANTS.GROUND_LAYER
            || collision.gameObject.layer == CONSTANTS.ENEMY_LAYER)
            contactWithGround = true;

        if (contacts.Contains(collision.gameObject.tag))
        {
            contacts.Remove(collision.gameObject.tag);
        }

        if (contacts.Contains(collision.gameObject.layer))
        {
            contacts.Remove(collision.gameObject.layer);
        }

    }




}
