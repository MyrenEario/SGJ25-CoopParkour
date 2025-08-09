using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int playerNumber = 1;
    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    public bool touchFloor = false;

    private Rigidbody2D rigBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MakeItMove();
    }

    void MakeItMove()
    {
        float movement = Input.GetAxis("Player " + playerNumber + " Horizontal");
        // Bewegung
        transform.Translate(new Vector3(speed * Time.deltaTime *Mathf.Abs(movement),0));
        
        // Sprung
        if (touchFloor && Input.GetKeyDown( playerNumber == 1? KeyCode.W: KeyCode.UpArrow))
        {
            rigBody.AddForce(new Vector2(0,jumpForce),ForceMode2D.Impulse);
            touchFloor = false;
        }

        // Rotation
        if (movement > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (movement < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            touchFloor = true;
        }
    }
}
