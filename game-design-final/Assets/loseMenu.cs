using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loseMenu : MonoBehaviour
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
        loseMenuImg.color = Color.Lerp(new Color(0,0,0,0), Color.black, transition);
      }
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
    
    public void ToggleLoseMenu()
    {
      loseMenuUI.SetActive(true); 
      isShown = true; 
    }
    
    public void Retry()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
