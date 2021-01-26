using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject pausedMenu;


    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                Pause();
            } 
            else if(gameIsPaused && settings.activeSelf)
            {
                settings.SetActive(false);
                pausedMenu.SetActive(true);
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        player.GetComponent<AudioSource>().Play();
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        player.GetComponent<AudioSource>().Pause();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
