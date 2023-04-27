using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : WeatherAndBoss
{
    [SerializeField] Sprite[] bossImages;
    [SerializeField] public int bossHp;
    [SerializeField] private Image HPPoint;


    Define.Boss _Bosstype;
    public Define.Boss Type
    {
        get { return _Bosstype; }
    }

    protected override void Init()
    {
        HPPoint = GameObject.FindGameObjectWithTag("HPPoint").GetComponent<Image>();
        HPPoint.fillAmount = (bossHp / GameManager.instance.bossClick);
        int bossIndex = GameManager.instance.season % 4;
        _Bosstype = (Define.Boss)(bossIndex);

        //i.sprite = 
        gameObject.GetComponent<SpriteRenderer>().sprite = bossImages[(int)_Bosstype]; //이미지 갈아 끼우기
        bossHp = GameManager.instance.bossClick;
    }

    public override void Kill()
    {
        Destroy(gameObject);
        Destroy(this);
    }

    protected override void Update()
    {
        HPPoint.fillAmount = ((float)bossHp / GameManager.instance.bossClick);
    }
}
