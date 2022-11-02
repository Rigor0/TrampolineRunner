using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
	public void Restart()
	{
		SceneManager.LoadScene("Level");
	}

	public void Shop()
	{
		SceneManager.LoadScene("Shop");
	}

	
}
