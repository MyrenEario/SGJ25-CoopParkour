using UnityEngine;

public class WizardScript : MonoBehaviour
{
    public GameObject goal1;
    public GameObject goal2;

    public Sprite withBallon;
    public float speed = 3.0f;
    public float deadY = 7.0f;

    private SpriteRenderer spriteRend;
    private bool finished = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (transform.position.y > deadY)
        {
            goal1.SetActive(true);
            goal2.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRend.sprite = withBallon;
        Destroy(collision.gameObject);
    }
}
