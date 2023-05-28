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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bomba")
        {
            score -= 5;
            if (score < 0) score = 0;

            updateVidas(-1)
        }

        if(collision.gameObject.tag == "Clock")
        {
            Destroy(collision.gameObject, 1.0f);
        }


    }

    public void Reset()
    {
        score = 0;
        txtScore.text = "Score: \n" + score;
    }
}
