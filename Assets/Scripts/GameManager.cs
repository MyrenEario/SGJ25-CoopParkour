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
    public int currentScene;
    public bool gameOver = false;

    
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
            loadNextScene();
        }
        if (Input.GetKeyDown(KeyCode.M))
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
        SceneManager.LoadScene(currentScene + 1 >= SceneManager.sceneCountInBuildSettings ? 0 : currentScene + 1);
    }
    public void loadPreviouseScene()
    {
        SceneManager.LoadScene(currentScene - 1 < 0 ? SceneManager.sceneCountInBuildSettings-1: currentScene - 1);
    }

    public void tryFinish()
    {
        Debug.Log("finished Players: " + finishedPlayers + ", try Finish()");
        if (finishedPlayers >= 2)
        {
            goal1.GetComponent<GoalScript>().finish();
            goal2.GetComponent<GoalScript>().finish();
            player1.SetActive(false);
            player2.SetActive(false);
        }
    }
    public void tryNextScene()
    {
        Debug.Log("finished Players: "+finishedPlayers);
        if (finishedPlayers <= 0)
        {
            loadNextScene();
        }
    }
}
