using UnityEngine;

public class Puerta : MonoBehaviour
{
    public float velocidadApertura = 1f; // Velocidad de apertura de la puerta
    public float distanciaApertura = 2f; // Distancia a la que se moverá la puerta al abrir

    public float velocidadCerrar = 1f; // Velocidad de apertura de la puerta
    public float distanciaCerrar = 2f; // Distancia a la que se moverá la puerta al abrir

    private Vector3 posicionInicial; // Posición inicial de la puerta
    private Vector3 posicionFinal; // Posición final de la puerta cuando esté abierta
    private bool puertaAbierta = false; // Variable para controlar si la puerta está abierta o cerrada

    private void Start()
    {
        posicionInicial = transform.position; // Guardar la posición inicial de la puerta
        posicionFinal = posicionInicial + Vector3.up * distanciaApertura; // Calcular la posición final de la puerta
    }

    public void AbrirPuerta()
    {
        // Verificar si la puerta ya está abierta para evitar abrir más de una vez
        if (puertaAbierta == false)
        {
            // Mover la puerta gradualmente hacia arriba hasta alcanzar la posición final
            transform.Translate(Vector3.up * velocidadApertura * Time.deltaTime);

            // Si la puerta ha alcanzado la posición final, marcarla como abierta
            if (transform.position.y >= posicionFinal.y)
            {
                puertaAbierta = true;
            }
        }
        // Verificar si la puerta ya está abierta para evitar abrir más de una vez
        else
        {
            // Mover la puerta gradualmente hacia arriba hasta alcanzar la posición final
            transform.Translate(Vector3.up * velocidadCerrar * Time.deltaTime);

            // Si la puerta ha alcanzado la posición final, marcarla como abierta
            if (transform.position.y >= posicionFinal.y)
            {
                puertaAbierta = true;
            }
        }
    }
}
