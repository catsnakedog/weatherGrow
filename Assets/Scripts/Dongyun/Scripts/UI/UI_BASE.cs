using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_BASE : MonoBehaviour
{
 
   
     //SoundManager _sound = new SoundManager() ; 
     // public AudioClip bgm ; 
    void Start()
    {
       
       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
      
    public void ButtonSetting() // 설정팝업창 생성
    {   
        //GameObject root = GameObject.Find("SettingCanavas");
       GameObject obj1 = transform.Find("SettingCanvas").gameObject;
       obj1.SetActive(true);
    }
  
    public void ButtonClose()  // 설정 팝업 닫기
    { 
       GameObject obj1 = GameObject.Find("Canvas");
       GameObject obj2 = obj1.transform.Find("SettingCanvas").gameObject;
       obj2.SetActive(false);
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
 