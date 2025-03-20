using UnityEngine;

public class Ship_Controls : MonoBehaviour{
    
    public static Ship_Controls instance;

    [SerializeField] float playerMoveSpeed = 10f;

    public Transform projectileTransform;
    public GameObject prefab;
    public Sprite damagedSprite;

    private Sprite originalSprite;
    private SpriteRenderer spriteRenderer;

    private void Update(){

        // Movimento no eixo X e Y
        float translationX = Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;
        float translationY = Input.GetAxis("Vertical") * playerMoveSpeed * Time.deltaTime;

        transform.Translate(translationX, translationY, 0);

        // Limites no eixo X
        if (transform.position.x < -4.4f)
        {
            transform.position = new Vector3(-4.4f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 4.4f)
        {
            transform.position = new Vector3(4.4f, transform.position.y, transform.position.z);
        }

        // Limites no eixo Y (defina valores apropriados)
        if (transform.position.y < -3.3f)
        {
            transform.position = new Vector3(transform.position.x, -3.3f, transform.position.z);
        }
        if (transform.position.y > 3.3f)
        {
            transform.position = new Vector3(transform.position.x, 3.3f, transform.position.z);
        }

        // Disparo
        if (Input.GetKeyDown(KeyCode.Space) && GameObject.FindWithTag("Player Projectile") == null)
        {
            Instantiate(prefab, projectileTransform.position, transform.rotation);
        }
    }

    void OnDestroy()
    {
        //Debug.Log("Player destruido");
        //ScoreManager.LostLife();
    }
}
