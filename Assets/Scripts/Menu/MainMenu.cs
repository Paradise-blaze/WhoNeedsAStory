using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int MenuScene;

    public GameObject mainMenu;
    public GameObject levelSelectionMenu;

    private void Start() {
        MenuScene = SceneManager.GetActiveScene().buildIndex;
    }

	public void LevelSelect(){
        mainMenu.SetActive(false);
        levelSelectionMenu.SetActive(true);
    }

    public void Quit(){
        Application.Quit();
    }
}
