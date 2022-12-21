using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{   
  public Text BestScore ;
  public Text CurrentScore ;
 
    //public int bestScore;
    //public int crruentScore;

    void Start()
    {
      
      if(GameManager.instance.bestScore <=GameManager.instance.crruentScore) 
      {
        GameManager.instance.bestScore = GameManager.instance.crruentScore ; 
        PlayerPrefs.SetInt("BestScore",GameManager.instance.bestScore) ;
      }

      
      int LoadScore = PlayerPrefs.GetInt("BestScore") ; 
       BestScore.text = (LoadScore / 48).ToString() + "년 " + ((LoadScore%48) / 4).ToString() + "월 " + (LoadScore%4).ToString() + "주 "; 
       CurrentScore.text = (GameManager.instance.crruentScore / 48).ToString() + "년 " + ((GameManager.instance.crruentScore%48) / 4).ToString() + "월 " + (GameManager.instance.crruentScore%4).ToString() + "주 ";
    }
  

    // Update is called once per frame
    void Update()
    {
       
    }

}
