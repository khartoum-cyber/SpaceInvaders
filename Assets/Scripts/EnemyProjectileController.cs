using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileController : MonoBehaviour
{
    public float enemyProjectileSpeed = -3;
    public GameObject enemyProjectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, enemyProjectileSpeed * Time.deltaTime, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // destroys player object
            collision.gameObject.SetActive(false);
            Destroy(enemyProjectile);
        }

        if (collision.gameObject.tag == "BottomOfScreen")
        {
            Destroy(enemyProjectile);
        }
    }
}
