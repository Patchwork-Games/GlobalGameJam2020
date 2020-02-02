using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGModeButton : MonoBehaviour
{

    public static bool PGModeOn;
    public GameObject CheckMark;

    private void Awake()
    {
        CheckMark = transform.GetChild(1).gameObject;
    }

    public void PGMode()
    {
        if (PGModeOn)
        {
            CheckMark.SetActive(false);
            PGModeOn = false;
        }
        else
        {
            CheckMark.SetActive(true);
            PGModeOn = true;
        }
    }







}
