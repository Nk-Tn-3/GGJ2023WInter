using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerColor", menuName ="Player/Color")]
public class CharacterColor : ScriptableObject
{
    public string name;
    public List<Color> colors;


}
