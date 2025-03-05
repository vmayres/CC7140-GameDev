using UnityEngine;

public class InvadersMovement : MonoBehaviour {

    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private int state = 0;
    private float x;
    private float speed = 2.0f;

    void ChangeState() {
        var vel = rb2d.linearVelocity;
        vel.x *= -1;
        rb2d.linearVelocity = vel;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        rb2d = GetComponent<Rigidbody2D>();
        x = transform.position.x;

        var vel = rb2d.linearVelocity;
        vel.x = speed;
        rb2d.linearVelocity = vel;
    }

    // Update is called once per frame
    void Update() {

        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            ChangeState();
            timer = 0.0f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bullet") {

            Destroy(rb2d);
        }
    }
}
