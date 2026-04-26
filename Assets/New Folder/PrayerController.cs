using System.Runtime.CompilerServices;
using UnityEngine;

public class PrayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float speed = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidBody.AddForce(transform.forward * speed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidBody.AddForce(transform.forward * speed * -1, ForceMode.Acceleration); 
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.AddForce(transform.right * speed, ForceMode.Acceleration);        
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.AddForce(transform.right * speed * -1, ForceMode.Acceleration);        
        }                          
    }
}
