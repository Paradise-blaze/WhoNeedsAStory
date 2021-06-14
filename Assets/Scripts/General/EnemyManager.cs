using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
	#region Singleton

	public static EnemyManager instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of EnemyManager");
			return;
		}
		instance = this;
	}

	#endregion

	public int enemyCount = 0;

	void Update()
    {
		if (enemyCount == 0)
        {
			int levelAt = PlayerPrefs.GetInt("levelAt", 2);
			PlayerPrefs.SetInt("levelAt", levelAt + 1);

			SceneManager.LoadScene(0);
			Cursor.lockState = CursorLockMode.None;
		}
    }
}
