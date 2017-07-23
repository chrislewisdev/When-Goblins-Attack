using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField]
    private float AttackRange = 1f;
    [SerializeField]
    private float AttackDuration = 1f;
    [SerializeField]
    private bool DrawGizmos = true;

    public bool IsAttacking { get; private set; }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAttacking)
        {
            Collider2D enemy = Physics2D.OverlapCircle(transform.position, AttackRange, 1 << LayerMask.NameToLayer("Enemy"));

            if (enemy)
            {
                LifeController lifeController = enemy.gameObject.GetComponent<LifeController>();
                if (lifeController && lifeController.IsAlive)
                {
                    StartCoroutine(PerformAttack(lifeController));
                }
            }
        }

    }

    private IEnumerator PerformAttack(LifeController target)
    {
        IsAttacking = true;
        target.ReceiveDamage();
        yield return new WaitForSeconds(AttackDuration);
        IsAttacking = false;
    }

    void OnDrawGizmos()
    {
        if (DrawGizmos)
        {
            Gizmos.DrawWireSphere(transform.position, AttackRange);
        }
    }
}
