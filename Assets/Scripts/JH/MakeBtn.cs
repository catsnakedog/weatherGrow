using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeBtn : MonoBehaviour
{
    //시계 방향으로 버튼 할당
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;

    private WeatherAndBoss n;

    //각 버튼에 해당하는 날씨 1234 1234 1245 1634 해/비/구름/바람/안개/눈
    private int[] btnFunc1 = new int[4];

    //계절에 따른 버튼 할당 매서드
    public void Update()
    {
        if (GameManager.instance.season == 0) //1234
        {
            btn1.onClick.AddListener(CheckAns1);
        }
        else if (GameManager.instance.season == 1)
        {
            btnFunc1[0] = 1;
            btnFunc1[1] = 2;
            btnFunc1[2] = 3;
            btnFunc1[3] = 4;
        }
        else if (GameManager.instance.season == 2)
        {
            btnFunc1[0] = 1;
            btnFunc1[1] = 2;
            btnFunc1[2] = 4;
            btnFunc1[3] = 5;
        }
        else if (GameManager.instance.season == 3)
        {
            btnFunc1[0] = 1;
            btnFunc1[1] = 6;
            btnFunc1[2] = 3;
            btnFunc1[3] = 4;
        }
        else
        {
            return;
        }
    }

    private void CheckAns1()
    {
        n = GameManager.instance.q.Peek().GetComponent<WeatherAndBoss>();
        if (n.weather.Contains(1))
        {
            n.weather.Remove(1);
        }
        else if (!n.weather.Contains(1)) GameManager.instance.hp--;
        else if (n.weather == null) return;
    }
    private int CheckAns2()
    {
        return btnFunc1[1];
    }
    private int CheckAns3()
    {
        return btnFunc1[2];
    }
    private int CheckAns4()
    {
        return btnFunc1[3];
    }


}