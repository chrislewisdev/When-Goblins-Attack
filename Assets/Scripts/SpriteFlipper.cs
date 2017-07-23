using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour 
{
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
		sprite.flipX = rigidbody.velocity.x < 0;
	}
}
