using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Options : MonoBehaviour
{
    // Start is called before the first frame update
    public void exit()
    {
        Application.Quit();
    }  

    public enum  Scene { 
        GameScene
    }


    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene("options");
    }
}
