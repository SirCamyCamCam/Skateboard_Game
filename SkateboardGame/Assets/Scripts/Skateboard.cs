using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skateboard : MonoBehaviour {
	
	public float JumpForce = 100f;
	public float KickForce = 50f;
	public float TopVelocity = 4f;
	public float MinimumJumpSpeed = 1f;
	public GameObject Wheel1;
	public GameObject Wheel2;
	public GameObject Player;
	public bool TouchingControl = true;
	public bool LandedCorrectly = true;
	public float TrickCompleted = 0f;
	public bool TrickPlaying = false;
	public Text Failed;
	//PopShivut
	private bool PopShivutF = false;
	private bool PopShivutR = false;
	private float PopShivutTimerF = 0f;
	private float PopShivutTimerLengthF = 20f;
	//KickFlip
	private bool KickFlipE = false;
	private bool KickFlipC = false;
	private float KickFlipTimerE = 0f;
	private float KickFlipTimerLengthE = 20f;
	//HeelFlip
	private bool HeelFlipX = false;
	private bool HeelFlipV = false;
	private float HeelFlipTimerX = 0f;
	private float HeelFlipTimerLengthX = 20f;
	//TicTac
	private bool TicTacQ1 = false;
	private bool TicTacQ2 = false;
	private float TicTacTimer = 0f;
	private float TicTacTimerLength = 20f;
	//AlphaFlip
	private bool AlphaFlipF1 = false;
	private bool AlphaFlipC = false;
	private bool AlphaFlipF2 = false;
	private float AlphaFlipTimerF1 = 0f;
	private float AlphaFlipTimerLengthF1 = 20f;
	private float AlphaFlipTimerC = 0f;
	private float AlphaFlipTimerLengthC = 20f;
	//GazelleFlip
	private bool GazelleFlipE1 = false;
	private bool GazelleFlipQ = false;
	private bool GazelleFlipE2 = false;
	private float GazelleFlipTimerE1 = 0f;
	private float GazelleFlipTimerLengthE1 = 20f;
	private float GazelleFlipTimerQ = 0f;
	private float GazelleFlipTimerLengthQ = 20f;
	//720Flip
	private bool t720FlipR1 = false;
	private bool t720FlipG = false;
	private bool t720FlipR2 = false;
	private float t720FlipTimerR1 = 0f;
	private float t720FlipTimerLengthR1 = 20f;
	private float t720FlipTimerG = 0f;
	private float t720FlipTimerLengthG = 20f;
	//360Flip
	private bool t360FlipT = false;
	private bool t360FlipR = false;
	private float t360FlipTimerT = 0f;
	private float t360FlipTimerLengthT = 20f;
	//HangTen
	private bool HangTenT = false;
	private bool HangTenF = false;
	private float HangTenTimerT = 0f;
	private float HangTenTimerLengthT = 10;
	//Random
	private Animator anim;
	private GameObject Visuals;
	private GameObject MainCamera;
	private GameObject SavePoints;
	private float ResetToDefaultTimerKick = 0f;
	private float JumpedForanimationTimer = 0f;
	private float CheckForLandingTimer = 0f;
	private float ZeroVelocityTimer = 0f;
	private float SpacePressedTimer = 0f;
	private float JumpTimer = 0f;
	private float TrickCompletedStatic = 0f;
	private float TopVelocityStatic = 0f;
	private float FailedTextEnabledTimer = 0f;
	private bool ResetToDefaultStateKick = false;
	private bool FacingRight = true;
	private bool PressStarted = false;
	private bool DownAnimationPlaying = false;
	private bool JumpedforAnimation = false;
	private bool ZeroVelocityState = false;
	private bool SpacePressed = false;
	private bool SpacePressedTimerOnce = false;
	private bool SpaceTimer = false;
	private bool FailedTextEnabled = false;

	void Start(){
		MainCamera = GameObject.Find ("Main Camera");
		Visuals = GameObject.Find ("Visual");
		anim = gameObject.GetComponentInChildren<Animator> ();
		if (Application.isEditor) {
		} else {
			SavePoints = GameObject.Find ("Points");
			TopVelocity = SavePoints.GetComponent<SavedPoints>().SaveMaxVelocity;
			KickForce = SavePoints.GetComponent<SavedPoints>().SaveKickForce;
			JumpForce = SavePoints.GetComponent<SavedPoints>().SaveJumpForce;
		}
		TopVelocityStatic = TopVelocity;
	}

	void Update () {
		/*if (Input.GetKeyDown (KeyCode.A) && rigidbody2D.velocity.x < TopVelocity && rigidbody2D.velocity.x > -TopVelocity && TouchingControl == true && ZeroVelocityState == false && SpacePressed == false) {
			rigidbody2D.AddRelativeForce (Vector2.right * -KickForce);
			anim.SetInteger("state", 1);
			ResetToDefaultStateKick = true;
			PressStarted = true;
		}*/
	
		if (rigidbody2D.velocity.x > 0 && FacingRight == false && PressStarted == true) {
			Visuals.transform.localScale = new Vector3(-Visuals.transform.localScale.x, Visuals.transform.localScale.y, Visuals.transform.localScale.z);
			FacingRight = true;
		}
		if(rigidbody2D.velocity.x < 0 && FacingRight == true && PressStarted == true){
			Visuals.transform.localScale = new Vector3(-Visuals.transform.localScale.x, Visuals.transform.localScale.y, Visuals.transform.localScale.z);
			FacingRight = false;
		}
		if (ResetToDefaultStateKick == true && SpacePressed == false) {
			if(ResetToDefaultTimerKick < 10f){
				ResetToDefaultTimerKick = ResetToDefaultTimerKick + 1f;
			} else if(ResetToDefaultTimerKick >= 10f){
				ResetToDefaultStateKick = false;
				ResetToDefaultTimerKick = 0f;
				anim.SetInteger("state", 0);
			}
		}
		if (TouchingControl == false) {
			if(CheckForLandingTimer < 10){
				CheckForLandingTimer = CheckForLandingTimer + 1f;
			} else if(CheckForLandingTimer >= 10){
				if(rigidbody2D.velocity.y < 0 && JumpedforAnimation == false){
					anim.SetInteger("state", 3);
					DownAnimationPlaying = true;
				}
			}
		}
		if (TouchingControl == true && DownAnimationPlaying == true && LandedCorrectly == true) {
			DownAnimationPlaying = false;
			anim.SetInteger("state", 0);
			LandedCorrectly = true;
			SpacePressed = false;
			SpacePressedTimerOnce = false;
		}
		if (TouchingControl == true && DownAnimationPlaying == true && LandedCorrectly == false) {
			ZeroVelocityState = true;
			DownAnimationPlaying = false;
			anim.SetInteger("state", 7);
			LandedCorrectly = true;
			MainCamera.GetComponent<CameraShake>().ShakeIt = true;
			SpacePressed = false;
			SpacePressedTimerOnce = false;
			TrickCompleted = 0f;
			Failed.enabled = true;
			FailedTextEnabled = true;
		}
		if (JumpedforAnimation == true) {
			if(JumpedForanimationTimer < 5f){
				JumpedForanimationTimer = JumpedForanimationTimer + 1f;
			} else if (JumpedForanimationTimer >= 5f){
				JumpedForanimationTimer = 0f;
				JumpedforAnimation = false;
			}
		}
		if (ZeroVelocityState == true) {
			rigidbody2D.velocity = Vector2.zero;
			if(ZeroVelocityTimer < 120f){
				ZeroVelocityTimer = ZeroVelocityTimer + 1f;
			} else if (ZeroVelocityTimer >= 120f){
				ZeroVelocityTimer = 0f;
				ZeroVelocityState = false;
			}
		}
		if (SpacePressed == true) {
			if(SpacePressedTimer < 30 && SpacePressedTimerOnce == false){
				SpacePressedTimer = SpacePressedTimer + 1f;
			} else if(SpacePressedTimer >= 30 && SpacePressedTimerOnce == false){
				SpacePressedTimer = 0f;
				SpacePressedTimerOnce = true;
				TouchingControl = false;
			}
		}
		if (Input.GetKey (KeyCode.Space) && SpaceTimer == true){
			rigidbody2D.AddRelativeForce (Vector2.up * 6);
			if(JumpTimer < 30){
				JumpTimer = JumpTimer + 1f;
			} else if (JumpTimer >= 30f){
				JumpTimer = 0f;
				SpaceTimer = false;
			}
		} else {
			SpaceTimer = false;
		}
		if (TrickCompleted != TrickCompletedStatic && TopVelocity < 10) {
			TrickCompletedStatic = TrickCompleted;
			TopVelocity = TopVelocity + 0.5f;
		}
		if (TrickCompleted == 0) {
			TopVelocity = TopVelocityStatic;
		}
		if (FailedTextEnabled == true) {
			if(FailedTextEnabledTimer < 100f){
				FailedTextEnabledTimer = FailedTextEnabledTimer + 1f;
			} else if(FailedTextEnabledTimer >= 100f){
				FailedTextEnabledTimer = 0f;
				Failed.enabled = false;
				FailedTextEnabled = false;
				anim.SetInteger("state", 0);
			}
		}
		if (Input.GetKeyDown (KeyCode.D) && rigidbody2D.velocity.x < TopVelocity && rigidbody2D.velocity.x > -TopVelocity && TouchingControl == true && ZeroVelocityState == false && SpacePressed == false) {
			rigidbody2D.AddRelativeForce (Vector2.right * KickForce);
			PressStarted = true;
		}
		if (Input.GetKeyDown (KeyCode.D) && TouchingControl == true && ZeroVelocityState == false && SpacePressed == false) {
			anim.SetInteger("state", 1);
			ResetToDefaultStateKick = true;
		}
		if (Input.GetKeyDown (KeyCode.Space) && TouchingControl == true /*&& (rigidbody2D.velocity.x > MinimumJumpSpeed || rigidbody2D.velocity.x < -MinimumJumpSpeed)*/) {
			rigidbody2D.AddForce (Vector2.up * JumpForce);
			anim.SetInteger("state", 2);
			JumpedforAnimation = true;
			SpacePressed = true;
			Wheel1.GetComponent<WheelTouchGround>().Touching = false;
			Wheel2.GetComponent<WheelTouchGround>().Touching = false;
			SpaceTimer = true;
		}
		//Slow Mo
		if (Input.GetKeyDown (KeyCode.Equals) && TouchingControl == false) {
			Time.timeScale = 0.6f;
		}
		//PopShivut
		if (Input.GetKey (KeyCode.J) && PopShivutF == false && TouchingControl == false && TrickPlaying == false) {
			PopShivutF = true;
		}
		if (PopShivutTimerF < PopShivutTimerLengthF && PopShivutF == true && PopShivutR == false) {
				PopShivutTimerF = PopShivutTimerF + 1f;
		} else if (PopShivutTimerF >= PopShivutTimerLengthF) {
			PopShivutTimerF = 0f;
			PopShivutF = false;
		}
		if (PopShivutTimerF > 0 && PopShivutF == true && PopShivutR == true) {
			PopShivutTimerF = 0;
		}
		if (Input.GetKey (KeyCode.K) && PopShivutF == true && PopShivutR == false) {
			Player.gameObject.GetComponent<PointsSystem>().PopShivut = true;
			PopShivutR = true;
			TrickPlaying = true;
		}
		if (PopShivutR == true) {
			PopShivutR = false;
			PopShivutF = false;
		}
		//KickFlip
		if (Input.GetKey (KeyCode.H) && KickFlipE == false && TouchingControl == false && TrickPlaying == false) {
			KickFlipE = true;
		}
		if (KickFlipTimerE < KickFlipTimerLengthE && KickFlipE == true && KickFlipC == false) {
				KickFlipTimerE = KickFlipTimerE + 1f;
		} else if (KickFlipTimerE >= KickFlipTimerLengthE) {
			KickFlipE = false;
			KickFlipTimerE = 0f;
		}
		if (KickFlipTimerE > 0f && KickFlipE == true && KickFlipC == true) {
			KickFlipTimerE = 0f;
		}
		if (Input.GetKey (KeyCode.J) && KickFlipE == true && KickFlipC == false) {
			Player.gameObject.GetComponent<PointsSystem>().KickFlip = true;
			KickFlipC = true;
			TrickPlaying = true;
			anim.SetInteger("state", 11);
		}
		if (KickFlipC == true) {
			KickFlipC = false;
			KickFlipE = false;
		}
		//HeelFlip
		if (Input.GetKey (KeyCode.K) && HeelFlipX == false && TouchingControl == false && TrickPlaying == false) {
			HeelFlipX = true;
		}
		if (HeelFlipTimerX < HeelFlipTimerLengthX && HeelFlipX == true && HeelFlipV == false) {
			HeelFlipTimerX = HeelFlipTimerX + 1f;
		} else if (HeelFlipTimerX >= HeelFlipTimerLengthX) {
			HeelFlipX = false;
			HeelFlipTimerX = 0f;
		}
		if (HeelFlipTimerX > 0f && HeelFlipX == true && HeelFlipV == true) {
			HeelFlipTimerX = 0f;
		}
		if (Input.GetKey (KeyCode.L) && HeelFlipX == true && HeelFlipV == false) {
			Player.gameObject.GetComponent<PointsSystem>().HeelFlip = true;
			HeelFlipV = true;
			anim.SetInteger("state", 5);
			TrickPlaying = true;
		}
		if (HeelFlipV == true) {
			HeelFlipV = false;
			HeelFlipX = false;
		}
		//Tic-Tac
		if (Input.GetKey (KeyCode.P) && TicTacQ1 == false && TrickPlaying == false) {
			TicTacQ1 = true;
		}
		if (TicTacTimer < TicTacTimerLength && TicTacQ1 == true && TicTacQ2 == false) {
				TicTacTimer = TicTacTimer + 1f;	
		} else if (TicTacTimer >= TicTacTimerLength) {
			TicTacTimer = 0f;
		}
		if (TicTacTimer > 0 && TicTacQ2 == true && TicTacQ1 == true) {
			TicTacTimer = 0;
		}
		if (Input.GetKey (KeyCode.P) && TicTacQ1 == true && TicTacQ2 == false) {
			Player.gameObject.GetComponent<PointsSystem>().TicTac = true;
			TicTacQ2 = true;
			TrickPlaying = true;
			anim.SetInteger("state", 10);
		}
		if (TicTacQ2 == true) {
			TicTacQ2 = false;
			TicTacQ1 = false;
		}
		//AlphaFlip
		if (Input.GetKey (KeyCode.Y) && AlphaFlipF1 == false && TouchingControl == false && TrickPlaying == false) {
			AlphaFlipF1 = true;
		}
		if (AlphaFlipTimerF1 < AlphaFlipTimerLengthF1 && AlphaFlipF1 == true && AlphaFlipC == false && AlphaFlipF2 == false) {
			AlphaFlipTimerF1 = AlphaFlipTimerF1 + 1f;
		} else if (AlphaFlipTimerF1 >= AlphaFlipTimerLengthF1) {
			AlphaFlipF1 = false;
			AlphaFlipTimerF1 = 0f;
		}
		if (AlphaFlipTimerF1 > 0f && AlphaFlipF1 == true && AlphaFlipC == true && AlphaFlipF2 == false) {
			AlphaFlipTimerF1 = 0f;
		}
		if (Input.GetKey (KeyCode.U) && AlphaFlipF1 == true && AlphaFlipC == false && AlphaFlipF2 == false) {
			AlphaFlipC = true;
		}
		if (AlphaFlipTimerC < AlphaFlipTimerLengthC && AlphaFlipF1 == true && AlphaFlipC == true && AlphaFlipF2 == false) {
			AlphaFlipTimerC = AlphaFlipTimerC + 1f;
		} else if (AlphaFlipTimerC >= AlphaFlipTimerLengthC) {
			AlphaFlipC = false;
			AlphaFlipF1 = false;
			AlphaFlipTimerC = 0f;
		}
		if (AlphaFlipTimerC > 0f && AlphaFlipC == true && AlphaFlipC == true && AlphaFlipF2 == true) {
			AlphaFlipTimerC = 0f;
		}
		if (Input.GetKey (KeyCode.I) && AlphaFlipF1 == true && AlphaFlipC == true && AlphaFlipF2 == false) {
			AlphaFlipF2 = true;
			Player.gameObject.GetComponent<PointsSystem>().AlphaFlip = true;
			TrickPlaying = true;
		}
		if (AlphaFlipF2 == true) {
			AlphaFlipF1 = false;
			AlphaFlipC = false;
			AlphaFlipF2 = false;
		}
		//GazelleFlip
		if (Input.GetKey (KeyCode.U) && GazelleFlipE1 == false && TouchingControl == false && TrickPlaying == false) {
			GazelleFlipE1 = true;
		}
		if (GazelleFlipTimerE1 < GazelleFlipTimerLengthE1 && GazelleFlipE1 == true && GazelleFlipQ == false && GazelleFlipE2 == false) {
			GazelleFlipTimerE1 = GazelleFlipTimerE1 + 1f;
		} else if (GazelleFlipTimerE1 >= GazelleFlipTimerLengthE1) {
			GazelleFlipE1 = false;
			GazelleFlipTimerE1 = 0f;
		}
		if (GazelleFlipTimerE1 > 0f && GazelleFlipE1 == true && GazelleFlipQ == true && GazelleFlipE2 == false) {
			GazelleFlipTimerE1 = 0f;
		}
		if (Input.GetKey (KeyCode.I) && GazelleFlipE1 == true && GazelleFlipQ == false && GazelleFlipE2 == false) {
			GazelleFlipQ = true;
		}
		if (GazelleFlipTimerQ < GazelleFlipTimerLengthQ && GazelleFlipE1 == true && GazelleFlipQ == true && GazelleFlipE2 == false) {
			GazelleFlipTimerQ = GazelleFlipTimerQ + 1f;
		} else if (GazelleFlipTimerQ >= GazelleFlipTimerLengthQ) {
			GazelleFlipQ = false;
			GazelleFlipE1 = false;
			GazelleFlipTimerQ = 0f;
		}
		if (GazelleFlipTimerQ > 0f && GazelleFlipQ == true && GazelleFlipQ == true && GazelleFlipE2 == true) {
			GazelleFlipTimerQ = 0f;
		}
		if (Input.GetKey (KeyCode.O) && GazelleFlipE1 == true && GazelleFlipQ == true && GazelleFlipE2 == false) {
			GazelleFlipE2 = true;
			Player.gameObject.GetComponent<PointsSystem>().GazelleFlip = true;
			anim.SetInteger("state", 6);
			TrickPlaying = true;
		}
		if (GazelleFlipE2 == true) {
			GazelleFlipE1 = false;
			GazelleFlipQ = false;
			GazelleFlipE2 = false;
		}
		//720Flip
		if (Input.GetKey (KeyCode.T) && t720FlipR1 == false && TouchingControl == false && TrickPlaying == false) {
			t720FlipR1 = true;
		}
		if (t720FlipTimerR1 < t720FlipTimerLengthR1 && t720FlipR1 == true && t720FlipG == false && t720FlipR2 == false) {
			t720FlipTimerR1 = t720FlipTimerR1 + 1f;
		} else if (t720FlipTimerR1 >= t720FlipTimerLengthR1) {
			t720FlipR1 = false;
			t720FlipTimerR1 = 0f;
		}
		if (t720FlipTimerR1 > 0f && t720FlipR1 == true && t720FlipG == true && t720FlipR2 == false) {
			t720FlipTimerR1 = 0f;
		}
		if (Input.GetKey (KeyCode.Y) && t720FlipR1 == true && t720FlipG == false && t720FlipR2 == false) {
			t720FlipG = true;
		}
		if (t720FlipTimerG < t720FlipTimerLengthG && t720FlipR1 == true && t720FlipG == true && t720FlipR2 == false) {
			t720FlipTimerG = t720FlipTimerG + 1f;
		} else if (t720FlipTimerG >= t720FlipTimerLengthG) {
			t720FlipG = false;
			t720FlipR1 = false;
			t720FlipTimerG = 0f;
		}
		if (t720FlipTimerG > 0f && t720FlipG == true && t720FlipR1 == true && t720FlipR2 == true) {
			t720FlipTimerG = 0f;
		}
		if (Input.GetKey (KeyCode.U) && t720FlipR1 == true && t720FlipG == true && t720FlipR2 == false) {
			t720FlipR2 = true;
			Player.gameObject.GetComponent<PointsSystem>().t720Flip = true;
			TrickPlaying = true;
			anim.SetInteger("state", 9);
		}
		if (t720FlipR2 == true) {
			t720FlipR1 = false;
			t720FlipG = false;
			t720FlipR2 = false;
		}
		//360Flip
		if (Input.GetKey (KeyCode.B) && t360FlipT == false && TouchingControl == false && TrickPlaying == false) {
			t360FlipT = true;
		}
		if (t360FlipTimerT < t360FlipTimerLengthT && t360FlipT == true && t360FlipR == false) {
			t360FlipTimerT = t360FlipTimerT + 1f;
		} else if (t360FlipTimerT >= t360FlipTimerLengthT) {
			t360FlipT = false;
			t360FlipTimerT = 0f;
		}
		if (t360FlipTimerT > 0f && t360FlipT == true && t360FlipR == true) {
			t360FlipTimerT = 0f;
		}
		if (Input.GetKey (KeyCode.N) && t360FlipR == false && t360FlipT == true) {
			Player.gameObject.GetComponent<PointsSystem>().t360Flip = true;
			t360FlipR = true;
			TrickPlaying = true;
			anim.SetInteger("state", 8);
		}
		if (t360FlipR == true) {
			t360FlipR = false;
			t360FlipT = false;
		}
		//HangTen
		if (Input.GetKey (KeyCode.N) && HangTenT == false && TouchingControl == false && TrickPlaying == false) {
			t360FlipT = true;
		}
		if (HangTenTimerT < HangTenTimerLengthT && HangTenT == true && HangTenF == false) {
			HangTenTimerT = HangTenTimerT + 1f;
		} else if (HangTenTimerT >= HangTenTimerLengthT) {
			HangTenT = false;
			HangTenTimerT = 0f;
		}
		if (HangTenTimerT > 0f && HangTenT == true && HangTenF == true) {
			HangTenTimerT = 0f;
		}
		if (Input.GetKey (KeyCode.M) && HangTenF == true && HangTenT == false) {
			Player.gameObject.GetComponent<PointsSystem>().HangTen = true;
			HangTenF = true;
			TrickPlaying = true;
		}
		if (HangTenF == true) {
			HangTenF = false;
			HangTenT = false;
		}
	}
}