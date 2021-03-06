using UnityEngine;
using System.Collections;

public class FoundWallet : MonoBehaviour {

	public Canvas Moral;
	public GameObject Player;

	void Start(){
		Moral.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			Moral.enabled = true;
			Player.rigidbody2D.isKinematic = true;
			Destroy(gameObject);
		}
	}
}
