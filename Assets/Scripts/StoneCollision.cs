using Unity.VisualScripting;
using UnityEngine;

public class StoneCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem GStone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GStone"))
        {
            Debug.Log("G Stone collected!");
            Destroy(collision.gameObject);;
            GStone.Play();
        }
    }
}
