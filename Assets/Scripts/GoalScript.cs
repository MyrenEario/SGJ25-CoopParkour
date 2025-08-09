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
            transform.Translate(Vector3.up * speed);
            if (transform.position.y > deadY)
            {
                Destroy(gameObject);
            }
        }

    }
    public void finish()
    {
        //    spriteRend.sprite = goalWithPlayer;
        //    // offset richtig machen
        //    finished = true;

        Debug.Log("goal catched");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name);
        if (collision.gameObject.CompareTag("Player")
            && collision.gameObject.name[collision.gameObject.name.Length - 1] == name[name.Length - 1])
        {
            gameManager.finishedPlayers++;
            Debug.Log(name + " entered the goal");
            gameManager.testFinish();
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
