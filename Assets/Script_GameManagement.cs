using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_GameManagement : MonoBehaviour
{
    [SerializeField] GameObject Obstacle;
    [SerializeField] GameObject Platform;
    [SerializeField] GameObject Log;
    [SerializeField] GameObject Player;


    public int Points;
    // Start is called before the first frame update
    void Start()
    {
        Points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") == null && GameObject.Find("Log") == null && GameObject.Find("Rock") == null)
        {
            GameObject PlayerSpawn = Instantiate(Player, transform.position, transform.rotation);
            PlayerSpawn.transform.name = "Player";
            PlayerSpawn.transform.Rotate(0f, 90f, 0f);
            Debug.Log("Spawn Player");
        }
    }
}
