using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] weatherPrefabs;
    public GameObject springPrefab;
    public GameObject _obj;

    [SerializeField] private float spawnX = 3;
    [SerializeField] private float spawnY = 3;
    [SerializeField] private float startDelay = 2;
    [SerializeField] private float spawnInterval = 1.5f;

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
        if (GameManager.instance.season == 0)
        {
            Vector3 spawnPos0 = new Vector3(spawnX, spawnY, 1);
            _obj = Instantiate(springPrefab, spawnPos0, springPrefab.transform.rotation);
            GameManager.instance.q.Enqueue(_obj);
        }
        int weatherIndex = Random.Range(0, weatherPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 1);

        Instantiate(weatherPrefabs[weatherIndex], spawnPos, weatherPrefabs[weatherIndex].transform.rotation);
    }

    public void SpringKill(Spring spring)
    {
        if (spring.Type == Define.Spring.Sunny)
        {

        }
    }
}
