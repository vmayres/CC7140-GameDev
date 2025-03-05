using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] float playerMoveSpeed = 10f;

    public Transform projectileTransform;
    public GameObject prefab;

    void Start() {

    }

    
    void Update() {

        float translation = Input.GetAxis("Horizontal") * playerMoveSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;

        transform.Translate(translation, 0, 0); // Translacao no eixo X
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
