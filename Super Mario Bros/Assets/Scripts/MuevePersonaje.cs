// Erik Owen Castro Flores
// A01800371
// Movimiento del Personaje
using UnityEngine;

public class MuevePersonaje : MonoBehaviour
{
    // Velocidad
    public float velocidadX;

    [SerializeField] // Permite al motor acceder a la variable

    private float velocidadY;

    // Se usa Rigidbody para usar la Física

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called 50 times per second
    void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");
        if (movVertical > 0)
        {
            rb.linearVelocity = new Vector2(movHorizontal * velocidadX, movVertical * velocidadY);
        }
        else
        {
            rb.linearVelocity = new Vector2(movHorizontal * velocidadX, rb.linearVelocityY);
        }
    }
}