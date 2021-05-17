using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;

    public GameObject pauseMenuUI;

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
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GoToMenu() {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(MainMenu.MenuScene);
	}
    
    public void QuitGame() {
        Application.Quit();
	}
}
