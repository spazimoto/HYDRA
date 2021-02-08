using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = .1f;

    public ProjectileController ProjectilePrefab;
    public Transform LaunchOffset;

    Animator playerAnimator;

    public AudioClip spearThrow;
    public AudioSource sfxSource;

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

            sfxSource.clip = spearThrow;
            sfxSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        float xDirection = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, 0.0f);

        transform.position += moveDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Head") || collision.gameObject.CompareTag("Body") || collision.gameObject.CompareTag("Gorgon"))
        {
            gameObject.SendMessage("TakeDamage", 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Cyclops"))
        {
            gameObject.SendMessage("TakeDamage", 1);
        }
    }
}
