using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class save : MonoBehaviour
{
     public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;

    public float time;
    public bool ImageChange;
    // Start is called before the first frame update
    public int savedScore = 0  ;
      
    UI_BASE _ui = new UI_BASE() ; 
   

    void Start()
    { 
        time = 0f;
        ImageChange = false;
       
       
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 2f)
        {
            ImageChange = true;
        }
        if(Image3.activeSelf==false)
        {
             savedScore = 1 ;
             Debug.Log("save 스코어 1"); 
              PlayerPrefs.SetInt("skip",savedScore) ; 
               _ui.MenuSceneChange() ; 
        }
    }
    void LateUpdate()
    {
       int load = PlayerPrefs.GetInt("skip") ; 
       if(load == 1)
       {
            Debug.Log("씬이동") ; 
            UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene") ; 
       }
    }
    public void ImageC1()
    {
        if (ImageChange)
        {
            Image1.SetActive(false);
            time = 0f;
            ImageChange = false;
        }
    }
    public void ImageC2()
    {
        if (ImageChange)
        {
            Image2.SetActive(false);
            time = 0f;
            ImageChange = false;
        }
    }
    public void ImageC3()
    {
        if (ImageChange)
        {
            Image3.SetActive(false);
            time = 0f;
            ImageChange = false;
        }
    }
    
    
}