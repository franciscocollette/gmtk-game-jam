using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour
{

    [SerializeField] private Image image;
    [SerializeField] private ResourceSO target;

    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        image.sprite = target.Icon;
    }

    private void Update()
    {
        text.text = ResourceManager.Instance.GetAmount(target).ToString();
    } 
}
