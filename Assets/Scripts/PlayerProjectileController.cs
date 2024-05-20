using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{
    public float projectileSpeed = -5;
    public GameObject playerProjectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, projectileSpeed * Time.deltaTime, 0));
    }
}
