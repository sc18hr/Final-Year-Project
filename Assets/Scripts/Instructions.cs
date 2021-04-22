using UnityEngine;
using UnityEngine.SceneManagement;

/** 
 * This class is attached to the instructions canvas.
 * This class provides methods for both buttons in the scene.
 */

public class Instructions : MonoBehaviour
{
    //this method is called by the "Start Game" button
    public void StartGame()
    {
        //loads the first level scene
        SceneManager.LoadScene("Level 1");
    }

    //this method is called by the "Return to Menu" button
    public void Menu()
    {
        //loads the menu scene
        SceneManager.LoadScene("Menu");
    }
}
