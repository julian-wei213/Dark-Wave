using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pause : MonoBehaviour
{
 
 public GameObject pauseMenu; 
 public GameObject optionsMenu; 
 
 /*void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){ 
            PauseButton();
        }
    }
 */
 public void Menu(){ 
     SceneManager.LoadScene(0);
 }
 public void PauseButton(){ 
     Time.timeScale =0f; 
     pauseMenu.SetActive(true);
     

 }
    // Start is called before the first frame update

public void ResumeButton(){ 
     Time.timeScale =1f; 
     pauseMenu.SetActive(false);
     

 }

    
    
}
