using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventSO", menuName = "Scriptable Objects/EventSO")]
public class EventSO : ScriptableObject
{
    public List<Events> eventList = new List<Events>();
    [System.Serializable]
    public class Events
    {
        [SerializeField] string personName;
        [TextArea]
        [SerializeField] string words;
        [SerializeField] int yes;
        [SerializeField] int no;

        public string Words { get => words; }
        public int Yes { get => yes; }
        public int No { get => no; }
    }
    
}
