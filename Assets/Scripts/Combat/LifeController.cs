﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
	[SerializeField]
	private float DeathLength = 1f;
	[SerializeField]
	private float BaseHealth = 5f;
	[SerializeField]
	private AudioClip DeathSound;

	public bool IsAlive { get; private set; }
	public float Health { get; private set; }

	private Animator animator;
	private new Rigidbody2D rigidbody;
	private new Collider2D collider;

    // Use this for initialization
    void Start()
    {
		IsAlive = true;
		Health = BaseHealth;

		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();
		collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void ReceiveDamage()
	{
		if (IsAlive)
		{
			Health -= 1.0f;

			animator.Play("Flash", animator.GetLayerIndex("Effects"));

			if (Health <= 0)
			{
				if (DeathSound)
				{
					AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position, 0.4f);
				}

				IsAlive = false;

				if (rigidbody) rigidbody.simulated = false;
				if (collider) collider.enabled = false;

				GameObject.Destroy(gameObject, DeathLength);
			}
		}
	}
}