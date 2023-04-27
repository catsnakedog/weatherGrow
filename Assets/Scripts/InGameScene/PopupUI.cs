using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopupUI : MonoBehaviour
{
    public List<Sprite> Imgs = new List<Sprite>();

    public GameObject wait; // 대기시간 텍스트를 품고있는 부모 오브젝트
    public Image waitSeconds; // 대기시간 텍스트

    // 일시정지 버튼
    public void pauseBtn()
    {
        Time.timeScale = 0f;
        GameManager.GameIsPaused = true;
    }

    // 계속 버튼
    public void resumeBtn()
    {
        StartCoroutine(StartGame());
    }

    // 게임 재개 후 카운트 다운
    IEnumerator StartGame()
    {
        wait.SetActive(true);
        waitSeconds.sprite = Imgs[2];
        yield return new WaitForSecondsRealtime(1.0f);
        waitSeconds.sprite = Imgs[1];
        yield return new WaitForSecondsRealtime(1.0f);
        waitSeconds.sprite = Imgs[0];
        yield return new WaitForSecondsRealtime(1.0f);
        wait.SetActive(false);

        Time.timeScale = 1f;
    }
}
