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
        Score = score;
    }
}
