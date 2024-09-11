using System;
using UnityEngine;

public class Level 
{
    public event Action Defeat; 

    public void Start()
    {
        //логитка старта
        Debug.Log("StartLevel");
    }

    public void Restart()
    {
        //логика очистки уровня
        Start();
    }

    public void OnDefeat()
    {
        //логика остановки уровня
        Defeat?.Invoke();
    }
}
