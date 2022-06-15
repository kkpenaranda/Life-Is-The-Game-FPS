using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Script that controls the functions that a button does.
 * This script is attached to buttons in the UI menu.
 **/
public class ButtonOption : MonoBehaviour
{
    /**
     * Animator that controls the animations in the character
     **/
    public Animator characterAnimator;

    /**
     * Animation that is currently playing
     **/
    private static string currentAnimation;


    /**
     * This method activates a trigger given by parameter which changes the animation of the character.
     * If the button is clicked when its animation is playing, it will not reactivate it.
     * @param animationName: Name of the trigger that activates the animation in the animator controller.
     **/
    public void ChangeAnimation(string animationName)
    {
        if (animationName != currentAnimation)
        {
            characterAnimator.SetTrigger(animationName);
            currentAnimation = animationName;            
        }
    }


    /**
     * Saves the current animation and changes the scene.
     * @param sceneName: Name of the new scene.
     **/
    public void ChangeScene(string sceneName)
    {
        FindObjectOfType<GameController>().SelectedAnimation = currentAnimation;
        SceneManager.LoadScene(sceneName);
    }
}
