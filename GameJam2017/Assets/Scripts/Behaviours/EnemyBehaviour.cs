using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public bool Follow = false;
    public float DeathTimer = 1.0f;
    private NavMeshAgent Agent;
    private Transform target;


    public int HitPoints = 10;

    [HideInInspector]
    public bool destroy = false;
    
    void Start ()
    {
        Agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("chassis").GetComponent<Transform>();	
	}
	
    private void FixedUpdate()
    {
        if(HitPoints <= 0)
        {
            destroy = true;
        }

        if(destroy == true)
        {
            //Destroy(gameObject, DeathTimer);
            Destroy(gameObject);
        }

        Agent.isStopped = true;

        if(Follow == true)
        {
            Agent.isStopped = false;
            Agent.SetDestination(target.position);
        }
    }
}
