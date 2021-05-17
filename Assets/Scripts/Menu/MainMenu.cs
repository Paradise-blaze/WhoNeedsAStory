using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int MenuScene;

	private void Start() {
        MenuScene = SceneManager.GetActiveScene().buildIndex;
    }

	public void GameStart(){
        SceneManager.LoadScene(MenuScene + 1);
    }

    public void Quit(){
        Application.Quit();
    }
}
