using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spinossauro : MonoBehaviour {

	public bool playerInArea; 
	public Player player;
	public AudioSource audioWin;
	public AudioSource audioLoose;
	public Sprite front;
	public Sprite side;
	private bool sideway;

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
		InvokeRepeating ("Move", 1.0f, 0.9f);
		sideway = true;
	}

	void Move(){
		if (sideway == true) {
			sideway = false;
			this.GetComponent<SpriteRenderer> ().sprite = front;
		} else {
			sideway = true;
			this.GetComponent<SpriteRenderer> ().sprite = side;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) == true) {
			if (playerInArea == true) {
				if (player.activePlayer == "rex") {
					if (player.life > 0) {
						StartCoroutine (Win ());
					} else {
						StartCoroutine (Loose ());
					}
				} else {
					StartCoroutine (Loose ());
				}
			}
		}
	}

	IEnumerator Loose(){
		audioLoose.Play ();
		yield return new WaitForSeconds(0.8f);
		SceneManager.LoadScene("Over");

	}

	IEnumerator Win(){
		audioWin.Play ();
		yield return new WaitForSeconds(0.8f);
		Destroy (this.gameObject);
	}
		
}
