using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CD_Level", menuName = "ScriptableObjects/CD_Level", order = 1)]

public class CD_Level : ScriptableObject
{

public List<LevelData> Levels=new List<LevelData>();
public LevelData levelData;

}
