using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {
	public bool playerInArea; 
	public Player player;
	private AudioSource audio;
	public GameObject gate;
	public Sprite buttonOff;

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
		this.GetComponent<AudioSource>().Play();
		this.GetComponent<SpriteRenderer> ().sprite = buttonOff;
		yield return new WaitForSeconds(0.8f);
		Destroy (gate);
	}
}
