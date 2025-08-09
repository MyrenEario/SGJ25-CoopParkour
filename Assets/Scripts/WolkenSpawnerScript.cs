using System.Collections;
using UnityEngine;

public class WolkenSpawnerScript : MonoBehaviour
{
    public Sprite[] wolkenAussehen;
    public GameObject wolkenPrefab;
    public float startX = -15;
    public float minY = 0.0f;
    public float maxY = 4.5f;

    private float timeSinceLastSpawn = 0;
    private float timeToNextSpawn = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            spawnRandomWolke(Random.Range(-8.0f, 8));
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > timeToNextSpawn)
        {
            spawnRandomWolke(startX);
            timeToNextSpawn = Random.Range(0.5f, 1.5f);
            timeSinceLastSpawn = 0;
        }
        
    }

    private void spawnRandomWolke(float x)
    {
        GameObject w = Instantiate(wolkenPrefab, new Vector3(x, Random.Range(minY, maxY), 0), wolkenPrefab.transform.rotation);
        w.gameObject.GetComponent<SpriteRenderer>().sprite = wolkenAussehen[Random.Range(0, wolkenAussehen.Length - 1)];
    }
}
