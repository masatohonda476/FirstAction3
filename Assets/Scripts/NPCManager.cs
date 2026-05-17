using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class NPCManager : MonoBehaviour
{
    [SerializeField] GameObject talkWindow;
    [SerializeField] TextMeshProUGUI talkText;
    [SerializeField] EventSO eventSO;
    private bool talkWIndowFrag = false;
    private int progressFlag = 0;
    private string currentText;
    
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
                    EventProgress();
                    talkText.text = currentText;
                    talkWIndowFrag = true;
                    break;
                case true:
                    // talkWindow.SetActive(false);
                    // talkText.text = "";
                    talkWIndowFrag = false;
                    break;
            }
        }
    }

    void EventProgress()
    {
        currentText = eventSO.eventList[progressFlag].Words;
        //progressFlag++;
    }

    public void ClickEventButton(bool yesno)
    {
        if (progressFlag < 0 || progressFlag >= eventSO.eventList.Count)
        {
            EndTalk();
            return;
        }

        switch (yesno)
        {
            case true:
                progressFlag = eventSO.eventList[progressFlag].Yes;
                break;
            case false:
                progressFlag = eventSO.eventList[progressFlag].No;
                break; 
        }

        if (progressFlag < 0 || progressFlag >= eventSO.eventList.Count)
        {
            EndTalk();
            return;
        }

        EventProgress();
    }

    void EndTalk()
    {
        talkWindow.SetActive(false);
        talkText.text = "";
        talkWIndowFrag = false;
        progressFlag = 0;
    }
}
