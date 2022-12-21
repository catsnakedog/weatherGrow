using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    SpawnManager SpawnManager;

    [SerializeField] private Text bestScoreText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text seasonText;
    [SerializeField] private Text tempText;
    [SerializeField] private int year;
    [SerializeField] private int speed;
    [SerializeField] private int month;
    [SerializeField] private int bossClick;
    [SerializeField] private int season;
    [SerializeField] private bool seasonEnd;
    [SerializeField] private string temp;
    private WeatherAndBoss n;

    [SerializeField] private List<GameObject> hearts = new List<GameObject>();

    void Start()
    {
        GameManager.instance.bestScore = PlayerPrefs.GetInt("BestScore");
        SpawnManager = GameObject.FindWithTag("InGame").GetComponent<SpawnManager>();
        speed = 1;
        year = 1;
        month = 3;
        bossClick = 10;
        GameManager.instance.crruentScore = year*48 + month*4;
        seasonEnd = false;
        GameManager.instance.bossClick = bossClick;
        InGame();
    }

    void Update()
    {
        if (GameManager.instance.q.Count != 0)
        {
            temp = "";
            n = GameManager.instance.q.Peek().GetComponent<WeatherAndBoss>();
            for (int j = 0; j < n.weather.Count; j++)
            {
                temp += n.weather[j].ToString();
            }
            tempText.text = temp;
        }    

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
        scoreText.text = (GameManager.instance.crruentScore / 48).ToString() + "년 " + ((GameManager.instance.crruentScore%48) / 4).ToString() + "월 " + (GameManager.instance.crruentScore%4).ToString() + "주 ";
        if (GameManager.instance.bestScore == 0)
        {
            bestScoreText.text = "아직없음!";
        }
        else bestScoreText.text = (GameManager.instance.bestScore / 48).ToString() + "년 " + ((GameManager.instance.bestScore % 48) / 4).ToString() + "월 " + (GameManager.instance.bestScore % 4).ToString() + "주 ";


        if (seasonEnd)
        {
            speed++;
            GameManager.instance.speed = 1 + speed * 0.25f;
            StartCoroutine(YearPlay());
            seasonEnd = false;
        }

        if (GameManager.instance.hp < 3)
        {
            hearts[2].SetActive(false);
        }
        if (GameManager.instance.hp < 2)
        {
            hearts[1].SetActive(false);
        }
        if (GameManager.instance.hp < 1)
        {
            hearts[0].SetActive(false);
        }

        switch (season)
        {
            case 0:
                seasonText.text = "봄";
                return;
            case 1:
                seasonText.text = "여름";
                return;
            case 2:
                seasonText.text = "가을";
                return;
            case 3:
                seasonText.text = "겨울";
                return;
            default:
                seasonText.text = "오류";
                return;
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
        yield return new WaitForSeconds(24f);
        StartCoroutine(SeasonPlay());
        yield return new WaitForSeconds(24f);
        StartCoroutine(SeasonPlay());
        yield return new WaitForSeconds(24f);
        StartCoroutine(SeasonPlay());
        yield return new WaitForSeconds(24f);
        seasonEnd = true;
    }
    IEnumerator SeasonPlay()
    {
        bossClick += 5;
        GameManager.instance.bossClick = bossClick;
        SpawnManager.SpawnBossWeather();
        yield return new WaitForSeconds(10f);
        

        for (int i = 1; i < 5; i++) // 1개월
        {
            yield return new WaitForSeconds(2f);
            SpawnManager.SpawnRandomWeather();
            GameManager.instance.crruentScore++;
        }
        month++;
        for (int i = 1; i < 5; i++) // 2개월
        {
            yield return new WaitForSeconds(2f);
            SpawnManager.SpawnRandomWeather();
            GameManager.instance.crruentScore++;
        }
        month++;
        for (int i = 1; i < 5; i++) // 3개월
        {
            yield return new WaitForSeconds(2f);
            SpawnManager.SpawnRandomWeather();
            GameManager.instance.crruentScore++;
        }
        month++;

        // 시즌이 끝날때 보스 소환 추가 여기다가 @@@@@@@
    }
}
