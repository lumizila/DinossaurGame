using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	public string SceneName;

	public void Load(){
		StartCoroutine (Wait ());

	}
	IEnumerator Wait(){
		yield return new WaitForSeconds(0.8f);
		SceneManager.LoadScene(SceneName);
	}
}
