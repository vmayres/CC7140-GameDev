using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{

    public string nextSceneName; // Nome da pr�xima cena

    private void Start()
    {
        // Come�a desativado
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Se o jogador encostar no objetivo e ele estiver ativo, avan�a de fase
        if (other.CompareTag("Player") && gameObject.activeSelf)
        {
            Debug.Log("Objetivo coletado, prosseguindo para a pr�xima fase");
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
