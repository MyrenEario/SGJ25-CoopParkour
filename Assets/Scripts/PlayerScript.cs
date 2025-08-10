using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject otherPlayer;

    public int playerNumber = 1;
    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    private float jumpPadMultiplier = 2.0f;


    public float standard_mass = 1;
    public float falling_mass = 10;

    public float ground_friction = 0.5f;

    public static Vector2 boxSize = new Vector2(0.4f, 0.1f);
    public static float castDistance = 0.5f;
    public  LayerMask groundLayer;

    public static Vector2 kickBox = new Vector2 (0.3f, 0.5f);
    public static float kickRange = -0.4f;
    public static float kickForce = 6.5f;
    public LayerMask playerLayer1;
    public LayerMask playerLayer2;

    private GameManager gameManager;
    private Animator anim;
    private Rigidbody2D rigBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rigBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        otherPlayer = GameObject.Find("Player" + (playerNumber == 1 ? "2" : "1"));
    }

    //Update is called once per frame
    void Update()
    {
        MakeItMove();
        MakeItKick();
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
            if (rigBody.linearVelocityX >= 2f * speed || rigBody.linearVelocityX <= -1.5f * speed)
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

    void MakeItKick()
    {
        if (Input.GetKeyDown((playerNumber == 1? KeyCode.S: KeyCode.DownArrow)))
        {
            anim.SetTrigger("Kick");
            if(Physics2D.BoxCast(transform.position, kickBox,0, Vector2.right * (transform.rotation.y.Equals(-1) ? 1: -1), kickRange,playerNumber == 1? playerLayer2 : playerLayer1))
            {
                otherPlayer.GetComponent<Rigidbody2D>().linearVelocity += Vector2.right * kickForce * (transform.rotation.y.Equals(-1) ? -1 : 1) + Vector2.up* jumpForce;
            }
        }
    }
  
    //* (transform.rotation.y == 180 ? 1 : -1)

    public bool isGrounded()
    {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -Vector2.up, castDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position - Vector3.up * castDistance, boxSize);
        Gizmos.DrawCube(transform.position - Vector3.right * kickRange * (transform.rotation.y.Equals(-1) ? -1 : 1), kickBox);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BouncePad")
            && collision.GetContact(0).normal == Vector2.up)
        {
            rigBody.linearVelocityY = jumpForce * jumpPadMultiplier;
        }
    }
}
