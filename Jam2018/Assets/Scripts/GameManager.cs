using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] destinationBox;
    public GameObject currentBox;
    public GameObject cube;
    public GameObject player;
    public bool letsMove;
    public Vector3[] rotationsCube;
    public int idBox;
    private float speed = .5f;
    private float timeRotation;

    private void Start()
    {
        currentBox = destinationBox[0];
        idBox++;
    }
    private void Update()
    {
        if (letsMove)
            Movement();
        else
            StayInYourBox();

		if(OrderManager.Instance.orderStack.Count > 0) CalculateDestinations ();
    }
    private void Movement()
    {
        Vector3 direccion = (player.transform.position - destinationBox[idBox].transform.position).normalized;
        Vector3 move = player.transform.position - (direccion * speed * Time.deltaTime);
        //player.transform.rotation = destinationBox[idBox].transform.rotation;
         timeRotation += Time.deltaTime * .0035f;
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, destinationBox[idBox].transform.rotation, timeRotation);
        player.transform.position = move;
        if((player.transform.position - destinationBox[idBox].transform.position).magnitude < .05f)
        {
            currentBox = destinationBox[idBox];
			if (idBox < destinationBox.Length - 1)
				idBox++;
			else
			{
				letsMove = false;
			}
        }
    }
    private void StayInYourBox()
    {
        player.transform.position = currentBox.transform.position;
    }
    private void RotateCube()
    {

    }

	public void CalculateDestinations()
	{
		foreach (var order in OrderManager.Instance.orderStack) 
		{
			switch (order) 
			{
			case OrderManager.Order.Catch:
				destinationBox [0].GetComponent<MeshRenderer> ().material.color = Color.green;
				break;
			default:
				destinationBox [0].GetComponent<MeshRenderer> ().material.color = Color.red;
				break;
				
			}
		}
	}

}
