using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public Canvas Loadng;
	private float timer;
	private bool Enable = false;

	void Start(){
		Loadng.enabled = false;
	}

	public void PlayPressed (int index){
		Loadng.enabled = true;
		Enable = true;
	}

	void Update(){
		if (timer < 5f && Enable == true) {
			timer = timer + 1f;
		} else if (timer >= 5f){
			Application.LoadLevel ("TestScene");
		}
	}
}
