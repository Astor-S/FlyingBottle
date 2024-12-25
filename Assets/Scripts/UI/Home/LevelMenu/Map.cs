using UnityEngine;

namespace UI.Home.LevelMenu
{
    [CreateAssetMenu (fileName = "NewMap", menuName = "Scriptable Objects/Map")]
    public class Map : ScriptableObject, IMapImageProvider
    {
        [SerializeField] private int _mapIndex;
        [SerializeField] private Sprite _mapImage;

        public Sprite GetMapImage() =>
            _mapImage;
    }
}