using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinalBoss : MonoBehaviour
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
    public SphereCollider slashCollider;

    [Header("Prefabs")]
    public GameObject spook;
    public GameObject projectile;
    public Transform[] spawnPointSpook;
    public Transform spawnPointProjectile;

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
        if (_contador > cooldown)
        {
            RandomAttack();
            _contador = 0f;
        }
        if (Vector3.Distance(transform.position, playerPos.position) < _distanceToAvoid)
        {
            transform.LookAt(playerPos.position);
            _agent.SetDestination(transform.position + (transform.position - playerPos.position));
            if (Vector3.Distance(transform.position, playerPos.position) < 1)
            {
                _anim.SetBool("Idle", false);
                _anim.SetBool("Slash", true);
            }
        }
    }

    public void RandomAttack()
    {
        _anim.SetBool("Idle", false);
        int attackIndex = Random.Range(0, attackTriggers.Length);
        _anim.SetBool(attackTriggers[attackIndex], true);
    }

    public void IdleAgain()
    {
        slashCollider.enabled = false;
        _anim.SetBool("Idle", true);
        _anim.SetBool("Slash", false);
        _anim.SetBool("Spell", false);
        _anim.SetBool("Projectile", false);
    }

    public void CastSpell()
    {
        int index = Random.Range(0, spawnPointSpook.Length);
        Instantiate(spook, spawnPointSpook[index].position, Quaternion.identity);
    }

    public void ShootProjectile()
    {
        Instantiate(projectile, spawnPointProjectile.position, Quaternion.identity);
    }

    public void SlashCollider()
    {
        slashCollider.enabled = true;
    }
}
