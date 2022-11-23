using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{   
  public Text BestScore ;
  public Text CurrentScore ;
 
int _BestScore = 0 ;
int _CurrentScore = 0 ; 

    void Start()
    {

       BestScore.text = $"{_BestScore}" ; 
        CurrentScore.text = $"{_CurrentScore}" ; 
     
    }
  

    // Update is called once per frame
    void Update()
    {
      
    }

}
