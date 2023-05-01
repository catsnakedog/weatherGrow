using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CloudMove : MonoBehaviour
{
    float runningTime;
    float yPos;
    float ExPos;
    float EyPos;
    float EzPos;

    [SerializeField] private float speed;
    [SerializeField] private float length;
    [SerializeField] private float delay;
    [SerializeField] private bool flag;
    void Start()
    {
        flag = false;
        ExPos = this.GetComponent<RectTransform>().anchoredPosition.x;
        EyPos = this.GetComponent<RectTransform>().anchoredPosition.y;
        StartCoroutine("CloudDelay");
    }
    // Update is called once per frame
    void Update()
    {
        if(flag)
        {
            runningTime += Time.deltaTime;
            yPos = Mathf.Sin(runningTime) * length / speed;
            this.GetComponent<RectTransform>().anchoredPosition = new Vector2(ExPos, EyPos += yPos);
        }
    }

    IEnumerator CloudDelay()
    {
        yield return new WaitForSeconds(delay);
        flag = true;
    }
}
