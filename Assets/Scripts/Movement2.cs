using UnityEngine;

public class Movement2 : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;

    [SerializeField] private ParticleSystem supersaiyan1;
    [SerializeField] private ParticleSystem supersaiyan2;
    [SerializeField] private ParticleSystem supersaiyan3;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, 0f, rotationSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 1f, 0f);
        }
        if (Input.GetKey(KeyCode.K))
        {
            supersaiyan2.Stop();
            supersaiyan3.Stop();
            supersaiyan1.Play();
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            supersaiyan1.Stop();
            supersaiyan2.Play();
            supersaiyan3.Play();
            spriteRenderer.color = Color.yellow;
        }
        Debug.Log("This probably still works. Hopefully, it does.");
        float x = Input.GetAxis("Horizontal");  // +1 or -1 for x value
        float y = Input.GetAxis("Vertical");  // +1 or -1 for y value
        Vector3 move = new Vector3(x, y, 0f);
        transform.Translate(moveSpeed * Time.deltaTime * move);  
    }
}
