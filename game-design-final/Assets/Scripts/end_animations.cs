using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end_animations : MonoBehaviour
{
    public Animator anim;
    private winMenu win;
    // Start is called before the first frame update
    void Start()
    {
      GameObject l = GameObject.FindGameObjectWithTag("canvas");
      win = l.GetComponent<winMenu>();
      
      anim.Play("player_wakeup");
      StartCoroutine(DisplayWin());
    }
    
    private IEnumerator DisplayWin()
    {
      yield return new WaitForSeconds(6.5f);
      win.ToggleWinMenu();
    }

}
