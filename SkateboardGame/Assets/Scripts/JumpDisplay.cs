using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JumpDisplay : MonoBehaviour {

	public GameObject SavePoints;
	public Text points;
	
	void Start () {
		if (Application.isEditor) {
		} else {
			SavePoints = GameObject.Find ("Points");
		}
	}
	
	void Update () {
		if (Application.isEditor) {
		} else {
			points.text = "Jump Force: " + SavePoints.GetComponent<SavedPoints> ().SaveJumpForce;
		}
	}
}
