using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeWorld : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		if (other.tag.Equals ("MainCharacter")) 
		{
			other.transform.GetComponent<Player>().Die();
		}
	}
}
