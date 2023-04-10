﻿using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    SpawnManager SpawnManager;

    int tempNum;

    [SerializeField] private GameObject BGObject;
    [SerializeField] private GameObject bossHP;
    [SerializeField] private Text bossHpText;
    [SerializeField] private Text bestScoreText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text seasonText;
    [SerializeField] private Text tempText;
    [SerializeField] private int year;
    [SerializeField] private float speed;
    [SerializeField] private int month;
    [SerializeField] private int bossClick;
    [SerializeField] private int season;
    [SerializeField] private bool seasonEnd;
    [SerializeField] private string temp;
    private WeatherAndBoss n;

    [SerializeField] private List<Sprite> BG = new List<Sprite>();
    [SerializeField] private List<GameObject> heartsFull = new List<GameObject>();
    [SerializeField] private List<GameObject> heartsEmpty = new List<GameObject>();
    [SerializeField] private List<GameObject> select = new List<GameObject>();
    [SerializeField] private List<GameObject> button = new List<GameObject>();

    void Start()
    {
        GameManager.instance.bestScore = PlayerPrefs.GetInt("BestScore");
        SpawnManager = GameObject.FindWithTag("InGame").GetComponent<SpawnManager>();
        speed = 0f;
        year = 1;
        month = 3;
        bossClick = 10;
        Time.timeScale = 1f;
        GameManager.instance.crruentScore = year*48 + month*4;
        seasonEnd = false;
        GameManager.instance.bossClick = bossClick;
        InGame();
    }

    void Update()
    {
        if (GameManager.instance.select.Count >= 1) select[0].SetActive(true);
        else select[0].SetActive(false);
        if (GameManager.instance.select.Count >= 2) select[1].SetActive(true);
        else select[1].SetActive(false);
        if (GameManager.instance.select.Count >= 3) select[2].SetActive(true);
        else select[2].SetActive(false);
        for (int i=0; i < GameManager.instance.select.Count; i++)
        {
            for(int j=0; j<4; j++)
            {
                if (GameManager.instance.select[i] == GameManager.instance.buttonNumber[j])
                    tempNum = j;
            }
            select[i].GetComponent<Image>().sprite = button[tempNum].GetComponent<Image>().sprite;
        }


        if (GameManager.instance.boss == null)
        {
            bossHP.SetActive(false);
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
        scoreText.text = (GameManager.instance.crruentScore / 48).ToString() + "년 " + ((GameManager.instance.crruentScore%48) / 4).ToString() + "개월 " + (GameManager.instance.crruentScore%4).ToString() + "주 ";
        if (GameManager.instance.bestScore == 0)
        {
            bestScoreText.text = "아직없음!";
        }
        else bestScoreText.text = (GameManager.instance.bestScore / 48).ToString() + "년 " + ((GameManager.instance.bestScore % 48) / 4).ToString() + "개월 " + (GameManager.instance.bestScore % 4).ToString() + "주 ";


        if (seasonEnd)
        {
            StartCoroutine(YearPlay());
            seasonEnd = false;
        }

        if (GameManager.instance.hp < 3)
        {
            heartsFull[2].SetActive(false);
            heartsEmpty[2].SetActive(true);
        }
        if (GameManager.instance.hp < 2)
        {
            heartsFull[1].SetActive(false);
            heartsEmpty[1].SetActive(true);
        }
        if (GameManager.instance.hp < 1)
        {
            heartsFull[0].SetActive(false);
            heartsEmpty[0].SetActive(true);
        }

        switch (season)
        {
            case 0:
                seasonText.text = "봄";
                BGObject.GetComponent<Image>().sprite = BG[0];
                return;
            case 1:
                seasonText.text = "여름";
                BGObject.GetComponent<Image>().sprite = BG[1];
                return;
            case 2:
                seasonText.text = "가을";
                BGObject.GetComponent<Image>().sprite = BG[2];
                return;
            case 3:
                seasonText.text = "겨울";
                BGObject.GetComponent<Image>().sprite = BG[3];
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
        yield return new WaitForSeconds((3f - GameManager.instance.speed)*12 + 7f - GameManager.instance.speed + 8f);
        speed += 0.5f;
        GameManager.instance.speed = 1 + speed * 0.25f;
        StartCoroutine(SeasonPlay());
        yield return new WaitForSeconds((3f - GameManager.instance.speed) * 12 + 7f - GameManager.instance.speed + 8f);
        speed += 0.5f;
        GameManager.instance.speed = 1 + speed * 0.25f;
        StartCoroutine(SeasonPlay());
        yield return new WaitForSeconds((3f - GameManager.instance.speed) * 12 + 7f - GameManager.instance.speed + 8f);
        speed += 0.5f;
        GameManager.instance.speed = 1 + speed * 0.25f;
        StartCoroutine(SeasonPlay());
        yield return new WaitForSeconds((3f - GameManager.instance.speed)*12 + 7f - GameManager.instance.speed + 8f);
        speed += 0.5f;
        GameManager.instance.speed = 1 + speed * 0.25f;
        seasonEnd = true;
    }
    IEnumerator SeasonPlay()
    {
        bossClick += 5;
        GameManager.instance.bossClick = bossClick;

        for (int i = 1; i < 5; i++) // 1개월
        {
            yield return new WaitForSeconds(3f - GameManager.instance.speed);
            SpawnManager.SpawnRandomWeather();
            GameManager.instance.crruentScore++;
        }
        month++;
        for (int i = 1; i < 5; i++) // 2개월
        {
            yield return new WaitForSeconds(3f - GameManager.instance.speed);
            SpawnManager.SpawnRandomWeather();
            GameManager.instance.crruentScore++;
        }
        month++;
        for (int i = 1; i < 5; i++) // 3개월
        {
            yield return new WaitForSeconds(3f - GameManager.instance.speed);
            SpawnManager.SpawnRandomWeather();
            GameManager.instance.crruentScore++;
        }

        yield return new WaitForSeconds(7f - GameManager.instance.speed);
        // 시즌이 끝날때 보스 소환 추가 여기다가 @@@@@@@
        SpawnManager.SpawnBossWeather();
        bossHP.SetActive(true);
        yield return new WaitForSeconds(8f);
        month++;
    }

    public void GameEnd()
    {
        Application.Quit();
    }
    
    public void ReStart()
    {
        SceneManager.LoadScene("InGame");
    }

    public void GoMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
}
