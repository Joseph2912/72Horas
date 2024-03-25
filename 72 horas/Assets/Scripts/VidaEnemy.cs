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
    public GameObject objetoConRigidbody; // Referencia al GameObject con el Rigidbody
    private Rigidbody rb; // Referencia al Rigidbody

    void Start()
    {
        _anim = GetComponent<Animator>();
        rb = objetoConRigidbody.GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
        rb.isKinematic = true; // Asegurarse de que el Rigidbody esté inicialmente desactivado
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
        rb.isKinematic = false; // Activar el Rigidbody
    }
}
