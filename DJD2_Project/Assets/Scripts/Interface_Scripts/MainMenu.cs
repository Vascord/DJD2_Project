using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    { // Loads the next scene in the build settings order
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    { //Leaves the application, does not work on the editor
        Debug.Log("Quitted!");
        Application.Quit();
    }
}
