using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IAEnemiga : Player
{
    // Start is called before the first frame update
    int rutina;
    float cronometro;
    Quaternion angulo;
    float grado;
    public GameObject target;
    bool atacando;
    bool isAttacking;
    
    // Update is called once per frame
    void Start()
    {
        base.Start();
        target = GameObject.Find("hero");
    }
    void Update()
    {

        Comportamiento_Enemigo();
        Die("death");
    }

    public void Comportamiento_Enemigo()
    {
        
        if (Vector3.Distance(transform.position, target.transform.position) > 200)
        {
            animator.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;
            switch (rutina)
            {
                case 0:
                    animator.SetBool("walk", false);
                    break;

                //case 1:
                //    grado = Random.Range(0, 360);
                //    angulo = Quaternion.Euler(0, grado, 0);
                //    rutina++;
                //    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                    animator.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 50 && !atacando)
            {


                var lookPost = target.transform.position - transform.position;
                lookPost.y = 0;
                var rotation = Quaternion.LookRotation(lookPost);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 5);
                animator.SetBool("walk", false);
                animator.SetBool("run", true);
                transform.Translate(Vector3.forward * 40 * Time.deltaTime);
            }
            else
            {
                if (Time.time >= nextAttack)
                {
                    animator.SetBool("walk", false);
                    animator.SetBool("run", false);
                    animator.SetBool("attack", true);
                    atacando = true;
                    //Debug.Log("tima" + Time.time);
                    Debug.Log("Condicion" + (Time.time >= nextAttack));
                
                
                    //AttackWithRate();
                    nextAttack = Time.time + 1f / attackRate;
                }
            }

        }
    }

    public void Final_Ani()
    {
        animator.SetBool("attack", false);
        atacando = false;
    }
    
    private void DieAndReset()
    {
        
        heromove heromove = target.GetComponent<heromove>();
        //heromove.LevelUp();
    }


}
