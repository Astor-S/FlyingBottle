using UnityEngine;

namespace UI.Home.LevelMenu
{
    [CreateAssetMenu (fileName = "NewMap", menuName = "Scriptable Objects/Map")]
    public class Map : ScriptableObject
    {
        public int mapIndex;
        public string mapName;
        public Sprite mapImage;
    }
}