using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitBarrier : MonoBehaviour
{
    [SerializeField]
    GameObject[] switches;

    [SerializeField]
    GameObject exitBarrier;

    int numSwitches = 0;

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
            }
        }
        numSwitches = x;

        return numSwitches;
    }

    public void GetExitBarrierState()
    {
        if (numSwitches <= 0) {
            exitBarrier.GetComponent<FinalBarrier>().OpenBarrier();
        }
    }

    void Update()
    {
        // Checking number of switches and state of the door
        GetNumSwitches();
        GetExitBarrierState();
    }
}
