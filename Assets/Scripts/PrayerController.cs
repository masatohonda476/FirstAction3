using System.Runtime.CompilerServices;
using UnityEngine;

public class PrayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator animator;
    private float speed = 30f;//移動速度
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //キャラクター移動処理S
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidBody.AddForce(transform.forward * speed, ForceMode.Acceleration);
            animator.SetBool("MoveFWD", true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidBody.AddForce(transform.forward * speed * -1, ForceMode.Acceleration); 
            animator.SetBool("MoveBWD", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.AddForce(transform.right * speed, ForceMode.Acceleration);        
            animator.SetBool("MoveRGT", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.AddForce(transform.right * speed * -1, ForceMode.Acceleration);        
            animator.SetBool("MoveLFT", true);
        }         

       if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.SetBool("MoveFWD", false);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animator.SetBool("MoveBWD", false);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("MoveRGT", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("MoveLFT", false);
        }

        //キャラクター移動処理E
    }
}
