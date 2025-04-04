using UnityEngine;

public class CoinsScript : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        // Pega a instância do GameManager no início
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.IncrementarPontuacao();
            }
            else
            {
                Debug.LogWarning("GameManager não encontrado!");
            }

            Destroy(gameObject); // Destroi a moeda
        }
    }
}
