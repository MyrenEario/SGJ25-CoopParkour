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

    //public string[] sceneList = { "SampleScene", "Level2", "Level3", "Level4", "Level5", "WizardLevel1" };
    public int currentScene;

    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        mainCamera = Camera.FindFirstObjectByType<Camera>();
        goal1 = GameObject.Find("Goal1");
        goal2 = GameObject.Find("Goal2");
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetScene();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            loadPreviouseScene();
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void loadNextScene() 
    {
        SceneManager.LoadScene(currentScene-1 >= SceneManager.sceneCount ? 0 : currentScene-1);
    }
    public void loadPreviouseScene()
    {
        SceneManager.LoadScene(currentScene + 1 <= 0 ? SceneManager.sceneCount-1: currentScene + 1);
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
