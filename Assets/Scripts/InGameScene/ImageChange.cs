using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public Sprite[] chageImg;
    public Image myimage;

    void Start()
    {
        myimage = GetComponent<Image>();
    }

    void Update()
    { 
        myimage.sprite = chageImg[GameManager.instance.season];
    }
}
