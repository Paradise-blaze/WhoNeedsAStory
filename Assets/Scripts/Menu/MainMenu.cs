using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int MenuScene;

	private void Start() {
        //Debug.Log("Scene:" + SceneManager.GetSceneByPath("Assets/Scenes/MainScene123"));
        MenuScene = SceneManager.GetActiveScene().buildIndex;
    }

	public void GameStart(){
        SceneManager.LoadScene(1);
    }

    public void Quit(){
        Application.Quit();
    }
}
