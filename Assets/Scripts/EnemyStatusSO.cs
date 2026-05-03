using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu]
public class EnemyStatusSO : ScriptableObject
{
    public List<EnemyStatus> enemyStatusList = new List<EnemyStatus>();

    [System.Serializable]
    public class EnemyStatus
    {
        //[Header("名前")]
        [SerializeField] string enemyName;
        //[TextArea]
        //[SerializeField] string description;
        [SerializeField] int hP;
        [SerializeField] int mP;
        [SerializeField] int attack;
        [SerializeField] int defense;
        // [SerializeField] enemyType type;

        // public enum enemyType
        // {
        //     normal,
        //     fire,
        //     water,
        // }

        public int HP { get => hP; }
    }

    
}
