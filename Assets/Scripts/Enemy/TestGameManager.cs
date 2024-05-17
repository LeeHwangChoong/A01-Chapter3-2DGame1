using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyObj;

    private void Start()
    {
        InvokeRepeating("MakeEnemy", 0f, 3f);
    }

    private void MakeEnemy()
    {
        Instantiate(EnemyObj);
    }
}