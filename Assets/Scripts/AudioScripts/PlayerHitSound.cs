using UnityEngine;

public class PlayerHitSound : MonoBehaviour
{
    public static PlayerHitSound instance;
    public AudioSource audio;
    public AudioClip playerHitSound;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audio.clip = playerHitSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerHit()
    {
        audio.Play();
    }
}
