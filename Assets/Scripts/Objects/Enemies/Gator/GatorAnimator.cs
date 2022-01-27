using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatorAnimator : Animation
{

    private static Dictionary<int, string> triggers;

    protected override Dictionary<int, string> GetTriggers()
    {

        if (triggers != null)
            return triggers;

        Dictionary<int, string> temp = new Dictionary<int, string>();

        temp.Add(1, "hurt");

        triggers = temp;

        return triggers;

    }

    public void Start()
    {

        base.Start();
    }

    public void FixedUpdate()
    {
        base.FixedUpdate();

    }


}
