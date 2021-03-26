using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager track;

    void Awake()
    {
        //if an track does not exist then create one, else destroy the duplicate
        if (track == null)
        {
            track = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //allows the track to continually play throughout the game and levels
        DontDestroyOnLoad(gameObject);
    }
}
