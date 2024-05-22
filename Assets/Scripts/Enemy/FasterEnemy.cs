using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FasterEnemy : MonoBehaviour
{
    public GameObject fasterEnemy;
    public GameObject enemyBullet;
    public GameObject explosion;
    //public Transform EnemySpawn;
    //public int enemyType = 1;

    private EnemyData enemy = new EnemyData(2, 0.005f, 1, EnemyType.faster);

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
                Destroy(fasterEnemy, 2.0f);
            }
        }
    }

    private void Attack()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        Instantiate(enemyBullet, new Vector2(x, y), Quaternion.identity, transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            if (enemy.Hp > 0)
            {
                enemy.Hp -= 1;
                Destroy(collision.gameObject);
            }

            if (enemy.Hp == 0)
            {
                //Debug.Log("Get Score");

                Destroy(fasterEnemy);
                Instantiate(explosion, transform.position, Quaternion.identity);
                GameManager.instance.score += enemy.Score;

            }
        }
    }
}