using UnityEngine;

[CreateAssetMenu(fileName = "RuntimeDataSO", menuName = "Game/Runtime Data")]
public class RuntimeDataSO : ScriptableObject
{
    // Пример данных, которые можно хранить
    public int playerScore;
    public string playerName;
    // Добавьте нужные поля для вашей сессии
}