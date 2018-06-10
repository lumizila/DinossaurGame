using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody2D rigidBody;
	public float speed;
	public string activePlayer;

	public Sprite Rexr;
	public Sprite Rexl;
	public Sprite Rext;
	public Sprite Rexb;
	public Sprite Pteror;
	public Sprite Pterol;
	public Sprite Pterot;
	public Sprite Pterob;

	private SpriteRenderer spriteR;
	public int life;
	public AudioSource RexAudio;
	public AudioSource PteroAudio;
	public bool hasKey;
	public int coins;
	private string direction;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D> ();
		spriteR = gameObject.GetComponent<SpriteRenderer>();
		activePlayer = "rex";
		life = 0;
		hasKey = false;
		coins = 0;
		direction = "right";
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (activePlayer == "ptero") {
			if (moveHorizontal < 0) {
				spriteR.sprite = Pterol;
				direction = "left";
			} else if (moveHorizontal > 0) {
				spriteR.sprite = Pteror;
				direction = "right";
			}

			if (moveVertical < 0) {
				spriteR.sprite = Pterob;
				direction = "bottom";
			} else if (moveVertical > 0) {
				spriteR.sprite = Pterot;
				direction = "top";
			}
		} else {
			if (moveHorizontal < 0) {
				spriteR.sprite = Rexl;
				direction = "left";
			} else if (moveHorizontal > 0) {
				spriteR.sprite = Rexr;
				direction = "right";
			}

			if (moveVertical < 0) {
				spriteR.sprite = Rexb;
				direction = "bottom";
			} else if (moveVertical > 0) {
				spriteR.sprite = Rext;
				direction = "top";
			}
		}

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rigidBody.AddForce (movement*speed);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.X) == true) {
			if (activePlayer == "rex") {
				PteroAudio.Play ();
				activePlayer = "ptero";
				if (direction == "left") {
					spriteR.sprite = Pterol;
				} else if (direction == "right") {
					spriteR.sprite = Pteror;
				} else if (direction == "top") {
					spriteR.sprite = Pterot;
				} else if (direction == "bottom") {
					spriteR.sprite = Pterob;
				}
			} else if (activePlayer == "ptero") {
				RexAudio.Play ();
				activePlayer = "rex";
				if (direction == "left") {
					spriteR.sprite = Rexl;
				} else if (direction == "right") {
					spriteR.sprite = Rexr;
				} else if (direction == "top") {
					spriteR.sprite = Rext;
				} else if (direction == "bottom") {
					spriteR.sprite = Rexb;
				}
			}
		} 
	}
}
