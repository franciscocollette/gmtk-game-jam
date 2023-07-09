using TMPro;
using UnityEngine;

public class DamageNumberOnDmg : MonoBehaviour, IOnDmg
{
    [SerializeField] private GameObject textPf;
    [SerializeField] private AnimationCurve scale;
    [SerializeField] private float randPos = .1f;

    //[SerializeField] private Color onCritColor = Color.yellow;
    //[SerializeField] private float onBonusSize = 1.2f;

    public void OnDmg(float amount)
    {
        Vector3 rand = Random.insideUnitCircle * randPos;
        var instance = Instantiate(textPf, transform.position + rand, transform.rotation);

        var txtInstance = instance.GetComponentInChildren<TextMeshProUGUI>();
        txtInstance.text = amount.ToString();

        //if (isCrit)
        //    txtInstance.color = onCritColor;

        //var sizeMultiplier = isCrit ? onBonusSize : 1;
        var sizeMultiplier = 1;
        instance.transform.localScale = scale.Evaluate(amount) * sizeMultiplier * Vector3.one;
    }
}