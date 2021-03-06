using UnityEngine;
using System.Collections;

public class EndFlippedBoard : MonoBehaviour {

	public bool Touching = false;
	private float Timer;
	private float MaxTimer = 30f;

	void Update () {
		if (Touching == true) {
			if(Timer < MaxTimer){
				Timer = Timer + 1f;
			} else if(Timer >= MaxTimer){
				Timer = 0;
				Application.LoadLevel(Application.loadedLevel);
			}
		} else if( Touching == false){
			Timer = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "floor" && gameObject.transform.name != "Box" && gameObject.transform.name != "Single-Barrel" && gameObject.name != "Tri-Barrel") {
			Touching = true;
		}
	}
	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "floor") {
			Touching = false;
		}
	}
	/*void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "JumpCollider") {
			GameObject.Find("Skateboard").GetComponent<Skateboard>().TouchingControl = false;
			GameObject.Find("Wheel1").GetComponent<WheelTouchGround>().Touching = false;
			GameObject.Find("Wheel2").GetComponent<WheelTouchGround>().Touching = false;
		}
	}*/
}
