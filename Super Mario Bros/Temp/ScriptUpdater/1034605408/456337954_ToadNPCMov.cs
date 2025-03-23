// Erik Owen Castro Flores
// A01800371

using UnityEngine;

public class ToadNPC : MonoBehaviour
{
    public float velocidad = 2f;  // Velocidad
    public Transform puntoA, puntoB;

    private bool moviendoDerecha = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Usamos un pequeño margen de error para la comparación
        float margenDeError = 0.1f;

        if (moviendoDerecha)
        {
            rb.linearVelocity = new Vector2(velocidad, rb.linearVelocity.y);

            // Verifica si Toad ha cruzado el puntoB
            if (transform.position.x >= puntoB.position.x - margenDeError)
                moviendoDerecha = false;
        }
        else
        {
            rb.linearVelocity = new Vector2(-velocidad, rb.linearVelocity.y);

            // Verifica si Toad ha cruzado el puntoA
            if (transform.position.x <= puntoA.position.x + margenDeError)
                moviendoDerecha = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MarioPersonaje")) // Detecta si ocurre alguna colisión
        {
            // Aquí puedes agregar la lógica para lo que debería hacer Toad al colisionar con Mario
        }
    }
}
