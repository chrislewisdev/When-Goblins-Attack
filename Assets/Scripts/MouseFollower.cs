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
	private Animator animator;
	private SpriteRenderer sprite;

	private Vector3 targetPosition;
	private Vector3 velocity;

	// Use this for initialization
	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		targetPosition.z = 0;

        float distanceToTarget = (transform.position - targetPosition).magnitude;
		if (distanceToTarget > GoodEnoughRange)
		{
			// rigidbody.MovePosition(Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime, MaxSpeed));
			Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime, MaxSpeed);
			rigidbody.velocity = velocity;
		}
		else
		{
			rigidbody.velocity = Vector2.MoveTowards(rigidbody.velocity, Vector2.zero, SlowdownSpeed * Time.deltaTime);
		}
		// else 
		// {
		// 	velocity = rigidbody.velocity;
		// }

		sprite.flipX = velocity.x < 0;

		animator.SetFloat("velocity", rigidbody.velocity.magnitude);
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position, targetPosition);
		Gizmos.DrawWireSphere(targetPosition, GoodEnoughRange);
	}
}
