using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsDisplay : MonoBehaviour {
	
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
			points.text = "Points: " + SavePoints.GetComponent<SavedPoints> ().SavePoints;
		}
	}
}
