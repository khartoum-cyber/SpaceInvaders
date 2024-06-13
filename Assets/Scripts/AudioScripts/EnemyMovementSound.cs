using UnityEngine;

public class EnemyMovementSound : MonoBehaviour
{
    public static EnemyMovementSound instance;
    public AudioSource audio;
    public AudioClip enemyMovementSound;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audio.clip = enemyMovementSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyMovement()
    {
        audio.Play();
    }
}
