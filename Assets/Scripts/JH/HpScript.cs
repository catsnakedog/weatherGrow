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
        Debug.Log("dd");
        GameManager.instance.q.Clear();
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);
        gameoverPanel.SetActive(true);
        crruentScoretext.text = (GameManager.instance.crruentScore / 48).ToString() + "년 " + ((GameManager.instance.crruentScore % 48) / 4).ToString() + "개월 " + (GameManager.instance.crruentScore % 4).ToString() + "주의\n" + "날씨를 만들었어!";
        bestScoretext.text = (GameManager.instance.bestScore / 48).ToString() + "년 " + ((GameManager.instance.bestScore % 48) / 4).ToString() + "개월 " + (GameManager.instance.bestScore % 4).ToString() + "주 ";
    }
}
