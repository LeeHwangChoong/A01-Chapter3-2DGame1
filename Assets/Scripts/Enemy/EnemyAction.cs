using UnityEngine;


public class EnemyAction : MonoBehaviour
{
    //public GameObject enemyBullet;

    public void Move(EnemyData enemy, GameObject enemyObj)
    {
        if (enemy.Hp > 0)
        {
            Debug.Log("EnemyAction Move");
            transform.position += Vector3.down * enemy.Speed;
            if (transform.position.y < -4.0f)
            {
                Destroy(enemyObj, 2.0f);
            }
        }
    }

    public void Attack(GameObject enemyBullet)
    {
        Debug.Log("EnemyAction Attack");
        float x = transform.position.x;
        float y = transform.position.y;
        Instantiate(enemyBullet, new Vector2(x, y), Quaternion.identity);
    }
}