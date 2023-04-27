using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UI_BASE : MonoBehaviour
{
  [SerializeField] Slider bgmVolumeSlider ;
  
  public GameObject SettingCanvas ;
  public GameObject Credit ;
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
       GameManager.Sound.Play("SFX/1_ButtonClick") ;
       SettingCanvas.SetActive(true);
    }

     public void CreditSetting() // 설정팝업창 생성
    {   
       GameManager.Sound.Play("SFX/1_ButtonClick") ;
       if(Credit.activeSelf ) Credit.SetActive(false);
       else Credit.SetActive(true);
    
    }
  
    public void ButtonClose()  // 설정 팝업 닫기
    { 
       GameManager.Sound.Play("SFX/1_ButtonClick") ;
       SettingCanvas.SetActive(false);
    }
      
    public void MenuSceneChange() // 메뉴로 돌아가는 함수
    {  
      GameManager.Sound.Play("SFX/2_ButtonClick") ;
        SceneManager.LoadScene("StartScene") ; 
    }
    public void GameSceneChange()  // 인게임으로 돌아가는함수
    {  GameManager.Sound.Play("SFX/2_ButtonClick") ;
        SceneManager.LoadScene(  "InGame"    ) ;
    }

    public void GameQuit()  // 게임종료 함수
    {  GameManager.Sound.Play("SFX/2_ButtonClick") ;
        Application.Quit() ; 
    }
    public void btnclicksound()
    {
      GameManager.Sound.Play("SFX/2_ButtonClick") ;
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