using UnityEngine;
using System.Collections;

public class SavedPoints : MonoBehaviour {

	public float SavePoints;
	public float SaveKickForce = 100f;
	public float SaveJumpForce = 250f;
	public float SaveMaxVelocity = 7f;

	void Update () {
		DontDestroyOnLoad (this);
		if (Application.loadedLevelName == "StartScene") {
			Application.LoadLevel("Menu");
		}
		if (Input.GetKey (KeyCode.Period)) {
			SavePoints = 99999999f;
		}
	}

	public void AddKickForce () {
		if (SaveKickForce < 400) {
			SavePoints = SavePoints - 10f;
			SaveKickForce = SaveKickForce + 50f;
		}
	}

	public void AddJumpForce () {
		if (SaveJumpForce < 600) {
			SavePoints = SavePoints - 12f;
			SaveJumpForce = SaveJumpForce + 50f;
		}
	}

	public void AddMaxVelocity () {
		if (SaveMaxVelocity < 12) {
			SavePoints = SavePoints - 15f;
			SaveMaxVelocity = SaveMaxVelocity + 1f;
		}
	}
}
