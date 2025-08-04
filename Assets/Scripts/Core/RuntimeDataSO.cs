using UnityEngine;

[CreateAssetMenu(fileName = "RuntimeDataSO", menuName = "Game/Runtime Data")]
public class RuntimeDataSO : ScriptableObject
{
    // Данные игрока, которые сохраняются между сценами
    public int playerScore;
    public string playerName;
    public int collectedFlies; // Количество собранных мошек в FrogPhase
}