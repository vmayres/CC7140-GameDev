using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Rigidbody2D rbd2;
    private Animator anim;

    [SerializeField] private LayerMask whatIsObstacle;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private Transform player; 

    [SerializeField] private float obstacleDetectionDistance = 1.0f;
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float detectionRadius = 5.0f; 

    private bool isChasing = false;

        void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }

    private void AnimationControlers_Enemy()
    {
        anim.SetFloat("X_Velocity", rbd2.linearVelocityX);
    }

    void Update()
    {
        AnimationControlers_Enemy();
        // Detecta se o player está no raio de detecção
        isChasing = Physics2D.OverlapCircle(transform.position, detectionRadius, whatIsPlayer);

        if (isChasing)
            ChasePlayer();
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;

        // Verifica se há um obstáculo na direção do movimento
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, obstacleDetectionDistance, whatIsObstacle);

        if (hit.collider == null) // Se não houver obstáculo, continua perseguindo
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else // Se houver obstáculo, tenta subir ou descer
        {
            Vector3 alternativeDirection = new Vector3(direction.x, direction.y + 1.0f, 0).normalized;
            transform.position += alternativeDirection * moveSpeed * Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}
