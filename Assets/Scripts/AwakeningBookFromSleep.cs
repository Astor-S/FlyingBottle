using System.Collections.Generic;
using UnityEngine;

public class AwakeningBookFromSleep : MonoBehaviour
{
    [SerializeField] private List <ShelfBreaker> _shelfBreakers;
    [SerializeField] private List<Book> _books;

    private void OnEnable()
    {
        foreach (ShelfBreaker shelfBreaker in _shelfBreakers)
                shelfBreaker.OnShelfBreak += OnShelfBreak;  
    }

    private void OnDisable()
    {
        foreach (ShelfBreaker shelfBreaker in _shelfBreakers)
            shelfBreaker.OnShelfBreak -= OnShelfBreak;
    }

    private void OnShelfBreak()
    {
        foreach (Book book in _books)
            book.WakeUp();
    }
}