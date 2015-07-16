using UnityEngine;
using System.Collections;

public class Addpoints : MonoBehaviour {



void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player") {
			Score.Addpoint();
			gameObject.SetActive(false);
		}
	}
}
