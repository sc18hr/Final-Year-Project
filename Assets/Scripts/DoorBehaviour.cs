using UnityEngine;

/** 
 * This class is attached to the gate object.
 * This class handles the collision between the gate and the player.
 */

public class DoorBehaviour : MonoBehaviour
{
    //references to both doors on the gate
    public GameObject leftDoor;
    public GameObject rightDoor;
    //reference to the manager class used to complete the level
    public Manager manager;

    void OnCollisionEnter(Collision collision)
    {
        //code only executes if the collision is with the player
        if (collision.collider.tag == "Player")
        {
            //disable the movement script so the player does not move while the next level is loaded
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementUDP>().enabled = false;

            //rotate doors to give the impression of them opening
            leftDoor.transform.Rotate(0, -120, 0); 
            rightDoor.transform.Rotate(0, 120, 0);

            //add the current total number of coins to the cumulative counter
            PlayerMovementUDP.sum += PlayerMovementUDP.counter;
            //reset number of coins to 0
            PlayerMovementUDP.counter = 0;
            //loads the next level
            manager.CompleteLevel();
        }
    }
}
