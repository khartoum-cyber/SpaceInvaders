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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
            Destroy(playerProjectile);
            GameManager.instance.playGame = true;
            GameManager.instance.enemyCount--;
        }

        if (collision.gameObject.CompareTag("TopOfScreen"))
        {
            Destroy(playerProjectile);
        }
    }
}
