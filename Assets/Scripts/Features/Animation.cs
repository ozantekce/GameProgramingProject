using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animation : MonoBehaviour, Feature
{

    protected Animator animator;

    private int code;

    public int Code { get => code; set => code = value; }

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        ResetAnimatorTriggers();
        AnimatorContor(code);
    }


    // This method triggers the desired animator trigger
    private void AnimatorContor(int code)
    {
        if (GetTriggers().ContainsKey(code))
            this.animator.SetTrigger(GetTriggers()[code]);
    }

    private void ResetAnimatorTriggers()
    {
        foreach (var item in GetTriggers())
        {
            this.animator.ResetTrigger(item.Value);
        }
    }


    protected abstract Dictionary<int, string> GetTriggers();

}
