using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFairy : MonoBehaviour
{
    [SerializeField] private GameObject fairy;
    [SerializeField] private List<Sprite> Imgs;
    // Start is called before the first frame update
    void Update()
    {
        if(GameManager.instance.TCount < -10) fairy.GetComponent<Image>().sprite = Imgs[3];
        else if (GameManager.instance.TCount >= 20) fairy.GetComponent<Image>().sprite = Imgs[2];
        else if (GameManager.instance.TCount >= 10) fairy.GetComponent<Image>().sprite = Imgs[1];
        else fairy.GetComponent<Image>().sprite = Imgs[0];
    }
}
