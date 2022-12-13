using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class AIController : MonoBehaviour
{
    public float health = 100;

    [HideInInspector] public bool alive;

    MoveTowardTarget moveTowardTarget;
    AIAttack aiAttack;

    GameObject player;

    NavMeshAgent agent;

    private void Awake()
    {
        moveTowardTarget = GetComponent<MoveTowardTarget>();
        aiAttack = GetComponent<AIAttack>();

        player = GameObject.FindGameObjectWithTag("Player");

        agent = GetComponent<NavMeshAgent>();
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
}
