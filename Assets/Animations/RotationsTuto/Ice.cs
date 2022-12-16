using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public GameObject prefGemIce;

    public Animator animIce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile_Ice>())
        {
            Debug.Log("ICE LETS GO");
            animIce.SetBool("oui", true);
        }
    }
}