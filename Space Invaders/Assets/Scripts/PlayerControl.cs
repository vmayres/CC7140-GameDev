using UnityEngine;
using UnityEngine.SceneManagement; // Importa SceneManager para mudar de cena

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;

    [SerializeField] float playerMoveSpeed = 10f;
    [SerializeField] private int playerHealth;

    public Transform projectileTransform;
    public GameObject prefab;

    public static void LostHealth()
    {
        if (instance != null)
        {
            instance.playerHealth -= 1;

            // Se a vida chegar a 0, vai para a cena de Game Over
            if (instance.playerHealth <= 0)
            {
                SceneManager.LoadScene("GameOver"); // Nome da cena de Game Over
            }
        }
    }

    private void Awake()
    {
        instance = this;
        instance.playerHealth = 3; // Jogador começa com 3 vidas
    }

    private void Update()
    {

        float translation = Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;

        transform.Translate(translation, 0, 0);

        if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) && GameObject.FindWithTag("Player Projectile") == null)
        {
            Instantiate(prefab, projectileTransform.position, transform.rotation);
        }
    }

}
