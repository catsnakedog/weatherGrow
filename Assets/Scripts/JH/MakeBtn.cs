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
            btn2.onClick.AddListener(CheckAns2);
            btn3.onClick.AddListener(CheckAns3);
            btn4.onClick.AddListener(CheckAns4);
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
            for(int i = 0; i<3; i++)
            {
                if(n.weather[i] == 1)
                {
                    n.weather.RemoveAt(i);
                    btn1.onClick.RemoveListener(CheckAns1);
                    break;
                }
            }
        }
        else if (!n.weather.Contains(1)) GameManager.instance.hp--;
        else if (n.weather == null) return;
    }
    private void CheckAns2()
    {
        n = GameManager.instance.q.Peek().GetComponent<WeatherAndBoss>();
        if (n.weather.Contains(2))
        {
            for (int i = 0; i < 3; i++)
            {
                if (n.weather[i] == 2)
                {
                    n.weather.RemoveAt(i);
                    btn1.onClick.RemoveListener(CheckAns2);
                    break;
                }
            }
        }
        else if (!n.weather.Contains(2)) GameManager.instance.hp--;
        else if (n.weather == null) return;
    }
    private void CheckAns3()
    {
        n = GameManager.instance.q.Peek().GetComponent<WeatherAndBoss>();
        if (n.weather.Contains(3))
        {
            for (int i = 0; i < 3; i++)
            {
                if (n.weather[i] == 3)
                {
                    n.weather.RemoveAt(i);
                    btn1.onClick.RemoveListener(CheckAns3);
                    break;
                }
            }
        }
        else if (!n.weather.Contains(3)) GameManager.instance.hp--;
        else if (n.weather == null) return;
    }
    private void CheckAns4()
    {
        n = GameManager.instance.q.Peek().GetComponent<WeatherAndBoss>();
        if (n.weather.Contains(4))
        {
            for (int i = 0; i < 3; i++)
            {
                if (n.weather[i] == 4)
                {
                    n.weather.RemoveAt(i);
                    btn1.onClick.RemoveListener(CheckAns4);
                    break;
                }
            }
        }
        else if (!n.weather.Contains(4)) GameManager.instance.hp--;
        else if (n.weather == null) return;
    }


}