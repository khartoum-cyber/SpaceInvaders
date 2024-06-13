using UnityEngine;

public class PlayerFireSound : MonoBehaviour
{

    public static PlayerFireSound instance;
    public AudioSource audio;
    public AudioClip playerFireSound;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audio.clip = playerFireSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerFire()
    {
        audio.Play();
    }
}
