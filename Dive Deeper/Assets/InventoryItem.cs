using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Dive Deeper/InventoryItem", order = 0)]
public class InventoryItem : ScriptableObject
{
    public Sprite sprite;
    public string displayName;
}