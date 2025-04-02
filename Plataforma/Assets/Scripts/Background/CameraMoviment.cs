using UnityEngine;

public class CameraMoviment : MonoBehaviour
{
    public Transform player; // Refer�ncia ao transform do jogador
    public float minX = 0f; // Limite m�nimo no eixo X
    public float maxX = 28f; // Limite m�ximo no eixo X
    public float speed = 2f; // Velocidade de movimento da c�mera

    void Start()
    {
        // Inicializa a posi��o da c�mera para garantir que ela comece em uma posi��o v�lida
        Vector3 startPosition = transform.position;
        startPosition.x = Mathf.Clamp(startPosition.x, minX, maxX);
        transform.position = startPosition;
    }

    void Update()
    {
        if (player != null)
        {
            // Pega a posi��o atual da c�mera
            Vector3 newPosition = transform.position;

            // Atualiza a posi��o X da c�mera para seguir o jogador
            newPosition.x = Mathf.Lerp(newPosition.x, player.position.x, speed * Time.deltaTime);

            // Garante que a posi��o X da c�mera n�o ultrapasse os limites
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            // Aplica a nova posi��o � c�mera
            transform.position = newPosition;
        }
    }
}
