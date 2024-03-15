using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_HitOnHead : MonoBehaviour
{
    [SerializeField] GameObject Explosion;
    GameObject ObstacleSpawner;
    // Start is called before the first frame update
    void Start()
    {
        ObstacleSpawner = GameObject.Find("GameObstacleSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Obstacle")
        {
            Explode();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void Explode()
    {
        GameObject Exploding = Instantiate(Explosion,transform.position,transform.rotation);
        Exploding.transform.name = "Explosion";
        Destroy(this.transform.parent.gameObject);
        Destroy(ObstacleSpawner);
    }

}
