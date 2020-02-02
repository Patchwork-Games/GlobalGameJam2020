using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;


    //button variables
    public InputMaster controls = null;
    public bool interact = false;

    private void Awake()
    {
        controls = new InputMaster();
    }

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            controls.Player.Continue.performed += context => LoadNextLevel();
            controls.Enable();
        }
        
    }

    private void OnDisable()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            controls.Player.Continue.performed -= context => LoadNextLevel();
            controls.Disable();
        }
        
    }


    public void LoadNextLevel()
    {
        transition.SetTrigger("Start");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }



    IEnumerator LoadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }

}
