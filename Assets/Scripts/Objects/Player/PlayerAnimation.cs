using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : Animation
{


    private static Dictionary<int, string> triggers;

    protected override Dictionary<int, string> GetTriggers()
    {

        if (triggers != null)
            return triggers;

        Dictionary<int, string> temp = new Dictionary<int, string>();

        temp.Add(0, "idle");
        temp.Add(1, "run");
        temp.Add(2, "jump");
        temp.Add(4, "hurt");
        triggers = temp;
        return triggers;

    }


    private Player player;


    //------CDs----------
    private Cooldown blinkCooldown;
    //--------------------


    public void Start()
    {

        base.Start();
        player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {

        base.FixedUpdate();
        if (player.Damageability.DamagedFlag)
        {
            Blink();
        }

    }




    // This method blink player when it get damage
    private void Blink()
    {

        if (!GetBlinkCooldown().Control())
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
        }
        else
        {
            blinkCooldown = null;
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            player.Damageability.DamagedFlag = false;
        }

    }


    private Cooldown GetBlinkCooldown()
    {
        if (blinkCooldown == null)
        {
            blinkCooldown = new Cooldown(1000);
        }

        return blinkCooldown;

    }


}
