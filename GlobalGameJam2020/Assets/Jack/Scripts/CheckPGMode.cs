using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPGMode : MonoBehaviour
{

    private void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            if (PGModeButton.PGModeOn)
            {
                GetComponent<Renderer>().enabled = true;
            }
            else
            {
                GetComponent<Renderer>().enabled = false;
            }
        }
    }
}
