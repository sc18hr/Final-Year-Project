using UnityEngine;
using UnityEngine.UI;

/** 
 * This class is attached to the coin objects.
 * This class provides the constant rotation for the coins.
 * It also handles the collision between the coin and the player.
 */

public class CoinBehaviour : MonoBehaviour
{
    //reference to the text displaying the total amount of coins collected
    public Text coins;
     
    void FixedUpdate()
    {
        //constantly rotates the coins
        transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        //code only executes if the collision is with the player
        if (collision.collider.tag == "Player")
        {
            //hide the coin
            gameObject.SetActive(false);

            //updates the global counter for the amount of coins collected
            PlayerMovementUDP.counter += 1;
            //updates text displaying the total amount of coins collected
            coins.text = PlayerMovementUDP.counter.ToString();
        }
    }
}
