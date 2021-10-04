using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollison : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject collider)
    {
        heromove hero = collider.GetComponent<heromove>();
        if (hero != null)
        {
            Debug.Log(hero.name);
            hero.receiveDamage(20);
        }
    }
}
