using UnityEngine;
using System.Collections;

public class LeaveMoral : MonoBehaviour {

	public Canvas TakePoints;
	public Canvas Morale;
	public GameObject SavePoints;
	
	void Start(){
		if (Application.isEditor) {
		} else {
			SavePoints = GameObject.Find ("Points");
		}
		TakePoints.enabled = false;
	}
	
	public void ButtonPressed (int index){
		Morale.enabled = false;
		TakePoints.enabled = true;
		if (Application.isEditor) {
		} else {
			SavePoints.GetComponent<SavedPoints> ().SavePoints = SavePoints.GetComponent<SavedPoints> ().SavePoints + 15f;
		}
	}
}
