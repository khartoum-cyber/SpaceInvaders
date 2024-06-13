using UnityEngine;

public class EnemyHitSound : MonoBehaviour
{
    public static EnemyHitSound instance;
    public AudioSource audio;
    public AudioClip enemyHitSound;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audio.clip = enemyHitSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyHit()
    {
        audio.Play();
    }
}
