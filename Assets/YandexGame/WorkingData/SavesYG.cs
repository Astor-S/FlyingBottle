using GameService;
using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения
        
        public List<Skins> ownedSkins = new List<Skins>();
        public List<Levels> openedLevels = new List<Levels>();
        public Skins selectedSkin; 

        public int balanceMoney;
        public int score;

        public bool isSoundOn;
        // ...

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива
            isSoundOn = true;
            openLevels[1] = true;

            ownedSkins.Add(Skins.Water);
            selectedSkin = Skins.Water;
            openedLevels.Add(Levels.Level1);
        }

        public bool IsLevelOpen(Levels level) =>
            openedLevels.Contains(level);
    }
}
