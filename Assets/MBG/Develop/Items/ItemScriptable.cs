using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject/ItemScriptable", menuName = "ItemScriptable")]
public class ItemScriptable : ScriptableObject
{
    [Min(1)] public int Responsiveness;
    [Min(1)] public int Durability;
    public TypeOfItem ItemType;

    public enum TypeOfItem
    {
        None,
        Liquid,
        Reactive
    }
}
