using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public enum Move {FORWARD,BACK,LEFT,RIGTH,}
    //Health
    public HealthBar healthBar;
    public int maxHealth;
    private int currentHealth;
    //Combat properties
    public float damage;
    public float attachRate;
    private float nextAttack;
    public Transform attackPoint;
    public float attackRange = 5f;
    public LayerMask enemyLayers;
    public CapsuleCollider capsule;

    //Movement
    public Animator animator;
    public int speed;
    public int rotationSpeed;
    private float x, y;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();   
        Joke();

        Die();
    }

    private void Attack()
    {
        if (Time.time >= nextAttack)
        {

            if (Input.GetKeyDown("x"))
            {
                Collider[] enemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
                foreach (Collider enemy in enemies)
                {
                    enemy.GetComponent<IAEnemiga>().receiveDamage(damage);
                }
            }
        }
        
    }
    private void Joke()
    {
        if (Input.GetKey("c"))
        {
            animator.SetBool("Other", false);
            animator.Play("dance");
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void MovePlayer()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);

        transform.Translate(0, 0, y * Time.deltaTime * speed);

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
        if (x > 0 || x < 0 || y > 0 || y < 0)
        {
            animator.SetBool("Other", true);
        }
    }
    private void Die()
    {
        if (currentHealth <= 0)
        {
            animator.SetBool("Other", false);
            animator.Play("Death");
            capsule.center = new Vector3(-0.004065989f, 1f, -3.600592e-12f);
            capsule.height = 0f;
        }
    }
}
