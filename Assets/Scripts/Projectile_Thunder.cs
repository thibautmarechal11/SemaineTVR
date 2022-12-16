using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Thunder : MonoBehaviour
{
    public float damage = 4;
    public float radius = 2;
    GameObject player;

    public GameObject feedbackSphere;
    public Material feedBackMat;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Golem")
        {
            Spreading(collision.transform.position);
            GameObject feedback;
            Destroy(feedback = Instantiate(feedbackSphere, transform.position, Quaternion.identity), 0.5f);
            feedback.transform.localScale = new Vector3(radius, radius, radius);
            feedback.GetComponent<Renderer>().material = feedBackMat;
        }
        else if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);

        Destroy(gameObject);
    }

    void Spreading(Vector3 pos)
    {
        Collider[] colliders = Physics.OverlapSphere(pos, radius);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.tag == "Golem")
                {
                    collider.SendMessage("GetZapped", damage);
                    Spreading(collider.gameObject.transform.position);
                }
            }
            Destroy(gameObject);
    }


}
