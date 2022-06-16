using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Uses the information provided by previous scenes
 **/
public class DataController : MonoBehaviour
{
    /**
     * Animator of the 3D model
     **/
    public Animator characterAnimator;

    // Start is called before the first frame update
    void Start()
    {
        GameController controller = FindObjectOfType<GameController>();
        if(controller!= null) characterAnimator.SetTrigger(controller.SelectedAnimation);
    }

}
