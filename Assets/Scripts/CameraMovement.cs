using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    private Vector3 position = new Vector3(0f, 6.76f, -3.63f); //0.5,-20

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + position;
        //transform.rotation = player.rotation * Quaternion.Euler(43f, 0f, 0f);
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(player.rotation.x+ 43f, player.rotation.y, player.rotation.z), 0.5f);
        //transform.LookAt(player);
    }
}
