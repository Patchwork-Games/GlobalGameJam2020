using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
	private bool startMusic = false;

	private void Update()
	{
		if (!startMusic)
		{
			startMusic = true;
			AudioManager.instance.PlaySound("LightMusicTrack");
			AudioManager.instance.PlaySound("HeavyMetal");
			AudioManager.instance.PauseSound("HeavyMetal");
		}
	}
}
