using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfMap : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Damageability damageability = collision.gameObject.GetComponent<Damageability>();

        if (damageability != null)
        {
            MobMovement movementModule = collision.gameObject.GetComponent<MobMovement>();
            if(damageability.Alive)
                movementModule.SetVelocity(3, 4);
            damageability.TakeDamage(damageability.CurrentHp);

        }

    }


}
