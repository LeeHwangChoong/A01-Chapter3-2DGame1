using System.Collections.Generic;

public enum EnemyType
{
    normal,
    faster,
    solid,
    boss
}

public class EnemyData // : MonoBehaviour
{
    public int Hp { get; set; }
    public float Speed { get; }
    public int Score { get; }

    public Dictionary<EnemyType, EnemyData> EnemyDB = new Dictionary<EnemyType, EnemyData>();

    public EnemyData(int hp, float speed, int score)
    {
        Hp = hp;
        Speed = speed;
        Score = score; // add this score to Player
    }

    // select enemy type

    public void InitEnemy()
    {
        EnemyDB.Add(EnemyType.normal, new EnemyData(1, 0.01f, 1));  
        EnemyDB.Add(EnemyType.faster, new EnemyData(1, 0.03f, 1));  
        EnemyDB.Add(EnemyType.solid, new EnemyData(2, 0.005f, 2));  
        EnemyDB.Add(EnemyType.boss, new EnemyData(20, 0.0f, 20));
        // GetEnemy(EnemyType.normal);
    }
    public EnemyData GetEnemy(EnemyType type)
    {
        if (EnemyDB.ContainsKey(type))
            return EnemyDB[type];
        else
            return null;
    }
}