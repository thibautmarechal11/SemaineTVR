using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject prefGemFire;

    public Animator animFire;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("FireGem"))
        {
            animFire.SetBool("oui", true);
        }
    }
}
