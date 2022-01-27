using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGround : MonoBehaviour
{


    private CompositeCollider2D collider;

    // Start is called before the first frame update
    private void Start()
    {
        collider = GetComponent<CompositeCollider2D>();
        collider.isTrigger = true;
    }


    private void FixedUpdate()
    {
        
    }


   private void OnTriggerEnter2D(Collider2D collision)
    {

        string tag = collision.gameObject.tag;

        if (tag == "DownBound")
        {

                collider.isTrigger = false;
        }



    }



    private void OnTriggerStay2D(Collider2D collision)
    {

        string tag = collision.gameObject.tag;
        if (tag == "Player")
        {
            Transform ts = collision.gameObject.GetComponent<Transform>();
            ts.position = new Vector2(ts.position.x, ts.position.y + 0.02f);

        }

    }

    private readonly float fixerF = 0.02f;
    private float fixer = 0.02f;

    private void OnCollisionStay2D(Collision2D collision)
    {

        string tag = collision.gameObject.tag;
        if (tag == "Player")
        {
            Transform ts = collision.gameObject.GetComponent<Transform>();
            ts.position = new Vector2(ts.position.x, ts.position.y + fixer);
            fixer /= 1.6f;

        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {

        string tag = collision.gameObject.tag;

        if (tag == "DownBound")
        {
            collider.isTrigger = true;
            fixer = fixerF;
        }

    }



    private void OnTriggerExit2D(Collider2D collision)
    {

        string tag = collision.gameObject.tag;

        if (tag == "DownBound")
        {
            collider.isTrigger = true;
            fixer = fixerF;
        }

    }



}
