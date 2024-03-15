using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player_FaceDirection : MonoBehaviour
{
    float ScaleZsize;
    public int Dir;
    // Start is called before the first frame update
    void Start()
    {
        ScaleZsize = transform.parent.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 theScale = transform.parent.localScale;

        Dir = this.transform.parent.gameObject.GetComponent<Script_Player>().Move;

        if (Dir != 0)
        {
            theScale.z = Dir* ScaleZsize;
        }
        transform.parent.localScale = theScale;
    }
}
