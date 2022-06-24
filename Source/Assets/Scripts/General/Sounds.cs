using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static Sounds sound { get; private set; }

    public AudioSource jumpSound;
    public AudioSource speedBoost;
    public AudioSource fallSound;
    public AudioSource deathSound;
    public AudioSource pauseMenuMusic;
    public AudioSource backgroundMusic;

    private void Awake()
    {
        sound = this;
    }
}
