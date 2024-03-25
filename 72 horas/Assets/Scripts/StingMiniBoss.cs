using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StingMiniBoss : MonoBehaviour
{
    [Header("Enemy")]
    private NavMeshAgent _agent;
    private Animator _anim;
    [SerializeField] private float _distanceToAvoid;

    [Header("Player")]
    public Transform playerPos;

    [Header("Attacks")]
    public string[] attackTriggers;
    public float cooldown;
    private float _contador;

    [Header("Colliders Attacks")]
    public SphereCollider powerCollider;
    public SphereCollider stingCollider;
    public SphereCollider sliceCollider;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _contador = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _contador += Time.deltaTime;
        if(_contador > cooldown)
        {
            RandomAttack();
            _contador = 0f;
        }
        if (Vector3.Distance(transform.position, playerPos.position) < _distanceToAvoid) 
        {
            transform.LookAt(new Vector3(playerPos.position.x, transform.position.y, playerPos.position.z));
            _agent.SetDestination(transform.position + (transform.position - playerPos.position));
        }
        else
        {
            _agent.SetDestination(playerPos.position);
        }
    }

    public void RandomAttack()
    {
        _anim.SetBool("Move", false);
        int attackIndex = Random.Range(0, attackTriggers.Length);
        _anim.SetBool(attackTriggers[attackIndex], true);
    }

    public void MoveAgain()
    {
        powerCollider.enabled = false;
        stingCollider.enabled = false;
        sliceCollider.enabled = false;
        _anim.SetBool("Move", true);
        _anim.SetBool("Slice", false);
        _anim.SetBool("Power", false);
        _anim.SetBool("Sting", false);
    }

    public void TurnOnColliderSlice()
    {
        sliceCollider.enabled = true;
    }

    public void TurnOffColliderPower()
    {
        powerCollider.enabled = true;
    }

    public void TurnOnColliderSting() 
    {
        stingCollider.enabled = true;
    }
    
}
