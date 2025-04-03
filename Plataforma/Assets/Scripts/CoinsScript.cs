using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinsScript : MonoBehaviour
{
    private ScoreManager scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (scoreManager != null)
            {
                scoreManager.IncrementarPontuacao();
            }
        }
    }
}
