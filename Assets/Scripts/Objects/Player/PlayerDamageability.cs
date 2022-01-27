using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageability : Damageability
{

    public static bool ChangeHp { get => changeHp; set => changeHp = value; }

    private static bool changeHp;

    public void Start()
    {

        base.Start();

    }


    public void FixedUpdate()
    {
        if (changeHp)
        {
            currentHp = StaticVariables.PlayerCurrentHP;
            changeHp = false;
            HUD.GETHUD().UpdateHpBar(this);
        }

        base.FixedUpdate();

    }


    public override void TakeDamage(int val)
    {
        if (currentHp <= 0)
            return;

        Music.GETMUSIC().HurtEffect1(transform.position);
        base.TakeDamage(val);
        StaticVariables.PlayerCurrentHP = currentHp;
        if(currentHp<=0)
            Music.GETMUSIC().LostEffect(transform.position);

    }




}

