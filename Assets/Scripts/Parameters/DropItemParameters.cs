using UnityEngine;

[CreateAssetMenu(fileName = "DropItemParameters", menuName = "CustomParameters/DropItemParameters")]
public class DropItemParameters : ScriptableObject
{
    [SerializeField] private Item _itemPrefab;

    public Item ItemPrefab => _itemPrefab;
}
