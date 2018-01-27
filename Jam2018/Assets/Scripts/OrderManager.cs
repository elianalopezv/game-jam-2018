using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour {

	public static OrderManager Instance;
	public List<int> orderStack = new List<int>();

	void Awake()
	{
		if(Instance == null)
			Instance = this;


	}

	public void AddOrder(string command)
	{
		switch (command)
		{
			case "m_LeftArrow":
				orderStack.Add (1);
				break;

		default:
			Debug.Log ("Not a command!");
			break;

		}
		
	}

	public void CleanOrderStack ()
	{
		orderStack.Clear ();
	}
		
}
