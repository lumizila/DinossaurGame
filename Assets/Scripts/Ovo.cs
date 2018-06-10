using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ovo : MonoBehaviour {
	public bool hasKey;
	public bool playerInArea; 
	public Player player;
	public AudioSource eggAudio;
	public AudioSource keyAudio;
	public GameObject warning;

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

	// Use this for initialization
	void Start () {
		playerInArea = false;
		AudioSource audio = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) == true) {
			if (playerInArea == true) {
				StartCoroutine (Wait ());
			}
		}
	}

	IEnumerator Wait(){
		if (hasKey == true) {
			keyAudio.Play ();
			warning.GetComponentInChildren<TextMeshProUGUI> ().SetText ("You got the key !!");
			warning.SetActive (true);
			player.hasKey = true;
		}
		else{
			eggAudio.Play ();
			player.coins = player.coins + 1;
			warning.GetComponentInChildren<TextMeshProUGUI> ().SetText ("Coins ! Money: " + player.coins.ToString());
			warning.SetActive (true);
		}
		yield return new WaitForSeconds(1);
		warning.SetActive (false);
		Destroy (this.gameObject);
	}
}
