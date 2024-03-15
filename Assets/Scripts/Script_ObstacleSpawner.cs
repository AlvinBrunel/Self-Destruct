using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject Obstacle;
    [SerializeField] GameObject Platform;
    [SerializeField] GameObject Log;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject GM;

    Vector3 SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObstacle();
        Invoke("SpawnLog", Random.Range(8.0f, 14f));
        //GM = GameObject.Find("GameMaanager");

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") == null && (IsInvoking("SpawnObstacle") || IsInvoking("SpawnLog")))
        {
            CancelInvoke("SpawnObstacle");
            CancelInvoke("SpawnLog");
        }


    }
    public void SpawnObstacle()
    {
        SpawnPoint = new Vector3(Random.Range( -(Platform.transform.localScale.x/2), Platform.transform.localScale.x / 2) ,transform.position.y,transform.position.z);

        GameObject Rocks = Instantiate(Obstacle,SpawnPoint,GM.transform.rotation);
        Rocks.transform.name = "Rock";


        Invoke("SpawnObstacle",Random.Range(0.2f,0.4f));
    }
    public void SpawnLog()
    {
        SpawnPoint = new Vector3(Random.Range(-(Platform.transform.localScale.x / 2) +Log.transform.localScale.x/2, (Platform.transform.localScale.x / 2) - Log.transform.localScale.x / 2), transform.position.y, transform.position.z);
        GameObject Logs = Instantiate(Log, SpawnPoint, GM.transform.rotation);
        Logs.transform.name = "Log";

        Invoke("SpawnLog", Random.Range(8.0f, 14f));
    }
}
