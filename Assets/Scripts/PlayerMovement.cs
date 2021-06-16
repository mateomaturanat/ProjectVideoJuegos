using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{

    bool alive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    [SerializeField] private Animator anim;

    [SerializeField] private float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;
    [SerializeField] float jump = 0;
    public float speedIncreasePerPoint = 0.1f;
    public bool isFloor = true;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        Jump();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (transform.position.y < -5)
        {
            Die();
        }
        anim.SetFloat("speedX", horizontalInput);
    }

    public void Die()
    {
        alive = false;
        // Reinicio del Juego
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isFloor)
        {
            rb.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
            isFloor = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isFloor = true;
        print("estoy en el suelo putos");
    }
}