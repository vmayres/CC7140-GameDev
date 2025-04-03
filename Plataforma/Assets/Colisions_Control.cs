using UnityEngine;

public class Colisions_Control : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 10f; // Força do empurrão
    private Rigidbody2D rbd2;

    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>(); // Obtém o Rigidbody2D do player
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("DeadZones"))
        {
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            rbd2.linearVelocity = knockbackDirection * knockbackForce;
        }
    }
}
