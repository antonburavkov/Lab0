using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player") {
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}
}
