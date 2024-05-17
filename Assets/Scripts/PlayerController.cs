using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float playerSpeed;
    private float movementHorizontal;
    public float maxX;
    public GameObject playerProjectile;
    public GameObject playerProjectileClone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");

        // move within screen logic
        if ((movementHorizontal > 0 && transform.position.x < maxX) || (movementHorizontal < 0 && transform.position.x > - maxX))
        {
            transform.position += Vector3.right * movementHorizontal * playerSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerProjectileClone = Instantiate(playerProjectile, new Vector3(player.transform.position.x, player.transform.position.y + 0.6f), player.transform.rotation);
        }
    }
}
