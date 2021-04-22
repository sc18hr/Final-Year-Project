using UnityEngine;
using UnityEngine.UI;

/** 
 * This class is attached to the animation inbetween levels canvas.
 * This class loads the next level.
 * It also aids the animation in counting down before the next level.
 */

public class LoadNextLevel : MonoBehaviour
{
    //reference to the manager class
    public Manager manager;
    //reference to the countdown timer text
    public Text timer;

    //counter for the countdown
    private int countdown = 3;

    //this method is called at the end of the countdown
    public void Next()
    {
        //load the next level
        manager.NextLevel();
    }

    //this method is called once a second
    public void Countdown()
    {
        //if the countdown counter is above 0 then decrement it 
        if (countdown > 0)
        {
            countdown--;
        }

        //displays the countdown counter as the timer on the canvas
        timer.text = countdown.ToString();
    }
}
