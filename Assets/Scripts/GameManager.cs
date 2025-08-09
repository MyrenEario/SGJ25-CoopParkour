using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject goal1;
    public GameObject goal2;
    public Camera mainCamera;

    public int finishedPlayers = 0;


    public int gameState = 0;
    // 0: Start
    // 1: running
    // 2: paused

    public bool gameOver = false;


    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        mainCamera = Camera.FindFirstObjectByType<Camera>();
        goal1 = GameObject.Find("Goal1");
        goal2 = GameObject.Find("Goal2");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void testFinish()
    {
        if (finishedPlayers == 2)
        {
            goal1.GetComponent<GoalScript>().finish();
            goal2.GetComponent<GoalScript>().finish();
        }
    }
}
