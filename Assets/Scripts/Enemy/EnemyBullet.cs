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
        transform.position += Vector3.up * 0.2f;
        if (transform.position.y > 6.0f)
        {
            Destroy(gameObject);
        }
    }
}
