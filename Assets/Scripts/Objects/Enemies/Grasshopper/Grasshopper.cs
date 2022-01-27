using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grasshopper : Enemy
{


    private Cooldown jumpCooldown;
    [SerializeField]private float jumpCD = 1000;



    public void Start()
    {
        base.Start();
    }


    void FixedUpdate()
    {

        base.FixedUpdate();
        AnimatorMethod();
    }


    public void AnimatorMethod()
    {

        if (!Damageability.Alive)
        {
            Animation.Code = 1;
        }
        else if (!Movement.DownBound.contactWithGround)
        {

            if(Movement.GetVelocity().y>0)
                Animation.Code = 3;
            else
                Animation.Code = 4;

        }
        else
        {

            Animation.Code = 2;

        }
        


    }

    protected override void SetFlags()
    {

        if (direction == 0 && !Movement.OnGround())
        {
            Movement.GoLeftFlag = true;
        }
        else if (direction == 1 && !Movement.OnGround())
        {

            Movement.GoRightFlag = true;

        }

        if (Movement.OnGround()&&GetjumpCooldown().Control())
        {
            Movement.JumpFlag = true;
        }


    }

    private Cooldown GetjumpCooldown()
    {
        if (jumpCooldown == null)
        {
            jumpCooldown = new Cooldown(jumpCD);
        }

        return jumpCooldown;

    }



}
