using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script that loads the game data and saves information between scenes.
 **/
public class GameController : MonoBehaviour
{
    /**
     * Selected animation for the character
     **/
    public string SelectedAnimation = "";

    /**
     * Allows the GameObject to be mantain between scenes
     * Start is called before the first frame update
     **/
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
