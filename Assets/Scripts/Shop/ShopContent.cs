using System;
using System.Collections.Generic;
using System.Linq;
using UI.Home.ShopMenu;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "ShopContent", menuName = "Shop/ShopContent")]
    public class ShopContent : ScriptableObject
    {
        [SerializeField] private List<SkinItem> _skinItems;

        public IEnumerable<SkinItem> SkinItems => _skinItems;

        private void OnValidate()
        {
            var skinsDuplicates = _skinItems.GroupBy(item => item.SkinType)
                                            .Where(array => array.Count() > 1);

            if(skinsDuplicates.Count() > 0)
                throw new InvalidOperationException(nameof(_skinItems));
        }
    }
}