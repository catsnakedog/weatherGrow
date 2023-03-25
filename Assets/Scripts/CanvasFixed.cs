using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFixed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int setWidth = 1080; // 사용자 설정 너비
        int setHeight = 1920; // 사용자 설정 높이

        int deviceWidth = Screen.width; // 기기 너비 저장
        int deviceHeight = Screen.height; // 기기 높이 저장

        int rate = (setHeight/setWidth);

        if (rate * deviceWidth > setHeight)// 가로가 더 긴 상황 (새로에 맞춰야함)
        {
            this.GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
        }
        else // 새로가 더 긴 상황 (가로에 맞춰야함)
        {
            this.GetComponent<CanvasScaler>().matchWidthOrHeight = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
