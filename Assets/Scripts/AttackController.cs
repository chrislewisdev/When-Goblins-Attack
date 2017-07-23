using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField]
    private float AttackRange = 1f;
    [SerializeField]
    private bool DrawGizmos = true;

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
            LifeController lifeController = enemy.gameObject.GetComponent<LifeController>();
            if (lifeController && lifeController.Alive)
            {
				lifeController.ReceiveDamage();
            }
        }
    }

    void OnDrawGizmos()
    {
        if (DrawGizmos)
        {
            Gizmos.DrawWireSphere(transform.position, AttackRange);
        }
    }
}
