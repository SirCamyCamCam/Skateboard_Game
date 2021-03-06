using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsSystem : MonoBehaviour {

	public float Points = 0f;
	public float PointDifference = 0f;
	public float PointOriginal = 0f;
	public bool DoubleSpace = false;
	public GameObject Wheel1;
	public GameObject Wheel2;
	public bool Trick = false;
	private bool TrickTextEnabled = false;
	private float TrickTextEnabledTimer = 0f;
	//PopShivut
	public bool PopShivut = false;
	public Text PopShivutText;
	private bool PopShivutActive = false;
	private float PopShivutTimer = 0f;
	private float PopShivutTimerLength = 30f;
	//KickFlip
	public bool KickFlip = false;
	public Text KickFlipText;
	private bool KickFlipActive = false;
	private float KickFlipTimer = 0f;
	private float KickFlipTimerLength = 30f;
	//HeelFlip
	public bool HeelFlip = false;
	public Text HeelFlipText;
	private bool HeelFlipActive = false;
	private float HeelFlipTimer = 0f;
	private float HeelFlipTimerLength = 45f;
	//TicTac
	public bool TicTac = false;
	public Text TicTacText;
	private bool TicTacActive = false;
	private float TicTacTimer = 0f;
	private float TicTacTimerLength = 30f;
	//AlphaFlip
	public bool AlphaFlip = false;
	public Text AlphaFlipText;
	private bool AlphaFlipActive = false;
	private float AlphaFlipTimer = 0f;
	private float AlphaFlipTimerLength = 30f;
	//GazelleFlip
	public bool GazelleFlip = false;
	public Text GazelleFlipText;
	private bool GazelleFlipActive = false;
	private float GazelleFlipTimer = 0f;
	private float GazelleFlipTimerLength = 60f;
	//720Flip
	public bool t720Flip = false;
	public Text t720GlipText;
	private bool t720FlipActive = false;
	private float t720FlipTimer = 0f;
	private float t720FlipTimerLength = 80f;
	//360flip
	public bool t360Flip = false;
	public Text t360FlipText;
	private bool t360FlipActive = false;
	private float t360FlipTimer = 0f;
	private float t360FlipTimerLength = 50f;
	//HangTen
	public bool HangTen = false;
	public Text HangTenText;
	private bool HangTenActive = false;
	private float HangTenTimer = 0f;
	private float HangTenTimerLength = 30f;

	void Start() {
		if (Application.isEditor) {
		} else {
			Points = GameObject.Find ("Points").GetComponent<SavedPoints> ().SavePoints;
		}
	}

	void Update () {
		if(Points != PointOriginal){
			PointDifference = Points - PointOriginal;
			Debug.Log(PointDifference + " Points Added");
			PointOriginal = Points;
			if(Application.isEditor){
			} else {
				GameObject.Find ("Points").GetComponent<SavedPoints> ().SavePoints = Points;
			}
		}

		//PopShivut
		if (PopShivut == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = true;
			Wheel2.GetComponent<WheelTouchGround>().Trick = true;
			Debug.Log("Pop Shivut");
			PopShivut = false;
			PopShivutActive = true;
			Trick = true;
		}
		if (PopShivutTimer < PopShivutTimerLength && PopShivutActive == true && Trick == true) {
				PopShivutTimer = PopShivutTimer + 1;
		} else if (PopShivutTimer >= PopShivutTimerLength && Trick == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			PopShivutActive = false;
			PopShivutTimer = 0f;
			Points = Points + 4f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
			gameObject.GetComponent<Skateboard>().TrickCompleted = gameObject.GetComponent<Skateboard>().TrickCompleted + 1f;
			PopShivutText.enabled = true;
			TrickTextEnabled = true;
		} else if (Trick == false && PopShivutActive == true){
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			PopShivutActive = false;
			PopShivutTimer = 0f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
		}

		//Kickflip
		if (KickFlip == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = true;
			Wheel2.GetComponent<WheelTouchGround>().Trick = true;
			Debug.Log("Kick Flip");
			KickFlip = false;
			KickFlipActive = true;
			Trick = true;
		}
		if (KickFlipTimer < KickFlipTimerLength && KickFlipActive == true && Trick == true) {
				KickFlipTimer = KickFlipTimer + 1f;
		} else if (KickFlipTimer >= KickFlipTimerLength && Trick == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			KickFlipActive = false;
			KickFlipTimer = 0f;
			Points = Points + 3f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
			gameObject.GetComponent<Skateboard>().TrickCompleted = gameObject.GetComponent<Skateboard>().TrickCompleted + 1f;
			KickFlipText.enabled = true;
			TrickTextEnabled = true;
		} else if(Trick == false && KickFlipActive == true){
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			KickFlipActive = false;
			KickFlipTimer = 0f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
		}

		//HeelFlip
		if (HeelFlip == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = true;
			Wheel2.GetComponent<WheelTouchGround>().Trick = true;
			Debug.Log("Heel Flip");
			HeelFlip = false;
			HeelFlipActive = true;
			Trick = true;
		}
		if (HeelFlipTimer < HeelFlipTimerLength && HeelFlipActive == true && Trick == true) {
			HeelFlipTimer = HeelFlipTimer + 1f;
		} else if (HeelFlipTimer >= HeelFlipTimerLength && Trick == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			HeelFlipActive = false;
			HeelFlipTimer = 0f;
			Points = Points + 3f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
			gameObject.GetComponent<Skateboard>().TrickCompleted = gameObject.GetComponent<Skateboard>().TrickCompleted + 1f;
			HeelFlipText.enabled = true;
			TrickTextEnabled = true;
		} else if (Trick == false && HeelFlipActive == true){
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			HeelFlipActive = false;
			HeelFlipTimer = 0f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
		}

		//TicTac
		if (TicTac == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = true;
			Wheel2.GetComponent<WheelTouchGround>().Trick = true;
			Debug.Log("Tic Tac");
			TicTac = false;
			TicTacActive = true;
			Trick = true;
		}
		if (TicTacTimer < TicTacTimerLength && TicTacActive == true && Trick == true) {
				TicTacTimer = TicTacTimer + 1f;
		} else if (TicTacTimer >= TicTacTimerLength && Trick == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			TicTacActive = false;
			TicTacTimer = 0f;
			Points = Points + 1f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
			gameObject.GetComponent<Skateboard>().TrickCompleted = gameObject.GetComponent<Skateboard>().TrickCompleted + 1f;
			TicTacText.enabled = true;
			TrickTextEnabled = true;
		} else if (Trick == false && TicTacActive == true){
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			TicTacActive = false;
			TicTacTimer = 0f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
		}
		//AlphaFlip
		if (AlphaFlip == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = true;
			Wheel2.GetComponent<WheelTouchGround>().Trick = true;
			Debug.Log("Alpha Flip");
			AlphaFlip = false;
			AlphaFlipActive = true;
			Trick = true;
		}
		if (AlphaFlipTimer < AlphaFlipTimerLength && AlphaFlipActive == true && Trick == true) {
			AlphaFlipTimer = AlphaFlipTimer + 1f;
		} else if (AlphaFlipTimer >= AlphaFlipTimerLength && Trick == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			AlphaFlipActive = false;
			AlphaFlipTimer = 0f;
			Points = Points + 5f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
			gameObject.GetComponent<Skateboard>().TrickCompleted = gameObject.GetComponent<Skateboard>().TrickCompleted + 1f;
			AlphaFlipText.enabled = true;
			TrickTextEnabled = true;
		} else if (Trick == false && AlphaFlipActive == true){
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			AlphaFlipActive = false;
			AlphaFlipTimer = 0f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
		}
		//GazelleFlip
		if (GazelleFlip == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = true;
			Wheel2.GetComponent<WheelTouchGround>().Trick = true;
			Debug.Log("Gazelle Flip");
			GazelleFlip = false;
			GazelleFlipActive = true;
			Trick = true;
		}
		if (GazelleFlipTimer < GazelleFlipTimerLength && GazelleFlipActive == true && Trick == true) {
			GazelleFlipTimer = GazelleFlipTimer + 1f;
		} else if (GazelleFlipTimer >= GazelleFlipTimerLength && Trick == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			GazelleFlipActive = false;
			GazelleFlipTimer = 0f;
			Points = Points + 5f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
			gameObject.GetComponent<Skateboard>().TrickCompleted = gameObject.GetComponent<Skateboard>().TrickCompleted + 1f;
			GazelleFlipText.enabled = true;
			TrickTextEnabled = true;
		} else if (Trick == false && GazelleFlipActive == true){
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			GazelleFlipActive = false;
			GazelleFlipTimer = 0f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
		}
		//720Flip
		if (t720Flip == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = true;
			Wheel2.GetComponent<WheelTouchGround>().Trick = true;
			Debug.Log("720 Flip");
			t720Flip = false;
			t720FlipActive = true;
			Trick = true;
		}
		if (t720FlipTimer < t720FlipTimerLength && t720FlipActive == true && Trick == true) {
			t720FlipTimer = t720FlipTimer + 1f;
		} else if (t720FlipTimer >= t720FlipTimerLength && Trick == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			t720FlipActive = false;
			t720FlipTimer = 0f;
			Points = Points + 5f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
			gameObject.GetComponent<Skateboard>().TrickCompleted = gameObject.GetComponent<Skateboard>().TrickCompleted + 1f;
			t720GlipText.enabled = true;
			TrickTextEnabled = true;
		} else if(Trick == false && t720FlipActive == true){
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			t720FlipActive = false;
			t720FlipTimer = 0f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
		}
		//360Flip
		if (t360Flip == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = true;
			Wheel2.GetComponent<WheelTouchGround>().Trick = true;
			Debug.Log("360 Flip");
			t360Flip = false;
			t360FlipActive = true;
			Trick = true;
		}
		if (t360FlipTimer < t360FlipTimerLength && t360FlipActive == true && Trick == true) {
			t360FlipTimer = t360FlipTimer + 1f;
		} else if (t360FlipTimer >= t360FlipTimerLength && Trick == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			t360FlipActive = false;
			t360FlipTimer = 0f;
			Points = Points + 4f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
			gameObject.GetComponent<Skateboard>().TrickCompleted = gameObject.GetComponent<Skateboard>().TrickCompleted + 1f;
			t360FlipText.enabled = true;
			TrickTextEnabled = true;
		} else if(Trick == false && t360FlipActive == true){
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			t360FlipActive = false;
			t360FlipTimer = 0f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
		}
		//HangTen
		if (HangTen == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = true;
			Wheel2.GetComponent<WheelTouchGround>().Trick = true;
			Debug.Log("Hang Ten");
			HangTen = false;
			HangTenActive = true;
			Trick = true;
		}
		if (HangTenTimer < HangTenTimerLength && HangTenActive == true && Trick == true) {
			HangTenTimer = HangTenTimer + 1f;
		} else if (HangTenTimer >= HangTenTimerLength && Trick == true) {
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			HangTenActive = false;
			HangTenTimer = 0f;
			Points = Points + 4f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
			gameObject.GetComponent<Skateboard>().TrickCompleted = gameObject.GetComponent<Skateboard>().TrickCompleted + 1f;
			HangTenText.enabled = true;
			TrickTextEnabled = true;
		} else if (Trick == false && HangTenActive == true){
			Wheel1.GetComponent<WheelTouchGround>().Trick = false;
			Wheel2.GetComponent<WheelTouchGround>().Trick = false;
			HangTenActive = false;
			HangTenTimer = 0f;
			gameObject.GetComponent<Skateboard>().TrickPlaying = false;
		}
		if (TrickTextEnabled == true) {
			if(TrickTextEnabledTimer < 60f){
				TrickTextEnabledTimer = TrickTextEnabledTimer + 1f;
			} else if (TrickTextEnabledTimer >= 60f){
				TrickTextEnabledTimer = 0f;
				TrickTextEnabled = false;
				PopShivutText.enabled = false;
				KickFlipText.enabled = false;
				HeelFlipText.enabled = false;
				TicTacText.enabled = false;
				AlphaFlipText.enabled = false;
				GazelleFlipText.enabled = false;
				t720GlipText.enabled = false;
				t360FlipText.enabled = false;
				HangTenText.enabled = false;
			}
		}
	}
}
