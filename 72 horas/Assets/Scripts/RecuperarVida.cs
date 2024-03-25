using UnityEngine;
using UnityEngine.UI;

public class RecuperarVida: MonoBehaviour
{
    public Slider vidaSlider; // Referencia al slider de vida del personaje
    public int puntosRecuperacion = 2; // Cantidad de puntos de vida a recuperar

    private void Start()
    {
        // Asegúrate de que el slider de vida esté configurado correctamente
        if (vidaSlider == null)
        {
            Debug.LogError("El slider de vida no está asignado en el inspector.");
            enabled = false; // Desactiva el script si el slider no está asignado
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Player" (o el nombre del tag que estés usando para el jugador)
        if (other.CompareTag("Player"))
        {
            // Aumenta la vida del jugador en la cantidad especificada
            vidaSlider.value += puntosRecuperacion;

            // Asegúrate de que la vida no supere el valor máximo (usualmente 10 si es un slider de números enteros)
            vidaSlider.value = Mathf.Clamp(vidaSlider.value, vidaSlider.minValue, vidaSlider.maxValue);
        }
    }
}
