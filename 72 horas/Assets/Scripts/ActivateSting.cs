using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActivateSting : MonoBehaviour
{
    public NavMeshAgent stingAgent;
    public Transform playerPos;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stingAgent.SetDestination(playerPos.position);
        }
    }
}
