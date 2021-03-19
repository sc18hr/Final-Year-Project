using UnityEngine;
using UnityEngine.UI;

public class LoadNextLevel : MonoBehaviour
{
    public Manager manager;
    public Text timer;

    private int countdown = 3;

    public void Next()
    {
        manager.NextLevel();
    }

    public void Countdown()
    {
        if (countdown > 0)
        {
            countdown--;
        }

        timer.text = countdown.ToString();
    }
}
