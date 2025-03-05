using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] float playerMoveSpeed = 10f;

    void Start() {
        
    }

    
    void Update() {

        float translation = Input.GetAxis("Horizontal") * playerMoveSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;

        transform.Translate(translation, 0, 0);    // Rotate around our y-axis
    }
}
