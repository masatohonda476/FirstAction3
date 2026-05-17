using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO.Compression;

public class ItemBoxManager : MonoBehaviour
{
    [SerializeField] ItemsSO itemsSO;
    [SerializeField] TextMeshProUGUI itemText;
    //[SerializeField] TextMeshProUGUI coinText;
    //[SerializeField] TextMeshProUGUI potionText;
    public int getItem;
    
    private int[] itemQtyAry; //各アイテムにの所持数を格納する配列
    private string itemOpenText; //

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemQtyAry = new int[itemsSO.itemList.Count];
        //Debug.Log("itemQtyAry = " + itemQtyAry.Length);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("getItem = " + getItem);
    }

    public void ItemGet()
    {
        itemQtyAry[getItem] = itemQtyAry[getItem] + 1; //獲得アイテムの数を+1する
    }

    public void ItemOpen()
    {
        //coinText.GetComponent<TextMeshProUGUI>().text = "Coin: " + itemQtyAry[0].ToString();
        //potionText.GetComponent<TextMeshProUGUI>().text = "Potion: " + itemQtyAry[1].ToString();
        for (int i = 0; i < itemQtyAry.Length; i++)
        {
            if (itemQtyAry[i] > 0)
            {
                itemOpenText = itemOpenText + itemsSO.itemList[i].ItemName + " " + itemQtyAry[i].ToString() + "\n";
                itemText.GetComponent<TextMeshProUGUI>().text = itemOpenText;
            }
        }
        itemOpenText = ""; //
    }
}
