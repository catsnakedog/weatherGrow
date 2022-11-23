using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/*
public class InGameManager : MonoBehaviour
{
    SpawnManager SpawnManager;
    int year;
    int month;
    float speed;
    int season;

    void start()
    {
        SpawnManager = GameObject.FindWithTag("InGame").GetComponent<SpawnManager>();
        month = 3;
        InGame();
    }

    private void InGame()
    {
        StartCoroutine(YearPlay);
        //소환

    }

    IEnumerator YearPlay()
    {
        speed = 1 + year * 0.25f;
        for (int i = 1; i < 5; i++)
        {
            yield return new WaitForSeconds(1.5f);
            SpawnManager.SpawnRandomWeather();
        }
    }
    private void MonthPlay()
    {
        speed = 1 + year * 0.25f;
        for(int i=1; i < 5; i++)
        {
            SpawnManager.SpawnRandomWeather();
        }
    }
}
*/