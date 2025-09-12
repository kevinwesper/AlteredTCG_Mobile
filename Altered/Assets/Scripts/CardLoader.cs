using System;
using System.Collections.Generic;
using UnityEngine;

public class CardLoader : MonoBehaviour
{
    public TextAsset cardJson; // Assign your JSON file in the Unity Inspector

    void Start()
    {
        
    }    
}

[Serializable]
public class Card
{
    public string id;
    public string reference;
    public string name;
    public string imagePath;
    public Dictionary<string, string> allImagePath;
    public List<string> assets;
    // Add other fields as needed (e.g., cardType, cardSubTypes, etc.)
}

[Serializable]
public class CardType
{
    public string id;
    public string reference;
    public string name;
}

[Serializable]
public class CardSubType
{
    public string id;
    public string reference;
    public string name;
}

[Serializable]
public class CardSet
{
    public string id;
    public string reference;
    public string name;
}

[Serializable]
public class Rarity
{
    public string id;
    public string reference;
    public string name;
}

[Serializable]
public class Faction
{
    public string id;
    public string reference;
    public string name;
    public string color;
}