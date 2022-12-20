using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeatherAndBoss : MonoBehaviour
{
    private float leftLimit = 5;

    //public SpriteRenderer i;

    public float move_speed;

    public List<int> weather = new List<int>() { 9, 9, 9 };
    protected Define.weatherState _weatherState;
    public Define.weatherState Weatherstate
    {
        get { return _weatherState; }
        set
        {
            if (_weatherState == value)
                return;
            _weatherState = value;
            if (_weatherState == Define.weatherState.Kill)
                Kill();
        }
    }

    public virtual void Kill()
    {

    }

    void Start()
    {
        //i = gameObject.GetComponent<SpriteRenderer>();
        Init();
    }

    /*void Update()
    {
        if (transform.position.x < -leftLimit)
        {
            Destroy(gameObject);
            GameManager.instance.q.Dequeue();
        }
    }
    */

    protected virtual void Init()
    {

    }
}
