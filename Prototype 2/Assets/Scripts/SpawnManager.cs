using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;// Scene'de EmptyGameObject olusturup bu kodu bagliyoruz.
    private float spawnRangeX = 15f;// x ekseninde -15.....0.....15 araliginda bir alanda spawn edilecek.
    private float spawnPosZ = 32f;// z ekseninde 32 irim mesafede spawn edilecek pozisyon
    private float startDelay = 2f;// void start basladiktan 2 saniye sonrasinda SpawnRandomAnimal metodunu cagirmasi saglanir.
    private float spawnInterval = 1.5f; // 1.5 saniyede spawnManager methodunu cagiracak.
    
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal() 
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);// 0 ile 2 arasinda rastgele bir sayi uretilecek ve busayi animalIndex degiskenine atilacak..."animalPrefabs.Lenght" burada 3 oluyor.
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);

    }
}
