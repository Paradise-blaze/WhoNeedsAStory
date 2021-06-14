using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int MenuScene;

    public GameObject mainMenu;
    public GameObject levelSelectionMenu;

    private void Start() {
        MenuScene = SceneManager.GetActiveScene().buildIndex;
        Cursor.lockState = CursorLockMode.None;
    }

	public void LevelSelect(){
        mainMenu.SetActive(false);
        levelSelectionMenu.SetActive(true);
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("levelAt", 2);
    }

    public void Quit(){
        Application.Quit();
    }
}
