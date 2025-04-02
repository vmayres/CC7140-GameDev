using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rbd2 => GetComponent<Rigidbody2D>();

    void Update() => transform.right = rbd2.linearVelocity;
}
