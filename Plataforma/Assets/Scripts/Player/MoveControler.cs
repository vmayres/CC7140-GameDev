using UnityEngine;

public class MoveControler : MonoBehaviour
{
    public Rigidbody2D rbd2;
    private Animator anim;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private float xinput;
    private bool IsGrounded;
    private bool facingRight = true;

    [Header("Collision Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;

    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        AnimationControlers();
        CollisionChecks();
        Andar();
        FlipChecks(); // Agora verifica primeiro o movimento, depois o mouse

        if (Input.GetKeyDown(KeyCode.Space))
            Pular();

        if (Input.GetKeyDown(KeyCode.F))
            Flip();
    }

    private void AnimationControlers()
    {
        anim.SetBool("IsGrounded", IsGrounded);
        anim.SetFloat("X_Velocity", rbd2.linearVelocityX);
        anim.SetFloat("Y_Velocity", rbd2.linearVelocityY);
    }

    private void Andar()
    {
        xinput = Input.GetAxis("Horizontal");
        rbd2.linearVelocityX = moveSpeed * xinput;
    }

    private void Pular()
    {
        if (IsGrounded)
        {
            rbd2.linearVelocityY = jumpForce;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FlipChecks()
    {
        // Prioriza o movimento do player antes do mouse
        if (xinput < 0 && facingRight) 
        {
            Flip();
        }
        else if (xinput > 0 && !facingRight) 
        {
            Flip();
        }
        else if (xinput == 0) // Se o player estiver parado, ele segue o mouse
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
