using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject GameUI;

    private float prevPitch;
    private float prevPitchDark;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                AudioManager.instance.SetPitch("LightMusicTrack", prevPitch);
                AudioManager.instance.SetPitch("HeavyMetal", prevPitch); 
            }
            else
            {
                Pause();
                prevPitch = AudioManager.instance.GetSoundPitch("LightMusicTrack");
                AudioManager.instance.SetPitch("LightMusicTrack", .8f);

                prevPitchDark = AudioManager.instance.GetSoundPitch("HeavyMetal");
                AudioManager.instance.SetPitch("HeavyMetal", .8f);
            }
        }

        if (GameIsPaused) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;
    }



    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        if(GameUI)GameUI.SetActive(true);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
        if (GameUI) GameUI.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}
