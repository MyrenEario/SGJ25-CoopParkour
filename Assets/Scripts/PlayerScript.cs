using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int playerNumber = 1;
    public float speed = 5.0f;
    public float jumpForce = 10.0f;

    public float groundFriction = 0.9f;

    public float standard_mass = 1;
    public float falling_mass = 10;

    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    private Animator anim;
    private Rigidbody2D rigBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rigBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MakeItMove();
    }

    void FixedUpdate()
    {
        float movement = Input.GetAxis("Player " + playerNumber + " Horizontal");
        // Bewegung
        rigBody.linearVelocityX = speed * movement;

        if (rigBody.linearVelocityY < -0.1)
        {
            rigBody.mass = falling_mass;
        }
        else
        {
            rigBody.mass = standard_mass;
        }
    }

    void MakeItMove()
    {
        float movement = Input.GetAxis("Player " + playerNumber + " Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(movement));
        anim.SetBool("grounded", isGrounded());

        // Sprung
        if (isGrounded() && Input.GetKeyDown( playerNumber == 1? KeyCode.W: KeyCode.UpArrow))
        {
            rigBody.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
        }

        // Rotation
        if (movement > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (movement < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

   
    public bool isGrounded()
    {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -Vector2.up, castDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position - Vector3.up * castDistance, boxSize);
    }
}
