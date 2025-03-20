using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public RectTransform fuelBarFill;  // Refer�ncia � imagem da barra de combust�vel
    public float maxFuel = 100f;
    public float currentFuel = 100f;

    private float initialHeight;

    void Start()
    {
        if (fuelBarFill != null)
        {
            initialHeight = fuelBarFill.sizeDelta.y;  // Armazena a altura original da barra
            UpdateFuelBar();  // Atualiza no in�cio para garantir que o valor inicial esteja correto
        }
    }

    void Update()
    {
        UpdateFuelBar();  // Garante que a barra seja atualizada a cada frame
    }

    void UpdateFuelBar()
    {
        if (fuelBarFill != null)
        {
            float fillAmount = Mathf.Clamp(currentFuel / maxFuel, 0, 1); // Garante que fique entre 0 e 1
            fuelBarFill.sizeDelta = new Vector2(fuelBarFill.sizeDelta.x, fillAmount * initialHeight);
        }
    }

    public void ConsumeFuel(float amount)
    {
        currentFuel = Mathf.Clamp(currentFuel - amount, 0, maxFuel);
    }

    public void RefillFuel(float amount)
    {
        currentFuel = Mathf.Clamp(currentFuel + amount, 0, maxFuel);
    }
}
