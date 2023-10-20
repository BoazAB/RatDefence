using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private int speed = 5;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > 0.9)
        {
            transform.position += new Vector3(-speed, 0) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 16)
        {
            transform.position += new Vector3(speed, 0) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, -180, 0);

        }
        if (Input.GetKey(KeyCode.W) && transform.position.y < 4)
        {
            transform.position += new Vector3(0, speed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > -0.3)
        {
            transform.position += new Vector3(0, -speed) * Time.deltaTime;
        }
    }
}
