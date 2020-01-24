using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public void changeTurnHelperBool()
    {
        FindObjectOfType<MoveSelector>().changeTurnHelper();
    } 

    public void backgroundMusicOnOff()
    {
        GameObject obj = GameObject.Find("BackgroundMusic");
        AudioSource audio = obj.GetComponent<AudioSource>();
        if (audio.mute == true){
            audio.mute = false;
        }
        else if(audio.mute == false){
            audio.mute = true;
        }  
    } 
}
