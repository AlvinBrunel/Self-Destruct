using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_GameMenu : MonoBehaviour
{
    GameObject Player;
    [SerializeField] GameObject GameMenu;
    [SerializeField] GameObject TapToStart;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("Player");
        if (Player != null)
        {
            if (Player.GetComponent<Script_PlayerPreGame>() != null)
            {
                GameMenu.SetActive(true);
                if (Player.GetComponent<Script_PlayerPreGame>().PlayerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Player Idle") || Player.GetComponent<Script_PlayerPreGame>().PlayerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Player Looking Back") || Player.GetComponent<Script_PlayerPreGame>().PlayerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Player Looking Side to Side"))
                {
                    TapToStart.SetActive(true);
                }
            }
            else
            {
                GameMenu.SetActive(false);
                TapToStart.SetActive(false);
            }
        }
    }
}
