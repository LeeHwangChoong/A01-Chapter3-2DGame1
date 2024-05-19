using UnityEngine;

public class EnemyData // : MonoBehaviour
{
    public int Hp { get; set; }
    public float Speed { get; set; }

    public EnemyData(int hp, float speed)
    {
        Hp = hp;
        Speed = speed;
    }
}
