using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_BASE : MonoBehaviour
{
    public GameObject Setting ; 
     static int SettingCount  = 1 ; 
     SoundManager _sound = new SoundManager() ; 
     public AudioClip bgm ; 
    void Start()
    {
       _sound.Init() ; 
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void ButtonSetting() // 설정팝업창 생성
    {   
         if(SettingCount == 0) return ; 
          Instantiate(Setting) ;
          SettingCount =0;
    }

    public void ButtonClose()  // 설정 팝업 닫기
    {

          Destroy(gameObject) ; 
          SettingCount = 1 ;
    }
      
    public void MenuSceneChange() // 메뉴로 돌아가는 함수
    {
        SceneManager.LoadScene("StartScene") ; 
    }
    public void GameSceneChange()  // 인게임으로 돌아가는함수
    {
        SceneManager.LoadScene(  "InGame"    ) ;
    }

    public void GameQuit()  // 게임종료 함수
    {
        Application.Quit() ; 
    }

}
 