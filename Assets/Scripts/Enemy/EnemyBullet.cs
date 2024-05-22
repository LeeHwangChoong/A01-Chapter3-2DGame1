using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int type = 1;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x > 0)
            dir += Vector3.left;
        else
            dir += Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyBulletType(type);
    }

    private void EnemyBulletType(int type)
    {
        transform.position += Vector3.down * 0.03f;

        switch (type)
        {
            case 1:
                break;
            case 2:
                transform.position += dir * 0.005f;
                break;
        }

        if (transform.position.y < -5.0f)
            Destroy(gameObject);
    }
}
