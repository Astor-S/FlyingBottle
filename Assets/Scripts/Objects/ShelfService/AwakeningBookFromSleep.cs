using System.Collections.Generic;
using UnityEngine;

namespace ShelfService
{
    public class AwakeningBookFromSleep : MonoBehaviour
    {
        [SerializeField] private List<ShelfBreaker> _shelfBreakers;
        [SerializeField] private List<Objects.Book> _books;

        private void OnEnable()
        {
            foreach (ShelfBreaker shelfBreaker in _shelfBreakers)
                shelfBreaker.ShelfBreak += OnShelfBreak;
        }

        private void OnDisable()
        {
            foreach (ShelfBreaker shelfBreaker in _shelfBreakers)
                shelfBreaker.ShelfBreak -= OnShelfBreak;
        }

        private void OnShelfBreak()
        {
            foreach (Objects.Book book in _books)
                book.Reawaken();
        }
    }
}