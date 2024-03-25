using UnityEngine;
using UnityEngine.UI;

public class RecuperarVida: MonoBehaviour
{
    public int lifeToRestore;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Player" (o el nombre del tag que estés usando para el jugador)
        if (other.CompareTag("Player"))
        {
            other.GetComponent<santa>().RestoreLife(lifeToRestore);
        }
    }
}
