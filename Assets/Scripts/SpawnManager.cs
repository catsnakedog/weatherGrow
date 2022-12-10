using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] weatherPrefabs;
    public GameObject springPrefab;
    
    private GameObject _obj; //생성된 인스턴스를 저장할 임시변수
    private GameObject findObj; //que의 맨앞 오브젝트를 저장할 임시변수
    private WeatherAndBoss _findObj;

    [SerializeField] private float spawnX = 3;
    [SerializeField] private float spawnY = 3;
    [SerializeField] private float startDelay = 2;
    [SerializeField] private float spawnInterval = 1.5f;

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
        int weatherIndex = Random.Range(0, weatherPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnX, spawnY, 1);


        //Instantiate(weatherPrefabs[weatherIndex], spawnPos, weatherPrefabs[weatherIndex].transform.rotation);
    }

    public void SpringKill(Spring spring)
    {
        if (spring.Type == Define.Spring.Sunny)
        {

        }
    }

    void UpdateController() //que의 맨앞에 있는 오브젝트를 찾아서 list가 충족되거나 바운더리 밖으로 나갔을때 파괴를 시키도록
    {
        if (GameManager.instance.gameState)
        {
            findObj = GameManager.instance.q.Peek();
            _findObj = findObj.GetComponent<WeatherAndBoss>();
            if (_findObj.weather.Count ==  0 || findObj.transform.position.x < -5)
            {
                GameManager.instance.q.Dequeue();
                Destroy(findObj);
            }
        }
    }
}
