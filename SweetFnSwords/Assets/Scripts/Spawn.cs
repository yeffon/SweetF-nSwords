using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    
    private int waveCap = 30;
    private float x;
    private int n = 0;
    private float z;
    public bool isSpawning = true;
    public int wave = 1;
    public float time = 0.5f;
    public static int curEn = 1;

    List<GameObject> enemyList = new List<GameObject>();
    private GameObject enemy;
    public GameObject levelUp;


    void Awake()
    {
        isSpawning = true;
    }

    void Start()
    {
        levelUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawning == true)
        {
            n = Random.Range(0, 6);

            if (n == 0)
            {
                x = -18.5f;
                z = 1.9f;
            }

            else if (n == 1)
            {
                x = -16.2f;
                z = 18.2f;
            }

            else if (n == 2)
            {
                x = 8.3f;
                z = 18.2f;
            }

            else if (n == 3)
            {
                x = 10.3f;
                z = 1.9f;
            }

            else if (n == 4)
            {
                x = 9.3f;
                z = -13.6f;
            }

            else if (n == 5)
            {
                x = -16.1f;
                z = -13.6f;
            }

            else
            {
                isSpawning = false;
            }

            enemy = Instantiate(enemyPrefab) as GameObject;
            enemy.transform.position = new Vector3(x, 1, z);
            enemyList.Add(enemy);

            if(wave == 1)
            {
                WaveSpawn1();
            }        

            if (enemyList.Count > 0)
            {
                isSpawning = false;
            }
        }

        levelSwitch();
    }

    private void WaveSpawn1()
    {       
        if (enemyList.Count < waveCap)
        {
            StartCoroutine(WaitTime());
            //isSpawning = true;
            curEn++;
            Debug.Log("Current Enemies: " + curEn);
        }

        else if(enemyList.Count >= waveCap)
        {
            Debug.Log("Wave 1 Finished");
            isSpawning = false;
        }
    }

    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(time);
        isSpawning = true;
        if (enemyList.Count > waveCap)
        {
            isSpawning = false;
        }
    }

    public void WaveIncrement()
    {
        time = 15;

        wave++;
        StartCoroutine(WaitTime());
        if (wave == 3)
        {
            
            isSpawning = false;
        }

        Debug.Log("Spawning next wave");
    }

    public void DieBitch()
    {
        curEn--;
        Debug.Log("Current Enemies: " + curEn);
    }

    void levelSwitch()
    {
        if (curEn <= 1)
        {
            levelUp.SetActive(true);
        }
    }
}

