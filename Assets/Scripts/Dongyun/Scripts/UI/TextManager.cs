using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{   
  public Text BestScore ;
  public Text CurrentScore ;
  private string key = "BestScore" ;
 
    
    int _crruentscore =  GameManager.instance.crruentScore;

    void Start()
    { int _bestscore = PlayerPrefs.GetInt(key)  ; 
      
      if(_bestscore <=_crruentscore) 
      {
       _bestscore = _crruentscore ; 
        PlayerPrefs.SetInt(key,_bestscore) ;
      }

      
      int LoadScore = PlayerPrefs.GetInt(key) ; 
       BestScore.text = (LoadScore / 48).ToString() + "년 " + ((LoadScore%48) / 4).ToString() + "월 " + (LoadScore%4).ToString() + "주 "; 
       CurrentScore.text = (_crruentscore / 48).ToString() + "년 " + ((_crruentscore%48) / 4).ToString() + "월 " + (_crruentscore%4).ToString() + "주 ";
    }
  

    // Update is called once per frame
    void Update()
    {
       
    }

}
