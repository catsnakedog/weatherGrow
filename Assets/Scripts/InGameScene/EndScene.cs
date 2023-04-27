using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Sound.Play("BGM/GameBgm_Score",Define.Sound.Bgm) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
