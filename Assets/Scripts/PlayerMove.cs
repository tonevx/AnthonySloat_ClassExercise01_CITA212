using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Layouts;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    bool hasPackage = false;
    SpriteRenderer ShirouEmiyaStandInRender;
    SpriteRenderer CustomerRender;
    SpriteRenderer CustomerRender2;

    [SerializeField] ParticleSystem testmyParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(hasPackage);
        Debug.Log("Game has begun.");
        ShirouEmiyaStandInRender = GetComponent<SpriteRenderer>();
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("The collision has been successful."+ collision.gameObject.name);
        if(collision.collider.CompareTag("Obstacle"))
        {
            Debug.Log("The collision was with an object of the 'Obstacle' tag. Reduce health or destroy object.");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("The trigger has been successful." + other.gameObject.name);
        if(other.CompareTag("Package"))
        {
            if (hasPackage)
            {
                Debug.Log("You already have a package!!");
                return;
            }
            hasPackage = true;
            Debug.Log("Obtained package!");
            ShirouEmiyaStandInRender.color = Color.red;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Customer"))
        {
            if (hasPackage) 
            {
                Debug.Log("Package successfully delivered!");
                hasPackage = false;
                ShirouEmiyaStandInRender.color = Color.black;
            }
            else 
            {
                Debug.Log("You don't have a package to deliver!");
            }
        }
         if(other.CompareTag("Trigger"))
        {
            testmyParticle.Play();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
         testmyParticle.Stop();
    }
}
