using UnityEngine;

public class Shotting : MonoBehaviour
{
    public float projectileSpeed = 10f;
    private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocityY = -projectileSpeed; // Alterado para mover para baixo
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (CompareTag("Player"))
        {
            Destroy(other.gameObject);
            PlayerControl.LostHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
