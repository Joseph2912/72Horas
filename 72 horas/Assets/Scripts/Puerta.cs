using UnityEngine;

public class Puerta : MonoBehaviour
{
    public float velocidadApertura = 1f; // Velocidad de apertura de la puerta
    public float distanciaApertura = 2f; // Distancia a la que se mover� la puerta al abrir

    public float velocidadCerrar = 1f; // Velocidad de apertura de la puerta
    public float distanciaCerrar = 2f; // Distancia a la que se mover� la puerta al abrir

    private Vector3 posicionInicial; // Posici�n inicial de la puerta
    private Vector3 posicionFinal; // Posici�n final de la puerta cuando est� abierta
    private bool puertaAbierta = false; // Variable para controlar si la puerta est� abierta o cerrada

    private void Start()
    {
        posicionInicial = transform.position; // Guardar la posici�n inicial de la puerta
        posicionFinal = posicionInicial + Vector3.up * distanciaApertura; // Calcular la posici�n final de la puerta
    }

    public void AbrirPuerta()
    {
        // Verificar si la puerta ya est� abierta para evitar abrir m�s de una vez
        if (puertaAbierta == false)
        {
            // Mover la puerta gradualmente hacia arriba hasta alcanzar la posici�n final
            transform.Translate(Vector3.up * velocidadApertura * Time.deltaTime);

            // Si la puerta ha alcanzado la posici�n final, marcarla como abierta
            if (transform.position.y >= posicionFinal.y)
            {
                puertaAbierta = true;
            }
        }
        // Verificar si la puerta ya est� abierta para evitar abrir m�s de una vez
        else
        {
            // Mover la puerta gradualmente hacia arriba hasta alcanzar la posici�n final
            transform.Translate(Vector3.up * velocidadCerrar * Time.deltaTime);

            // Si la puerta ha alcanzado la posici�n final, marcarla como abierta
            if (transform.position.y >= posicionFinal.y)
            {
                puertaAbierta = true;
            }
        }
    }
}
