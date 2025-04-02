using UnityEngine;

public class CameraMoviment : MonoBehaviour
{
    public Transform player; // Referência ao transform do jogador
    public float minX = 0f; // Limite mínimo no eixo X
    public float maxX = 28f; // Limite máximo no eixo X
    public float speed = 2f; // Velocidade de movimento da câmera

    void Start()
    {
        // Inicializa a posição da câmera para garantir que ela comece em uma posição válida
        Vector3 startPosition = transform.position;
        startPosition.x = Mathf.Clamp(startPosition.x, minX, maxX);
        transform.position = startPosition;
    }

    void Update()
    {
        if (player != null)
        {
            // Pega a posição atual da câmera
            Vector3 newPosition = transform.position;

            // Atualiza a posição X da câmera para seguir o jogador
            newPosition.x = Mathf.Lerp(newPosition.x, player.position.x, speed * Time.deltaTime);

            // Garante que a posição X da câmera não ultrapasse os limites
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            // Aplica a nova posição à câmera
            transform.position = newPosition;
        }
    }
}
