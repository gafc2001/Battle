using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heromove : MonoBehaviour
{
    // Start is called before the first frame update
    public float runSpeed = 500;
    public float rotationSpeed =150;
    public Animator animator;
 

    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    public WaitForSeconds wait;

    public CapsuleCollider colider;

    private float x, y;


    public GameObject target;
    /*public GameObject target2;*/

    public float attackRate = 2f;
    float nextAttack = 0f;


    //Combat properties
    public Transform attackPoint;
    public float attackRange = 5f;
    public LayerMask enemyLayers;
    // Update is called once per frame

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
    }
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);

        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
        /*if (Vector3.Distance(transform.position, target.transform.position) < 10){
            receiveDamage(0.1f);
        }
        if (Vector3.Distance(transform.position, target2.transform.position) < 10)
        {
            receiveDamage(0.1f);
        }*/

        //if (Input.GetKey("z"))
        //{
        //    animator.SetBool("Other", false);
        //    animator.Play("se_me_hace_tarde");
        //}
        //if (Time.time >= nextAttack)
        //{

        //    if (Input.GetKeyDown("x"))
        //    {
        //        attack(20);
        //        animator.SetBool("Other", false);
        //        animator.Play("golpear");
        //        nextAttack = Time.time + 1f / attackRate;
        //    }

        //}
        //if (Input.GetKey("c"))
        //{
        //    animator.SetBool("Other", false);
        //    animator.Play("dance");
        //}
        //if (x > 0 || x < 0 || y > 0 || y < 0)
        //{
        //    animator.SetBool("Other", true);
        //}
        //if (currentHealth <= 0)
        //{
        //    animator.SetBool("Other", false);
        //    animator.Play("Death");
        //    colider.center=new Vector3(-0.004065989f,1f, -3.600592e-12f);
        //    colider.height = 0f;
        //}
    }

    public void receiveDamage(float damage)
    {
       
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        
    }
    public void attack(int damage)
    {
        Debug.Log(Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers));
        Collider[] enemies = Physics.OverlapSphere(attackPoint.position, attackRange,enemyLayers);
        if(enemies.Length == 0)
        {
            Debug.Log("Empty Array");
        }
        foreach(Collider enemy in enemies)
        {
            enemy.GetComponent<IAEnemiga>().receiveDamage(30f);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

