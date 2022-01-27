using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement: MonoBehaviour, Feature
{


    // direction : 0-left   1-right     2-down  3-up 

    //---------Attributes--------------

    public float acceleration;
    public float gravity;
    public float friction;

    //---------------------------------


    //---------Fixers----------------
    private float extraFriction;
    //------------------------------


    public void Start()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        PhysicFunc();
        ControlMaxVelocity();
    }


    private Rigidbody2D rigidbody2D;

    public void Init()
    {
        rigidbody2D = this.GetComponent<Rigidbody2D>();
    }
    public void Tick() {

        PhysicFunc();
        ControlMaxVelocity();

    }




    //This method applies gravity and friction.
    private void PhysicFunc()
    {

        // Gravity
        GiveVelocity(2,gravity);




        // Friction (düzenlenebilir)

        if (Mathf.Abs(rigidbody2D.velocity.x) > 0.1f)
        {

            if (rigidbody2D.velocity.x > 0)
            {
                if (rigidbody2D.velocity.x <= friction+extraFriction)
                    SetVelocity(0, 0);
                else
                    GiveVelocity(0, friction+ extraFriction);
            }
            else
            {
                if (rigidbody2D.velocity.x >= friction+ extraFriction)
                    SetVelocity(1, 0);
                else
                    GiveVelocity(1, friction+ extraFriction);
            }

        }

    }


    //This method checks velocity doesn't exceed the max speed.
    private void ControlMaxVelocity()
    {
        if (rigidbody2D.velocity.magnitude > CONSTANTS.MAX_SPEED)
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * CONSTANTS.MAX_SPEED;

    }

    //This method increases current velocity with second parameter
    public void GiveVelocity(int direction, float velocity)
    {
        rigidbody2D.velocity += velocity * CONSTANTS.DIRECTIONS[direction];
    }

    //This method set current velocity with second parameter
    public void SetVelocity(int direction, float velocity)
    {
        Vector2 temp = velocity * CONSTANTS.DIRECTIONS[direction];

        if (direction == 0 || direction == 1)
            temp.y = rigidbody2D.velocity.y;
        else
            temp.x = rigidbody2D.velocity.x;

        rigidbody2D.velocity = temp;

    }

    //This method applies force as the second parameter.
    public void GiveForce(int direction, float force)
    {
        rigidbody2D.AddForce(force * CONSTANTS.DIRECTIONS[direction]);
        
    }





    //------Get/Set----------
    public Vector2 GetVelocity()
    {
        return rigidbody2D.velocity;
    }
    public Rigidbody2D Rigidbody2D { get => rigidbody2D; set => rigidbody2D = value; }
    public float ExtraFriction { get => extraFriction; set => extraFriction = value; }
}
