using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{

    [SerializeField] private Image fillBar;
    [SerializeField] private TextMeshProUGUI text;

    private HitPoints target;
    private void Start()
    {
        target = Player.Instance.GetComponent<HitPoints>();
    }
    private void Update()
    {
        fillBar.fillAmount = target.CurrentHP / target.MaxHP;

        text.text = target.CurrentHP + "/" + target.MaxHP;
    }

}
