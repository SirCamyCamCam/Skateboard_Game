using UnityEngine;
using System.Collections;

public class ShopButton : MonoBehaviour {

	public Canvas Loading;

	public void ShopPressed (int index){
		Loading.enabled = true;
		Application.LoadLevel ("ShopScene");
	}
}
