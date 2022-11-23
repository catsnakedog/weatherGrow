using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherMove : MonoBehaviour
{
    public float speed;
    public List<int> element;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
