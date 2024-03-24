using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class santa : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento del jugador
    public float velocidadCorrer = 5f; // Velocidad de movimiento del jugador
    public float rotationSpeed = 5f; // Velocidad de rotación del personaje

    private Rigidbody rb; // Rigidbody para el movimiento suave
    private Vector3 movement; // Vector para almacenar la dirección del movimiento

    public BoxCollider colliderEspada;
    public Espada espada;

    public Animator anim;
    public LayerMask groundLayer; // Capa que representa el suelo

    public Slider healthSlider; // Referencia al Slider de salud
    public int maxHealth = 4; // Salud máxima del jugador
    private int currentHealth; // Salud actual del jugador

    public Gradient healthGradient; // Gradiente de colores para la salud

    public AudioSource audioSource;
    public float tiempoEsperaEntreAtaques = 1f; // Tiempo de espera entre ataques en segundos
    private float tiempoUltimoAtaque; // Tiempo en que se realizó el último ataque

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth; // Inicializar la salud actual con la máxima salud
        UpdateHealthUI(); // Actualizar el slider de salud al inicio
        tiempoUltimoAtaque = -tiempoEsperaEntreAtaques;
    }

    public void PrenderCollider()
    {
        espada.AumentarGolpes();
        colliderEspada.enabled = true;
    }

    public void ApagarCollider()
    {
        colliderEspada.enabled = false;
    }

    void Update()
    {
        // Entrada del jugador
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcula la dirección del movimiento
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        if (Input.GetMouseButtonDown(0) && Time.time >= tiempoUltimoAtaque + tiempoEsperaEntreAtaques) // 0 representa el botón izquierdo del mouse
        {
            anim.SetBool("golpe", true);
            audioSource.PlayOneShot(audioSource.clip);
            tiempoUltimoAtaque = Time.time; // Actualizar el tiempo del último ataque
        }
        else
        {
            anim.SetBool("golpe", false);
        }

        if (Input.GetMouseButtonDown(1)) // 0 representa el botón izquierdo del mouse
        {
            anim.SetBool("escudo", true);
        }
        else
        {
            anim.SetBool("escudo", false);
        }
    }

    private void FixedUpdate()
    {
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");
        anim.SetFloat("VelX", movimientoHorizontal);
        anim.SetFloat("VelY", movimientoVertical);

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical).normalized;

        if (movimiento != Vector3.zero)
        {
            float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidadMovimiento;
            rb.velocity = new Vector3(movimiento.x * velocidadActual, rb.velocity.y, movimiento.z * velocidadActual); // Mantener la velocidad vertical del Rigidbody

            Quaternion rotacionDeseada = Quaternion.LookRotation(movimiento);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacionDeseada, Time.deltaTime * rotationSpeed);
        }
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f); // Mantener la velocidad vertical del Rigidbody
        }

        // Verificar si el jugador está en el suelo y si está sobre una escalera
        RaycastHit hit;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f, groundLayer);
        bool isOnStairs = Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f, LayerMask.GetMask("Stairs"));

        if (!isGrounded && isOnStairs)
        {
            // Bajar las escaleras suavemente
            rb.velocity += Physics.gravity * Time.fixedDeltaTime;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir la salud del jugador
        UpdateHealthUI(); // Actualizar el slider de salud
        if (currentHealth <= 0)
        {
            Die(); // Llamar a la función de muerte si la salud del jugador es igual o menor a cero
        }
    }

    void Die()
    {
        // Reiniciar la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth; // Actualizar el valor del slider de salud
        healthSlider.fillRect.GetComponent<Image>().color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }
}
