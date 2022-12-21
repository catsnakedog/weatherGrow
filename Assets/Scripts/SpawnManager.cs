using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] weatherPrefabs;
    public GameObject springPrefab;
    public GameObject summerPrefab;
    public GameObject fallPrefab;
    public GameObject winterPrefab;
    public GameObject bossPrefab;

    private GameObject _obj; //생성된 인스턴스를 저장할 임시변수
    private GameObject findObj; //que의 맨앞 오브젝트를 저장할 임시변수
    private WeatherAndBoss _findObj;
    private GameObject bossObj;
    private Boss _bossObj;

    [SerializeField] private float spawnX = 3;
    [SerializeField] private float spawnY = 3;
    [SerializeField] private float startDelay = 2;
    [SerializeField] private float spawnInterval = 1.5f;

    private bool DestoryObj;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateController();
    }

    public void SpawnRandomWeather()
    {
        if (GameManager.instance.season == 0)
        {
            Vector3 spawnPos0 = new Vector3(spawnX, spawnY, 1);
            _obj = Instantiate(springPrefab, spawnPos0, springPrefab.transform.rotation);
            GameManager.instance.q.Enqueue(_obj);
        }
        else if (GameManager.instance.season == 1)
        {
            Vector3 spawnPos0 = new Vector3(spawnX, spawnY, 1);
            _obj = Instantiate(summerPrefab, spawnPos0, summerPrefab.transform.rotation);
            GameManager.instance.q.Enqueue(_obj);
        }
        else if (GameManager.instance.season == 2)
        {
            Vector3 spawnPos0 = new Vector3(spawnX, spawnY, 1);
            _obj = Instantiate(fallPrefab, spawnPos0, fallPrefab.transform.rotation);
            GameManager.instance.q.Enqueue(_obj);
        }
        else if (GameManager.instance.season == 3)
        {
            Vector3 spawnPos0 = new Vector3(spawnX, spawnY, 1);
            _obj = Instantiate(winterPrefab, spawnPos0, winterPrefab.transform.rotation);
            GameManager.instance.q.Enqueue(_obj);
        }
    }

    public void SpringKill(Spring spring)
    {
        if (spring.Type == Define.Spring.Sunny)
        {

        }
    }

    void UpdateController() //que의 맨앞에 있는 오브젝트를 찾아서 list가 충족되거나 바운더리 밖으로 나갔을때 파괴를 시키도록
    {
        if (GameManager.instance.nowBoss)
        {
            _bossObj = GameManager.instance.boss.GetComponent<Boss>();
            if (_bossObj.bossHp <= 0)
            {
                Destroy(bossObj);
                GameManager.instance.nowBoss = false;
            }
            else if (GameManager.instance.boss.transform.position.x < -5)
            {
                Destroy(bossObj);
                GameManager.instance.nowBoss = false;
                GameManager.instance.hp--;
            }
        }
        else
        {
            if (GameManager.instance.q.Count != 0)
            {
                findObj = GameManager.instance.q.Peek();
                _findObj = findObj.GetComponent<WeatherAndBoss>();
                if (_findObj.weather.Count == 0)
                {
                    Color color = findObj.GetComponent<SpriteRenderer>().color;
                    color.a = 0.5f;
                    findObj.GetComponent<SpriteRenderer>().color = color;
                    findObj.GetComponent<WeatherMove>().destoryObj = true;
                    GameManager.instance.q.Dequeue();
                }
                if (findObj.transform.position.x < -2.7f)
                {
                    Destroy(findObj);
                    if (_findObj.weather.Count != 0)
                    {
                        GameManager.instance.hp--;
                        GameManager.instance.q.Dequeue();
                    }
                }
            }
        }
        
    }

    public void SpawnBossWeather()
    {
        GameManager.instance.nowBoss = true;
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 1);
        bossObj = Instantiate(bossPrefab, spawnPos, bossPrefab.transform.rotation);
        GameManager.instance.boss = bossObj;
    }
}
