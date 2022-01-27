using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableText : MonoBehaviour
{


    public float speed = 0.1f;
    public float speedOfGrow;

    private Cooldown cooldown;
    // Start is called before the first frame update
    void Start()
    {

        cooldown = new Cooldown(2000);

    }

    // Update is called once per frame
    void Update()
    {

        if (cooldown.Control())
        {
            speed *= -1;
            speedOfGrow *= -1;
        }
            

        transform.Translate(0, speed * Time.deltaTime, 0, Space.World);

        float x = transform.localScale.x;
        float y = transform.localScale.y;


        transform.localScale = new Vector2(x+ speedOfGrow, y+ speedOfGrow);

    }


}
