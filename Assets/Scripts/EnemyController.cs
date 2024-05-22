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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
            transform.Translate(0, -1, 0);
            numOfMovements = 0;
            timer = 0;
            movementAmount = -movementAmount;
        }
    }
}
