using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour {

    public static float score;
    public Text scoreText;

    public AudioSource gameMusic;
    public AudioSource winMusic;
    public AudioSource lossMusic;

    public Text timerText;
    public float time;

    public GameObject winText;
    public GameObject lossText;
    public GameObject resetText;

    public GameObject player;

    private bool gameOver;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        gameMusic.Play();
        score = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1"))
        {
            if (gameOver) SceneManager.LoadScene("main_menu");
        }

        scoreText.text = "Score: " + score;

        if (!gameOver)
        {
            time -= Time.deltaTime;
            timerText.text = (int)time + "";
        }

        //if player wins
        if (time <= 1)
        {
            Cursor.visible = true;
            winScreen();
        }
        //if they lose
        else if (player == null)
        {
            Cursor.visible = true;
            lossScreen();
        }
    }

    void winScreen()
    {
        if (!gameOver)
        {
            //change music
            gameMusic.Pause();
            winMusic.PlayOneShot(winMusic.clip, 1);

            winText.SetActive(true);
            resetText.SetActive(true);
        }
        gameOver = true;
    }

    void lossScreen()
    {
        if (!gameOver)
        {
            //change music
            gameMusic.Pause();
            lossMusic.PlayOneShot(lossMusic.clip, 1);

            lossText.SetActive(true);
            resetText.SetActive(true);
        }
        gameOver = true;
    }
}
