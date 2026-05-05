using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(fileName = "PlayerStatusSO", menuName = "Scriptable Objects/PlayerStatusSO")]
public class PlayerStatusSO : ScriptableObject
{
    [SerializeField] int hP;
    [SerializeField] int mP;
    [SerializeField] int attack;
    [SerializeField] int defense;

    public int HP { get => hP; }
    public int MP { get => mP; }
    public int ATTACK { get => attack; }
    public int DEFENSE { get => defense; }
}
