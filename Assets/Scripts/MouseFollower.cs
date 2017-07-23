using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour 
{
	[SerializeField]
	private float SmoothTime = 0.5f;
	[SerializeField]
	private float MaxSpeed = 1f;
	[SerializeField]
	private float GoodEnoughRange = 5f;
	[SerializeField]
	private float SlowdownSpeed = 0.25f;

	private new Rigidbody2D rigidbody;

	private Vector3 targetPosition;

	// Use this for initialization
	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		targetPosition.z = 0;

        float distanceToTarget = (transform.position - targetPosition).magnitude;
		if (distanceToTarget > GoodEnoughRange)
		{
			Vector3 velocity = rigidbody.velocity;
			Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime, MaxSpeed);
			rigidbody.velocity = velocity;
		}
		else
		{
			rigidbody.velocity = Vector2.MoveTowards(rigidbody.velocity, Vector2.zero, SlowdownSpeed * Time.deltaTime);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position, targetPosition);
		Gizmos.DrawWireSphere(targetPosition, GoodEnoughRange);
	}
}
