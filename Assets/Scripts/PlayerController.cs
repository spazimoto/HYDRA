using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = .1f;

    public ProjectileController ProjectilePrefab;
    public Transform LaunchOffset;

    Animator playerAnimator;

    void Start()
    {
        var healthScript = gameObject.GetComponent<LifeCounter>();

        playerAnimator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            playerAnimator.SetTrigger("throw");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, yDirection, 0.0f);

        transform.position += moveDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Head") || collision.gameObject.CompareTag("Body"))
        {
            gameObject.SendMessage("TakeDamage", 1);
        }
    }
}
