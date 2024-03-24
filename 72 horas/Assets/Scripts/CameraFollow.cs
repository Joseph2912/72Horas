using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencia al transform del jugador
    public float smoothSpeed = 0.125f; // Velocidad de seguimiento de la cámara
    public float distanceFromGround = 5f; // Distancia de la cámara al suelo
    public LayerMask collisionMask; // Máscara de capas para la colisión de la cámara con la geometría de la escena
    public float additionalOffsetMultiplier = 2f; // Multiplicador para el desplazamiento adicional de la cámara
    public float maxFOV = 80f; // Máximo campo de visión (FOV)
    public float minFOV = 60f; // Mínimo campo de visión (FOV)
    public float maxLookAheadDistance = 5f; // Distancia máxima a mirar hacia adelante en la dirección del movimiento

    private Vector3 offset; // Desfase de la cámara con respecto al jugador
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
            // Calcula la posición deseada de la cámara
            Vector3 desiredPosition = target.position + offset;

            // Calcula el desplazamiento adicional de la cámara basado en la dirección del movimiento del jugador
            Vector3 movementDirection = target.position - transform.position;
            Vector3 lookAheadPosition = target.position + movementDirection.normalized * maxLookAheadDistance;
            desiredPosition += movementDirection.normalized * additionalOffsetMultiplier;

            // Combina la posición deseada y la posición deseada mirando hacia adelante para obtener la posición final deseada de la cámara
            desiredPosition = Vector3.Lerp(desiredPosition, lookAheadPosition, 0.5f);

            RaycastHit hit;

            // Lanza un rayo desde la posición deseada de la cámara hacia abajo para evitar la colisión con la geometría
            if (Physics.Raycast(desiredPosition, Vector3.down, out hit, Mathf.Infinity, collisionMask))
            {
                desiredPosition = hit.point + Vector3.up * distanceFromGround;
            }

            // Interpola suavemente la posición actual de la cámara hacia la posición deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            // Calcula el ángulo de visión (FOV) basado en la dirección de movimiento del jugador
            float angle = Vector3.Angle(transform.forward, movementDirection);
            cam.fieldOfView = Mathf.Lerp(minFOV, maxFOV, angle / 180f);
        }
    }
}
