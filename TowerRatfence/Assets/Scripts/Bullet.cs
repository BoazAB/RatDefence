using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float BS = 5f;
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1, 0, 0)* BS * Time.deltaTime;
        if (transform.position.x > 22)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Rat")
        {
            col.gameObject.GetComponent<EnemyHP>().Damage();
            Destroy(gameObject);
        }
    }
}
