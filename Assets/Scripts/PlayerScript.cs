using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int playerNumber = 1;
    public float speed = 5.0f;
    public float jumpForce = 10.0f;


    public float standard_mass = 1;
    public float falling_mass = 10;

    public float ground_friction = 0.5f;

    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    private GameManager gameManager;
    private Animator anim;
    private Rigidbody2D rigBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rigBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Update is called once per frame
    void Update()
    {
        MakeItMove();
    }

    void FixedUpdate()
    {
        float movement = Input.GetAxis("Player " + playerNumber + " Horizontal");

        //transform.Translate(Vector3.right * Time.deltaTime * Mathf.Abs(movement) * speed,Space.Self);

        // Bewegung
        if (0 < movement && rigBody.linearVelocityX <= speed * movement ||
            0 > movement && rigBody.linearVelocityX >= speed * movement)
        {
            rigBody.linearVelocityX = speed * movement;
        }

        if (isGrounded())
        {
            if (rigBody.linearVelocityX >= 1.5f * speed || rigBody.linearVelocityX <= -1.5f * speed)
            {
                rigBody.linearVelocityY = jumpForce;
            }
            else if (movement == 0)
            {
                rigBody.linearVelocityX = (1 - ground_friction) * rigBody.linearVelocityX;
            }
        }


        if (rigBody.linearVelocityY < -5)
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
            rigBody.linearVelocityY = jumpForce;
        }

        // Rotation
        if (movement > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (movement < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    //private void OnCollision2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Goal") && 
    //        collision.gameObject.name[collision.gameObject.name.Length-1] == name[name.Length - 1])
    //    {
    //        collision.gameObject.GetComponent<GoalScript>().finish();
    //    }
    //}

    public bool isGrounded()
    {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -Vector2.up, castDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position - Vector3.up * castDistance, boxSize);
    }
}
