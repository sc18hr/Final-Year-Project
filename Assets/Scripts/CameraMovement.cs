using UnityEngine;

/** 
 * This class is attached to the camera object.
 * The class allows the camera to follow the player around the maze.
 * The camera's position is constantly updated according to the player's
 * position.
 */

public class CameraMovement : MonoBehaviour
{
    //reference to the player object in order to get its position
    public Transform player;
    //This is the difference between the player's and the camera's original position 
    private Vector3 offset = new Vector3(0f, 4.7f, -3.8f);

    void Update()
    {
        //sets the camera's position to the player's position + the offset
        transform.position = player.position + offset;
    }
}
