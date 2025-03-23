// Erik Owen Castro Flores
// A01800371

using UnityEngine;

public class ToadNPC : MonoBehaviour
{
    public float velocidad = 2f;
    public Transform puntoA, puntoB;

    private bool moviendoDerecha = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float margenDeError = 0.1f;

        if (moviendoDerecha)
        {
            rb.linearVelocity = new Vector2(velocidad, rb.linearVelocity.y);

            if (transform.position.x >= puntoB.position.x - margenDeError)
                moviendoDerecha = false;
        }
        else
        {
            rb.linearVelocity = new Vector2(-velocidad, rb.linearVelocity.y);

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
