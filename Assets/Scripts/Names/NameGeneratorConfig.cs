using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NameGeneratorConfig", menuName = "ScriptableObjects/NameGeneratorConfig", order = 1)]
public class NameGeneratorConfig : ScriptableObject
{
    public string[] prefixes;
    public string[] roots;
    public string[] suffixes;
}
