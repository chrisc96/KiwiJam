using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour {

    public GameObject OlafText;
    public GameObject NotifyText;
    public GameObject IntroText;
    public GameObject BackgroundImage;
    private int navState;

    // Use this for initialization
    void Start () {
        navState = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) navigate();
    }

    //update menu state or transisition to next scene
    void navigate() {
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

        }
    }
}
