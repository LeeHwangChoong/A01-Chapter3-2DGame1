using UnityEngine;


public class NormalEnemy : MonoBehaviour
{
    public GameObject normalEnemy;
    public EnemyData enemy = new(1, 0.01f);

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        MoveEnemy(enemy);
    }

    // 일반 적 생성

    private void SpawnEnemy()
    {
        Debug.Log("화면 상단에 적 랜덤 생성");

        float x = Random.Range(-2.5f, 2.5f);
        float y = 5.0f;
        transform.position = new Vector3(x, y);
    }

    private void MoveEnemy(EnemyData enemy)
    {
        // 살아있는 적 기본 이동(하강)

        if (enemy.Hp > 0)
        {
            transform.position += Vector3.down * enemy.Speed;
            if (transform.position.y < -5.0f)
            {
                Debug.Log("화면 최하단에 도달한 적 오브젝트를 파괴합니다.");
                Destroy(normalEnemy, 3.0f);
            }
        }
    }

    private void Attack()
    {
        // 총알 생성 함수 호출하기
    }

    //이하 충돌 감지

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // 살아 있을 때 player의 bullet에 맞으면
            // Hp가 줄고 player의 bullet을 파괴한다

            if (enemy.Hp > 0)
            {
                enemy.Hp -= 1;
                Destroy(collision.gameObject);
            }
            else if (enemy.Hp == 0)
            {
                Destroy(normalEnemy, 3.0f);
                //GameManager.Instance.AddScore();
            }

            // TODO: 플레이어와 충돌 시에도 피해 줌

            // TODO: (HP가 1 이상인 적만) HP가 1 남았을때 붉은 색조 입히기

        }
    }
}