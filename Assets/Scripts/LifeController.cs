using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
	[SerializeField]
	private float DeathLength = 1f;
	[SerializeField]
	private float BaseHealth = 5f;

	public bool IsAlive { get; private set; }
	public float Health { get; private set; }

	private Animator animator;

    // Use this for initialization
    void Start()
    {
		IsAlive = true;
		Health = BaseHealth;

		animator = GetComponent<Animator>();
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
				IsAlive = false;
				GetComponent<Rigidbody2D>().simulated = false;

				GameObject.Destroy(gameObject, DeathLength);
			}
		}
	}
}
