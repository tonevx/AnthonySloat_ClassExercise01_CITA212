using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Game has begun.");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("This probably still works. Hopefully, it does.");
        float x = Input.GetAxis("Horizontal");  // +1 or -1 for x value
        float y = Input.GetAxis("Vertical");  // +1 or -1 for y value
        Vector3 move = new Vector3(x, y, 0f);
        transform.Translate(move * moveSpeed * Time.deltaTime);

    }
}
