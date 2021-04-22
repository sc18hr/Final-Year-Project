using UnityEngine;

/**
 * This class is attached to the player object.
 * This class provides the movement for the player.
 * This class focuses on the movement using the "WASD" keys on the keyboard.
 * It also animates the robot's body parts when walking in order to emulate walking.
 */

public class PlayerMovement : MonoBehaviour
{
    //reference to the six body parts that are animated
    public GameObject leftShoulder;
    public GameObject rightShoulder;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject leftKnee;
    public GameObject rightKnee;

    //counter for the coin collisions
    public static int counter = 0;
    //counter for the total number of coins collected throughout the game
    public static int sum = 0;

    //used to know which limb to move
    private int moveCounter = 0;

    void FixedUpdate()
    {
        /* 
         * The same principle applies to every if statement in this method but with different directions.
         * The four directions are within separate if statements in order to allow the player to move
         * in multiple directions at a time.
         * Each if statement first calls the MoveBody() method in order to animate the robot's movement.
         * The rotation of the robot is then changed by using Quaternion.Lerp which changes the object's
         * rotation from one to the other.
         * The position of the robot is updated by adding 10 or -10 in the appropriate direction. 10 is 
         * an arbitrary number and could be anything else. The number is multiplied by Time.deltaTime so 
         * that the movement is the same across all platforms regardless of hardware differences.
         */

        //move forward
        if (Input.GetKey("w"))
        {
            this.MoveBody();
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.5f);
            transform.position += new Vector3(0, 0, 10 * Time.deltaTime);
        }

        //move left
        if (Input.GetKey("a"))
        {
            this.MoveBody();
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 0.5f);
            transform.position += new Vector3(-10 * Time.deltaTime, 0, 0);
        }

        //move backwards
        if (Input.GetKey("s"))
        {
            //does not allow the robot to go past the -21 Z position which would hide the camera from the user's view
            if (transform.position.z <= -21)
            {
                return;
            }
            this.MoveBody();
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), 0.5f);
            transform.position += new Vector3(0, 0, -10 * Time.deltaTime);
        }

        //move right
        if (Input.GetKey("d"))
        {
            this.MoveBody();
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 0.5f);
            transform.position += new Vector3(10 * Time.deltaTime, 0, 0);
        }
    }

    //Rotates the arms and legs depending on the current value of moveCounter
    void MoveBody()
    {
        /*
         * The body parts are moved according to the value of moveCounter.
         * The "movement" is done by rotating the appropriate body parts.
         */

        if (moveCounter < 30) //left arm + right leg forward
        {
            leftShoulder.transform.Rotate(-50 * Time.deltaTime, 0, 0);
            rightShoulder.transform.Rotate(50 * Time.deltaTime, 0, 0);
            leftLeg.transform.Rotate(0, 0, -50 * Time.deltaTime);
            rightLeg.transform.Rotate(0, 0, -60 * Time.deltaTime);
            rightKnee.transform.Rotate(0, 0, 50 * Time.deltaTime);

            ++moveCounter;
        }
        else if (moveCounter < 60) //back to normal
        {
            leftShoulder.transform.Rotate(50 * Time.deltaTime, 0, 0);
            rightShoulder.transform.Rotate(-50 * Time.deltaTime, 0, 0);
            leftLeg.transform.Rotate(0, 0, 50 * Time.deltaTime);
            rightLeg.transform.Rotate(0, 0, 60 * Time.deltaTime);
            rightKnee.transform.Rotate(0, 0, -50 * Time.deltaTime);

            ++moveCounter;
        }
        else if (moveCounter < 90) //right arm + left leg forward
        {
            leftShoulder.transform.Rotate(50 * Time.deltaTime, 0, 0);
            rightShoulder.transform.Rotate(-50 * Time.deltaTime, 0, 0);
            leftLeg.transform.Rotate(0, 0, 60 * Time.deltaTime);
            rightLeg.transform.Rotate(0, 0, 50 * Time.deltaTime);
            leftKnee.transform.Rotate(0, 0, -50 * Time.deltaTime);

            ++moveCounter;
        }
        else if (moveCounter < 120) //back to normal
        {
            leftShoulder.transform.Rotate(-50 * Time.deltaTime, 0, 0);
            rightShoulder.transform.Rotate(50 * Time.deltaTime, 0, 0);
            leftLeg.transform.Rotate(0, 0, -60 * Time.deltaTime);
            rightLeg.transform.Rotate(0, 0, -50 * Time.deltaTime);
            leftKnee.transform.Rotate(0, 0, 50 * Time.deltaTime);

            //update the counter and reset when it reaches 119
            if (moveCounter != 119)
            {
                ++moveCounter;
            }
            else
            {
                moveCounter = 0;
            }
        }
    }
}
