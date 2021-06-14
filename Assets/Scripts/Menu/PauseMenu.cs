using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    #region Singleton

    public static PauseMenu instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    #endregion

    public bool isPaused = false;

    public GameObject pauseMenuUI;
    public GameObject crossHair;

    void Update(){

        if (Input.GetKeyDown(KeyCode.Escape)){

            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        } 
    }

    void Pause() {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        crossHair.SetActive(false);
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        crossHair.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GoToMenu() {
        Debug.Log("menu button");
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(MainMenu.MenuScene);
	}
    
    public void QuitGame() {
        Application.Quit();
	}
}
