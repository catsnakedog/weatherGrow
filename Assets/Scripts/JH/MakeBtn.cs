using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeBtn : MonoBehaviour
{
    //시계 방향으로 버튼 할당
    //public Button btn1;
    //public Button btn2;
    //public Button btn3;
    //public Button btn4;

    private WeatherAndBoss n;
    private Boss bossn;

    //각 버튼에 해당하는 날씨 1234 1234 1245 1634 해/비/구름/바람/안개/눈
    //private int[] btnFunc1 = new int[4];

    //계절에 따른 버튼 할당 매서드
    /*  public void Update()
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
    */

    //버튼이 눌렸을 때 실행될 함수
    public void Onclickbtn1()
    {
        if (GameManager.instance.nowBoss)
        {
            CheckAnsBoss();
        }
        else
        {
            if (GameManager.instance.season == 0) //1234
            {
                CheckAns1();
            }
            else if (GameManager.instance.season == 1)
            {
                CheckAns1();
            }
            else if (GameManager.instance.season == 2)
            {
                CheckAns1();
            }
            else if (GameManager.instance.season == 3)
            {
                CheckAns1();
            }
            else
            {
                return;
            }

        }
    }
    public void Onclickbtn2()
    {
        if (GameManager.instance.nowBoss)
        {
            CheckAnsBoss();
        }
        else
        {
            if (GameManager.instance.season == 0) //1234
            {
                CheckAns2();
            }
            else if (GameManager.instance.season == 1)
            {
                CheckAns2();
            }
            else if (GameManager.instance.season == 2)
            {
                CheckAns2();
            }
            else if (GameManager.instance.season == 3)
            {
                CheckAns6();
            }
            else
            {
                return;
            }
        }

    }
    public void Onclickbtn3()
    {
        if (GameManager.instance.nowBoss)
        {
            CheckAnsBoss();
        }
        else
        {
            if (GameManager.instance.season == 0) //1234
            {
                CheckAns3();
            }
            else if (GameManager.instance.season == 1)
            {
                CheckAns3();
            }
            else if (GameManager.instance.season == 2)
            {
                CheckAns4();
            }
            else if (GameManager.instance.season == 3)
            {
                CheckAns3();
            }
            else
            {
                return;
            }
        }

    }
    public void Onclickbtn4()
    {
        if (GameManager.instance.nowBoss)
        {
            CheckAnsBoss();
        }
        else
        {
            if (GameManager.instance.season == 0) //1234
            {
                CheckAns4();
            }
            else if (GameManager.instance.season == 1)
            {
                CheckAns4();
            }
            else if (GameManager.instance.season == 2)
            {
                CheckAns5();
            }
            else if (GameManager.instance.season == 3)
            {
                CheckAns4();
            }
            else
            {
                return;
            }
        }

    }

    private void CheckAns1()
    {
        if (GameManager.instance.q.Count != 0)
        {
            n = GameManager.instance.q.Peek().GetComponent<WeatherAndBoss>();
            if (n.weather.Contains(1))
            {
                n.weather.Remove(1);
            }
            else if (!n.weather.Contains(1)) GameManager.instance.hp--;
            else if (n.weather == null) return;
        }

    }
    private void CheckAns2() //Update문에서 프레임 문제로 한번 클릭도 2번으로 인식
    {
        if (GameManager.instance.q.Count != 0)
        {
            n = GameManager.instance.q.Peek().GetComponent<WeatherAndBoss>();
            if (n.weather.Contains(2))
            {
                n.weather.Remove(2);
                Debug.Log("클릭된 횟수");
            }
            else if (!n.weather.Contains(2)) GameManager.instance.hp--;
            else if (n.weather == null) return;
        }

    }
    private void CheckAns3()
    {
        if (GameManager.instance.q.Count != 0)
        {
            n = GameManager.instance.q.Peek().GetComponent<WeatherAndBoss>();
            if (n.weather.Contains(3))
            {
                n.weather.Remove(3);
            }
            else if (!n.weather.Contains(3)) GameManager.instance.hp--;
            else if (n.weather == null) return;
        }
    }
    private void CheckAns4()
    {
        if (GameManager.instance.q.Count != 0)
        {
            n = GameManager.instance.q.Peek().GetComponent<WeatherAndBoss>();
            if (n.weather.Contains(4))
            {
                n.weather.Remove(4);
            }
            else if (!n.weather.Contains(4)) GameManager.instance.hp--;
            else if (n.weather == null) return;
        }
    }

    private void CheckAns5()
    {
        if (GameManager.instance.q.Count != 0)
        {
            n = GameManager.instance.q.Peek().GetComponent<WeatherAndBoss>();
            if (n.weather.Contains(5))
            {
                n.weather.Remove(5);
            }
            else if (!n.weather.Contains(5)) GameManager.instance.hp--;
            else if (n.weather == null) return;
        }
    }
    private void CheckAns6()
    {
        if (GameManager.instance.q.Count != 0)
        {
            n = GameManager.instance.q.Peek().GetComponent<WeatherAndBoss>();
            if (n.weather.Contains(6))
            {
                n.weather.Remove(6);
            }
            else if (!n.weather.Contains(6)) GameManager.instance.hp--;
            else if (n.weather == null) return;
        }
    }

    private void CheckAnsBoss()
    {
        bossn = GameManager.instance.boss.GetComponent<Boss>();
        bossn.bossHp--;
    }
}