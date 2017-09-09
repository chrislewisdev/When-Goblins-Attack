using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpriteFlipper : MonoBehaviour 
{
	[SerializeField]
	private float ThresholdVelocity = 0.1f;

	private new Rigidbody2D rigidbody;
	private NavMeshAgent navMeshAgent;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		navMeshAgent = GetComponentInParent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (rigidbody && Mathf.Abs(rigidbody.velocity.x) > ThresholdVelocity)
		{
			sprite.flipX = rigidbody.velocity.x < 0;
		}

		if (navMeshAgent && Mathf.Abs(navMeshAgent.velocity.x) > ThresholdVelocity)
		{
			sprite.flipX = navMeshAgent.velocity.x < 0;
		}
	}
}
