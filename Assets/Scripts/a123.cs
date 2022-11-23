using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a123 : MonoBehaviour
{
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;

    public float time;
    public bool ImageChange;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        ImageChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 2f)
        {
            ImageChange = true;
        }
    }

    public void ImageC1()
    {
        if (ImageChange)
        {
            Image1.SetActive(false);
            time = 0f;
            ImageChange = false;
        }
    }
    public void ImageC2()
    {
        if (ImageChange)
        {
            Image2.SetActive(false);
            time = 0f;
            ImageChange = false;
        }
    }
    public void ImageC3()
    {
        if (ImageChange)
        {
            Image3.SetActive(false);
            time = 0f;
            ImageChange = false;
        }
    }
}
