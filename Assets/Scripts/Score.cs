using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    public Text txtScore;

    void Start()
    {
        score = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bola"))
        {
            score++;
            txtScore.text = "Score: \n" + score;
        }
    }

    public void Reset()
    {
        score = 0;
        txtScore.text = "Score: \n" + score;
    }
}
