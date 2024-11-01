using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackTransform;
    [SerializeField] private Transform attackTransform2;
    [SerializeField] private Transform attackTransform3;

    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackRange2 = 2.0f;
    [SerializeField] private float attackRange3 = 2.5f;

    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private int attackDamage2 = 15;
    [SerializeField] private int attackDamage3 = 20;

    [SerializeField] private float knockbackForce = 5f;
    [SerializeField] private float knockbackForce2 = 7f;
    [SerializeField] private float knockbackForce3 = 10f;

    private PlayerControls playerControls;
    private InputAction attackAction;
    private InputAction attackAction2;
    private InputAction attackAction3;

    private void Awake()
    {
        Debug.Log("Awake called on " + gameObject.name);
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable called on " + gameObject.name);
        attackAction = playerControls.Player.Attack;
        attackAction2 = playerControls.Player.Attack2;
        attackAction3 = playerControls.Player.Attack3;

        attackAction.Enable();
        attackAction2.Enable();
        attackAction3.Enable();

        attackAction.performed += OnAttackPerformed;
        attackAction2.performed += OnAttack2Performed;
        attackAction3.performed += OnAttack3Performed;
    }

    private void OnDisable()
    {
        attackAction.performed -= OnAttackPerformed;
        attackAction2.performed -= OnAttack2Performed;
        attackAction3.performed -= OnAttack3Performed;

        attackAction.Disable();
        attackAction2.Disable();
        attackAction3.Disable();
    }

    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Primary attack performed by: " + gameObject.name);
        PerformAttack(attackTransform, attackRange, attackDamage, knockbackForce);
    }

    private void OnAttack2Performed(InputAction.CallbackContext context)
    {
        Debug.Log("Second attack performed by: " + gameObject.name);
        PerformAttack(attackTransform2, attackRange2, attackDamage2, knockbackForce2);
    }
    
    private void OnAttack3Performed(InputAction.CallbackContext context)
    {
        Debug.Log("Third attack performed by: " + gameObject.name);
        PerformAttack(attackTransform3, attackRange3, attackDamage3, knockbackForce3);
    }

    private void PerformAttack(Transform attackTransform, float attackRange, int attackDamage, float knockbackForce)
    {
        Vector3 attackDirection = Vector3.right;
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackTransform.position, attackRange, attackableLayer);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject != gameObject)
            {
                Vector3 directionToEnemy = hit.transform.position - transform.position;
                if (directionToEnemy.x < 0)
                {
                    attackDirection = Vector3.left;
                }

                // Apply damage and knockback
                PlayerHealth2 enemyHealth = hit.GetComponent<PlayerHealth2>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(attackDamage);
                    hit.GetComponent<Rigidbody2D>().AddForce(attackDirection * knockbackForce, ForceMode2D.Impulse);
                }
            }
        }
    }

}