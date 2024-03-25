using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpookEnemy : MonoBehaviour
{
    [Header("Enemy")]
    private NavMeshAgent _agent;
    private Animator _anim;
    [SerializeField] private float distanceToAttack;
    [SerializeField] private SphereCollider slashCollider;

    [Header("Player")]
    public GameObject playerPos;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        playerPos = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = playerPos.transform;
        if (Vector3.Distance(transform.position, playerTransform.position) < distanceToAttack)
        {
            _agent.SetDestination(transform.position);
            _anim.SetBool("Slash", true);
        }
        else
        {
            _agent.SetDestination(playerTransform.position);
        }
    }

    public void OnCollider()
    {
        slashCollider.enabled = true;
    }

    public void OffCollider()
    {
        slashCollider.enabled = false;
        _anim.SetBool("Slash", false);
    }
}
