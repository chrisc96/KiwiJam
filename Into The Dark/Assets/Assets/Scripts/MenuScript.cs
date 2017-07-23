using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject OlafText;
    public GameObject NotifyText;
    public GameObject IntroText;
    public GameObject BackgroundImage;

    public Texture2D cursorImage;

    private int navState;

    // Use this for initialization
    void Start()
    {
        //reset cursor
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Cursor.visible = true;

        navState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) navigate();
    }

    //update menu state or transisition to next scene
    void navigate()
    {
        if (navState == 0)
        {
            OlafText.SetActive(false);
            NotifyText.SetActive(false);

            BackgroundImage.SetActive(true);
            IntroText.SetActive(true);
            navState++;
        }
        else
        {
            //changes cursor to olaf
            Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.Auto);

            //goes to main game scene
            SceneManager.LoadScene("main_scene");
        }
    }
}