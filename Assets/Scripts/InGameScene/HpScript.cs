using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HpScript : MonoBehaviour
{
    private int Maxhp = 3;
    public GameObject Gameover;
    public Text crruentScoretext;
    public Text bestScoretext;
    public Text tipText;
    List<string> tips = new List<string>() {
    "날씨는 날씨 버튼 3개를 조합하여 만들 수 있습니다",
    "날씨 요정의 키는 17cm입니다",
    "계절이 지날때마다 속도가 점점 빨라집니다",
    "개발자의 최고 기록은 4년 1개월입니다",
    "날씨를 잘 보면 어떤 버튼을 클릭해야하는지 알 수 있습니다",
    "보스는 매번 계절이 끝날때 나옵니다",
    "튜토리얼은 시작화면에서 다시 볼 수 있습니다",
    "T동 4층 열람실은 24시간 오픈입니다",
    "설정창에 살고있는 요정은 누군가 자신을 건드리는 것을 싫어합니다"
    };

    private string key = "BestScore" ;

    [SerializeField] private GameObject gameoverPanel;
    bool check;

    void Start()
    {
        GameManager.instance.hp = Maxhp;
        check = false;
   
    }

    void Update()
    {
        if (GameManager.instance.hp > 0)
        {

        }
        else
        {
            if (check) return;
            check = true;
            StartCoroutine(gameEnd());
        }
    }

    IEnumerator gameEnd()
    {
        GameManager.Sound.Play("BGM/GameBgm_Score", Define.Sound.Bgm);
        tipText.text = "tip: " + tips[Random.Range(0, tips.Count)];
        GameManager.instance.q.Clear();
        Time.timeScale = 0;
          if(GameManager.instance.bestScore <=GameManager.instance.crruentScore) 
      {
            GameManager.instance.bestScore = GameManager.instance.crruentScore ;
        PlayerPrefs.SetInt(key,GameManager.instance.bestScore) ;
      }

        yield return new WaitForSecondsRealtime(1f);

        gameoverPanel.SetActive(true);
        crruentScoretext.text = (GameManager.instance.crruentScore / 48).ToString() + "년 " + ((GameManager.instance.crruentScore % 48) / 4).ToString() + "개월 " + (GameManager.instance.crruentScore % 4).ToString() + "주의\n" + "날씨를 만들었어!";
        bestScoretext.text = (GameManager.instance.bestScore / 48).ToString() + "년 " + ((GameManager.instance.bestScore % 48) / 4).ToString() + "개월 " + (GameManager.instance.bestScore % 4).ToString() + "주 ";
    }
}
