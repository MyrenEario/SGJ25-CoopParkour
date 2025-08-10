using UnityEngine;

public class WizardScript : MonoBehaviour
{
    public Sprite withBallon;
    public float speed = 3.0f;
    public float deadY = 7.0f;

    private GameManager gameManager;
    private Animator animat;
    private Rigidbody2D rigBody;
    private bool finished = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animat = GetComponent<Animator>();
        rigBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed,Space.World);
        }
        if (transform.position.y > deadY)
        {
            gameManager.loadNextScene();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animat.SetBool("finished", true);
        transform.Translate(Vector3.up * 0.8f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        finished = true;
        rigBody.simulated = false;
        Destroy(collision.gameObject);
    }
}
