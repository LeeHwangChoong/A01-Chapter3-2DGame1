using System.Collections.Generic;
using UnityEngine;

public class EnemyData // : MonoBehaviour
{
    public int Hp { get; set; }
    public float Speed { get; set; }
    public int Score { get; }

    public EnemyData(int hp, float speed, int score)
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
        EnemyDB.Add(1, new EnemyData(1, 0.01f, 1));  //normal enemy
        EnemyDB.Add(2, new EnemyData(1, 0.02f, 1));  //faster
        EnemyDB.Add(3, new EnemyData(2, 0.005f, 1));  //more solid
        EnemyDB.Add(4, new EnemyData(20, 0.0f, 100));  //bose enemy
    }
}
