using UnityEngine;
using UnityEngine.SceneManagement;

/** 
 * This class is attached to the game manager object.
 * This class enables the inbetween levels canvas.
 * It also loads the next scene.
 */

public class Manager : MonoBehaviour
{
    //reference to the inbetween levels canvas that is disabled by default
    public GameObject complete;

    //this method is called when the player collides with the gate
    public void CompleteLevel()
    {
        //enable the canvas
        complete.SetActive(true);
    }

    //this method is called when the next level is ready to be loaded
    public void NextLevel()
    {
        //loads the next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
