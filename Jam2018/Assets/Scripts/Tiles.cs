using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
	public enum myType
	{
		m_Dot,
		m_Hash,
		m_LeftArrow,
		m_P,
		m_Plus,
		m_Target,
	}
	public enum myProperty
	{
		Walkable,
		Dieable,
		Interactable,
		Winable
	}
	public myProperty property;
	public myType type;
    public string myString;


	void Awake(){
		switch (type) {
		case myType.m_Dot:
			myString = myType.m_Dot.ToString();
			break;
		case myType.m_Hash:
			myString = myType.m_Hash.ToString();
			break;
		case myType.m_LeftArrow:
			myString = myType.m_LeftArrow.ToString();

			break;
		case myType.m_P:
			myString = myType.m_P.ToString();

			break;
		case myType.m_Plus:
			myString = myType.m_Plus.ToString();
			break;
		case myType.m_Target:
			myString = myType.m_Target.ToString();
			break;
		default:
			break;

		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals ("MainCharacter")) 
		{
			other.transform.GetComponent<Player>().OnDestination(this.transform, this.property);
		}
			
	}
		


}
