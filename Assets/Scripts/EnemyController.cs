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

<<<<<<< HEAD
        // Move enemies horizontally
=======
>>>>>>> 4b0ec850f81e8fb445733bc8036a89a6990e1bf1
        if (timer > 0.5 && numOfMovements != 17)
        {
            transform.Translate(new Vector3(movementAmount, 0, 0));
            timer = 0;
            numOfMovements++;
        }
<<<<<<< HEAD

        // Move enemies vertically and reverse horizontal movement direction
        if (numOfMovements == 17)
        {
            transform.Translate(0, -1, 0);
            numOfMovements = 0;
            timer = 0;
            movementAmount = -movementAmount;
        }
=======
>>>>>>> 4b0ec850f81e8fb445733bc8036a89a6990e1bf1
    }
}
