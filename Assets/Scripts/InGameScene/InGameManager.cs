using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    SpawnManager SpawnManager;
    UI_BASE UI_BASE;
    [SerializeField] Animator AN;

    int tempNum;

    [SerializeField] private GameObject BGObject;
    [SerializeField] private GameObject bossHP;
    [SerializeField] private GameObject gameEnd;
    [SerializeField] private GameObject waitText;
    [SerializeField] private RectTransform bossNews;
    [SerializeField] private Text bestScoreText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text seasonText;
    [SerializeField] private Text bossNewsText;
    [SerializeField] private int year;
    [SerializeField] private float speed;
    [SerializeField] private float createDelay;
    [SerializeField] private float weatherWrongDelay;
    [SerializeField] private int month;
    [SerializeField] private int bossClick;
    [SerializeField] private int season;
    [SerializeField] private bool seasonEnd;
    [SerializeField] public bool bossOn;
    [SerializeField] private bool changeOn;
    [SerializeField] private bool wrongChangeOn;
    [SerializeField] private string temp;
    [SerializeField] private int tempHPCheck;
    [SerializeField] private Sprite defaultImg;
    private WeatherAndBoss n;

    [SerializeField] private List<Sprite> BG = new List<Sprite>();
    [SerializeField] private List<Sprite> BossSelect = new List<Sprite>();
    [SerializeField] private List<GameObject> heartsFull = new List<GameObject>();
    [SerializeField] private List<GameObject> heartsEmpty = new List<GameObject>();
    [SerializeField] private List<GameObject> select = new List<GameObject>();
    [SerializeField] private List<GameObject> selectS = new List<GameObject>();
    [SerializeField] private List<GameObject> selectS2 = new List<GameObject>();
    [SerializeField] private List<GameObject> button = new List<GameObject>();

    void Awake()
    {
        AN.SetBool("Damage", false);
    }

    void Start()
    {
        GameManager.instance.select.Clear();
        GameManager.instance.bestScore = PlayerPrefs.GetInt("BestScore");
        UI_BASE = GameObject.Find("Canvas").GetComponent<UI_BASE>();
        SpawnManager = GameObject.FindWithTag("InGame").GetComponent<SpawnManager>();
        speed = 0f;
        changeOn = false;
        wrongChangeOn = false;
        GameManager.instance.speed = 1 + speed * 0.25f;
        year = 1;
        month = 3;
        bossClick = 10;
        Time.timeScale = 1f;
        tempHPCheck = GameManager.instance.hp; 
        GameManager.instance.crruentScore = year*48 + month*4;
        seasonEnd = false;
        GameManager.instance.bossClick = bossClick;
        InGame();
    }

    void Update()
    {
        if(!wrongChangeOn)
        {
            selectS2[0].SetActive(false);
            selectS2[1].SetActive(false);
            selectS2[2].SetActive(false);
        }
        if(bossOn)
        {
            bossNewsText.transform.Translate(Vector3.left * GameManager.instance.speed * 0.7f * Time.deltaTime);
            if (bossNews.anchoredPosition.x < -540 - bossNews.rect.width / 2)
            {
                bossNews.anchoredPosition = new Vector3(540 + bossNews.rect.width / 2, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && (GameManager.instance.hp != 0) && (waitText.activeSelf == false))
        {
            if(Time.timeScale != 0f)
            {
                Time.timeScale = 0f;
                GameManager.GameIsPaused = true;
            }
            if (UI_BASE.SettingCanvas.activeSelf == true)
            {
                if (gameEnd.activeSelf == true) Application.Quit();
                else gameEnd.SetActive(true);
            }
            else UI_BASE.SettingCanvas.SetActive(true);
        }

        if (GameManager.instance.select.Count >= 3) GameManager.Sound.Play("SFX/5_WeatherRight");
        for (int i=0; i < GameManager.instance.select.Count; i++)
        {
            for(int j=0; j<4; j++)
            {
                if (GameManager.instance.select[i] == GameManager.instance.buttonNumber[j])
                    tempNum = j;
            }
            select[i].GetComponent<Image>().sprite = button[tempNum].GetComponent<Image>().sprite;
        }
        int tempCnt = 2;
        if (!changeOn && !bossOn)
        {
            if (GameManager.instance.select.Count == 3)
            {
                changeOn = true;
                StartCoroutine("WeatherCreateImg");
            }
            else
            {
                for (int j = GameManager.instance.select.Count; j < 3; j++)
                {
                    select[tempCnt].GetComponent<Image>().sprite = defaultImg;
                    tempCnt--;
                }
            }
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

        if (tempHPCheck != GameManager.instance.hp)
        {
            AN.SetBool("Damage", true);
        }
        else AN.SetBool("Damage", false);

        tempHPCheck = GameManager.instance.hp;
        switch (season)
        {
            case 0:
                seasonText.text = ": 봄";
                BGObject.GetComponent<Image>().sprite = BG[0];
                return;
            case 1:
                seasonText.text = ": 여름";
                BGObject.GetComponent<Image>().sprite = BG[1];
                return;
            case 2:
                seasonText.text = ": 가을";
                BGObject.GetComponent<Image>().sprite = BG[2];
                return;
            case 3:
                seasonText.text = ": 겨울";
                BGObject.GetComponent<Image>().sprite = BG[3];
                return;
            default:
                seasonText.text = ": 오류";
                return;
        }
    }

    private void InGame()
    {
        StartCoroutine(YearPlay());
    }

    public void WeatherWrong()
    {
        if (!wrongChangeOn) StartCoroutine("WeatherWrongImg");
    }
    IEnumerator WeatherCreateImg()
    {
        selectS[0].SetActive(true);
        selectS[1].SetActive(true);
        selectS[2].SetActive(true);
        yield return new WaitForSeconds(createDelay);
        select[0].GetComponent<Image>().sprite = defaultImg;
        select[1].GetComponent<Image>().sprite = defaultImg;
        select[2].GetComponent<Image>().sprite = defaultImg;
        selectS[0].SetActive(false);
        selectS[1].SetActive(false);
        selectS[2].SetActive(false);
        changeOn = false;
    }

    IEnumerator WeatherWrongImg()
    {
        wrongChangeOn = true;
        selectS2[GameManager.instance.select.Count].SetActive(true);
        yield return new WaitForSeconds(weatherWrongDelay);
        selectS2[GameManager.instance.select.Count].SetActive(false);
        wrongChangeOn = false;
    }

    IEnumerator YearPlay()
    {
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
        bossOn = true;
        select[0].GetComponent<Image>().sprite = BossSelect[season];
        select[1].GetComponent<Image>().sprite = BossSelect[season];
        select[2].GetComponent<Image>().sprite = BossSelect[season];
        bossNews.anchoredPosition = new Vector3(540 + bossNews.rect.width / 2, 0);
        SpawnManager.SpawnBossWeather();
        bossHP.SetActive(true);
        yield return new WaitForSeconds(8f);
        select[0].GetComponent<Image>().sprite = defaultImg;
        select[1].GetComponent<Image>().sprite = defaultImg;
        select[2].GetComponent<Image>().sprite = defaultImg;
        if (GameManager.instance.TCount > - 50) GameManager.instance.TCount--;
        PlayerPrefs.SetInt("TouchCount", GameManager.instance.TCount);
        bossOn = false;
        month++;
    }

    public void GameEnd()
    {
        Application.Quit();
    }
    
    public void ReStart()
    {
        GameManager.instance.select.Clear();
        SceneManager.LoadScene("InGame");
    }

    public void GoMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScene");
    }
}
