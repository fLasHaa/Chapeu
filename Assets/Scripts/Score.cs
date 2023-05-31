using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    public Text txtScore;

    public GameController gc;




    void Start()
    {
        score = 0;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomba")
        {
            score = score - 5;
            txtScore.text = "Score: \n" + score;
            if (score < 0) score = 0;

            gc.updateVidas(-1);
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Clock")
        {
            gc.bonusTempo(10);
        }

        if (collision.gameObject.tag == "Morte")
        {
            gc.updateVidas(-3);

        }

        if (collision.gameObject.CompareTag("Bola"))
        {
            score++;
            txtScore.text = "Score: \n" + score;
        }

        if (collision.gameObject.CompareTag("Health"))
        {
            gc.updateVidas(1);
        }
    }

    public void Reset()
    {
        score = 0;
        txtScore.text = "Score: \n" + score;
    }
}
