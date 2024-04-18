using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;

public class start_menu : MonoBehaviour
{
    public void turnoff(){
        gameObject.SetActive(false);
    }
    public void QuitGame()
 {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
     
 } 



 public void ChangeScene(string sceneChange) 
 { 
     
     
     SceneManager.LoadScene(sceneChange);
 }
 public void MuteToggle(bool muted) {
 
 
    if (muted)
    {
         AudioListener.volume = 0; 
    }  
    
    
    else
    { 
             AudioListener.volume = 1;
    }
    }
}
