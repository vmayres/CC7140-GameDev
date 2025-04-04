using UnityEngine;

public class CoinsScript : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        // Pega a inst�ncia do GameManager no in�cio
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
                Debug.LogWarning("GameManager n�o encontrado!");
            }

            Destroy(gameObject); // Destroi a moeda
        }
    }
}
