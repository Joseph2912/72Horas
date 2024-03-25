using UnityEngine;
using UnityEngine.UI;

public class RecuperarVida: MonoBehaviour
{
    public Slider vidaSlider; // Referencia al slider de vida del personaje
    public int puntosRecuperacion = 2; // Cantidad de puntos de vida a recuperar

    private void Start()
    {
        // Aseg�rate de que el slider de vida est� configurado correctamente
        if (vidaSlider == null)
        {
            Debug.LogError("El slider de vida no est� asignado en el inspector.");
            enabled = false; // Desactiva el script si el slider no est� asignado
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Player" (o el nombre del tag que est�s usando para el jugador)
        if (other.CompareTag("Player"))
        {
            // Aumenta la vida del jugador en la cantidad especificada
            vidaSlider.value += puntosRecuperacion;

            // Aseg�rate de que la vida no supere el valor m�ximo (usualmente 10 si es un slider de n�meros enteros)
            vidaSlider.value = Mathf.Clamp(vidaSlider.value, vidaSlider.minValue, vidaSlider.maxValue);
        }
    }
}
