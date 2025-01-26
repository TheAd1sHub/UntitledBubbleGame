using UnityEngine;

public class BubblePlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f; // Controls overall speed of movement
    public float responsiveness = 2f; // Controls how quickly the bubble responds to input

    [Header("Bubble Properties")]
    public float durability = 100f; // Placeholder for durability logic

    [Header("Bubble Float Settings")]
    public float floatStrength = 0.5f; // Controls the left-right floating strength
    public float floatFrequency = 1f; // Controls the speed of floating movement

    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;
    private float floatOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component is required for the bubble movement.");
        }
        floatOffset = Random.Range(0f, Mathf.PI * 2);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            Vector3 targetVelocity = new Vector3(horizontalInput * speed, verticalInput * speed, 0f);
            rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, targetVelocity, responsiveness * Time.fixedDeltaTime);

            float floatMotion = Mathf.Sin(Time.time * floatFrequency + floatOffset) * floatStrength;
            rb.position += new Vector3(floatMotion * Time.fixedDeltaTime, 0f, 0f);
        }
    }
}

