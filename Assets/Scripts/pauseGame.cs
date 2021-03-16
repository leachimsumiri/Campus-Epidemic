using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseGame : MonoBehaviour
{
    public bool gamePaused = false;

    public void togglePause(){
        gamePaused =! gamePaused;
        if(gamePaused == true){
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }
    }
}
