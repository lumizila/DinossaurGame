using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meat : MonoBehaviour {
	public Player player;
	AudioSource audio;

	void Start()
	{
		AudioSource audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player"){
			this.GetComponent<AudioSource>().Play();
			player.life = player.life + 1;
			StartCoroutine (Wait ());
		}
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (0.5f);
		Destroy (this.gameObject);
	}
}
