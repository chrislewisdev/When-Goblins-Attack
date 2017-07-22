using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour 
{
	[SerializeField]
	private float SmoothTime = 0.5f;
	[SerializeField]
	private float MaxSpeed = 1f;

	private Vector3 velocity;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		targetPosition.z = 0;

		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime, MaxSpeed);
	}
}
