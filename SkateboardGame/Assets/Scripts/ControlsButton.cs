using UnityEngine;
using System.Collections;

public class ControlsButton : MonoBehaviour {

	public Canvas Loading;
	private float timer;
	private bool Enable = false;
	
	void Start(){
		Loading.enabled = false;
	}
	
	public void ShopPressed (int index){
		Loading.enabled = true;
		Enable = true;
	}

	void Update(){
		if (timer < 5f && Enable == true) {
			timer = timer + 1f;
		} else if (timer >= 5f){
			Application.LoadLevel ("ControlsScene");
		}
	}
}
