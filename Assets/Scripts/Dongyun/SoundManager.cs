using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// 사용법
public class SoundManager :MonoBehaviour 
{
   AudioSource[] _audioSources  = new AudioSource[(int)Sound.MaxCount] ;
   [SerializeField] Slider bgmVolumeSlider ;
    [SerializeField] Slider sfxVolumeSlider ;

   public enum Sound
   {
      Bgm,
      Effect,
    MaxCount,

   }

  void Start()
   {
        Init() ; 

   }

 void Update()
 {
   SeasonChangeSensor() ; 
 }
   
   public void Init()
   {
     GameObject root = GameObject.Find("Sound");
     if(root == null)
     {
        root = new GameObject{name = "@Sound"} ; 
        Object.DontDestroyOnLoad(root) ; 
        string[ ] soundNames  = System.Enum.GetNames(typeof(Sound)) ;  // Define의 사운드목록 추출
        for(int i =0 ; i < soundNames.Length-1; i ++ ) 
        {
           GameObject go =   new GameObject{name = soundNames[i]} ; 
           _audioSources[i] = go.AddComponent<AudioSource>() ; 
           
           go.transform.parent = root.transform ; 
        }

        _audioSources[(int)Sound.Bgm].loop = true ; 
       
     }
   }
public AudioClip bgm1 ;
public AudioClip bgm2 ;
public AudioClip bgm3 ;
public AudioClip bgm4 ;
public AudioClip bgm5 ;
    
 
  int SeasonValue;
     
   int tmp;
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
   if(GameManager. instance.season == -1)
   { 
     Play(bgm1,Sound.Bgm) ; 

   }
  
    if(GameManager. instance.season == 0)
   { 
     Play(bgm2,Sound.Bgm) ; 

   }
     if(GameManager. instance.season == 1)
   { 
     Play(bgm3,Sound.Bgm) ; 

   }
     if(GameManager. instance.season == 2)
   { 
     Play(bgm4,Sound.Bgm) ; 

   
     if(GameManager. instance.season == 3)
   { 
     Play(bgm5,Sound.Bgm) ; 

   }}
}



   public void Play(  AudioClip audioClip,Sound type= Sound.Effect,float pitch = 1.0f)  // 오디오 클립을 퍼블릭으로 받는 버전
   {

       if(audioClip == null) return ; 
       if(type == Sound.Bgm)
       {
    
             if(audioClip == null)
             {
                Debug.Log("AudioClip missing!") ;
                return ;
             }
             AudioSource audioSource = _audioSources[(int)Sound.Bgm] ; 
             if(audioSource.isPlaying) audioSource.Stop() ; //만약 다른비지엠이 재생중이라면 정지
            audioSource.pitch = pitch ; 
            audioSource.clip = audioClip ; 
            //CurBgm.clip = audioSource.clip  ; 
            audioSource.Play() ; 


       }



       
       else
       {
           
             if(audioClip == null)
             {
                Debug.Log("AudioClip missing!") ;
                return ;
             }
            AudioSource audioSource = _audioSources[(int)Sound.Effect] ; 
            audioSource.pitch = pitch ; 
           // CurSfx.clip = audioSource.clip ; 
            audioSource.PlayOneShot(audioClip) ; 
            
       }
   }

   public void SetBgmVolume()
   {
       AudioSource obj1 =   _audioSources[(int)Sound.Bgm] ;
       obj1.volume = bgmVolumeSlider.value ;
   }

   public void SetSfxVolume()
   {
          AudioSource obj1 =   _audioSources[(int)Sound.Effect] ;
          obj1.volume =  sfxVolumeSlider.value ;
   }
}
