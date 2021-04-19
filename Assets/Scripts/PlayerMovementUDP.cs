using UnityEngine;

public class PlayerMovementUDP : MonoBehaviour
{
    public GameObject leftShoulder;
    public GameObject rightShoulder;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject leftKnee;
    public GameObject rightKnee; 

    //counter for the coin collisions
    public static int counter = 0;

    //used to know which limb to move
    private int moveCounter = 0;

    void FixedUpdate()
    {
        if (UDP_Handling.Y2pos > 20)
        {
            this.MoveBody();
            this.MoveForward();
        }

        if (UDP_Handling.X2pos < -40)
        {
            this.MoveBody();
            this.MoveLeft();
        }

        if (UDP_Handling.X2pos > 40)
        {
            this.MoveBody();
            this.MoveRight();
        }

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

    //Rotates the arms and legs depending on the current moveCounter
    void MoveBody()
    {
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
