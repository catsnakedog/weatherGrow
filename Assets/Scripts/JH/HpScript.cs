using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            GameManager.instance.q.Clear();
            SceneManager.LoadScene("GameEnd");
        }
    }
}
