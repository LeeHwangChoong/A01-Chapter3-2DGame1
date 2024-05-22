using UnityEngine;
using UnityEngine.UI;


public class NormalEnemy : MonoBehaviour
{
    public GameObject normalEnemy;
    public GameObject enemyBullet;
    public GameObject explosion;

    private EnemyAction enemyAction;
    private EnemyData enemy = new EnemyData();


    private bool isDead;

    //private bool IsTrigger;

    void Start()
    {
        Debug.Log(enemy);
        InvokeRepeating("enemyAction.Attack(enemyBullet)", 0.1f, 2.0f);
    }

    void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        enemyAction.Move(enemy, normalEnemy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet") && !isDead)
        {

            if (enemy.Hp == 1)
            {
                Debug.Log("Get Score");
                isDead = true;
                Destroy(normalEnemy);
                Instantiate(explosion, transform.position, Quaternion.identity);

                GameManager.instance.score += enemy.Score;

            }

            else if (enemy.Hp > 1)
            {
                enemy.Hp -= 1;
                Destroy(collision.gameObject);
            }
            else
                Debug.Log("enemy 충돌 감지-체력 감소 오류입니다.");
        }
    }
}