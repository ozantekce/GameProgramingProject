using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{


    public float speed = 0.1f;
    private Cooldown cooldown;
    // Start is called before the first frame update
    void Start()
    {

        cooldown = new Cooldown(500);

    }

    // Update is called once per frame
    void Update()
    {

        if (cooldown.Control())
            speed *= -1;

        transform.Translate(0, speed * Time.deltaTime, 0, Space.World);


    }


}