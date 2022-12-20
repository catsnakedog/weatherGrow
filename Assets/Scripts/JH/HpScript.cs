using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpScript : MonoBehaviour
{
    private int Maxhp = 3;
    public GameObject Gameover;
    bool check;

    void Start()
    {
        GameManager.instance.hp = Maxhp;
        check = false;
    }

    void Update()
    {
        if (GameManager.instance.hp > 0)
        {

        }
        else
        {
            if (check) return;
            check = true;
            ShowPopup(Gameover);
        }
    }

    private void ShowPopup(GameObject go)
    {
        go.SetActive(true);
        Time.timeScale = 0;
    }



}
