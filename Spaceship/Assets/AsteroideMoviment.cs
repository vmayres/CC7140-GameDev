using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] public float baseSpeed = 3f; // Velocidade base do asteroide
    private float speed; // Velocidade final do asteroide
    private float destroyX = -6f; // Posi��o X onde o asteroide ser� destru�do

    void Start()
    {
        // Define uma velocidade aleat�ria entre 100% e 150% da baseSpeed
        speed = baseSpeed * Random.Range(1.0f, 1.5f);
    }

    void Update()
    {
        // Move o asteroide para a esquerda
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Verifica se o asteroide atingiu a posi��o de destrui��o
        if (transform.position.x <= destroyX)
        {
            Destroy(gameObject);
        }
    }
}
