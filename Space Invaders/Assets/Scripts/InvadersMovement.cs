using UnityEngine;
using System.Collections;

public class InvadersMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private static InvadersMovement[] allInvaders; // Para controlar os invaders no cenário

    [SerializeField] public Transform projectileTransform;
    [SerializeField] public GameObject projectilePrefab; // Prefab do projétil
    private static float shootTimer = 0.0f; // Tempo acumulado para disparos
    private static float shootInterval = 1.5f; // Intervalo entre tentativas de disparo

    void Start()
    {
        // Obtém o Rigidbody2D do próprio invader (GameObject filho)
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        TryToShoot();
    }

    // Função chamada quando o invader é destruído
    void OnDestroy()
    {
        Debug.Log("Invader Destroyed");
    }

    // Função para tentar disparar um projétil
    void TryToShoot()
    {
        // Verifica se já existe um projétil na cena
        if (GameObject.FindWithTag("Enemy Projectile") == null)
        {
            allInvaders = FindObjectsOfType<InvadersMovement>();

            if (allInvaders.Length > 0)
            {
                // Escolhe aleatoriamente um invader para atirar
                int randomIndex = Random.Range(0, allInvaders.Length);
                InvadersMovement shooter = allInvaders[randomIndex];

                if (shooter != null && shooter.projectilePrefab != null)
                {
                    // Instancia o projétil na posição do invader
                    GameObject projectile = Instantiate(shooter.projectilePrefab, shooter.transform.position, Quaternion.identity);

                    // Garantir que o projétil seja gerado no valor z correto (exemplo: z = 1 ou z = 2, conforme necessário)
                    Vector3 projectilePosition = projectile.transform.position;
                    projectilePosition.z = 1f; // Ajuste conforme necessário
                    projectile.transform.position = projectilePosition;

                    // Marca o projétil com a tag correta
                    projectile.tag = "Enemy Projectile";
                }
            }
        }
    }

}
