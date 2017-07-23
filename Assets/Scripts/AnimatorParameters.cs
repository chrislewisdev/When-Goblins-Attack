using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameters : MonoBehaviour 
{
	private new Rigidbody2D rigidbody;
	private LifeController lifeController;
	private Animator animator;


	// Use this for initialization
	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
		lifeController = GetComponent<LifeController>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat("velocity", rigidbody.velocity.magnitude);
		animator.SetBool("alive", lifeController.Alive);
	}
}
