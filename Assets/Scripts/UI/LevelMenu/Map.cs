using UnityEngine;

namespace UI.LevelMenu
{
    [CreateAssetMenu (fileName = "NewMap", menuName = "Scriptable Objects/Map")]
    public class Map : ScriptableObject
    {
        public int mapIndex;
        public string mapName;
        public Sprite mapImage;
    }
}