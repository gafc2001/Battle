using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public enum Move {FORWARD,BACK,LEFT,RIGTH,}
    //Health
    public HealthBar healthBar;
    public int maxHealth;
    protected int currentHealth;
    //Combat properties
    public int damage;
    public float attackRate;
    protected float nextAttack;
    public Transform attackPoint;
    public float attackRange = 5f;
    public LayerMask typeOfUnit;
    public CapsuleCollider capsule;

    //Movement
    public Animator animator;
    public int speed;
    public int rotationSpeed;
    protected float x, y;

    // Start is called before the first frame update
    protected void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }
    

    public void AttackWithRate()
    {
        
        
            Collider[] colliders = Physics.OverlapSphere(attackPoint.position, attackRange, typeOfUnit);
            
            foreach (Collider collider in colliders)
            {
                Player player = collider.GetComponent<Player>();
            }
            
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    protected void Die(string nameAnimation)
    {
        if (currentHealth <= 0)
        {
            animator.SetBool(nameAnimation, false);
            animator.Play("Death");
            capsule.center = new Vector3(-0.004065989f, 1f, -3.600592e-12f);
            capsule.height = 0f;
            this.enabled = false;
        }
    }
    public void receiveDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
