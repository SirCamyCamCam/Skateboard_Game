using UnityEngine;
using System.Collections;

public class WheelTouchGround : MonoBehaviour {

	public bool Touching = true;
	public GameObject Player;
	public bool Trick = false;
	public bool Wheel1 = false;
	public bool Wheel2 = false;
	public bool HitRamp = false;
	public float HitRampTimer = 0f;
	public bool SecondWheel = false;

	private float WheelCorrectionTimer = 0f;
	private GameObject Wheel1GameObject;
	private GameObject Wheel2GameObject;

	void Start(){
		if (Wheel1 == true) {
			Wheel2GameObject = GameObject.Find ("Wheel2");
		}
		if (Wheel2 == true) {
			Wheel1GameObject = GameObject.Find ("Wheel1");
		}
	}

	void Update () {
		if (Touching == true) {
			if(Trick == true){
				Player.gameObject.GetComponent<Skateboard>().LandedCorrectly = false;
				Player.gameObject.GetComponent<PointsSystem>().Trick = false;
				Trick = false;
			}
			Player.gameObject.GetComponent<Skateboard> ().TouchingControl = true;
			if (Time.timeScale < 1f) {
					Time.timeScale = 1;
			}
		} else if (Touching == false) {
			Player.gameObject.GetComponent<Skateboard> ().TouchingControl = false;
		}
		/*if (Wheel1 == true) {
			if(Wheel2GameObject.GetComponent<WheelTouchGround>().Touching != Touching){
				if(WheelCorrectionTimer < 30f){
					WheelCorrectionTimer = WheelCorrectionTimer + 1f;
				} else if (WheelCorrectionTimer >= 30f){
					if(Wheel2GameObject.GetComponent<WheelTouchGround>().Touching == false && Touching == true){
						Wheel2GameObject.GetComponent<WheelTouchGround>().Touching = true;
						WheelCorrectionTimer = 0f;
					} 
				}
			}
		}*/
		if (Wheel2 == true) {
			if(Wheel1GameObject.GetComponent<WheelTouchGround>().Touching != Touching){
				if(WheelCorrectionTimer < 10f){
					WheelCorrectionTimer = WheelCorrectionTimer + 1f;
				} else if (WheelCorrectionTimer >= 10f){
					if(Wheel1GameObject.GetComponent<WheelTouchGround>().Touching == true && Touching == false){
						Wheel1GameObject.GetComponent<WheelTouchGround>().Touching = false;
						WheelCorrectionTimer = 0f;
					} 
				}
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "floor" || col.gameObject.tag == "Obsticle" || col.gameObject.tag == "Ramp") {
			Touching = true;
		}
	}
	void OnTriggerExit2D (Collider2D col){
		if (col.gameObject.tag == "JumpCollider" && SecondWheel == true) {
			Touching  = false;		
		}
	}
}
