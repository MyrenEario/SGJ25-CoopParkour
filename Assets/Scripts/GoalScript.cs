using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public static float speed = 3.0f;

    public Sprite goalWithPlayer;
    public float deadY = 9;

    private GameManager gameManager;
    private SpriteRenderer spriteRend;
    private bool finished = false;

    private void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (finished)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (transform.position.y > deadY)
            {
                gameManager.finishedPlayers--;
                gameManager.tryNextScene();
                Destroy(gameObject);
            }
        }

    }
    public void finish()
    {
        spriteRend.sprite = goalWithPlayer;
        // offset richtig machen
        finished = true;

        Debug.Log("See you");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")
            && collision.gameObject.name[collision.gameObject.name.Length - 1] == name[name.Length - 1])
        {
            gameManager.finishedPlayers++;
            Debug.Log(name + " entered the goal");
            gameManager.tryFinish();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")
           && collision.gameObject.name[collision.gameObject.name.Length - 1] == name[name.Length - 1])
        {
            gameManager.finishedPlayers--;
            Debug.Log(name + " left the goal");
        }
    }
}
