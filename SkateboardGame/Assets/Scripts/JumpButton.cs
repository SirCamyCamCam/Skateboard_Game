using UnityEngine;
using System.Collections;

public class JumpButton : MonoBehaviour {

	public GameObject SavePoints;
	
	void Start () {
		SavePoints = GameObject.Find ("Points");
	}

	public void JumpPressed (int index){
		if (SavePoints.GetComponent<SavedPoints> ().SavePoints >= 12f) {
			SavePoints.GetComponent<SavedPoints>().AddJumpForce();
		}
	}
}
