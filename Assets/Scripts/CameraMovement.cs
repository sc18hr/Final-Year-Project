using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    private Vector3 position = new Vector3(0f, 4.7f, -3.8f);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + position;
    }
}
