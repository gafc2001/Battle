using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heromove : Player
{



    void Start()
    {
        base.Start();
    }
    void Update()
    {
        MovePlayer();

        Attack();

        Joke();
        
        Dance();

        Die(null);
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
    private void Attack()
    {
        if (Input.GetKeyDown("x"))
        {
            AttackWithRate();
            animator.SetBool("Other", false);
            animator.Play("golpear");
            nextAttack = Time.time + 1f / attackRate;
        }
    }

    private void Joke()
    {
        if (Input.GetKey("z"))
        {
            animator.SetBool("Other", false);
            animator.Play("se_me_hace_tarde");
        }
    }
    
    private void Dance()
    {
        if (Input.GetKey("c"))
        {
            animator.SetBool("Other", false);
            animator.Play("dance");
        }
    }
    public void LevelUp()
    {
        this.maxHealth += 100;
        this.currentHealth = maxHealth;
        this.damage += 50;
    }
}

