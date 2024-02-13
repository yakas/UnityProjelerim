using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public GameObject powerupPrefabs;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;



    void Start()
    {

        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;// burada enemy dizisinin uzunlugunu alir.
        Debug.Log("enemyCount:" + enemyCount);
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefabs, GenerateSpawnPosition(), powerupPrefabs.transform.rotation);

        }
    }

    void SpawnEnemyWave(int enemiesToSpawn) // metod burada enemiesToSpawn ile int bir degisken aliyor.Metod enemiesToSpawn kadar enemy yaratiyor.
    {
        for (int i = 0; i < enemiesToSpawn; i++)

            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);// Instantiate metodu enemeyPrefab adinda olusturulan gameObject'e position ve rotation vererek bir enemy olusturuyoruz.Enemy prefab'ini inspector penceresinden kendimiz surukle birak ile ayarliyoruz unutma...
    }
    private Vector3 GenerateSpawnPosition() // bir metod kullanarak enemyPos degerini hesaplayarak geri donduruyoruz.
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
