using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Para usar el UI

public class CharacterControl : MonoBehaviour {

	public float speed;
	int coins = 0; // cantidad de monedas
	public Text contadorCoins;
	int heart = 0; // cantidad de vidas
	public Text contadorHeart;


	bool isGrounded =false;

	// Use this for initialization
	void Start () {

	}

	public void clickEnElBoton() {
		this.gameObject.GetComponent <Rigidbody2D> ().AddForce (Vector2.up * 7, ForceMode2D.Impulse); 
	}
	
	void Update () {
		//movimiento
		if (Input.GetKey (KeyCode.RightArrow)) {
			this.gameObject.transform.Translate (speed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.gameObject.transform.Translate (-speed * Time.deltaTime, 0, 0);

		} 

		if (Input.GetKeyDown (KeyCode.Space) && isGrounded == true) {
			this.gameObject.GetComponent <Rigidbody2D> ().AddForce (Vector2.up * 9, ForceMode2D.Impulse); // le agregamos una fuerza hacia arriba

		}
		
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Coin") { 
			coins = coins + 1;
		
			contadorCoins.text = coins.ToString ();

			GameObject.Destroy (coll.gameObject);
		}

			
		if (coll.gameObject.tag == "Heart") { 
			heart = heart + 1;

			contadorHeart.text = heart.ToString ();

			//Destruimos la moneda
			GameObject.Destroy (coll.gameObject);
		}
			
			
		if (coll.gameObject.tag == "caida") {
		}
		if (coll.gameObject.tag == "final") {

			GameObject.Destroy (coll.gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D collision){
		if (collision.collider.gameObject.tag == "isGrounded") {
			isGrounded = true;


		}
	}
	void OnCollisionExit2D (Collision2D collision){
		if (collision.collider.gameObject.tag == "isGrounded") {
			isGrounded = false;

		}
	}



}
