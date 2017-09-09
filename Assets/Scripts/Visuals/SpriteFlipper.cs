using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour 
{
	[SerializeField]
	private float ThresholdVelocity = 0.1f;

	private new Rigidbody2D rigidbody;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Mathf.Abs(rigidbody.velocity.x) > ThresholdVelocity)
		{
			sprite.flipX = rigidbody.velocity.x < 0;
		}
	}
}
