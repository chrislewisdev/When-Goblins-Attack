using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameters : MonoBehaviour 
{
	private new Rigidbody2D rigidbody;
	private LifeController lifeController;
	private AttackController attackController;
	private Animator animator;


	// Use this for initialization
	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
		lifeController = GetComponent<LifeController>();
		attackController = GetComponent<AttackController>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody) animator.SetFloat("velocity", rigidbody.velocity.magnitude);
		if (lifeController) animator.SetBool("alive", lifeController.IsAlive);
		if (attackController) animator.SetBool("attacking", attackController.IsAttacking);
	}
}
