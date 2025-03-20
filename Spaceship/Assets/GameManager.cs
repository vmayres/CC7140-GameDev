using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FuelBar fuelBar;  // Refer�ncia ao script FuelBar
    public GameObject heartContainer;  // Refer�ncia ao HeartContainer
    public int maxHealth = 3;  // Vida m�xima do jogador
    private int currentHealth;  // Vida atual do jogador

    public float fuelDecreaseRate = 1f;  // Quantidade de combust�vel a ser diminu�da a cada segundo
    public float speedMultiplier = 1f;  // Multiplicador de velocidade (1x � a velocidade normal)
    public float maxSpeedMultiplier = 2f;  // Multiplicador m�ximo de velocidade
    public float timeWithoutDamageToIncreaseSpeed = 5f;  // Tempo sem tomar dano para aumentar a velocidade
    private float timeWithoutDamage = 0f;  // Tempo que o jogador est� sem tomar dano

    // Start � chamado antes da primeira execu��o de Update
    void Start()
    {
        // Inicia o combust�vel e a vida do jogador
        if (fuelBar != null)
        {
            fuelBar.RefillFuel(100f);  // Reabastece o combust�vel para 100%
        }

        // Inicia a vida do jogador
        currentHealth = maxHealth;
        UpdateHealthDisplay();
    }

    // Update � chamado a cada frame
    void Update()
    {
        // Diminui o combust�vel a cada segundo
        if (fuelBar != null && fuelBar.currentFuel > 0)
        {
            fuelBar.ConsumeFuel(fuelDecreaseRate * Time.deltaTime);  // Consome combust�vel
        }
        else
        {
            // O combust�vel acabou, voc� pode colocar aqui o c�digo de perda de jogo ou o que preferir
            Debug.Log("Game Over: Out of Fuel");
        }

        // Aumenta o multiplicador de velocidade com o tempo sem tomar dano
        if (timeWithoutDamage >= timeWithoutDamageToIncreaseSpeed)
        {
            speedMultiplier = Mathf.Min(maxSpeedMultiplier, 1 + (timeWithoutDamage / 10f));  // Aumenta a velocidade at� 2x
        }
    }

    // M�todo para o jogador perder vida
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Aqui voc� pode adicionar l�gica para finalizar o jogo
            Debug.Log("Game Over: No Health");
        }
        UpdateHealthDisplay();

        // Resetar o tempo sem tomar dano
        timeWithoutDamage = 0f;
    }

    // Atualiza a exibi��o dos cora��es
    void UpdateHealthDisplay()
    {
        // Desativa todos os cora��es
        for (int i = 1; i <= maxHealth; i++)
        {
            Transform heart = heartContainer.transform.Find("Heart" + i);
            if (heart != null)
            {
                // Ativa ou desativa o cora��o baseado na vida
                heart.gameObject.SetActive(i <= currentHealth);
            }
        }
    }

    // M�todo chamado a cada frame para aumentar o tempo sem dano
    public void IncreaseTimeWithoutDamage(float deltaTime)
    {
        if (currentHealth > 0)  // S� conta o tempo se o jogador ainda estiver vivo
        {
            timeWithoutDamage += deltaTime;
        }
    }
}
