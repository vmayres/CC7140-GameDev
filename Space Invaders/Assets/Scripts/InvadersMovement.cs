using UnityEngine;

public class InvadersMovement : MonoBehaviour {

    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 2.0f;
    private int state = 0;
    private float x;
    private float speed = 2.0f;
    private float stepDown = 0.1f; // Distância que os invaders descem
    private float minY = -1.5f; // Limite inferior para não descer indefinidamente
    private bool firstMove = true; // Controle para a primeira iteração

    void ChangeState() {
        var vel = rb2d.linearVelocity;
        vel.x *= -1;
        rb2d.linearVelocity = vel;

        // Faz os invaders descerem
        Vector3 newPosition = transform.position;
        newPosition.y -= stepDown;
        if (newPosition.y > minY) // Garante que não desçam infinitamente
            transform.position = newPosition;

        // Se for a primeira troca de direção, restauramos o tempo normal
        if (firstMove){
            waitTime *= 2; // Retorna ao tempo normal após a primeira inversão
            firstMove = false;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

        rb2d = GetComponent<Rigidbody2D>();
        x = transform.position.x;

        var vel = rb2d.linearVelocity;
        vel.x = speed;
        rb2d.linearVelocity = vel;

        // Reduz o tempo da primeira iteração
        waitTime /= 2;
        
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

    private void OnDestroy()
    {
        Debug.Log("Invader Destroyed");
        if (CompareTag("Octopus"))
        {
            ScoreManager.AddScore(10);
        }
        else if (CompareTag("Crab"))
        {
            ScoreManager.AddScore(20);
        }
        else if (CompareTag("Squid"))
        {
            ScoreManager.AddScore(40);
        }
    }

}
