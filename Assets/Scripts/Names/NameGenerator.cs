using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameGenerator : MonoBehaviour
{
    [SerializeField] private NameGeneratorConfig nameConfig;
    [SerializeField] private TMP_Text playerName;
    private void Start()
    {
        string randomName = GenerateName();
        playerName.text = $"Descent: {randomName}";
    }

    private string GenerateName()
    {
        string prefix = nameConfig.prefixes.Length > 0
            ? nameConfig.prefixes[Random.Range(0, nameConfig.prefixes.Length)]
            : string.Empty;

        string root = nameConfig.roots[Random.Range(0, nameConfig.roots.Length)];

        string suffix = nameConfig.suffixes.Length > 0
            ? nameConfig.suffixes[Random.Range(0, nameConfig.suffixes.Length)]
            : string.Empty;

        return $"{prefix}{root}{suffix}".Trim();
    }
}
