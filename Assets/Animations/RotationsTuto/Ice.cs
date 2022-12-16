using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public GameObject prefGemIce;

    public Animator animIce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("IceGem"))
        {
            animIce.SetBool("oui", true);
        }
    }
}