using System;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    normal = 1,
    faster,
    solid,
    boss
}

public class EnemyData // : MonoBehaviour
{
    public int Hp { get; set; }
    public float Speed { get; set; }
    public int Score { get; }

    private EnemyType Type;

    public EnemyData(int hp, float speed, int score, EnemyType Type)
    {
        Hp = hp;
        Speed = speed;
        Score = score; // add this score to Player
    }

    // paste following code to DataManager later

    public Dictionary<int, EnemyData> EnemyDB = new Dictionary<int, EnemyData>();

    // select enemy type
    public void InitEnemy()
    {
        EnemyDB.Add(1, new EnemyData(1, 0.01f, 1, EnemyType.normal));  
        EnemyDB.Add(2, new EnemyData(1, 0.02f, 1, EnemyType.faster));  
        EnemyDB.Add(3, new EnemyData(2, 0.005f, 1, EnemyType.solid));  
        EnemyDB.Add(4, new EnemyData(20, 0.0f, 100, EnemyType.boss));  
    }
}
