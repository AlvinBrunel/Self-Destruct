using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerPreGame : MonoBehaviour
{
    public Animator PlayerAnimation;
    [SerializeField] GameObject ObstacleSpawner;
    GameObject GM;
    [SerializeField] GameObject GameMenu;
    // Start is called before the first frame update
    void Start()
    {
        PlayerAnimation = this.transform.GetChild(1).GetChild(0).GetComponent<Animator>();
        GM = GameObject.Find("GameManager").gameObject;
        GM.GetComponent<Script_GameManagement>().Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("a") ^ Input.GetKeyDown("d")) && ((PlayerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Player Idle") || PlayerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Player Looking Back") || PlayerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Player Looking Side to Side") )))
        {
            GetComponent<Script_Player>().Move = -(Convert.ToInt32((Input.GetKeyDown("a")))) + Convert.ToInt32(Input.GetKeyDown("d"));
            PlayerAnimation.Play("Player Running");
            transform.GetChild(1).Rotate(0.0f, 0.0f, -90.0f);

            GameObject ObstacleSpawn = Instantiate(ObstacleSpawner,new Vector3(0,16f,0),GM.transform.rotation);
            ObstacleSpawn.transform.name = "ObstacleSpawner";

            Destroy(GetComponent<Script_PlayerPreGame>());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Platform" && PlayerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Player Falling"))
        {
            PlayerAnimation.Play("Player Landing");
            Invoke("PlayerOnGround", PlayerAnimation.GetCurrentAnimatorStateInfo(0).length);
        }
    }
    private void PlayerOnGround()
    {
        PlayerAnimation.Play("Player On Ground");
        Invoke("PlayerGetUp",1);
    }
    private void PlayerGetUp()
    {
        PlayerAnimation.Play("Player Standing Up");
        Invoke("PlayerIdle", 2);
    }
    private void PlayerIdle()
    {
        if (PlayerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Player Standing Up"))
        {
            Vector3 Increment = Vector3.down * 0.75f;
            transform.GetChild(1).Rotate(-90.0f, 0.0f, 0.0f);
            transform.position = Increment;

            transform.GetChild(0).position += Increment/2;
            transform.GetChild(1).position -= Increment;

            transform.position = -(Increment*1.5f);
        }

        PlayerAnimation.Play("Player Idle");
        Invoke("PlayerLookingAround", UnityEngine.Random.Range(5, 8));

    }
    private void PlayerLookingAround()
    {
        if(UnityEngine.Random.Range(0,2) == 1)
        {
            PlayerAnimation.Play("Player Looking Back");
            Invoke("PlayerIdle", 3.5f);
        }
        else
        {
            PlayerAnimation.Play("Player Looking Side to Side");
            Invoke("PlayerIdle", 2.458f);
        }
        
    }
}
