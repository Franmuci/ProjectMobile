using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SavePoints", menuName = "Scriptable Objects/SavePoints")]
public class SavePoints : ScriptableObject
{
    public int highScore;

    public List<LeaderBoard> leaderBoard;

}


[System.Serializable]
public class LeaderBoard
{
    public LeaderBoard(string curNombre, int curPuntos) 
    {
        nombre = curNombre;
        puntos = curPuntos;
    }

    public string nombre;
    public int puntos;
}

