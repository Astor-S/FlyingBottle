using UnityEngine;
using UnityEngine.UI;

namespace UI.Home.LevelMenu
{
    public class MapDisplay : MonoBehaviour
    {
        [SerializeField] private Image _mapImage;

        public void DisplayMap(Map map) =>
            _mapImage.sprite = map.GetMapImage();
    }
}