using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class save : MonoBehaviour
{
    public List<Sprite> images = new List<Sprite>();
    public List<GameObject> panels = new List<GameObject>();
    public List<Sprite> BG = new List<Sprite>();
    public GameObject panel;
    public GameObject backgroud;

    int cnt = 0;
    public float time;
    public bool ImageChange;
    public int savedScore = 0;
      
    UI_BASE _ui = new UI_BASE(); 
   

    void Start()
    {
        panel.GetComponent<Image>().sprite = images[cnt];
        time = 0f;
        cnt++;
        ImageChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1f) ImageChange = true;
    }
    void LateUpdate()
    {
       int load = PlayerPrefs.GetInt("skip") ; 
       if(load == 1)
       {
            UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene") ; 
       }
    }
    public void ImageC()
    {
        if (ImageChange)
        {
            if(cnt >= 10 && cnt < 28)
            {
                panels[cnt - 10].SetActive(true);
                if(cnt != 10)
                {
                    panels[cnt - 11].SetActive(false);
                }
            }
            if(cnt == 16) backgroud.GetComponent<Image>().sprite = BG[0];
            if(cnt == 20) backgroud.GetComponent<Image>().sprite = BG[1];
            if(cnt == 22) backgroud.GetComponent<Image>().sprite = BG[2];
            if(cnt == 24) backgroud.GetComponent<Image>().sprite = BG[3];
            if(cnt == 28)
            {
                SceneManager.LoadScene("StartScene");
            }
            panel.GetComponent<Image>().sprite = images[cnt];
            time = 0f;
            cnt++;
            ImageChange = false;
        }
    }
}