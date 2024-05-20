using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * 0.05f;
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
            Debug.Log("Destroy Enemy Bullet");
        }
    }
}
