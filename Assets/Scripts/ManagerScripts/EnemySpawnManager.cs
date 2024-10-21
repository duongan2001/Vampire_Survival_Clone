using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    #region Bien singleton
    public static EnemySpawnManager enemySpawnManager;
    #endregion

    [SerializeField] Transform[] enemySpawnPos;
    [SerializeField] GameObject[] enemyPref;
    [SerializeField] int maxEnemyNumber;
    int currentEnemyNumber;
    [SerializeField] float enemySpawnCD;
    float enemySpawnCD_ing;
    int enemySpawnNumber;
    int randomPos;
    float minRandomEnemy;
    float maxRandomEnemy;
    float time;

    Transform player;

    private void Awake()
    {
        if (enemySpawnManager && enemySpawnManager != this)
        {
            Debug.LogError("Loi nhieu Enemy Spawn Manager");
        }
        else
            enemySpawnManager = this;
    }

    void Start()
    {
        enemySpawnCD_ing = enemySpawnCD;
        enemySpawnNumber = 0;
        time = 0;
        minRandomEnemy = 0;
        maxRandomEnemy = 1;
        currentEnemyNumber = 0;
        player = GameObject.FindWithTag("Player").GetComponentInParent<Transform>();
    }

    void Update()
    {
        GetEnemyBaseOnTime();
        SpawnEnemy();
    }

    public int CurrentEnemySpawnNumber
    {
        get
        {
            return currentEnemyNumber;
        }
        set
        {
            currentEnemyNumber = value;
        }
    }

    public void SpawnEnemy()
    {
        time += Time.deltaTime;
        enemySpawnCD_ing -= Time.deltaTime;

        if (enemySpawnCD_ing <= 0 && enemySpawnNumber < 3 && currentEnemyNumber < maxEnemyNumber)
        {
            int enemyID = (int)Random.Range(minRandomEnemy, maxRandomEnemy);
            if (enemyID == maxRandomEnemy)
            {
                enemyID -= 1; 
            }

            RandomPos();
            Vector3 spawnPos = new Vector3(enemySpawnPos[randomPos].position.x, enemySpawnPos[randomPos].position.y);
            Instantiate(enemyPref[enemyID], spawnPos, Quaternion.identity);
            
            enemySpawnNumber++;
            currentEnemyNumber++;
            enemySpawnCD_ing = 0.2f;
            
            if (enemySpawnNumber >= 3 || currentEnemyNumber >= maxEnemyNumber)
            {
                enemySpawnCD_ing = enemySpawnCD;
                enemySpawnNumber = 0;
            }
        }
    }

    public void GetEnemyBaseOnTime()
    {
        if (time <= 180)// 180
        {
            minRandomEnemy = 0;
            maxRandomEnemy = 1;
        }
        else if (time > 180 && time <= 360)// 180 - 360
        {
            minRandomEnemy = 0;
            maxRandomEnemy = 2;
        }
        else if (time > 360 && time <= 540)// 360 - 540
        {
            minRandomEnemy = 0;
            maxRandomEnemy = 3;
        }
        else
        {
            minRandomEnemy = 1;
            maxRandomEnemy = 4;
        }
    }

    public void RandomPos()
    {      
        if (player.transform.position.x < -29.5f && player.transform.position.y > 13.5f) //Left Top
        {
            randomPos = (int)Random.Range(3, 5.99f); 
        }
        else if (player.transform.position.x < -29.5f && player.transform.position.y < -13.5f)//Left Bot
        {
            randomPos = (int)Random.Range(1, 3.99f);
        }
        else if (player.transform.position.x > 29.5f && player.transform.position.y > 13.5f) //Right Top
        {
            randomPos = (int)Random.Range(5, 7.99f);
        }
        else if (player.transform.position.x > 29.5f && player.transform.position.y < -13.5f) //Right Bot
        {
            randomPos = (int)Random.Range(0, 7.99f);
            while (randomPos >= 2 && randomPos < 7)
            {
                randomPos = (int)Random.Range(0, 7.99f);
            }
        }
        else if (player.transform.position.x < -29.5f) //Left
        {
            randomPos = (int)Random.Range(1, 5.99f);
        }
        else if (player.transform.position.x > 29.5f) //Right
        {
            randomPos = (int)Random.Range(0, 7.99f);
            while (randomPos >= 2 && randomPos < 5)
            {
                randomPos = (int)Random.Range(0, 7.99f);
            }
        }
        else if (player.transform.position.y > 13.5f) //Top
        {
            randomPos = (int)Random.Range(3, 7.99f);
        }
        else if (player.transform.position.y < -13.5f) //Bot
        {
            randomPos = (int)Random.Range(0, 7.99f);
            while (randomPos >= 4 && randomPos < 7)
            {
                randomPos = (int)Random.Range(0, 7.99f);
            }
        }
        else
        {
            randomPos = (int)Random.Range(0, 7.99f);
        }
    }
}
