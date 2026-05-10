using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatusWindowManager : MonoBehaviour
{
    [SerializeField] PlayerStatusSO playerStatusSO;
    [SerializeField] TextMeshProUGUI MAXHPValue;
    [SerializeField] TextMeshProUGUI currentHP;
    [SerializeField] TextMeshProUGUI MAXMPValue;
    [SerializeField] TextMeshProUGUI AttackValue;
    [SerializeField] TextMeshProUGUI DefenseValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MAXHPValue.GetComponent<TextMeshProUGUI>().text = playerStatusSO.HP.ToString();
        MAXMPValue.GetComponent<TextMeshProUGUI>().text = playerStatusSO.MP.ToString();
        AttackValue.GetComponent<TextMeshProUGUI>().text = playerStatusSO.ATTACK.ToString();
        DefenseValue.GetComponent<TextMeshProUGUI>().text = playerStatusSO.DEFENSE.ToString();
    }

    public void StatusOpen()
    {
        currentHP.GetComponent<TextMeshProUGUI>().text = GameObject.Find("MaleCharacterPBR").GetComponent<PlayerController>().currentHP.ToString();
    }
}
