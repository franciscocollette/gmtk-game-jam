using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillButtonUI : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler
{

    [SerializeField] private SkillSO target;

    [Space]
    [SerializeField] private Image button;

    [SerializeField] private Color locked = Color.white;
    [SerializeField] private Color unlocked = Color.white;
    [SerializeField] private Color maxLevel = Color.white;
    [SerializeField] private Color oneLevel = Color.white;

    [Space]
    [SerializeField] private Image[] arrows;

    [SerializeField] private Color arrowLocked = Color.white;
    [SerializeField] private Color arrowUnlocked = Color.white;
    [Space]

    [SerializeField] private Image Icon;
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private TextMeshProUGUI Description;
    [SerializeField] private TextMeshProUGUI Level;
    [SerializeField] private SkillCostUI[] Costs;
    [Space]
    [SerializeField] private GameObject OnSelect;


    private void Start()
    {
        Icon.sprite = target.Icon;
        Title.text = target.Title;
        Description.text = target.Description;

        OnSelect.SetActive(false);
    }

    private void Update()
    {
        if (target.IsLocked())
            button.color = locked;
        else if (target.IsMaxLevel)
            button.color = maxLevel;
        else if (target.AtLeastOneLevel)
            button.color = oneLevel;
        else
            button.color = unlocked;

        foreach (var item in arrows)
        {
            item.color = target.IsLocked() ? arrowLocked : arrowUnlocked;
        }

        Level.text = target.IsMaxLevel ? "Max Lvl" : "Lvl" + target.CurrentLevel.ToString();

        foreach (var item in Costs)
            item.gameObject.SetActive(false);
        int i = 0;
        if (target.IsMaxLevel)
            return;
        foreach (var item in target.Cost.Resources)
        {
            Costs[i].SetUp(item);
        }

    }

    public void UI_OnPressed()
    {
        target.TryLevelUp();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnSelect.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnSelect.SetActive(true);
    }
}
