using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencia al transform del jugador
    public float smoothSpeed = 0.125f; // Velocidad de seguimiento de la c�mara
    public float distanceFromGround = 5f; // Distancia de la c�mara al suelo
    public LayerMask collisionMask; // M�scara de capas para la colisi�n de la c�mara con la geometr�a de la escena
    public float additionalOffsetMultiplier = 2f; // Multiplicador para el desplazamiento adicional de la c�mara
    public float maxFOV = 80f; // M�ximo campo de visi�n (FOV)
    public float minFOV = 60f; // M�nimo campo de visi�n (FOV)
    public float maxLookAheadDistance = 5f; // Distancia m�xima a mirar hacia adelante en la direcci�n del movimiento

    private Vector3 offset; // Desfase de la c�mara con respecto al jugador
    private Camera cam;

    void Start()
    {
        offset = transform.position - target.position;
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la posici�n deseada de la c�mara
            Vector3 desiredPosition = target.position + offset;

            // Calcula el desplazamiento adicional de la c�mara basado en la direcci�n del movimiento del jugador
            Vector3 movementDirection = target.position - transform.position;
            Vector3 lookAheadPosition = target.position + movementDirection.normalized * maxLookAheadDistance;
            desiredPosition += movementDirection.normalized * additionalOffsetMultiplier;

            // Combina la posici�n deseada y la posici�n deseada mirando hacia adelante para obtener la posici�n final deseada de la c�mara
            desiredPosition = Vector3.Lerp(desiredPosition, lookAheadPosition, 0.5f);

            RaycastHit hit;

            // Lanza un rayo desde la posici�n deseada de la c�mara hacia abajo para evitar la colisi�n con la geometr�a
            if (Physics.Raycast(desiredPosition, Vector3.down, out hit, Mathf.Infinity, collisionMask))
            {
                desiredPosition = hit.point + Vector3.up * distanceFromGround;
            }

            // Interpola suavemente la posici�n actual de la c�mara hacia la posici�n deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            // Calcula el �ngulo de visi�n (FOV) basado en la direcci�n de movimiento del jugador
            float angle = Vector3.Angle(transform.forward, movementDirection);
            cam.fieldOfView = Mathf.Lerp(minFOV, maxFOV, angle / 180f);
        }
    }
}
