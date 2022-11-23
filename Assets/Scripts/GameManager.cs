using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float speed;
    public int season; // 계절 봄/여름/가을/겨울 0/1/2/3
    public int[] nowState = new int[3]; //현재 입력된 정답
    public int hp;


    #endregion

}

