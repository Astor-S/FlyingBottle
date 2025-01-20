using GameService;
using UnityEngine;

namespace UI.Home.ShopMenu
{
    [CreateAssetMenu(fileName = "BottleSkinItem", menuName = "Shop/BottleSkinItem")]
    public class SkinItem : ShopItem
    {
        [field: SerializeField] public Skins SkinType { get; private set; }
    }
}