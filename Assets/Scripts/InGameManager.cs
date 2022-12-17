using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    SpawnManager SpawnManager;

    [SerializeField] private Text monthText; 
    [SerializeField] private Text yearText;
    [SerializeField] private int year;
    [SerializeField] private int speed;
    [SerializeField] private int month;
    [SerializeField] private int bossClick;
    [SerializeField] private int season;
    [SerializeField] private bool seasonEnd;

    void Start()
    {
        SpawnManager = GameObject.FindWithTag("InGame").GetComponent<SpawnManager>();
        speed = 1;
        year = 1;
        month = 3;
        bossClick = 10;
        seasonEnd = false;
        GameManager.instance.bossClick = bossClick;
        InGame();
    }

    void Update()
    {
        if (month >= 3 && month <= 5) season = 0;
        else if (month >= 6 && month <= 8) season = 1;
        else if (month >= 9 && month <= 11) season = 2;
        else season = 3;

        if (month > 12)
        {
            year++;
            month = 1;
        }

        GameManager.instance.season = season;
        yearText.text = year.ToString();
        monthText.text = month.ToString();

        if (seasonEnd)
        {
            speed++;
            GameManager.instance.speed = 1 + speed * 0.25f;
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
        bossClick += 5;
        GameManager.instance.bossClick = bossClick;
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

        // 시즌이 끝날때 보스 소환 추가 여기다가 @@@@@@@
    }
}
