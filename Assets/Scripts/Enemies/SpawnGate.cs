using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject robotPrefab;
    [SerializeField] float spawnTime = 5f;
    [SerializeField] Transform spawnPoint;

    PlayerHealth player;
    void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (player)
        { 
            Instantiate(robotPrefab, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spawnTime);
        }
    }
    /* My Code
    [SerializeField] GameObject robot;
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] Transform spawnPoint;
    float spawnInterval = 0;

    void Update()
    {
        spawnInterval += Time.deltaTime;
        if (playerHealth.currentHealth > 0)
        { 
            if (spawnInterval > 5)
            {
                StartCoroutine(SpawnEnemy());
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(robot, spawnPoint.position, Quaternion.identity);
        spawnInterval = 0;
        yield return null;
    }
    */
}
