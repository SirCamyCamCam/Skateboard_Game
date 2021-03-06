using UnityEngine;
using System.Collections;

public class ContinueGameMoral : MonoBehaviour {

	public Canvas CloseCurrent;
	public GameObject PLayer;

	public void ShopPressed (int index){
		CloseCurrent.enabled = false;
		PLayer.rigidbody2D.isKinematic = false;
	}
}
