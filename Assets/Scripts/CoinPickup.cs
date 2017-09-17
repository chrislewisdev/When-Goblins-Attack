using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
	[SerializeField]
	private LayerMask RecipientLayer;
	[SerializeField]
	private float PickupRange = 0.5f;

    void Update()
	{
		Collider2D pickerupper = Physics2D.OverlapCircle(transform.position, PickupRange, RecipientLayer);
		if (pickerupper)
		{
			Events.FireCoinPickedUp();
			GameObject.Destroy(gameObject);
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, PickupRange);
	}
}
