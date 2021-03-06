using UnityEngine;
using System.Collections;

public class KickButton : MonoBehaviour {

	public GameObject SavePoints;
	
	void Start () {
		SavePoints = GameObject.Find ("Points");
	}
	
	public void KickPressed (int index){
		if (SavePoints.GetComponent<SavedPoints> ().SavePoints >= 10f) {
			SavePoints.GetComponent<SavedPoints>().AddKickForce();
		}
	}
}
