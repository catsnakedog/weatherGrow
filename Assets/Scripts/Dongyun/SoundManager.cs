﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 사용법
public class SoundManager 
{
   AudioSource[] _audioSources  = new AudioSource[(int)Sound.MaxCount] ;

   public enum Sound
   {
      Bgm,
      Effect,
    MaxCount,

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
            audioSource.PlayOneShot(audioClip) ; 
            
       }
   }

}