using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    public GameObject prefGemAir;

    public Animator animAir;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("AirGem"))
        {
            animAir.SetBool("oui", true);
        }
    }
}
