using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class winMenu : MonoBehaviour
{
    public GameObject loseMenuUI;
    public Image loseMenuImg;
    
    private bool isShown = false;
    private float transition = 0.0f;
  
    // Start is called before the first frame update
    void Start()
    {
        loseMenuUI.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
      if(!isShown) 
      {
        
      } else {
        transition += Time.deltaTime;
        loseMenuImg.color = Color.Lerp(new Color(0,0,0,0), new Color(0,0,0,0.5f), transition);
      }
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
    
    public void ToggleWinMenu()
    {
      loseMenuUI.SetActive(true); 
      isShown = true;
    }

    public void Menu()
    {
      Time.timeScale = 1f;
      SceneManager.LoadScene("MainMenu");
    }
}
