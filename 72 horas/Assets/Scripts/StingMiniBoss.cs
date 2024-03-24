using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StingMiniBoss : MonoBehaviour
{
    [Header("Enemy")]
    private NavMeshAgent _agent;
    private Animator _anim;

    [Header("Attacks")]
    public string[] attackTriggers;
    public float cooldown;
    [SerializeField] private float _contador;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _contador = 0f;
        _contador += Time.deltaTime;
        if(_contador > cooldown)
        {
            RandomAttack();
            _contador = 0f;
        }
    }

    public void RandomAttack()
    {
        int attackIndex = Random.Range(0, attackTriggers.Length);
        _anim.SetTrigger(attackTriggers[attackIndex]);
    }
}
