using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Camera mainCamera;


    public int gameState = 0;
    // 0: Start
    // 1: running
    // 2: paused

    public bool gameOver = false;


    void Start()
    {
        
    }

    void Update()
    {

    }
}
