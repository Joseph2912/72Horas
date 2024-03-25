using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination; // Punto de destino al que se teletransportará el jugador

    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verificar si el objeto que entra al portal es el jugador
        {
            TeleportPlayer(other.transform);
            audioSource.Play();
        }
    }

    private void TeleportPlayer(Transform playerTransform)
    {
        if (destination != null)
        {
            playerTransform.position = destination.position; // Teletransportar al jugador al punto de destino
        }
        else
        {
            Debug.LogWarning("¡El portal no tiene un punto de destino asignado!");
        }
    }
}
