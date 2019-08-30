using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(GameManager))]
public class JumperSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject jumperPrefab;

    float lastSpawnTime;
    //GameManager gameManager;

    [Range(0, 5)]
    public float spawnDelay = 3.0f;
    [Range(0, 2)]
    public float deltaRandomSpawning = 0.5f;

    private float randomSpawnDelay;

    private void Start()
    {
        if (jumperPrefab == null)
        {
            return;
        }

        //gameManager = GetComponent<GameManager>();

        randomSpawnDelay = spawnDelay;
        SpawnJumper();
    }

    private void Update()
    {
        if (Time.time > lastSpawnTime + randomSpawnDelay)
        {
            SpawnJumper();
        }
    }

    private void SpawnJumper()
    {
        lastSpawnTime = Time.time;
        randomSpawnDelay = Random.Range(spawnDelay - deltaRandomSpawning, spawnDelay + deltaRandomSpawning);
        GameObject jumper =  Instantiate(jumperPrefab);

        //JumperController jumperController = jumper.GetComponentInChildren<JumperController>();

        //jumperController.gameManager = gameManager;
    }
}
