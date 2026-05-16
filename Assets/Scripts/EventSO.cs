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

        public string Words { get => words; }
    }
    
}
