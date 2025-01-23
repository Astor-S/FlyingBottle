using UnityEngine;

namespace UI.Home.ShopMenu
{
    public abstract class ShopItem : ScriptableObject
    {
        [field: SerializeField] public GameObject Model {  get; private set; }
        [field: SerializeField] public Sprite Image { get; private set; }
    }
}