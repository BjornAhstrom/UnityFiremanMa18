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
    private bool stop = false;

    private List<GameObject> jumpers = new List<GameObject>();

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
        if (!stop && Time.time > lastSpawnTime + randomSpawnDelay)
        {
            SpawnJumper();
        }
    }

    private void SpawnJumper()
    {
        lastSpawnTime = Time.time;
        randomSpawnDelay = Random.Range(spawnDelay - deltaRandomSpawning, spawnDelay + deltaRandomSpawning);

        // Skapa Jumper
        GameObject jumper =  Instantiate(jumperPrefab);

        // Lägg till i listan
        jumpers.Add(jumper);
        JumperController jumperController = jumper.GetComponentInChildren<JumperController>();
      
        jumperController.jumperSpawner = this;

        //JumperController jumperController = jumper.GetComponentInChildren<JumperController>();

        //jumperController.gameManager = gameManager;
    }

    public void DestroyJumper(GameObject jumper)
    {
        // ta bort jumper ut listan
        jumpers.Remove(jumper);

        // Ta bort jumper 
        Destroy(jumper);

    }

    public void Stop()
    {
        stop = true;

        // Gå igenom listan förstör alla jumpers
        for (int i = jumpers.Count - 1; i >= 0; i--)
        {
            DestroyJumper(jumpers[i]);

        }

    }
}
