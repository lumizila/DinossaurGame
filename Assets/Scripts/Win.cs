using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Win : MonoBehaviour {
	public Player player;
	AudioSource audio;
	public bool playerInArea; 
	public GameObject warning;
	void Start()
	{
		AudioSource audio = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			playerInArea = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			playerInArea = false;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) == true) {
			if (playerInArea == true) {
				if (player.hasKey) {
					StartCoroutine (Wait ());
				} else {
					warning.GetComponentInChildren<TextMeshProUGUI> ().SetText ("No Key :( !!");
					warning.SetActive (true);
					StartCoroutine (Wait2 ());
				}
			}
		}
	}

	IEnumerator Wait2(){
		yield return new WaitForSeconds(1);
		warning.SetActive (false);
	}

	IEnumerator Wait(){
		player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
		this.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(0.8f);
		SceneManager.LoadScene("Win");
	}
}
