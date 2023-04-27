using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winter : WeatherAndBoss
{
    [SerializeField] Sprite[] images;

    Define.Winter _type;
    public Define.Winter Type
    {
        get { return _type; }
    }

    protected override void Init()
    {
        int randomWinter = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Define.Winter)).Length); // 랜덤하게 타입 설정
        _type = (Define.Winter)(randomWinter);

        //해1 비2 구름3 바람4 안개5 눈6
        gameObject.GetComponent<SpriteRenderer>().sprite = images[(int)_type]; //이미지 갈아 끼우기
        if (_type == 0)
        {
            weather[0] = 1;
            weather[1] = 1;
            weather[2] = 4;
        }
        else if ((int)_type == 1)
        {
            weather[0] = 3;
            weather[1] = 3;
            weather[2] = 4;
        }
        else if ((int)_type == 2)
        {
            weather[0] = 3;
            weather[1] = 4;
            weather[2] = 4;

        }
        else if ((int)_type == 3)
        {
            weather[0] = 6;
            weather[1] = 6;
            weather[2] = 3;
        }
        else if ((int)_type == 4)
        {
            weather[0] = 6;
            weather[1] = 3;
            weather[2] = 4;
        }
        else if ((int)_type == 5)
        {
            weather[0] = 1;
            weather[1] = 6;
            weather[2] = 3;
        }
    }
}
