using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spring : WeatherAndBoss
{
    [SerializeField] Sprite[] images;

    Define.Spring _type;
    public Define.Spring Type
    {
        get { return _type; }
    }

    protected override void Init()
    {
        int randomSpring = Random.Range(0, System.Enum.GetValues(typeof(Define.Spring)).Length); // 랜덤하게 타입 설정
        _type = (Define.Spring)(randomSpring);
        GetComponent<Image>().sprite = images[(int)_type]; //이미지 갈아 끼우기
        if (_type == 0)
        {
            weather[0] = 1;
            weather[1] = 1;
            weather[2] = 4;
        }
    }

    public override void Kill()
    {

        Destroy(gameObject);
        Destroy(this);
    }
}
