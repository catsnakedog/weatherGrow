using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class save : MonoBehaviour
{
    public List<Sprite> images = new List<Sprite>();
    public GameObject panel;

    int cnt = 0;
    public float time;
    public bool ImageChange;
    public int savedScore = 0;
      
    UI_BASE _ui = new UI_BASE(); 
   

    void Start()
    {
        PlayerPrefs.SetFloat("bgmvolume", 0.5f);
        PlayerPrefs.SetFloat("sfxvolume", 0.5f);
        panel.GetComponent<Image>().sprite = images[cnt];
        time = 0f;
        cnt++;
        ImageChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        time += Time.deltaTime;
        if (time > 1f) ImageChange = true;
    }
    void Awake()
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
            if(cnt == 23)
            {
                int load = 1;
                PlayerPrefs.SetInt("skip", load);
                SceneManager.LoadScene("StartScene");
            }
            panel.GetComponent<Image>().sprite = images[cnt];
            time = 0f;
            cnt++;
            ImageChange = false;
        }
    }
}