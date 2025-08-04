using UnityEngine;
using TMPro;

public class SuperAttackUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private PlayerSpider playerSpider;

    void Update()
    {
        if (ammoText != null && playerSpider != null) ammoText.text = $"{playerSpider.Flies}";
    }
}
