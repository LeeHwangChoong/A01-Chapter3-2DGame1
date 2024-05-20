using UnityEngine;
using UnityEngine.UI;


public class NormalEnemy : MonoBehaviour
{
    public GameObject normalEnemy;
    public GameObject enemyBullet;
    public Text showScoreText;

    public EnemyData enemy = new(1, 0.01f, 1);
    
    //public GameObject player;
    private int nowScore = 0;

    void Start()
    {
        SpawnEnemy();
        InvokeRepeating("Attack", 0.1f, 0.5f);
    }

    void Update()
    {
        MoveEnemy(enemy);
        
    }

    private void SpawnEnemy()
    {
        Debug.Log("Spawn Enemy");

        float x = Random.Range(-2.5f, 2.5f);
        //float x = 0.0f;
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
                Debug.Log("Enemy Move");
                Destroy(normalEnemy, 3.0f);
            }
        }
    }

    private void Attack()
    {
        Debug.Log("Enemy Attacks");
        float x = transform.position.x;
        float y = transform.position.y;
        Instantiate(enemyBullet, new Vector2(x, y), Quaternion.identity);
        Instantiate(enemyBullet, new Vector2(x, y), Quaternion.identity);
        Instantiate(enemyBullet, new Vector2(x, y), Quaternion.identity);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy Damage Detected");
            if (enemy.Hp > 0)
            {
                Debug.Log("Reduce enemy Hp");
                Debug.Log($"Origin Hp: {enemy.Hp}");
                enemy.Hp -= 1;
                Destroy(collision.gameObject);
                Debug.Log($"Now Hp: {enemy.Hp}");
            }

            if (enemy.Hp == 0)
            {
                Debug.Log("Get Score");

                //Get Score
                // Player playerLogic = player.GetComponent<Player>();
                //playerLogic.score += enemy.Score;
                nowScore += enemy.Score;
                showScoreText.text = nowScore.ToString("F2");
                Destroy(normalEnemy, 2.0f);
                Debug.Log("Destroy Enemy Obj");
            }
        }
    }
}