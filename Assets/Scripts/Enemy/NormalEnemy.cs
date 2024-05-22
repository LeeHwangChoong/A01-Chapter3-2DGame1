using UnityEngine;
using UnityEngine.UI;


public class NormalEnemy : MonoBehaviour
{
    public GameObject normalEnemy;
    public GameObject enemyBullet;
    public GameObject explosion;

    private EnemyData enemy = new(1, 0.01f, 1, EnemyType.normal);
    private bool isDead;

    //private bool IsTrigger;

    void Start()
    {
        InvokeRepeating("Attack", 0.1f, 2.0f);
    }

    void Update()
    {
        if (!GameManager.instance.isLive)
            return;
        MoveEnemy(enemy);
    }

    private void MoveEnemy(EnemyData enemy)
    {
        if (enemy.Hp > 0)
        {
            transform.position += Vector3.down * enemy.Speed;
            if (transform.position.y < -4.0f)
            {
                //Debug.Log("Enemy Move");
                Destroy(normalEnemy, 2.0f);
            }
        }
    }

    private void Attack()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        Instantiate(enemyBullet, new Vector2(x, y), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") && !isDead)
        {
            enemy.Hp -= 1;
            if (enemy.Hp > 0)
            {           
                Destroy(collision.gameObject);
            }

            else if (enemy.Hp == 0)
            {
                //Debug.Log("Get Score");
                isDead = true;
                Destroy(normalEnemy);
                Instantiate(explosion, transform.position, Quaternion.identity);

                GameManager.instance.score += enemy.Score;

            }
        }
    }
}