using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
	[SerializeField]
	private float DeathLength = 1f;

	public bool IsAlive { get; private set; }

    // Use this for initialization
    void Start()
    {
		IsAlive = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void ReceiveDamage()
	{
		// if (Alive)
		// {
		// 	Alive = false;
		// 	GetComponent<Rigidbody2D>().simulated = false;

		// 	GameObject.Destroy(gameObject, DeathLength);
		// }
	}
}
