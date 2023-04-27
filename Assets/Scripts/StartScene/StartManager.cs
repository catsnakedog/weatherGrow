using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartManager : MonoBehaviour
{
    [SerializeField] private Image HowToPlayImage;
    [SerializeField] private GameObject Left;
    [SerializeField] private GameObject Right;
    [SerializeField] private GameObject gameEnd;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject credit;
    [SerializeField] private List<Sprite> ImageList = new List<Sprite>();

    [SerializeField] private int ImageCount;

    void Start()
    {
        ImageCount = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (credit.activeSelf == true) credit.SetActive(false);
            else if (setting.activeSelf == true) setting.SetActive(false);
            else if (gameEnd.activeSelf == true) Application.Quit();
            else gameEnd.SetActive(true);
        }
    }
    public void GameEnd()
    {
        Application.Quit();
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
}
