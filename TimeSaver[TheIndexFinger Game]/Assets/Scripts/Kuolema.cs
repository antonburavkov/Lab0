using UnityEngine;
using System.Collections;

public class Kuolema : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player") {
			//Liike.dead = true;
			//Liike.deathcooldown = 0.5f;
			KeyboardMove.dead = true;
		}
	}
}
