using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayIntroAudio : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.PlaySound("MonologueIntro");
    }

}
