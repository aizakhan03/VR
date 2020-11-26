using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        

    // }
    public void StartGame(){
        Debug.Log("Button clicked?");
    	SceneManager.LoadScene("SampleScene");

    }
   public void Endgame(){
    Debug.Log("Button clicked??");
    	Application.Quit();
    }
    public void gaming(){
    Debug.Log(" random Button clicked??");
        Application.Quit();
    }
}
