using UnityEngine;

public class Cofre : MonoBehaviour
{
    public GameObject objetoConRigidbody; // Referencia al GameObject con el Rigidbody
    private Rigidbody rb; // Referencia al Rigidbody

    public AudioSource audioSource; // Referencia al AudioSource

    public Animator animator; // Referencia al Animator

    private void Start()
    {
        rb = objetoConRigidbody.GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
        rb.isKinematic = true; // Asegurarse de que el Rigidbody esté inicialmente desactivado
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el collider tocado pertenece a un objeto con el tag "Player"
        if (other.CompareTag("Player"))
        {
            rb.isKinematic = false; // Activar el Rigidbody
        }
        if (other.CompareTag("Suelo"))
        {
            audioSource.Play(); // Reproducir el sonido
            if (animator != null)
            {
                animator.enabled = true;
            }
        }
    }
 
}
