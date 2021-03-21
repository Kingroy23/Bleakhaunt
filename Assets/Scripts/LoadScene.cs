using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
	public string SceneToLoad = "";
	public void Load()
	{
		SceneManager.LoadScene(SceneToLoad);
	}
}
