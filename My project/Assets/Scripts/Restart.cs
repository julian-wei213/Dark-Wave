using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject pause;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);//restartScene(); 
            Time.timeScale = 0f;
        }
    } 


    public void restartScene()
    { 

        SceneManager.LoadScene("SampleScene");
    }
}
