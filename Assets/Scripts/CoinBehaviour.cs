using UnityEngine;
using UnityEngine.UI;

public class CoinBehaviour : MonoBehaviour
{
    public Text coins;
     
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            gameObject.SetActive(false);

            //update UI
            PlayerMovement.counter += 1;
            coins.text = PlayerMovement.counter.ToString();
        }
    }
}
