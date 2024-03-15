using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Explosion : MonoBehaviour
{
    ParticleSystem PS;
    // Start is called before the first frame update
    void Start()
    {
        PS = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("StopExplosion",PS.main.duration/2);
    }
    void StopExplosion()
    {
        Destroy(this.gameObject);
    }
}
