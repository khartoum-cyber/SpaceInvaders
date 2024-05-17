using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float playerSpeed;
    private float movementHorizontal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * movementHorizontal * playerSpeed * Time.deltaTime;
    }
}
