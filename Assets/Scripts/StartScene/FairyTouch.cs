using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FairyTouch : MonoBehaviour
{
    [SerializeField] Animator AN;
    [SerializeField] private int touchCount;
    void Awake()
    {
        AN.SetBool("Start", true);
        AN.SetBool("Damage", false);
    }

    void Start()
    {
        GameManager.instance.TCount = PlayerPrefs.GetInt("TouchCount", GameManager.instance.TCount);
        if (GameManager.instance.TCount >= 10) GameManager.instance.hurt1 = true;
        if (GameManager.instance.TCount >= 20) GameManager.instance.hurt2 = true;
    }

    public void setting()
    {
        AN.SetBool("Start", true);
        AN.SetBool("Damage", false);
        touchCount = PlayerPrefs.GetInt("TouchCount", GameManager.instance.TCount);

        if(GameManager.instance.TCount >= 10)
        {
            AN.SetBool("Hurt1", true);
        }
        if(GameManager.instance.TCount >= 20)
        {
            AN.SetBool("Hurt2", true);
        }
    }
    public void touchFairy()
    {
        GameManager.Sound.Play("SFX/7_Hit");
        StartCoroutine("Damage");
        if(GameManager.instance.TCount < 50)
        {
            GameManager.instance.TCount++;
        }
        PlayerPrefs.SetInt("TouchCount", GameManager.instance.TCount);
        if (GameManager.instance.TCount >= 10)
        {
            AN.SetBool("Hurt1", true);
        }
        if (GameManager.instance.TCount >= 20)
        {
            AN.SetBool("Hurt2", true);
        }
    }

    IEnumerator Damage()
    {
        AN.SetBool("Damage", true);
        yield return new WaitForSecondsRealtime(0.1f);
        AN.SetBool("Damage", false);
    }
}
