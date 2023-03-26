using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsCast : MonoBehaviour
{
    public Text _text ;
    string  newsContent = "                                                                      (종합) 대기 매우 건조, 화재 유의, 낮과 밤의 기온차 큼 (오늘) 전국 대체로 맑음 (내일) 전국 가끔 구름많음 (모레) 중부지방 가끔 구름많음, 남부지방과 제주도 대체로 흐림, 제주도 가끔 비 (종합) 대기 매우 건조, 화재 유의, 낮과 밤의 기온차 큼, 모레까지 서해중부해상 바다 안개 유의 (오늘) 대체로 맑음 (내일~모레) 가끔 구름많음 (종합) 대기 매우 건조, 산불 등 화재 유의, 경남내륙 낮과 밤의 기온차 매우 큼 (오늘~내일) 대체로 맑음 (모레) 흐림 (종합) 대기 매우 건조, 산불 등 화재 주의. 낮과 밤의 기온차 큼 (오늘) 대체로 맑음 (내일) 가끔 구름많음 (모레) 대체로 맑다가 오전부터 차차 흐려짐 (종합) 대기 매우 건조, 화재 유의, 낮과 밤의 기온차 큼 (오늘~내일) 대체로 맑다가 내일 밤부터 구름많아짐 (모레) 대체로 흐림";
    public GameObject spawnpos ;
    public GameObject removepos ;

    public bool arrive = false ;
    public bool WriteRunning = true ; 

 

   
    IEnumerator stopcor ;
    void Start()
    {   
        this.transform.GetComponent<Text>().text  = newsContent ;
        stopcor = NewsRemove() ;
         
         StartCoroutine(NewsRemove()) ;
    }

    // Update is called once per frame
    void Update()
    {
       
       
        
    }

 
        IEnumerator NewsRemove()
    {
       while(true)
       {
           char temp = _text.text[0];
             string tmp = _text.text.Substring(1, this.transform.GetComponent<Text>().text.Length -1) ;
           _text.text =  tmp+temp ;
           yield return new WaitForSeconds(0.15f) ;
       } 
          
             
        
       
    }
}
