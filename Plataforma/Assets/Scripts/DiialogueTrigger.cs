using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox; // Referência ao GameObject que contém o script DIalogue

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueBox.SetActive(true); // Garante que o painel esteja visível

            // Reinicia o diálogo chamando o método público do script DIalogue
            DIalogue dialogueScript = dialogueBox.GetComponent<DIalogue>();
            if (dialogueScript != null)
            {
                dialogueScript.StartDialogueExternamente();
            }
        }
    }
}
