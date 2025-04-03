using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{

    public string nextSceneName; // Nome da próxima cena

    private void Start()
    {
        // Começa desativado
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Se o jogador encostar no objetivo e ele estiver ativo, avança de fase
        if (other.CompareTag("Player") && gameObject.activeSelf)
        {
            Debug.Log("Objetivo coletado, prosseguindo para a próxima fase");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
