using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Fire : MonoBehaviour
{
    public float damage = 4;
    public float radius = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Golem" || collision.gameObject.tag == "Ground")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Spells/Fire");
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.tag == "Golem")
                    collider.SendMessage("GetDamaged", damage);
            }
            Destroy(gameObject);
        }
    }
}
