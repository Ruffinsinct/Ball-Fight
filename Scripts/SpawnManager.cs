using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawmEmemyWave(waveNumber);
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            SpawmEmemyWave(waveNumber);
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);

        }
    }
    
    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange , spawnRange);
        float spawnPosZ = Random.Range(-spawnRange , spawnRange);

        Vector3 randomSpawn = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomSpawn;
    }

    void SpawmEmemyWave(int enemyToSpawn)
    {
        for (int i=0; i<enemyToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition() , enemyPrefab.transform.rotation);
        }
    }

    

}
