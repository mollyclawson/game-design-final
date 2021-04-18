using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3Manager : MonoBehaviour
{
    [SerializeField]
    GameObject[] switches;

    [SerializeField]
    GameObject exitDoor;

    int numSwitches = 0;

    [SerializeField] Animator[] animatorSwitchesUI;

    void Start()
    {
        GetNumSwitches();
    }

    public int GetNumSwitches()
    {
        int x = 0;

        // Counts the number of switches still left to pull
        for(int i = 0; i < switches.Length; i++) {
            if(switches[i].GetComponent<Switch>().isOn == false) {
                x = x + 1;
            } else if(switches[i].GetComponent<Switch>().isOn == true) {
                x = x;
                animatorSwitchesUI[i].SetTrigger("SwitchOn");
            }
        }
        numSwitches = x;

        return numSwitches;
    }

    public void GetExitDoorState()
    {
        if (numSwitches <= 0) {
            exitDoor.GetComponent<FinalDoor>().OpenDoor();
        }
    }

    void Update()
    {
        // Checking number of switches and state of the door
        GetNumSwitches();
        GetExitDoorState();
    }
}
