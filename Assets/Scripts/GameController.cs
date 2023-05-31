using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject [] bolas;
    private float MaxWidth;
    public Camera cam;
    public float timeLeft;
    public Text txtTimeLeft;
    public GameObject txtGameOver;
    public HatController hc;
    public GameObject SplashImage;
    public GameObject StartButton;
    public GameObject RestartButton;
    private bool playing;
    public Score sc;
    public int nVidas;
    public GameObject[] vidas;
    public string SceneName;

    public int scoreAdv = 2;


    void Start()
    {
        
        playing = false;
        if (cam == null) cam = Camera.main;
        Vector3 UpperC = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 dim = cam.ScreenToWorldPoint(UpperC);
        MaxWidth = dim.x - bolas[0].GetComponent<Renderer>().bounds.extents.x;
        timeLeft = 20.0f;
        txtGameOver.SetActive(false);
        hc.MudaEstado(false);
        RestartButton.SetActive(false);

        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        
        Debug.Log(CurrentScene);

        if (SceneManager.GetActiveScene().name == "Cena 2")
        {
            StartGame();
        }
    }

    public void RestartGame()
    {
        timeLeft = 30.0f;
        txtGameOver.SetActive(false);
        RestartButton.SetActive(false);
        sc.Reset();
        StartGame();
    }

    public void StartGame()
    {
        

        nVidas = 3;
        updateVidas(0);
        SplashImage.SetActive(false);
        StartButton.SetActive(false);
        hc.MudaEstado(true);
        playing = true;
        //Rato invisivel
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        StartCoroutine(Spawn());

        
    }

    IEnumerator Spawn()
    {
        while(timeLeft > 0 && nVidas > 0)
        {
            Vector3 spawnPosition = 
                new Vector3(Random.Range(-MaxWidth, MaxWidth), transform.position.y, 0.0f);
                GameObject bola = bolas[Random.Range(0, bolas.Length)];

            Instantiate(bola, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(1.0f); // AS BOMBAS SÓ DEVEM EXPLODIR QUANDO TOCAM NO CHAPEU!
        }
        txtGameOver.SetActive(true);
        hc.MudaEstado(false);
        RestartButton.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    void Update()
    {
        if (playing)
        {
            if (timeLeft > 0 && nVidas > 0)
            {
                timeLeft -= Time.deltaTime;
                txtTimeLeft.text = "Time Left: \n" + Mathf.RoundToInt(timeLeft);
            }
        }


        if(sc.score >= scoreAdv)
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }

    }

    public void updateVidas(int value)
    {
        nVidas += value;

        if (nVidas > 3) nVidas = 3;

        if (nVidas <= 0) nVidas = 0;

        for (int i=0; i < vidas.Length; i++)
        {
            vidas[i].SetActive(i<nVidas);
        }
    }

    public void bonusTempo(int value)
    {
        timeLeft = timeLeft + value;

    }

}
