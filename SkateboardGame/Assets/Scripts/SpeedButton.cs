using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedButton : MonoBehaviour {

	public GameObject SavePoints;
	public Text Loading;
	
	void Start () {
		SavePoints = GameObject.Find ("Points");
	}
	
	public void SpeedPressed (int index){
		if (SavePoints.GetComponent<SavedPoints> ().SavePoints >= 15f) {
			SavePoints.GetComponent<SavedPoints>().AddMaxVelocity();
		}
	}
	
	void Update(){
		if(Input.GetKey(KeyCode.Escape)){
			Loading.enabled = true;
			Application.LoadLevel ("Menu");
		}
	}
}
