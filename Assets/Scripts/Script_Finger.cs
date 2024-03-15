using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Finger : MonoBehaviour
{
    GameObject GM;

    [SerializeField] GameObject Debris;
    GameObject TMP;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager");
        TMP = GameObject.Find("PointsCounter");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Platform")
        {
            Destroy(this.gameObject);
            Crash();
            GM.GetComponent<Script_GameManagement>().Points++;
            TMP.GetComponent<Script_GUI_Points>().Pulse();
        }
    }
    void Crash()
    {
        Debug.Log("Explode");
        GameObject Exploding = Instantiate(Debris, transform.position, transform.rotation);
        Exploding.transform.name = "RockDebris";
        Destroy(this.transform.parent.gameObject);
    }
}
