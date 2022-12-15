using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Air : MonoBehaviour
{
    public float damage = 4;
    public float distance = 5;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Golem")
        {
            // AIR COMPORTEMENT
            Destroy(gameObject);
        }
    }
}
