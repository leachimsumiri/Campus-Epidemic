using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muteScript : MonoBehaviour
{ 
 public void Mute (){
     AudioListener.volume =  0;
 }
}
