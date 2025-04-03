using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject coletaveis;     // Objeto pai com todas as moedas
    public GameObject objetivo;       // Objetivo (Goal) a ser ativado
    public int moedasColetadas = 0;   // Contador de moedas coletadas

    public int vidas = 3;             // Vidas do jogador

    void Start()
    {
        if (objetivo != null)
        {
            objetivo.SetActive(false); // Começa desativado
        }
    }

    void Update()
    {
        // Verifica se ainda há moedas
        int moedasRestantes = coletaveis.transform.childCount;

        if (moedasRestantes == 0 && objetivo != null && !objetivo.activeSelf)
        {
            objetivo.SetActive(true);
            Debug.Log("Todas as moedas coletadas!");
        }

        // Verifica se as vidas acabaram
        if (vidas <= 0)
        {
            Debug.Log("Game Over! Indo para a tela de derrota...");
            SceneManager.LoadScene("TelaDerrota"); // Nome da cena de derrota
        }
    }

    // Chamada pelas moedas ao serem coletadas
    public void IncrementarPontuacao()
    {
        moedasColetadas++;
        Debug.Log("Moedas coletadas: " + moedasColetadas);
    }

    // Chamada quando o jogador toma dano
    public void PerderVida()
    {
        vidas--;
        Debug.Log("Vida perdida! Vidas restantes: " + vidas);
    }
}
