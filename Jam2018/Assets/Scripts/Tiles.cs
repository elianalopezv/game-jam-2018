using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{

	public enum myType
	{
		Hole,
		Walkable,
		Interactive
	}

	public myType type;
    public string myString;

}
