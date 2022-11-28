﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }

    }


    #region 설정 변수
    public static bool GameIsPaused = false; //게임 일시정지 변수
    #endregion

    #region 인게임 변수
    public List<GameObject> weatherList = new List<GameObject> { };
    public List<int> nowState = new List<int> { }; //현재 입력된 정답
    public List<int> weatherState = new List<int> { };
    public int season; // 계절 봄/여름/가을/겨울 0/1/2/3
    public int hp;


    #endregion

    #region 인게임 2
    public Queue<GameObject> q = new Queue<GameObject>();


    public Action<Button> clickedBtn;

    public void ClickedBtn(Button button)
    {
        clickedBtn?.Invoke(button);
    }

    #endregion
}

