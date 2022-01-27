using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cooldown
{


    private float cooldown;

    private float lastTime;


    public Cooldown(float cooldown)
    {
        this.cooldown = cooldown;
        lastTime = Time.realtimeSinceStartup;
    }

    public void SetCooldown(float cooldown)
    {
        this.cooldown = cooldown;
    }

    public bool Control()
    {

        if (ElapsedTime() >= cooldown)
        {
            lastTime = Time.realtimeSinceStartup;
            return true;
        }
        else
            return false;

    }


    public float ElapsedTime()
    {

        return (Time.realtimeSinceStartup - lastTime) * 1000;
    }

}
