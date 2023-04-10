using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class NewsSpawn : MonoBehaviour
{
    int random;
    public Text text;
    public GameObject news;
    public List<string> newsContent = new List<string> {
        "(종합) 대기 매우 건조, 화재 유의, 낮과 밤의 기온차 큼" ,
        "(오늘) 전국 대체로 맑음" ,
        "(내일) 전국 가끔 구름많음" ,
        "(모레) 중부지방 가끔 구름많음, 남부지방과 제주도 대체로 흐림, 제주도 가끔 비" ,
        "(종합) 대기 매우 건조, 화재 유의, 낮과 밤의 기온차 큼, 모레까지 서해중부해상 바다 안개 유의" ,
        "(오늘) 대체로 맑음" ,
        "(내일~모레) 가끔 구름많음" ,
        "(종합) 대기 매우 건조, 산불 등 화재 유의, 경남내륙 낮과 밤의 기온차 매우 큼" ,
        "(오늘~내일) 대체로 맑음" ,
        "(모레) 흐림" ,
        "(종합) 대기 매우 건조, 산불 등 화재 주의. 낮과 밤의 기온차 큼" ,
        "(오늘) 대체로 맑음" ,
        "(내일) 가끔 구름많음" ,
        "(모레) 대체로 맑다가 오전부터 차차 흐려짐" ,
        "(종합) 대기 매우 건조, 화재 유의, 낮과 밤의 기온차 큼" ,
        "(오늘~내일) 대체로 맑다가 내일 밤부터 구름많아짐" ,
        "(모레) 대체로 흐림" };

    void Start()
    {
        random = Random.Range(0, newsContent.Count);
        text.text = newsContent[random];
    }
    void Update()
    {
        news.transform.Translate(Vector3.left * GameManager.instance.speed * Time.deltaTime);
        Debug.Log(news.transform.position.y);
        if (news.transform.position.x < -7.7f)
        {
            NewsSetting();
        }
    }

    void NewsSetting()
    {
        news.transform.position = new Vector3(7.7f, 1.125f);
        random = Random.Range(0, newsContent.Count);
        text.text = newsContent[random];
    }
}
