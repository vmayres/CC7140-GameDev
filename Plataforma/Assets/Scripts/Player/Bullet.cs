using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rbd2 => GetComponent<Rigidbody2D>();

    void Update() => transform.right = rbd2.linearVelocity;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // Destroi o inimigo
            Destroy(gameObject); // Destroi o tiro
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            Destroy(gameObject); // Destroi o tiro ao colidir com o tilemap
        }
    }
}
