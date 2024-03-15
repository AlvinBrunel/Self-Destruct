using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Script_GUI_Points : MonoBehaviour
{
    [SerializeField] GameObject GM;
    [SerializeField] TextMeshProUGUI TMP;

    private RectTransform RT;
    [SerializeField] private int MaxScale = 180;
    [SerializeField] private int MinScale = 120;
    [SerializeField] private float IntScale = 1;
    private Vector3 VectorScale;
    private bool ScaleUp = true;
    // Start is called before the first frame update
    void Start()
    {
        TMP = GetComponent<TextMeshProUGUI>();
        RT = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        TMP.text = GM.GetComponent<Script_GameManagement>().Points.ToString();
        if (GameObject.Find("Player") != null )
        {
            if(GameObject.Find("Player").GetComponent<Script_Player>().Move != 0)
            {
                GetComponent<TextMeshProUGUI>().enabled = true;
            }
            else
            {
                GetComponent<TextMeshProUGUI>().enabled = false;
            }
        }
        else
        {

            GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }
    public void Pulse()
    {
        Debug.Log("Pulse");
        if (ScaleUp == true)
        {
            PulseUp();
        }
        if (ScaleUp == false)
        {
            PulseDown();
        }
    }
    void PulseUp()
    {
        if (TMP.fontSize >= MaxScale)
        {
            ScaleUp = false;
        }
        else
        {
            TMP.fontSize+=6;
        }

            Pulse();
    }
    void PulseDown()
    {
        TMP.fontSize-=6;
        if (RT.localScale.x > MinScale)
        {
            Pulse();
        }
        else
        {
            ScaleUp = true;
        }

    }
}
