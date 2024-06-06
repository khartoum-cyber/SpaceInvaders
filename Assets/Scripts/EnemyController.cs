using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float timer = 0;
    private int numOfMovements = 0;
    private float movementAmount = 0.19f;
    public GameObject enemyProjectile;
    public GameObject enemyProjectileClone;
    public GameObject enemy;
    private float fireTimer = 0;
    private float timeToFire = 0.1f;
    private float maxY = -3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.playGame == true)
        {
            timer += Time.deltaTime;

            // Move enemies horizontally
            if (timer > 0.5 && numOfMovements != 17)
            {
                transform.Translate(new Vector3(movementAmount, 0, 0));
                timer = 0;
                numOfMovements++;
            }

            // Move enemies vertically and reverse horizontal movement direction
            if (numOfMovements == 17)
            {
                transform.Translate(0, (float)-0.5, 0);
                numOfMovements = 0;
                timer = 0;
                movementAmount = -movementAmount;

                if(transform.position.y < maxY)
                {
                    GameManager.instance.enemyBreach = true;
                    GameManager.instance.playGame = false;
                }
            }

            fireTimer += Time.deltaTime;

            if (fireTimer > timeToFire)
            {
                FireEnemyProjectile();
                fireTimer = 0;
            }
        }
    }

    private void FireEnemyProjectile()
    {
        // if less than 1f - fire
        if(Random.Range(0f, 125f) < 1)
        {
            enemyProjectileClone = Instantiate(enemyProjectile, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.6f), enemy.transform.rotation);
        }
    }
}
