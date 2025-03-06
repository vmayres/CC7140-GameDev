using UnityEngine;

public class InvadersMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float timer = 0.0f;
    private float waitTime = 2.0f;
    private float stepDown = 0.1f;
    private float minY = -1.5f;
    private bool firstMove = true;
    [SerializeField] private static float speed = 2.0f;

    [SerializeField] private GameObject projectilePrefab; // Prefab do projétil
    private static float shootTimer = 0.0f; // Tempo acumulado para tiros
    private static float shootInterval = 1.5f; // Intervalo entre tentativas de tiro

    void ChangeState()
    {
        var vel = rb2d.linearVelocity;
        vel.x *= -1;
        rb2d.linearVelocity = vel;

        Vector3 newPosition = transform.position;
        newPosition.y -= stepDown;
        if (newPosition.y > minY)
            transform.position = newPosition;

        if (firstMove)
        {
            waitTime *= 2;
            firstMove = false;
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        var vel = rb2d.linearVelocity;
        vel.x = speed;
        rb2d.linearVelocity = vel;

        waitTime /= 2;
    }

    void Update()
    {
        timer += Time.deltaTime;
        shootTimer += Time.deltaTime;

        if (timer >= waitTime)
        {
            ChangeState();
            timer = 0.0f;
        }

        // Verifica se é hora de um invader atirar
        if (shootTimer >= shootInterval)
        {
            TryToShoot();
            shootTimer = 0.0f; // Reinicia o tempo de tiro
        }
    }

    void OnDestroy()
    {
        speed += 0.2f;

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

        InvadersMovement[] allInvaders = FindObjectsOfType<InvadersMovement>();
        foreach (InvadersMovement invader in allInvaders)
        {
            invader.UpdateSpeed();
        }
    }

    public void UpdateSpeed()
    {
        if (rb2d != null)
        {
            var vel = rb2d.linearVelocity;
            vel.x = Mathf.Sign(vel.x) * speed;
            rb2d.linearVelocity = vel;
        }
    }

    void TryToShoot()
    {
        // Verifica se já existe um projétil na cena
        if (GameObject.FindWithTag("Laser") == null)
        {
            InvadersMovement[] allInvaders = FindObjectsOfType<InvadersMovement>();

            if (allInvaders.Length > 0)
            {
                // Escolhe aleatoriamente um invader para atirar
                int randomIndex = Random.Range(0, allInvaders.Length);
                InvadersMovement shooter = allInvaders[randomIndex];

                if (shooter != null && shooter.projectilePrefab != null)
                {
                    // Instancia o projétil na posição do invader
                    GameObject projectile = Instantiate(shooter.projectilePrefab, shooter.transform.position, Quaternion.identity);
                    projectile.tag = "Laser"; // Marca o projétil com uma tag
                }
            }
        }
    }
}
