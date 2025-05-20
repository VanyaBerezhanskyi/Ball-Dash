using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform tile;
    [SerializeField] private Transform obstacle;

    public Vector3 startPoint = new Vector3(0, 0, -5);
    public int initNoObstacles = 4;
    public float timeAcceleration = 0.1f;
    public static int recordScore = 0;
    public int currentScore = 0;
    public float waitTime = 2.0f;

    [Range(1, 15)]
    public int initSpawnNum = 10;

    private Vector3 _nextTileLocation;
    private Quaternion _nextTileRotation;

    private void Start()
    {
        _nextTileLocation = startPoint;
        _nextTileRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; ++i)
        {
            SpawnNextTile(i >= initNoObstacles);
        }
    }

    private void Update()
    {
        Time.timeScale += timeAcceleration * Time.unscaledDeltaTime;
    }

    public void SpawnNextTile(bool spawnObstacles = true)
    {
        Transform newTile = Instantiate(tile, _nextTileLocation, _nextTileRotation);

        Transform nextTile = newTile.Find("Next Spawn Point");
        _nextTileLocation = nextTile.position;
        _nextTileRotation = nextTile.rotation;

        if (spawnObstacles)
        {
            SpawnObstacle(newTile);
        }
    }

    private void SpawnObstacle(Transform newTile)
    {
        List<Transform> obstacleSpawnPoints = new List<Transform>();

        foreach (Transform child in newTile)
        {
            if (child.CompareTag("ObstacleSpawn"))
            {
                obstacleSpawnPoints.Add(child);
            }
        }

        int index = Random.Range(0, obstacleSpawnPoints.Count);
        Transform spawnPoint = obstacleSpawnPoints[index];

        Vector3 spawnPos = spawnPoint.transform.position;

        Transform newObstacle = Instantiate(obstacle, spawnPos, Quaternion.identity);

        newObstacle.SetParent(spawnPoint);
    }

    public IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(waitTime);

        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);

        Time.timeScale = 1.0f;

        if (recordScore < currentScore)
        {
            recordScore = currentScore;
        }
    }
}
