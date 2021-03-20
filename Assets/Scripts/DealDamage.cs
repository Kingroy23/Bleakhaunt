using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public int Attack = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        damagable checkIfDamagable = collision.gameObject.GetComponent<damagable>();
        //var checkIfDamagable = collision.GetComponent<Damagable>();
        if (checkIfDamagable != null)
        {
            if (checkIfDamagable.isPlayer)
            {
                checkIfDamagable.Damage(Attack);
            }
        }

        /*PlayerMovement motion = collision.gameObject.GetComponent<PlayerMovement>();
        if (motion != null)
        {
            Vector2 bounceDirection = collision.relativeVelocity;
            motion.movement = bounceDirection.normalized * -10f;

        }*/
    }
}
