using UnityEngine;
using UnityEngine.Audio;

/** 
 * This class is attached to the audio manager game object.
 * On awake, if a sound track does not exist then it creates one.
 * The main reason for this class is the DontDestroyOnLoad method that
 * allows the sound track to continuously loop through levels.
 */

public class AudioManager : MonoBehaviour
{
    public static AudioManager track;

    void Awake()
    {
        //if a track does not exist then create one, else destroy the duplicate
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
