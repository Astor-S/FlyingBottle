using NaughtyAttributes;
using UnityEngine;

namespace UI.Home.LevelMenu
{
    [CreateAssetMenu(fileName = "NewLevelCell", menuName = "Scriptable Objects/LevelCell")]
    public class LevelCell : ScriptableObject
    {
        [Scene]
        [SerializeField] private string _sceneToLoad;
        [SerializeField] private int _cellIndex;
    }
}