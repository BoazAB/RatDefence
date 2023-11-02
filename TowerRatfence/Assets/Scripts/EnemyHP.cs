using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] private int hp = 10;

    private void Awake()
    {
        hp = 10;
    }

    public void Damage()
    {
        hp -= 1;
        if (hp <= 0)
        {
            gameObject.GetComponent<EnemyMove>().RespawnRat();
            Destroy(gameObject);
        }
    }
}
