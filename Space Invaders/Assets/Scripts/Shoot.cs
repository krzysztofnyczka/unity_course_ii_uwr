using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    /*[SerializeField]
    KeyCode shootKey;*/

    /*[SerializeField]*/
    public GameObject bullet_obj;
    private float lastShot;
    public float shotFreq;

    private void Start()
    {
        lastShot = Time.time;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastShot >= (1 / shotFreq))
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 100);
                GameObject bullet = Instantiate(bullet_obj, pos, bullet_obj.transform.rotation);
                bullet.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 500);
                lastShot = Time.time;
            }
        }
    }
}
