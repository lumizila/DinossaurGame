using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour {
	public Player player;
	AudioSource audio;

	void Start()
	{
		AudioSource audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player"){
			if (player.activePlayer == "rex") {
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
				StartCoroutine (Wait ());
			}
		}
	}

	IEnumerator Wait(){
		this.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(0.8f);
		SceneManager.LoadScene("Over");
	}
}
