using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OrderManager : MonoBehaviour {

	public enum Order
	{
		Walk,
		Jump,
		Catch,
		Hide,
		Punch,
		Fight
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
			orderStack.Add (Order.Catch);
				break;

			case "m_Target":
			orderStack.Add (Order.Fight);
				break;

			case "m_Plus":
			orderStack.Add (Order.Hide);
				break;

			case "m_P":
			orderStack.Add (Order.Jump);
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
