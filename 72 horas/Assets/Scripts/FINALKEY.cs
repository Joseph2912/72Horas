using UnityEngine;

public class FINALKEY : MonoBehaviour
{
    public GameObject puerta; // Referencia al objeto de la puerta
   /* public AudioClip sonidoLlave; */// Sonido al recolectar la llave

    private bool llaveRecogida = false; // Variable para controlar si la llave ha sido recogida

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !llaveRecogida) // Verifica si el objeto que colisiona es el jugador y la llave no ha sido recogida
        {
            RecogerLlave(); // Función para recoger la llave
        }
    }

    private void RecogerLlave()
    {
        llaveRecogida = true; // Marca la llave como recogida
       /* AudioSource.PlayClipAtPoint(sonidoLlave, transform.position); */// Reproduce el sonido de recolección en la posición de la llave

        // Desactiva la representación visual de la llave (puedes desactivar el objeto o cambiar su apariencia)
        gameObject.SetActive(false);

        // Abre la puerta
        if (puerta != null)
        {
            puerta.GetComponent<Puerta>().AbrirPuerta(); // Llama a la función para abrir la puerta en el script de la puerta
        }
    }
}
