using UnityEngine;

[CreateAssetMenu(menuName = "AbyssalTree/Resource")]
public class ResourceSO : ScriptableObject
{

    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public string Title { get; private set; }

}
