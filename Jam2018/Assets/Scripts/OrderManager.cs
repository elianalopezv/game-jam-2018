using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OrderManager : MonoBehaviour {

	public enum Order
	{
		Forward,
		Back,
		Right,
		Left,
		Jump,
		Action
	}
	public static OrderManager Instance;
	public List<Order> orderStack = new List<Order>();

	void Awake()
	{
		if(Instance == null)
			Instance = this;

		CleanOrderStack ();
	}

	public void AddOrder(string command)
	{
		switch (command)
		{
			case "m_LeftArrow":
			orderStack.Add (Order.Forward);
				break;

			case "m_Target":
			orderStack.Add (Order.Back);
				break;

			case "m_Plus":
			orderStack.Add (Order.Right);
				break;

			case "m_P":
			orderStack.Add (Order.Left);
				break;

			case "m_Dot":
			orderStack.Add (Order.Jump);
				break;

			case "m_Hash":
			orderStack.Add (Order.Action);
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

	public void PrintStack()
	{
		foreach (var order in orderStack)
			Debug.Log ("*********** "+ order);

		CleanOrderStack ();
	}

		
}
