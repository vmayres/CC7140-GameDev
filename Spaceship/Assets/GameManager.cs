using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FuelBar fuelBar;  // Referência ao script FuelBar
    public GameObject heartContainer;  // Referência ao HeartContainer
    public int maxHealth = 3;  // Vida máxima do jogador
    private int currentHealth;  // Vida atual do jogador

    public float fuelDecreaseRate = 1f;  // Quantidade de combustível a ser diminuída a cada segundo
    public float speedMultiplier = 1f;  // Multiplicador de velocidade (1x é a velocidade normal)
    public float maxSpeedMultiplier = 2f;  // Multiplicador máximo de velocidade
    public float timeWithoutDamageToIncreaseSpeed = 5f;  // Tempo sem tomar dano para aumentar a velocidade
    private float timeWithoutDamage = 0f;  // Tempo que o jogador está sem tomar dano

    // Start é chamado antes da primeira execução de Update
    void Start()
    {
        // Inicia o combustível e a vida do jogador
        if (fuelBar != null)
        {
            fuelBar.RefillFuel(100f);  // Reabastece o combustível para 100%
        }

        // Inicia a vida do jogador
        currentHealth = maxHealth;
        UpdateHealthDisplay();
    }

    // Update é chamado a cada frame
    void Update()
    {
        // Diminui o combustível a cada segundo
        if (fuelBar != null && fuelBar.currentFuel > 0)
        {
            fuelBar.ConsumeFuel(fuelDecreaseRate * Time.deltaTime);  // Consome combustível
        }
        else
        {
            // O combustível acabou, você pode colocar aqui o código de perda de jogo ou o que preferir
            Debug.Log("Game Over: Out of Fuel");
        }

        // Aumenta o multiplicador de velocidade com o tempo sem tomar dano
        if (timeWithoutDamage >= timeWithoutDamageToIncreaseSpeed)
        {
            speedMultiplier = Mathf.Min(maxSpeedMultiplier, 1 + (timeWithoutDamage / 10f));  // Aumenta a velocidade até 2x
        }
    }

    // Método para o jogador perder vida
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Aqui você pode adicionar lógica para finalizar o jogo
            Debug.Log("Game Over: No Health");
        }
        UpdateHealthDisplay();

        // Resetar o tempo sem tomar dano
        timeWithoutDamage = 0f;
    }

    // Atualiza a exibição dos corações
    void UpdateHealthDisplay()
    {
        // Desativa todos os corações
        for (int i = 1; i <= maxHealth; i++)
        {
            Transform heart = heartContainer.transform.Find("Heart" + i);
            if (heart != null)
            {
                // Ativa ou desativa o coração baseado na vida
                heart.gameObject.SetActive(i <= currentHealth);
            }
        }
    }

    // Método chamado a cada frame para aumentar o tempo sem dano
    public void IncreaseTimeWithoutDamage(float deltaTime)
    {
        if (currentHealth > 0)  // Só conta o tempo se o jogador ainda estiver vivo
        {
            timeWithoutDamage += deltaTime;
        }
    }
}
