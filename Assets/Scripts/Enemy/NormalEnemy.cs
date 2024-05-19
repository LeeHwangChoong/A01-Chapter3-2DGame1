using UnityEngine;


public class NormalEnemy : MonoBehaviour
{
    public GameObject normalEnemy;
    public EnemyData enemy = new(1, 0.01f);
    
    public GameObject player;
    public int enemyScore;

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        MoveEnemy(enemy);
    }

    private void SpawnEnemy()
    {
        Debug.Log("SpawnEnemy");

        float x = Random.Range(-2.5f, 2.5f);
        float y = 5.0f;
        transform.position = new Vector3(x, y);
    }

    private void MoveEnemy(EnemyData enemy)
    {
        if (enemy.Hp > 0)
        {
            transform.position += Vector3.down * enemy.Speed;
            if (transform.position.y < -5.0f)
            {
                Debug.Log("EnemyMove");
                Destroy(normalEnemy, 3.0f);
            }
        }
    }

    private void Attack()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (enemy.Hp > 0)
            {
                enemy.Hp -= 1;
                Destroy(collision.gameObject);
            }
            else if (enemy.Hp == 0)
            {
                //Get Score
                Player playerLogic = player.GetComponent<Player>();
                playerLogic.score += enemyScore;
                Destroy(normalEnemy, 3.0f);
            }
        }
    }
}