using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemigo2 : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public GameObject target;
    public bool atacando;

    //atacando
    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;
    public ParticleSystem magia;


    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("hero2");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);

    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento_Enemigo();
    }
    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 50)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                    ani.SetBool("walk", true);
                    magia.Play();
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 30 && !atacando)
            {


                var lookPost = target.transform.position - transform.position;
                lookPost.y = 0;
                var rotation = Quaternion.LookRotation(lookPost);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("walk", false);
                ani.SetBool("run", true);
                magia.Play();
                transform.Translate(Vector3.forward * 3 * Time.deltaTime);
            }
            else
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
                ani.SetBool("attack", true);
                
                atacando = true;
                if (currentHealth <= 0)
                {
                    ani.SetBool("death", false);
                    ani.Play("death");
                    magia.Play();
                }
                if (Input.GetKeyDown("x"))
                {
                    
                    receiveDamage(20);

                }


            }

        }
    }
    public void Final_Ani2()
    {
        ani.SetBool("attack", false);

        atacando = false;
    }
    void receiveDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
