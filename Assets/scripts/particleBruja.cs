using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleBruja : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnParticleCollision(GameObject other)
    {

        heromove heromove =other.GetComponent<heromove>();
        Debug.Log(heromove.name);
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
