using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Ice : MonoBehaviour
{
    public float damage = 4;
    public float timeToSlow = 5;
    float[] param = new float[2];

    private void Start()
    {
        param[0] = damage;
        param[1] = timeToSlow;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Golem")
        {
            collision.gameObject.SendMessage("GetSlowed", param);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);
    }
}
