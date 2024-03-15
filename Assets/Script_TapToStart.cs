using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_TapToStart : MonoBehaviour
{
    private RectTransform RT;
    [SerializeField] private float MaxScale = 1.1f;
    [SerializeField] private float MinScale = 0.9f;
    [SerializeField] private float IntScale = 10f;
    private Vector3 VectorScale;
    private bool ScaleUp = true;

    // Start is called before the first frame update
    void Start()
    {
        RT = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        VectorScale = new Vector2(IntScale * Time.deltaTime, IntScale * Time.deltaTime);
        if (ScaleUp == true)
        {
            RT.localScale += VectorScale;
            if(RT.localScale.x > MaxScale)
            {
                ScaleUp = false;
            }
        }
        if (ScaleUp == false)
        {
            RT.localScale -= VectorScale;
            if (RT.localScale.x < MinScale)
            {
                ScaleUp = true;
            }
        }
    }
}
