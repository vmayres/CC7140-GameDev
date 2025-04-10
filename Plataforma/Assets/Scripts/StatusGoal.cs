using UnityEngine;

public class PlacaStatus : MonoBehaviour
{
    [Header("Sprites da Placa")]
    public Sprite spriteAntes;
    public Sprite spriteDepois;

    [Header("Referências")]
    public GameObject objetivo; // este deve ser o mesmo objetivo ativado no LevelManager
    public GameObject dialogo;  // este deve ser o painel de diálogo (com script DIalogue)

    private SpriteRenderer sr;
    private bool atualizado = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (sr != null && spriteAntes != null)
            sr.sprite = spriteAntes;
    }

    void Update()
    {
        if (!atualizado && objetivo != null && objetivo.activeSelf)
        {
            Debug.Log("Objetivo foi ativado, atualizando placa...");
            atualizado = true;
            AtualizarEstadoDaPlaca();
        }
    }

    void AtualizarEstadoDaPlaca()
    {
        if (sr != null && spriteDepois != null)
            sr.sprite = spriteDepois;

        if (dialogo != null)
        {
            DIalogue dialogueScript = dialogo.GetComponent<DIalogue>();
            if (dialogueScript != null)
            {
                dialogo.SetActive(false); // desativa o painel do diálogo
            }
        }
    }
}
