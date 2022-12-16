using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    public GameObject prefGemAir;

    public Animator animAir;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile_Air>())
        {
            animAir.SetBool("oui", true);
        }
    }
}
