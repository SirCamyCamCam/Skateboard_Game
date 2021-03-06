using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	public Canvas Loading;
	private float timer;
	private bool Enable = false;
	
	void Start(){
		Loading.enabled = false;
	}

	public void MenuPressed (int index){
		Loading.enabled = true;
		Enable = true;
	}

	void Update(){
		if (timer < 5f && Enable == true) {
			timer = timer + 1f;
		} else if (timer >= 5f){
			Application.LoadLevel ("Menu");
		}
	}
}
