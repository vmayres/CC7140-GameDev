using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBotaoController : MonoBehaviour
{
    public void RetryGame()
    {
        Debug.Log("Reiniciando a fase...");

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetarEstadoDoJogo();
        }
        else
        {
            Debug.LogWarning("GameManager não encontrado!");
        }

        SceneManager.LoadScene("Fase 1 - Forest");
    }

    public void GoBackToMainMenu()
    {
        Debug.Log("Voltando para o menu principal...");
        SceneManager.LoadScene("MainMenu");
    }
}
