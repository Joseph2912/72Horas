using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrullaGhost : MonoBehaviour
{
    [Header("NavMesh")]
    private NavMeshAgent _agent;
    public Transform[] waypoints;
    private int _waypointsIndex;
    private Vector3 _target;

    [Header("Player")]
    public Transform playerPos;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetBool("Dash", false);
        _anim.SetBool("Attack", false);
        if (Vector3.Distance(transform.position, playerPos.position) < 8)
        {
            _anim.SetBool("Dash", true);
            _anim.SetBool("Attack", false);
            _agent.SetDestination(playerPos.position);
            _agent.speed = 4;
            if(Vector3.Distance(transform.position, playerPos.position) < 1)
            {
                _agent.SetDestination(transform.position);
                _anim.SetBool("Dash", false);
                _anim.SetBool("Attack", true);
            }
        }
        else
        {
            UpdateDestination();
            if (Vector3.Distance(transform.position, _target) < 1)
            {
                _agent.speed = 2;
                IterateWaypointsIndex();
                UpdateDestination();
            }
        }
        
    }

    public void UpdateDestination()
    {
        _target = waypoints[_waypointsIndex].position;
        _agent.SetDestination(_target);
    }

    public void IterateWaypointsIndex()
    {
        _waypointsIndex++;
        if( _waypointsIndex == waypoints.Length)
            _waypointsIndex = 0;
    }
}
