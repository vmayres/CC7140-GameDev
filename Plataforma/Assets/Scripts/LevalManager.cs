using UnityEngine;
using TMPro;

public class LevalManager : MonoBehaviour
{
    public GameObject coletaveis;
    public GameObject objetivo;
    public GameObject dialogo;
    public TextMeshProUGUI statusText;

    [Header("Se precisar iniciar o GameManager")]
    public GameObject gameManagerPrefab;

    void Awake()
    {
        // Garante que o GameManager esteja na cena
        if (GameManager.Instance == null && gameManagerPrefab != null)
        {
            Instantiate(gameManagerPrefab);
            Debug.Log("GameManager criado automaticamente pelo LevelManager.");
        }
    }

    void Start()
    {
        if (objetivo != null)
        {
            objetivo.SetActive(false);
        }
    }

    void Update()
    {
        AtualizarTextoStatus();

        if (coletaveis == null || objetivo == null) return;

        int moedasRestantes = coletaveis.transform.childCount;

        if (moedasRestantes == 0 && !objetivo.activeSelf)
        {
            objetivo.SetActive(true);
            dialogo.SetActive(false);
            Debug.Log("Todas as moedas coletadas! Objetivo ativado.");
        }
    }

    void AtualizarTextoStatus()
    {
        if (statusText != null && GameManager.Instance != null)
        {
            int vidas = GameManager.Instance.vidas;
            int moedas = GameManager.Instance.moedasColetadas;
            statusText.text = $"Vida: {vidas} | Moedas: {moedas}";
        }
    }
}
