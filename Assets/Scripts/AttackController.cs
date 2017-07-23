using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
	[SerializeField]
	private float AttackRange = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		Collider2D enemy = Physics2D.OverlapCircle(transform.position, AttackRange, 1 << LayerMask.NameToLayer("Enemy"));
		if (enemy)
		{
			Debug.Log("Got an enemy here");
		}
    }

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, AttackRange);
	}
}
