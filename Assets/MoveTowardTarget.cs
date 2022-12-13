using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTowardTarget : MonoBehaviour
{
    NavMeshAgent agent;

    private void Awake()
    {

        agent = GetComponent<NavMeshAgent>();
    }

    public void GoToTarget(Vector3 target)
    {
        agent.SetDestination(target);
    }

}
