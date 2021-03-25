using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Text amount;

    private void Update()
    {
        amount.text = PlayerMovement.sum.ToString();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
