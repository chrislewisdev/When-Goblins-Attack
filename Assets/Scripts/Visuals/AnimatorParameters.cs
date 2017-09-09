using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimatorParameters : MonoBehaviour 
{
	private new Rigidbody2D rigidbody;
	private LifeController lifeController;
	private AttackController attackController;
	private Animator animator;
	private NavMeshAgent navMeshAgent;

	// Use this for initialization
	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
		lifeController = GetComponent<LifeController>();
		attackController = GetComponent<AttackController>();
		animator = GetComponent<Animator>();
		navMeshAgent = GetComponentInParent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody) animator.SetFloat("velocity", rigidbody.velocity.magnitude);
		if (navMeshAgent) animator.SetFloat("velocity", navMeshAgent.velocity.magnitude);
		if (lifeController) animator.SetBool("alive", lifeController.IsAlive);
		if (attackController) animator.SetBool("attacking", attackController.IsAttacking);
	}
}
