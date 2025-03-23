// Erik Owen Castro Flores
// A01800371
// Movimiento del Personaje con Animaciones

using UnityEngine;

public class MuevePersonaje : MonoBehaviour
{
    // Velocidad
    public float velocidadX;
    [SerializeField] private float velocidadY;

    // Componentes
    private Rigidbody2D rb; // Permite uso de las Fisicas
    private Animator animator; // Accede a las animaciones

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        // Movimiento del personaje
        if (movVertical > 0)
        {
            rb.linearVelocity = new Vector2(movHorizontal * velocidadX, movVertical * velocidadY);
        }
        else
        {
            rb.linearVelocity = new Vector2(movHorizontal * velocidadX, rb.linearVelocity.y);
        }

        // Llamamos a la función que maneja las animaciones
        ActualizarAnimaciones(movHorizontal, movVertical);
    }

    void ActualizarAnimaciones(float movHorizontal, float movVertical)
    {
        // Si hay movimiento en X, activar la animación de caminar
        animator.SetBool("IsRunning", movHorizontal != 0);

        // Si el personaje está saltando, activar la animación de salto
        animator.SetBool("IsJumping", movVertical > 0);
    }
}
