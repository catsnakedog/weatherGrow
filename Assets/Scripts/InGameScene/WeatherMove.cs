using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherMove : MonoBehaviour
{
    public List<int> element;
    public bool destoryObj = false;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * GameManager.instance.speed * Time.deltaTime);

        if(destoryObj)
        {
            if(gameObject.transform.position.x < -2.7f)
            {
                Destroy(gameObject);
            }
        }
    }
}
