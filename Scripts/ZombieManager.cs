using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public GameObject zombiePrefab; 
    public float spawnRadius = 10f; 
    public int minZombies = 1; 
    public int maxZombies = 3; 
    public float spawnInterval = 10f; 

    void Start()
    {
        InvokeRepeating("SpawnZombies", 10f, spawnInterval);
    }

    void SpawnZombies()
    {
        int numZombies = Random.Range(minZombies, maxZombies + 1);

        for (int i = 0; i < numZombies; i++)
        {
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(zombiePrefab, randomPosition, Quaternion.identity);
        }
    }
}