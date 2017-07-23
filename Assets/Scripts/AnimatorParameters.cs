using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameters : MonoBehaviour 
{
	private new Rigidbody2D rigidbody;
	private Animator animator;


	// Use this for initialization
	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat("velocity", rigidbody.velocity.magnitude);
	}
}
