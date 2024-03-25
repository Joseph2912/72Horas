using UnityEngine;

public class FINALKEY : MonoBehaviour
{
    public GameObject puerta; // Referencia al objeto de la puerta
    public AudioSource audioSource; // Fuente de audio para reproducir sonido al recoger la llave

    [SerializeField] private static int llavesRecogidas = 0; // Variable estática para contar las llaves recogidas
    private bool llaveRecogida = false; // Variable para controlar si esta llave ha sido recogida

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !llaveRecogida) // Verifica si el objeto que colisiona es el jugador y la llave no ha sido recogida
        {
            RecogerLlave(); // Función para recoger la llave
            audioSource.Play();
        }
    }

    private void RecogerLlave()
    {
        llaveRecogida = true; // Marca la llave como recogida
        llavesRecogidas++; // Incrementa el contador de llaves recogidas

        // Desactiva la representación visual de la llave (puedes desactivar el objeto o cambiar su apariencia)
        gameObject.SetActive(false);

        // Verifica si se han recogido todas las llaves
        if (llavesRecogidas == 3 && puerta != null)
        {
            puerta.GetComponent<Puerta>().AbrirPuerta(); // Llama a la función para abrir la puerta en el script de la puerta
        }
    }
}
