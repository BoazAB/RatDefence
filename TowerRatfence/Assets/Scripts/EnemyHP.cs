using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int hp = 10;
    private GameObject manager;

    private void Awake()
    {
        hp = 10;
        manager = GameObject.Find("GritManager");
    }

    public void Damage()
    {
        hp -= 1;
        if (hp <= 0)
        {
            manager.GetComponent<RatSpawn>().ReRat(this.gameObject);
        }
    }
}
