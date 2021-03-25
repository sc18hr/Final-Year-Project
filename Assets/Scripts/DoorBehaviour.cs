using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public GameObject leftDoor;
    public GameObject rightDoor;
    public Manager manager;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementUDP>().enabled = false;

            leftDoor.transform.Rotate(0, -120, 0); 
            rightDoor.transform.Rotate(0, 120, 0);  

            //display message before next level
            manager.CompleteLevel();
        }
    }
}
