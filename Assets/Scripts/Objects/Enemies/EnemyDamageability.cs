using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageability : Damageability
{


    public void Start()
    {
        base.Start();
    }


    public void FixedUpdate()
    {
        base.FixedUpdate();
    }


    public override void TakeDamage(int val)
    {
        Music.GETMUSIC().HurtEffect2(transform.position);
        base.TakeDamage(val);

    }

}
