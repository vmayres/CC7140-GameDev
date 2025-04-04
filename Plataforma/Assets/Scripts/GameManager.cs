using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int moedasColetadas = 0;
    public int vidas = 3;

    [Header("Menus do Main Menu")]
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Garante que o painel de opções comece desativado
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(false);
        }
    }

    // ---------- Controle de pontuação e vidas ----------
    public void IncrementarPontuacao()
    {
        moedasColetadas++;
        Debug.Log("Moedas coletadas: " + moedasColetadas);
    }

    public void PerderVida()
    {
        vidas--;
        Debug.Log("Vida perdida! Vidas restantes: " + vidas);

        if (vidas <= 0)
        {
            Debug.Log("Game Over! Indo para a cena GameOver...");
            SceneManager.LoadScene("GameOver"); // <-- Nome da nova cena
        }
    }

    // ---------- Controle de cenas via botões ----------
    public void IniciarJogo()
    {
        Debug.Log("Iniciando o jogo...");
        ResetarEstadoDoJogo();
        SceneManager.LoadScene("Fase 1 - Forest");
    }

    public void VoltarMenu()
    {
        Debug.Log("Voltando para o menu...");
        SceneManager.LoadScene("MainMenu");
    }

    public void AlternarOptionsMenu()
    {
        if (optionsPanel != null && mainMenuPanel != null)
        {
            bool ativo = optionsPanel.activeSelf;
            optionsPanel.SetActive(!ativo);
            mainMenuPanel.SetActive(ativo); // Inverte o estado do menu principal
            Debug.Log("Painel de opções " + (ativo ? "fechado" : "aberto"));
        }
    }

    public void ResetarEstadoDoJogo()
    {
        moedasColetadas = 0;
        vidas = 3;
        Debug.Log("Estado do jogo resetado.");
    }


    public void SairDoJogo()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


}
