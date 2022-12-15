using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class AIController : MonoBehaviour
{
    public float health = 100;
    [SerializeField] float slowSpeed = 1;
    float speedNormal;

    [HideInInspector] public bool alive;

    MoveTowardTarget moveTowardTarget;
    AIAttack aiAttack;

    GameObject player;

    NavMeshAgent agent;

    public Material damageMaterial;
    public Material slowMaterial;
    public Material normalMaterial;

    private void Awake()
    {
        moveTowardTarget = GetComponent<MoveTowardTarget>();
        aiAttack = GetComponent<AIAttack>();

        player = GameObject.FindGameObjectWithTag("Player");

        agent = GetComponent<NavMeshAgent>();
        speedNormal = agent.speed;
    }

    private void Start()
    {
        moveTowardTarget.GoToTarget(player.transform.position);
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= agent.stoppingDistance + 1)
            aiAttack.enabled = true;
        else
            aiAttack.enabled = false;
    }

    public void GetSlowed(float[] param)
    {
        GetDamaged(param[0]);
        StartCoroutine("SlowTime", param[1]);
    }

    IEnumerator SlowTime(float timeToSlow)
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.material = slowMaterial;
        }
        agent.speed = slowSpeed;
        yield return new WaitForSeconds(timeToSlow);
        /*foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.material = normalMaterial;
        }*/
        agent.speed = speedNormal;
    }

    public void GetDamaged(float damage)
    {
        health -= damage;
        StartCoroutine("ClignotiClignota");
    }

    IEnumerator ClignotiClignota()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.material = damageMaterial;
        }
        yield return new WaitForSeconds(0.2f);
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            renderer.material = normalMaterial;
        }
    }
}
