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

            leftDoor.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -150, 0), 0.5f);
            rightDoor.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 150, 0), 0.5f);

            //display message before next level
            manager.CompleteLevel();
        }
    }
}
