using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionMenu : MonoBehaviour
{
    public static int MenuScene;

    public GameObject mainMenu;
    public GameObject levelSelectionMenu;
    public Button[] levelButtons;

    public void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void Update()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void LevelSelect(int levelNumber)
    {
        SceneManager.LoadScene(MenuScene + levelNumber);
    }

    public void Return()
    {
        levelSelectionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
