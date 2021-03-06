using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	
	public Transform Player;
	public float damping = 0.3f;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;
	public float MinYPosRestriction = -1;
	public float MaxYPosRestriction = 1;
	public float MinXPosRestriction = -1;
	public float MaxXPosRestriction = 1;
	
	float offsetZ = -10;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;

	
	void FixedUpdate () {
			float xMoveDelta = (Player.position - lastTargetPosition).x;
			bool updateLookAheadTarget = Mathf.Abs (xMoveDelta) > lookAheadMoveThreshold;
			if (updateLookAheadTarget) {
				lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign (xMoveDelta);
			} else {
				lookAheadPos = Vector3.MoveTowards (lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
			}
			Vector3 aheadTargetPos = Player.position + lookAheadPos + Vector3.forward * offsetZ;
			Vector3 newPos = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, damping);
			newPos = new Vector3 (Mathf.Clamp (newPos.x, MinXPosRestriction, MaxXPosRestriction), Mathf.Clamp (newPos.y, MinYPosRestriction, MaxYPosRestriction), newPos.z);
			transform.position = newPos;
			lastTargetPosition = Player.position;		
		}
}