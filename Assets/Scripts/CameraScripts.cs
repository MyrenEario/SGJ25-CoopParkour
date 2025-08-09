using UnityEngine;

public class CameraScripts : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public float deadzonesX;
    public float deadzonesY;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float x1 = player1.transform.position.x;
        float x2 = player2.transform.position.x;
        float maxX = Mathf.Max(x1, x2);
        float minX = Mathf.Min(x1, x2);
        float y1 = player1.transform.position.y;
        float y2 = player2.transform.position.y;
        float maxY = Mathf.Max(y1, y2);
        float minY = Mathf.Min(y1, y2);
        
        if (maxX >= transform.position.x + deadzonesX)
        {
            transform.position = new Vector3(maxX - deadzonesX, transform.position.y, transform.position.z);
        }
        else if (minX < transform.position.x - deadzonesX && maxX < transform.position.x + deadzonesX)
        {
            transform.position = new Vector3(maxX > transform.position.x+ deadzonesX-0.2f ? maxX - deadzonesX: minX+deadzonesX, transform.position.y, transform.position.z);
        } 
        
        if (maxY >= transform.position.y + deadzonesY)
        {
            transform.position = new Vector3(transform.position.x, maxY - deadzonesY, transform.position.z);
        }
        else if (minY < transform.position.y - deadzonesY && maxY < transform.position.y + deadzonesY)
        {
            transform.position = new Vector3(transform.position.x, maxY > transform.position.y + deadzonesY -0.2f ? maxY - deadzonesY : minY+deadzonesY, transform.position.z);
        }
    }
}
