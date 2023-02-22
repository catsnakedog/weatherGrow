using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UI_BASE : MonoBehaviour
{
  [SerializeField] Slider bgmVolumeSlider ;
  
  
    [SerializeField] Slider sfxVolumeSlider ;
   
     //SoundManager _sound = new SoundManager() ; 
     // public AudioClip bgm ; 
    void Start()
    {
       bgmVolumeSlider.value = 0.5f ;
       sfxVolumeSlider.value = 0.5f ;

       
    }

    // Update is called once per frame
    void Update()
    {
        bgmVolumeSlider.value = PlayerPrefs.GetFloat("bgmvolume") ;
       sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxvolume") ;
    }
      
    public void ButtonSetting() // 설정팝업창 생성
    {   
        //GameObject root = GameObject.Find("SettingCanavas");
       GameObject obj1 = transform.Find("Setting").gameObject;
       obj1.SetActive(true);
    }
  
    public void ButtonClose()  // 설정 팝업 닫기
    { 
       GameObject obj2 = transform.Find("Setting").gameObject;
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
 
       public void SetBgmVolume()
   {   
       GameObject obj1 = GameObject.Find("@Sound") ; 
       GameObject obj2 = obj1.transform.GetChild(0).gameObject ;
       AudioSource obj3 = obj2.GetComponent<AudioSource>() ; 
       obj3.volume = bgmVolumeSlider.value ; 
        PlayerPrefs.SetFloat("bgmvolume",bgmVolumeSlider.value) ; 
   }
 

   public void SetSfxVolume()
   {
          GameObject obj1 = GameObject.Find("@Sound") ; 
       GameObject obj2 = obj1.transform.GetChild(1).gameObject ;
       AudioSource obj3 = obj2.GetComponent<AudioSource>() ; 
       obj3.volume = sfxVolumeSlider.value ; 
         PlayerPrefs.SetFloat("sfxvolume",sfxVolumeSlider.value) ; 
   }
}