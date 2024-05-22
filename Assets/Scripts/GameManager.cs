using System;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] enemyObjs;
    public Transform[] spawnPoints;
    
    public float maxSpawnDelay;
    public float curSpawnDelay;

    public GameObject player;
    public int score;

    public TextMesh msgText;
    public Text bombCountText;

    public int highScore; // 최고 점수 변수 추가
    
    //UI
    public Text scoreText;
    public Text nowScoreText;
    public Text highScoreText; // 최고 점수 UI 추가
    public Image[] lifeImage;
    public GameObject gameOverSet;

    public Transform EnemySpawn; // EnemySpawn instantiate position

    public bool isLive;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        Time.timeScale = 1.0f;

        // 최고 점수 로드
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
        if (!isLive)
            return;
        
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            Debug.Log("Spawn");
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0;
        }
        scoreText.text = string.Format("{0:n0}", score);
    }

    //life Appear
    public void UpdateLife(int life)
    {
        //Life Disable
        for (int i = 0; i < lifeImage.Length; i++)
        {
            if(i < life)
            {
                lifeImage[i].color = new Color(1, 1, 1, 1);
            }
            else
            {
                lifeImage[i].color = new Color(1, 1, 1, 0);
            }
        }
    }
    
    void SpawnEnemy()
    {
        Debug.Log("SpawnEnemy");
        int ranEnemy = Random.Range(0, enemyObjs.Length);
        int ranPoint = Random.Range(0, 5);
        Instantiate(enemyObjs[ranEnemy],
            spawnPoints[ranPoint].position,
            spawnPoints[ranPoint].rotation,
            EnemySpawn);
    }

    public void RespawnPlayer()
    {
        Invoke("Exe", 2f);
    }
    private void Exe()
    {
        player.transform.position = Vector3.down * 3f;
        player.SetActive(true);
    }

    public void GameOver()
    {
        isLive = false;
        Time.timeScale = 0.0f;
        nowScoreText.text = scoreText.text;
        gameOverSet.SetActive(true);

        // 최고 점수 갱신
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        highScoreText.text = string.Format("{0:n0}", highScore); 
    }

    public void GameRetry()
    {
        SceneManager.LoadScene(0);
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }
    
    public void Resume(int state)
    {
        if (state == 1)
        {
            isLive = false;
            Time.timeScale = 0;
        }
        else if (state == 0)
        {
            isLive = true;
            Time.timeScale = 1;
        }
    }
}
