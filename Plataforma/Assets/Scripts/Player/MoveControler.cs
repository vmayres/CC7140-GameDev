using UnityEngine;

public class MoveControler : MonoBehaviour
{
    public Rigidbody2D rbd2;
    private Animator anim;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    private float xinput;
    private bool IsGrounded;
    private bool facingRight = true;

    [Header("Collision Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask whatIsGround;

    [Header("GameManager Config")]
    [SerializeField] private GameObject gameManagerPrefab; // Prefab do GameManager, para instanciar se n�o existir

    void Start()
    {
        // Garante que o GameManager exista na cena
        if (GameManager.Instance == null && gameManagerPrefab != null)
        {
            Instantiate(gameManagerPrefab);
            Debug.Log("GameManager instanciado pelo MoveControler.");
        }

        rbd2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        AnimationControlers();
        CollisionChecks();
        Andar();
        FlipChecks();

        if (Input.GetKeyDown(KeyCode.Space))
            Pular();

        if (Input.GetKeyDown(KeyCode.F))
            Flip();
    }

    private void AnimationControlers()
    {
        anim.SetBool("IsGrounded", IsGrounded);
        anim.SetFloat("X_Velocity", rbd2.linearVelocity.x);
        anim.SetFloat("Y_Velocity", rbd2.linearVelocity.y);
    }

    private void Andar()
    {
        xinput = Input.GetAxis("Horizontal");
        rbd2.linearVelocity = new Vector2(moveSpeed * xinput, rbd2.linearVelocity.y);
    }

    private void Pular()
    {
        if (IsGrounded)
        {
            rbd2.linearVelocity = new Vector2(rbd2.linearVelocity.x, jumpForce);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FlipChecks()
    {
        if (xinput < 0 && facingRight)
        {
            Flip();
        }
        else if (xinput > 0 && !facingRight)
        {
            Flip();
        }
        else if (xinput == 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x < transform.position.x && facingRight) { Flip(); }
            else if (mousePos.x > transform.position.x && !facingRight) { Flip(); }
        }
    }

    private void CollisionChecks()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Destroi o inimigo

            if (GameManager.Instance != null)
            {
                GameManager.Instance.PerderVida(); // Perde uma vida
            }
            else
            {
                Debug.LogWarning("GameManager n�o encontrado!");
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
