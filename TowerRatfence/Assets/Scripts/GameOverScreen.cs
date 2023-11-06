using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void GameOver(int score)
    {
        pointsText.text = score.ToString() + " DEAD RATS";
        this.gameObject.SetActive(true);
    }

    public void GotClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
