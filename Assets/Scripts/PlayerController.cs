using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Animator animator;
    private float speed = 30f;//移動速度
    public int currentHP;
    private int damage;
    private bool statusWindowFrag = false;
    [SerializeField] EnemyStatusSO EnemyStatusSO;

    [SerializeField] PlayerStatusSO playerStatusSO;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] GameObject statusWindow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        hpText.GetComponent<TextMeshProUGUI>().text = "HP: " + currentHP.ToString();
        currentHP = playerStatusSO.HP;
        statusWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        hpText.GetComponent<TextMeshProUGUI>().text = "HP: " + currentHP.ToString();

        //キャラクター移動処理
        if (Input.GetKey(KeyCode.UpArrow))//前
        {
            rigidBody.AddForce(transform.forward * speed, ForceMode.Acceleration);
            animator.SetBool("MoveFWD", true);
        }
        if (Input.GetKey(KeyCode.DownArrow))//後
        {
            rigidBody.AddForce(transform.forward * speed * -1, ForceMode.Acceleration); 
            animator.SetBool("MoveBWD", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))//右
        {
            rigidBody.AddForce(transform.right * speed, ForceMode.Acceleration);        
            animator.SetBool("MoveRGT", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow))//左
        {
            rigidBody.AddForce(transform.right * speed * -1, ForceMode.Acceleration);        
            animator.SetBool("MoveLFT", true);
        }

        //攻撃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Attack", true);
        }

        //ステータス画面
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (statusWindowFrag)
            {
                case false:
                    GameObject.Find("StatusWindowManager").GetComponent<StatusWindowManager>().StatusOpen();
                    statusWindow.SetActive(true);
                    Time.timeScale = 0;
                    statusWindowFrag = true;
                    break;
                case true:
                    statusWindow.SetActive(false);
                    Time.timeScale = 1;
                    statusWindowFrag = false;
                    break;
            }
        }
                 
    //キーを離したときの処理
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
        //攻撃
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Attack", false);
        }

        //死亡判定
        if (currentHP <= 0)
        {            
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("被弾");
            damage = (int)(EnemyStatusSO.enemyStatusList[0].ATTACK / 2 - playerStatusSO.DEFENSE / 4);
            if (damage > 0)
            {
               currentHP = currentHP - damage;
            }
        }
        
    }
}
