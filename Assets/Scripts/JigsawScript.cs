using UnityEngine;

public class JigsawScript : MonoBehaviour
{
    public float maxArc = 50;
    private Rigidbody2D rigBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rigBody.rotation > maxArc)
        {
            rigBody.rotation = maxArc;
            rigBody.angularVelocity = 0; 
        } else if (rigBody.rotation < -maxArc)
        {
            rigBody.rotation = -maxArc;
            rigBody.angularVelocity = 0;
        }
    }
}
