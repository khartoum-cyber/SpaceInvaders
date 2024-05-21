using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float timer = 0;
    private int numOfMovements = 0;
    private float movementAmount = 0.19f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5 && numOfMovements != 17)
        {
            transform.Translate(new Vector3(movementAmount, 0, 0));
            timer = 0;
            numOfMovements++;
        }
    }
}
