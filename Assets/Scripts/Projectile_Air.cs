using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Air : MonoBehaviour
{
    public float damage = 4;
    public float distance = 5;
    float[] param = new float[2];
    GameObject player;

    private void Start()
    {
        param[0] = damage;
        param[1] = distance;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Golem")
        {
            collision.gameObject.SendMessage("GetAirPush", param);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);
    }
}
