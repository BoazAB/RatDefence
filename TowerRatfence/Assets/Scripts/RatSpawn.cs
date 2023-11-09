using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatSpawn : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject Rat;
    [SerializeField] private int score;
    [SerializeField] private int hp;
    public Text HpText;
    public Text ScoreText;

    private void Start()
    {
        Instantiate(Rat);
        hp = 10;
    }

    private void FixedUpdate()
    {
        if (hp <= 0)
        {
            GameOver.GetComponent<GameOverScreen>().GameOver(score);
            HpText.gameObject.SetActive(false);
            ScoreText.gameObject.SetActive(false);
        }
        HpText.text = hp + " HP";
        ScoreText.text = score + " Score";
    }

    public void ReRat(GameObject whatRat, bool good)
    {
        if (hp > 0)
        {
            if (good == true)
            {
                score += 1;
            }
            else
            {
                hp -= 1;

            }
            if (score == 5 || score == 10 || score == 15 || score == 20 || score == 25 || score == 30 || score == 35 || score == 40 || score == 45 || score == 50)
            {
                Instantiate(Rat);
            }
            Instantiate(Rat);
        }
        Destroy(whatRat);
    }
}
