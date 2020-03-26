using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RecyclerFollowPlayer : MonoBehaviour
{

    public Transform player;
    public float followRadiusFar, followRadiusClose;
    public NavMeshAgent navMeshAgent;

    void Start()
    {
        
    }


    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) > followRadiusFar)
        {
            navMeshAgent.SetDestination(player.position);
        }
        else if(Vector3.Distance(transform.position, player.position) < followRadiusClose)
        {
            navMeshAgent.SetDestination(transform.position);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followRadiusFar);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, followRadiusClose);
    }
}
