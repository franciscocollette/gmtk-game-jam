using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillCostUI : MonoBehaviour
{

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI amount;

    public void SetUp(ResourceCost cost)
    {
        gameObject.SetActive(true);
        icon.sprite = cost.Resource.Icon;
        amount.text = cost.amount.ToString();
    }
}
