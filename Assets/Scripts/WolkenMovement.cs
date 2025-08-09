using UnityEngine;

public class WolkenMovement : MonoBehaviour
{
    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(1.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (transform.position.x > 20)
        {
            Destroy(gameObject);
        }
    }
}
