using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Sound.Play("BGM/GameBgm_Defalu",Define.Sound.Bgm) ;
    }

    // Update is called once per frame
    void Update()
    {
        SeasonChangeSensor() ;
    }

   public  int SeasonValue;
     
   public int tmp = -1;
    public void  SeasonChangeSensor()
{
     SeasonValue = GameManager.instance.season;
     if(SeasonValue!=tmp)
     {
         GameAudioPlay();
     }
  
   tmp = SeasonValue ; 
 
  
}
public void GameAudioPlay()
{   

  
    if(GameManager. instance.season == 0)
   {
     GameManager.Sound.Play("BGM/GameBgm_Spring",Define.Sound.Bgm) ;

   }
     if(GameManager. instance.season == 1)
   {
            GameManager.Sound.Play("BGM/GameBgm_Summer",Define.Sound.Bgm) ;

   }
        if (GameManager.instance.season == 2)
        {
            GameManager.Sound.Play("BGM/GameBgm_Fall", Define.Sound.Bgm);
        }
   
     if(GameManager. instance.season == 3)
   {
                GameManager.Sound.Play("BGM/GameBgm_Winter",Define.Sound.Bgm) ;

   }
}

}
