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
        transform.position += Vector3.down * 0.03f;
        /*
        if (transform.position.x > 0)
            transform.position += Vector3.left * 0.01f;
        else
            transform.position += Vector3.right * 0.01f;
        */
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
            //Debug.Log("Destroy Enemy Bullet");
        }
    }
}
