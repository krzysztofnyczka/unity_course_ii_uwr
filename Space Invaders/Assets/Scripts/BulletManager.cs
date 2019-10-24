using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 1800 || transform.position.z < -1000)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            MoveEnemies.Instance.killEnemy();
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            MoveEnemies.Instance.HurtPlayer();
            Destroy(gameObject);
        }
    }
}
