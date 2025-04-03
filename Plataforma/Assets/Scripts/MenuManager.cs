using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel; // Referência ao painel de menu principal
    public GameObject instructionsPanel; // Referência ao painel de instruções

    void Start()
    {
        // Garante que o painel de instruções comece escondido
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(false);
        }
    }

    public void PlayGame()
    {
        Debug.Log("Jogo iniciado");
        SceneManager.LoadScene("Fase 1 - Forest");
    }

    public void OpenInstructions()
    {
        Debug.Log("Instruções abertas");
        ToggleInstructionsPanel();
    }

    private void ToggleInstructionsPanel()
    {
        if (instructionsPanel != null && mainMenuPanel != null)
        {
            bool isActive = instructionsPanel.activeSelf;
            instructionsPanel.SetActive(!isActive);
            mainMenuPanel.SetActive(isActive);
        }
    }
}
