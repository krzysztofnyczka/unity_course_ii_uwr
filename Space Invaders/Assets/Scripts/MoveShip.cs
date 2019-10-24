using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    [SerializeField]
    Vector3 vForce;
    [SerializeField]
    KeyCode keyOne, keyTwo;



    void FixedUpdate()
    {
        transform.SetPositionAndRotation(new Vector3(transform.position.x, 25, transform.position.z), transform.rotation);

        if (transform.position.x < -500)
            this.transform.SetPositionAndRotation(new Vector3(-500, transform.position.y, transform.position.z), this.transform.rotation);
        if (transform.position.x > 500)
            this.transform.SetPositionAndRotation(new Vector3(500, transform.position.y, transform.position.z), this.transform.rotation);
        if (transform.position.z > 225)
            this.transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, 225), this.transform.rotation);
        if (transform.position.z < -225)
            this.transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, -225), this.transform.rotation);

        if (Input.GetKey(keyOne))
        {
            GetComponent<Rigidbody>().velocity = vForce;
        }
        if (Input.GetKey(keyTwo))
        {
            GetComponent<Rigidbody>().velocity = -vForce;
        }
        /*else
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }*/
    }
}
