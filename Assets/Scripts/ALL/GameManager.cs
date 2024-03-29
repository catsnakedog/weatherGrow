using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;
    SoundManager _sound =  new SoundManager();
    ResourceManager _resource = new ResourceManager();
     public static SoundManager Sound { get { return instance._sound; } }
     
    public static ResourceManager Resource { get { return instance._resource; } }
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
        _sound.Init() ;

    }


    #region 설정 변수
    public static bool GameIsPaused = false; //게임 일시정지 변수
    #endregion

    #region 인게임 변수
    public List<GameObject> weatherList = new List<GameObject> { };
    public List<int> nowState = new List<int> { }; //현재 입력된 정답
    public List<int> weatherState = new List<int> { };
    public List<int> select = new List<int> { };
    public List<int> buttonNumber = new List<int> {0, 0, 0, 0};
    public int season; // 계절 봄/여름/가을/겨울 0/1/2/3
    public int hp;
    public int bossClick;
    public bool nowBoss;
    public float speed;
    public int bestScore;
    public int crruentScore; // n년 n개월 n주 이런식으로 점수가 저장됨 crruentScore에는 n주 형식으로 데이터가 들어감 스코어 표시할때 n주 기준으로 형태 바꿔서 나타내기
    public bool hurt1;
    public bool hurt2;
    public int TCount;

    #endregion

    #region 인게임 2
    public Queue<GameObject> q = new Queue<GameObject>();
    public GameObject boss;
    public bool gameState = false;

    public Action<Button> clickedBtn;

    public void ClickedBtn(Button button)
    {
        clickedBtn?.Invoke(button);
    }

    #endregion
}

