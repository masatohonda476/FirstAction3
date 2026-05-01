using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator animator;
    private float speed = 30f;//移動速度
    private int hp = 200;
    [SerializeField] TextMeshProUGUI hpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        hpText.GetComponent<TextMeshProUGUI>().text = "HP: " + hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        hpText.GetComponent<TextMeshProUGUI>().text = "HP: " + hp.ToString();

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

    void OnCollisionEnter(Collision col)
    {
        hp = hp - 10;
    }
}
