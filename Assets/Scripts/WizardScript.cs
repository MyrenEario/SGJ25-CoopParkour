using UnityEngine;

public class WizardScript : MonoBehaviour
{
    public GameObject goal1;
    public GameObject goal2;

    public Sprite withBallon;
    public float speed = 3.0f;
    public float deadY = 7.0f;

    private Animator animat;
    private Rigidbody2D rigBody;
    private bool finished = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animat = GetComponent<Animator>();
        rigBody = GetComponent<Rigidbody2D>();
        goal1 = GameObject.Find("Goal1");
        goal2 = GameObject.Find("Goal2");
        goal1.SetActive(false);
        goal2.SetActive(false);
        
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
            goal1.SetActive(true);
            goal2.SetActive(true);
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
