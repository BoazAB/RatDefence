using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpawn : MonoBehaviour
{
    public GameObject Rat;
    [SerializeField] private int score;
    [SerializeField] private int hp = 10;

    private void Start()
    {
        Instantiate(Rat);
    }
    public void ReRat(GameObject whatRat, bool good)
    {
        if (good == true)
        {
            score += 1;
        }
        else
        {
            hp -= 1;
        }
        if (score == 5 || score == 10 || score == 15|| score == 20|| score == 25|| score == 30 || score == 35 || score == 40 || score == 45 || score == 50)
        {
            Instantiate(Rat);
        }
        Instantiate(Rat);
        Destroy(whatRat);
    }
}
