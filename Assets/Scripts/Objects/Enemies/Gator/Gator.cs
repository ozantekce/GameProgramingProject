using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gator : Enemy
{

    public int verticalDir;
    public float verticalSpeed;

    public float maxDistance;

    private Vector2 firstPoint;


    /*
    protected override void Init()
    {

        base.Init();
        firstPoint = transform.position;
    }

    protected override void Tick()
    {

        base.Tick();

    }
    */

    public void FixedUpdate()
    {

        base.FixedUpdate();

    }

    public void Start()
    {
        base.Start();
        firstPoint = transform.position;

    }


    private readonly float timeFixFinal = 0.2f;
    private float timeFix = 0.2f;

    protected override void BasicAI()
    {
        base.BasicAI();

        timeFix -= Time.deltaTime;

        //print(timeFix);

        if(timeFix<=0 && Mathf.Abs(firstPoint.y-transform.position.y) > maxDistance)
        {

            if (verticalDir == 2)
                verticalDir = 3;
            else if (verticalDir == 3)
                verticalDir = 2;
            timeFix = timeFixFinal;

        }
        

        if (verticalDir== 2)
        {

            if (Attack.AttackedFlag || (GetchangeDirectionCooldown().Control() &&
                CONSTANTS.ContainsList(Movement.DownBound.contacts, CONSTANTS.ENEMY_CHANGE_DIRECTION_LIST)))
            {
                verticalDir = 3;
                Attack.AttackedFlag = false;
            }

        }
        else if(verticalDir == 3)
        {


            if (Attack.AttackedFlag || (GetchangeDirectionCooldown().Control() &&
                CONSTANTS.ContainsList(Movement.UpBound.contacts, CONSTANTS.ENEMY_CHANGE_DIRECTION_LIST)))
            {

                verticalDir = 2;
                Attack.AttackedFlag = false;
            }

        }

    }

    protected override void SetFlags()
    {
        base.SetFlags();

        if (verticalDir == 2)
        {
            Movement.SetVelocity(2,verticalSpeed);
        }
        else if (verticalDir == 3)
        {

            Movement.SetVelocity(3, verticalSpeed);

        }

    }



}
