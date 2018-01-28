using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAttack : MonoBehaviour {


	public Animator animator;
	private int random;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		random = Random.Range (0, 1000);
		if (random < 10)
			animator.Play ("Attack");
	}
}
