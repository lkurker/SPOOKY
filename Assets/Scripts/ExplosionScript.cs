using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float explosionDuration;

    public int explosionPower = 5;

    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("endExplosion", explosionDuration);
    }

    //make the explosion go away
    void endExplosion()
    {
        Destroy(gameObject);
    }
}
