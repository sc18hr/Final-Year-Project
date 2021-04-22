using UnityEngine;
using UnityEngine.UI;

/** 
 * This class is attached to the end screen canvas.
 * This class displays the total number coins collected as text.
 * It also enables the application to be quit by pressing the 
 * button.
 */

public class Exit : MonoBehaviour
{
    //reference to the text displaying the total amount of coins collected
    public Text amount;

    void Update()
    {
        //display total amount of coins collected
        amount.text = PlayerMovementUDP.sum.ToString();
    }

    //this method is called when the "Quit" button is pressed
    public void Quit()
    {
        //quit the application
        Application.Quit();
    }
}
