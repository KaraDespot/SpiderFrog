using UnityEngine;

[CreateAssetMenu(fileName = "RuntimeDataSO", menuName = "Game/Runtime Data")]
public class RuntimeDataSO : ScriptableObject
{
    // ������ ������, ������� ����� �������
    public int playerScore;
    public string playerName;
    // �������� ������ ���� ��� ����� ������
}