using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : WeatherAndBoss
{
    [SerializeField] Sprite[] images;

    Define.Fall _type;
    public Define.Fall Type
    {
        get { return _type; }
    }
    //해 비 구름 바람 안개 눈
    protected override void Init()
    {
        int randomFall = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Define.Fall)).Length); // 랜덤하게 타입 설정
        _type = (Define.Fall)(randomFall);


        gameObject.GetComponent<SpriteRenderer>().sprite = images[(int)_type]; //이미지 갈아 끼우기
        if (_type == 0)
        {
            weather[0] = 1;
            weather[1] = 1;
            weather[2] = 4;
        }
        else if ((int)_type == 1)
        {
            weather[0] = 5;
            weather[1] = 5;
            weather[2] = 4;
        }
        else if ((int)_type == 2)
        {
            weather[0] = 2;
            weather[1] = 2;
            weather[2] = 5;

        }
        else if ((int)_type == 3)
        {
            weather[0] = 2;
            weather[1] = 2;
            weather[2] = 4;
        }
        else if ((int)_type == 4)
        {
            weather[0] = 1;
            weather[1] = 5;
            weather[2] = 5;
        }
        else if ((int)_type == 5)
        {
            weather[0] = 5;
            weather[1] = 4;
            weather[2] = 4;
        }
    }
}
