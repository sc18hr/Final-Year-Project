using UnityEngine;

/**
 * This class is attached to the player object.
 * This class provides the movement for the player.
 * This class focuses on the movement using MyPAM as the input.
 * It also animates the robot's body parts when walking in order to emulate walking.
 */

public class PlayerMovementUDP : MonoBehaviour
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
         * The appropriate moving method is then called. All the methods do the same thing with the
         * directions being different:
         *  First the rotation of the robot is changed by using Quaternion.Lerp which changes the object's
         *  rotation from one to the other.
         *  Then the position of the robot is updated by adding the joystick's X or Y position divided by
         *  a constant (for balancing purposes so the robot does not move too fast) to the robot's current 
         *  position. The number is multiplied by Time.deltaTime so that the movement is the same across all 
         *  platforms regardless of hardware differences.
         */

        //move forward
        if (UDP_Handling.Y2pos > 20)
        {
            this.MoveBody();
            this.MoveForward();
        }

        //move left
        if (UDP_Handling.X2pos < -40)
        {
            this.MoveBody();
            this.MoveLeft();
        }

        //move right
        if (UDP_Handling.X2pos > 40)
        {
            this.MoveBody();
            this.MoveRight();
        }

        //move backwards
        if (UDP_Handling.Y2pos < -20)
        {
            if (transform.position.z <= -21) return;
            this.MoveBody();
            this.MoveBackwards();
        }
    }

    void MoveForward()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.5f);
        transform.position += new Vector3(0, 0, (float)UDP_Handling.Y2pos / 20 * Time.deltaTime);
        UDP_Handling.Ytarget = UDP_Handling.Y2pos * 1.2;
    }

    void MoveLeft()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 0.5f);
        transform.position += new Vector3((float)UDP_Handling.X2pos / 30 * Time.deltaTime, 0, 0);
        UDP_Handling.Xtarget = UDP_Handling.X2pos * 1.2;
    }

    void MoveBackwards()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), 0.5f);
        transform.position += new Vector3(0, 0, (float)UDP_Handling.Y2pos / 20 * Time.deltaTime);
        UDP_Handling.Ytarget = UDP_Handling.Y2pos * 1.2;
    }

    void MoveRight()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 0.5f);
        transform.position += new Vector3((float)UDP_Handling.X2pos / 30 * Time.deltaTime, 0, 0);
        UDP_Handling.Xtarget = UDP_Handling.X2pos * 1.2;
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
