using UnityEngine;

public class EnemyData // : MonoBehaviour
{
    //적 데이터
    public int Hp { get; set; } // 몇 번 피격하면 파괴되는지 1~3
    public float Speed { get; set; } // 이동 속도


    public EnemyData(int hp, float speed)
    {
        Hp = hp;
        Speed = speed;
    }
}
