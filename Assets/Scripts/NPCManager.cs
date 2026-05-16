using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class NPCManager : MonoBehaviour
{
    [SerializeField] GameObject talkWindow;
    [SerializeField] TextMeshProUGUI talkText;
    [SerializeField] EventSO eventSO;
    private bool talkWIndowFrag = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Weapon")
        {

            switch (talkWIndowFrag)
            {
                case false:
                    talkWindow.SetActive(true);
                    talkText.text = eventSO.eventList[0].Words;
                    talkWIndowFrag = true;
                    break;
                case true:
                    talkWindow.SetActive(false);
                    talkText.text = "";
                    talkWIndowFrag = false;
                    break;
                default:
                    break;
            }
        }
    }
}
