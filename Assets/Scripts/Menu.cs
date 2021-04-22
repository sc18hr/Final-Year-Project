using UnityEngine;
using UnityEngine.SceneManagement;

/** 
 * This class is attached to the menu canvas.
 * This class gives functionality to the two buttons in the canvas.
 */

public class Menu : MonoBehaviour
{
    //this method is called by the "Start Game" button
    public void StartGame()
    {
        //loads the first level scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //this method is called by the "Instructions" button
    public void Instructions()
    {
        //loads the instructions scene
        SceneManager.LoadScene("Instructions");
    }
}
