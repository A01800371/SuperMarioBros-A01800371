// Erik Owen Castro Flores
// A01800371
// Animaciones Toad

using UnityEngine;

public class ToadNPC : MonoBehaviour
{
    // Velocidad
    public float velocidad = 2f;

    // Puntos A & B. Representan los límites entre los que Toad se mueve
    public Transform puntoA, puntoB;

    private bool moviendoDerecha = true;

    // Permite uso de las Fisicas
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Evita que el NPC se quede atascado
        float margenDeError = 0.1f;

        if (moviendoDerecha)
        {
            rb.linearVelocity = new Vector2(velocidad, rb.linearVelocity.y);

            // Si Toad ha llegado al punto B o está cerca cambia la direccion del movimiento
            if (transform.position.x >= puntoB.position.x - margenDeError)
                moviendoDerecha = false;
        }
        else
        {
            // Si no está moviéndose hacia la derecha, se mueve hacia la izquierda con la misma lógica
            rb.linearVelocity = new Vector2(-velocidad, rb.linearVelocity.y);

            // Si Toad ha llegado al punto A o está cerca cambia la dirección del movimiento
            if (transform.position.x <= puntoA.position.x + margenDeError)
                moviendoDerecha = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MarioPersonaje"))
        {
        }
    }
}
