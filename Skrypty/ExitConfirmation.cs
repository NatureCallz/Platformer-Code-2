using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitConfirmation : MonoBehaviour {

    public bool exitApplication;

    public GameObject exitMenuCanvas;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       

       
    }

    public void No()
    {
        exitApplication = false;
    }

    public void Yes()
    {
        Application.Quit();
    }

}