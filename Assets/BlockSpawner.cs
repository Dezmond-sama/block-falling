using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject block;
    public float timeBetweenWaves = 2f;
    private float countdown = 2f;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (countdown <= 0)
        {
            DropBlocks();
            countdown = timeBetweenWaves;
        }
        else
        {
            countdown -= Time.deltaTime;
        }
    }

    private void DropBlocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != randomIndex)
            {
                Instantiate(block, spawnPoints[i].position, Quaternion.identity);
            }
        }
        gameManager.currentWave++;
        gameManager.UpdateScore();
    }
}
