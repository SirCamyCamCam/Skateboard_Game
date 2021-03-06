using UnityEngine;
using System.Collections;

public class TakeMoral : MonoBehaviour {

	public Canvas LostPoints;
	public Canvas Morale;
	public GameObject SavePoints;

	void Start(){
				if (Application.isEditor) {
				} else {
						SavePoints = GameObject.Find ("Points");
				}
		LostPoints.enabled = false;
		}

	public void ButtonPressed (int index){
		Morale.enabled = false;
		LostPoints.enabled = true;
		if (Application.isEditor) {
		} else {
			SavePoints.GetComponent<SavedPoints> ().SavePoints = SavePoints.GetComponent<SavedPoints> ().SavePoints - 15f;
		}
	}
}
