using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActivateBoss : MonoBehaviour
{
    public NavMeshAgent stingAgent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stingAgent.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}
