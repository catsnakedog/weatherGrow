using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summer : WeatherAndBoss
{
    [SerializeField] Sprite[] images;

    Define.Summer _type;

    public Define.Summer Type
    {
        get { return _type; }
    }

    protected override void Init()
    {
        int randomSummer = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Define.Summer)).Length); // 랜덤하게 타입 설정
        _type = (Define.Summer)(randomSummer);

        //i.sprite = 
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
            weather[0] = 2;
            weather[1] = 2;
            weather[2] = 3;

        }
        else if ((int)_type == 3)
        {
            weather[0] = 2;
            weather[1] = 3;
            weather[2] = 4;
        }
        else if ((int)_type == 4)
        {
            weather[0] = 1;
            weather[1] = 1;
            weather[2] = 1;
        }
        else if ((int)_type == 5)
        {
            weather[0] = 2;
            weather[1] = 2;
            weather[2] = 2;
        }
    }
}
