using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBreak : MonoBehaviour
{
    [SerializeField]
    private float health = 50;
    private bool rattack;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rattack == true)
        {
            health -= Time.deltaTime;
        }
        if (health <= 0)
        {
            rattack = false;
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Rat")
        {
            rattack = true;
        }   
    }
}
