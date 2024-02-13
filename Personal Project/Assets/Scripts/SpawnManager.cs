using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   
    public GameObject[] spawn;
    public GameObject powerUp;
    private float spawnRange = 19.0f;
    private float randomRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SpawnEnemy()
    {
        
    }
    void EnemyRandomPos()
    {
        randomRange = Random.Range(-spawnRange, spawnRange);
    }
}
