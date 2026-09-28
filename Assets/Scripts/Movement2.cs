using UnityEngine;

public class Movement2 : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        Debug.Log("This probably still works. Hopefully, it does.");
        float x = Input.GetAxis("Horizontal");  // +1 or -1 for x value
        float y = Input.GetAxis("Vertical");  // +1 or -1 for y value
        Vector3 move = new Vector3(x, y, 0f);
        transform.Translate(moveSpeed * Time.deltaTime * move);  
    }
}
