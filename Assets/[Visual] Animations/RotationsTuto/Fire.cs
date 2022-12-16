using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject prefGemFire;

    public Animator animFire;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile_Fire>())
        {
            animFire.SetBool("oui", true);
        }
    }
}
