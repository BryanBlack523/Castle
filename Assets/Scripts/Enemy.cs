using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float maxSpeed = 6f;
    [SerializeField] Transform target;
    [SerializeField] float health = 1;

    private NavMeshAgent navMeshAgent;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.enabled = !isDead;// false when dead
        MoveTo(target.position);

        if (target.position.x == this.transform.position.x)
        {
            Death();
        }
    }

    public void MoveTo(Vector3 destination)
    {
        navMeshAgent.destination = destination;
        navMeshAgent.isStopped = false;
    }

    public void Death()
    {
        navMeshAgent.isStopped = true;
        isDead = true;
        health = 0;
    }
}
