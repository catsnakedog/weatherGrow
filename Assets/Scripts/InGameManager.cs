using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    SpawnManager SpawnManager;
    [SerializeField] private int year;
    [SerializeField] private int month;
    [SerializeField] private float speed;
    [SerializeField] private int season;
    [SerializeField] private bool seasonEnd;

    void Start()
    {
        SpawnManager = GameObject.FindWithTag("InGame").GetComponent<SpawnManager>();
        year = 1;
        month = 3;
        seasonEnd = false;
        InGame();
    }

    void Update()
    {
        if (month >= 3 && month <= 5) season = 0;
        else if (month >= 6 && month <= 8) season = 1;
        else if (month >= 9 && month <= 11) season = 2;
        else season = 3;
        GameManager.instance.season = season;

        if (seasonEnd)
        {
            year++;
            GameManager.instance.speed = 1 + year * 0.25f;
            StartCoroutine(YearPlay());
            seasonEnd = false;
        }
    }

    private void InGame()
    {
        StartCoroutine(YearPlay());
    }

    IEnumerator YearPlay()
    {
        Debug.Log("test");
        StartCoroutine(SeasonPlay());
        yield return new WaitForSeconds(18.5f);
        StartCoroutine(SeasonPlay());
        yield return new WaitForSeconds(18.5f);
        StartCoroutine(SeasonPlay());
        yield return new WaitForSeconds(18.5f);
        StartCoroutine(SeasonPlay());
        yield return new WaitForSeconds(18.5f);
        seasonEnd = true;
    }
    IEnumerator SeasonPlay()
    {
        for (int i = 1; i < 5; i++) // 1개월
        {
            yield return new WaitForSeconds(1.5f);
            SpawnManager.SpawnRandomWeather();
        }
        month++;
        for (int i = 1; i < 5; i++) // 2개월
        {
            yield return new WaitForSeconds(1.5f);
            SpawnManager.SpawnRandomWeather();
        }
        month++;
        for (int i = 1; i < 5; i++) // 3개월
        {
            yield return new WaitForSeconds(1.5f);
            SpawnManager.SpawnRandomWeather();
        }
        month++;
    }
}
