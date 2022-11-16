using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] weatherPrefabs;

    [SerializeField] private float spawnX = 3;
    [SerializeField] private float spawnY = 3;
    [SerializeField] private float startDelay = 2;
    [SerializeField] private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomWeather", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomWeather()
    {
        int weatherIndex = Random.Range(0, weatherPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 1);

        Instantiate(weatherPrefabs[weatherIndex], spawnPos, weatherPrefabs[weatherIndex].transform.rotation);
    }
}
