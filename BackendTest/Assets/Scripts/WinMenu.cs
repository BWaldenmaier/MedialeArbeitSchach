using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        String winner = PlayerPrefs.GetString("Winner");
        Debug.Log(winner + " hat das Spiel gewonnen!");   
        GetComponent<UnityEngine.UI.Text>().text = winner.ToUpper() + " WON THE GAME";
    }

    public void backToMainMenu(){
        SceneManager.LoadScene(0);
    }   
}
