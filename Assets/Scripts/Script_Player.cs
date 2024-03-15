using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Player : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 10f;
    [SerializeField] float[] XClamps;
    public int Move;
    // Start is called before the first frame update
    void Start()
    {
        Move = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Script_PlayerPreGame>() == null)
        {
            if (Input.GetKeyDown("a") ^ Input.GetKeyDown("d"))
            {
                Move = -(Convert.ToInt32((Input.GetKeyDown("a")))) + Convert.ToInt32(Input.GetKeyDown("d"));
            }
            transform.Translate(new Vector3(0, 0, Move) * MovementSpeed * Time.deltaTime);
            if (transform.position.x < XClamps[0])
            {
                transform.position = new Vector3(XClamps[0], transform.position.y, transform.position.z);
                Move = 1;
            }
            if (transform.position.x > XClamps[1])
            {
                transform.position = new Vector3(XClamps[1], transform.position.y, transform.position.z);
                Move = -1;
            }
        }
    }
}
