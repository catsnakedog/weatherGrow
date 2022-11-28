using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherAndBoss : MonoBehaviour
{
    private float leftLimit = 5;

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
        Init();
    }

    void Update()
    {
        if (transform.position.x < -leftLimit)
        {
            Destroy(gameObject);
            GameManager.instance.q.Dequeue();
        }
    }
    protected virtual void Init()
    {

    }
}
