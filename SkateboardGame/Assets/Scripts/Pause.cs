using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	public Canvas PauseCanvas;
	public GameObject Player;
	private bool Paused = false; 
	private Vector2 Velocity;
	private bool RunVelocityOnce = false;
	
	void Start(){
		PauseCanvas.enabled = false;
	}
	
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape)){
			if(Paused == false){
				Velocity = Player.rigidbody2D.velocity;
				Paused = true;
			} else if(Paused == true){
				Paused = false;
			}
		}
		if (Paused == true) {
			Player.rigidbody2D.isKinematic = true;
			RunVelocityOnce = false;
			Time.timeScale = 0;
			PauseCanvas.enabled = true;
		} else if (Paused == false){
			if(RunVelocityOnce == false){
				Player.rigidbody2D.isKinematic = false;
				Player.rigidbody2D.velocity = Velocity;
				RunVelocityOnce = true;
			}
			Time.timeScale = 1;
			PauseCanvas.enabled = false;
		}
	}
	
	public void PauseButton(int index){
		Paused = false;
	}
}
