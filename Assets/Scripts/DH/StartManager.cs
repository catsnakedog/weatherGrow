using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartManager : MonoBehaviour
{
    public Image HowToPlayImage;
    public GameObject Left;
    public GameObject Right;
    public List<Sprite> ImageList = new List<Sprite>();

    public int ImageCount;

    void Start()
    {
        ImageCount = 1;
    }
    public void GameEnd()
    {
        Application.Quit();
        Debug.Log("게임종료");
    }

    public void GameStart()
    {
        SceneManager.LoadScene("InGame");
    }
    public void HowToPlayImageChange()
    {
        HowToPlayImage.sprite = ImageList[ImageCount-1];
      GameManager.Sound.Play("SFX/2_ButtonClick") ;
        if(ImageCount == 1)
        {
            Left.SetActive(false);
        }
        else
        {
            Left.SetActive(true);
        }

        if (ImageCount == ImageList.Count)
        {
            Right.SetActive(false);
        }
        else
        {
            Right.SetActive(true);
        }
    }

    public void CountUp()
    {
        if(ImageList.Count > ImageCount)
        {
            ImageCount++;
        }
        HowToPlayImageChange();
    }
    public void CountDown()
    {
        if (ImageCount > 1)
        {
            ImageCount--;
        }
        HowToPlayImageChange();
    }

    public void Reset()
    {
        ImageCount = 1;
    }
}
