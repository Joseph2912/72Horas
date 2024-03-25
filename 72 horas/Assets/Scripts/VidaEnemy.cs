using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VidaEnemy : MonoBehaviour
{
    [SerializeField] private int _life = 2;
    private Animator _anim;
    private NavMeshAgent _agent;
    public GameObject puerta; // Referencia al objeto de la puerta
    public AudioSource audioSource;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void RecibirGolpe()
    {
        _life--;
        if(_life <= 0)
        {
            _anim.SetTrigger("Die");
            _agent.SetDestination(transform.position);
       
        }
    }

    public void Desaparecer()
    {
        Destroy(this.gameObject);
        puerta.GetComponent<Puerta>().AbrirPuerta();
        audioSource.Play();
    }
}
