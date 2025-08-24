using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// Class to control the card. showing it's sides, loading the artwork.
public class CardController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer frontCard;
    [SerializeField] private TextAsset dataFile;
    [SerializeField] private CardData cardData;
    [SerializeField] private string cardPath;
    private Sprite cardSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GetTexture());
    }

    // Download and return the image of the card from string.
    IEnumerator GetTexture()
    {
        string dataName = string.Format(dataFile.name);
        Debug.Log("name = " + dataName);

        // Doesnt work, I think it cant find the string imagepath cause its inside of another group of variables.
        cardData = JsonUtility.FromJson<CardData>(dataName);

        //Debug.Log("path = " + cardData.imagePath);

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(cardPath);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Texture2D myTexture = DownloadHandlerTexture.GetContent(www);

            cardSprite = Sprite.Create(myTexture, new Rect(0.0f, 0.0f, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
            frontCard.sprite = cardSprite;
        }
    }

    void Update()
    {
        if (frontCard.sprite != null)
        {
            transform.Rotate(0, 0.2f, 0, Space.Self);
        }
    }
}

[Serializable]
public class CardData
{
    public string imagePath;
}

/* Raw Data from JSON File, to be deleted after this script works.
[
  {
    "@context": "/contexts/Card",
    "@id": "/cards/ALT_ALIZE_A_AX_35_C",
    "@type": "Card",
    "cardType": {
      "@id": "/card_types/01H19NWA92A4ERAC4ATMSZNASS",
      "@type": "CardType",
      "reference": "CHARACTER",
      "id": "01H19NWA92A4ERAC4ATMSZNASS",
      "name": "Character"
    },
    "cardSubTypes": [
      {
        "@type": "CardSubType",
        "@id": "/.well-known/genid/c6666f6a65513158681d",
        "reference": "ENGINEER",
        "id": "01HKAGPA9AS71JN0H9HQZTBNCD",
        "name": "Engineer"
      }
    ],
    "cardSet": {
    "@id": "/card_sets/ALIZE",
      "@type": "CardSet",
      "id": "01J1Q4NZCDCGMFTFKASM8H29N6",
      "reference": "ALIZE",
      "name": "Trial by Frost"
    },
    "rarity": {
    "@type": "Rarity",
      "@id": "/.well-known/genid/5c6fcb67048d0c313213",
      "reference": "COMMON",
      "id": "01GE7AC9WEQKW1Y1BF8SCY745A",
      "name": "Common"
    },
    "cardRulings": [],
    "imagePath": "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/JPG/en_US/4d3866d16f8ea46f7020e88437445acc.jpg",
    "assets": {
    "WEB": [
      "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/WEB_633225e9bf5942ef82fcff9bc8f94a36",
        "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/WEB_e92f1de750c6aa55a18e88d28cb32cc1",
        "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/WEB_9824bd19b9054c72c900b1d98a94def5"
    ]
    },
    "lowerPrice": 0,
    "qrUrlDetail": "https://qr.altered.gg/ALT_ALIZE_A_AX_35_C",
    "reference": "ALT_ALIZE_A_AX_35_C",
    "id": "01J3GQBCXE936A2VRZPQ28B83V",
    "mainFaction": {
    "@id": "/factions/AX",
      "@type": "Faction",
      "reference": "AX",
      "color": "#8c432a",
      "id": "01GE7AC9XBG707G19F03A95TH1",
      "name": "Axiom"
    },
    "allImagePath": {
    "en-us": "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/JPG/en_US/4d3866d16f8ea46f7020e88437445acc.jpg",
      "fr-fr": "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/JPG/fr_FR/c527e2f49be74af55ad0aec0e90b2302.jpg",
      "de-de": "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/JPG/de_DE/798a242f144518a439b5fdd7da0e8491.jpg",
      "it-it": "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/JPG/it_IT/b52e79fe13b4a5a440aa13dd85b025b8.jpg",
      "es-es": "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/JPG/es_ES/fcc1e23d0b87bdf9d8cdd5be340cd5d7.jpg"
    },
    "name": "Vaike, Energy Pioneer",
    "elements": {
    "MAIN_COST": "2",
      "RECALL_COST": "2",
      "OCEAN_POWER": "2",
      "FOREST_POWER": "2",
      "MOUNTAIN_POWER": "2",
      "MAIN_EFFECT": "You may play exhausted cards from your Reserve."
    },
    "isSuspended": false,
    "isErrated": false,
    "collectorNumberFormatted": "TBF-005-C-EN"
  },
  {
    "@context": "/contexts/Card",
    "@id": "/cards/ALT_ALIZE_A_AX_35_R1",
    "@type": "Card",
    "cardType": {
        "@id": "/card_types/01H19NWA92A4ERAC4ATMSZNASS",
      "@type": "CardType",
      "reference": "CHARACTER",
      "id": "01H19NWA92A4ERAC4ATMSZNASS",
      "name": "Character"
    },
    "cardSubTypes": [
      {
        "@type": "CardSubType",
        "@id": "/.well-known/genid/d0b5507f6953ad958924",
        "reference": "ENGINEER",
        "id": "01HKAGPA9AS71JN0H9HQZTBNCD",
        "name": "Engineer"
      }
    ],
    "cardSet": {
        "@id": "/card_sets/ALIZE",
      "@type": "CardSet",
      "id": "01J1Q4NZCDCGMFTFKASM8H29N6",
      "reference": "ALIZE",
      "name": "Trial by Frost"
    },
    "rarity": {
        "@type": "Rarity",
      "@id": "/.well-known/genid/5a5fffaacba3c6d07130",
      "reference": "RARE",
      "id": "01GE7AC9WY6PK56RADXXD6P1T5",
      "name": "Rare"
    },
    "cardRulings": [],
    "imagePath": "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/JPG/en_US/e0c45b771648a566f2e6d042272c0428.jpg",
    "assets": {
        "WEB": [
          "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/WEB_633225e9bf5942ef82fcff9bc8f94a36",
        "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/WEB_e92f1de750c6aa55a18e88d28cb32cc1",
        "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/WEB_9824bd19b9054c72c900b1d98a94def5"
        ]
    },
    "lowerPrice": 0,
    "qrUrlDetail": "https://qr.altered.gg/ALT_ALIZE_A_AX_35_R1",
    "reference": "ALT_ALIZE_A_AX_35_R1",
    "id": "01J3GQGGWXD0A35P2C6WDYJSSB",
    "mainFaction": {
        "@id": "/factions/AX",
      "@type": "Faction",
      "reference": "AX",
      "color": "#8c432a",
      "id": "01GE7AC9XBG707G19F03A95TH1",
      "name": "Axiom"
    },
    "allImagePath": {
        "de-de": "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/JPG/de_DE/ce56fd05da3b73df311156372a0266f9.jpg",
      "en-us": "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/JPG/en_US/e0c45b771648a566f2e6d042272c0428.jpg",
      "fr-fr": "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/JPG/fr_FR/4a9b9d28d57c30c9dbbb701ad05a7180.jpg",
      "it-it": "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/JPG/it_IT/78448220f1a9edb4d316bd4683ef7815.jpg",
      "es-es": "https://altered-prod-eu.s3.amazonaws.com/Art/ALIZE/CARDS/ALT_ALIZE_A_AX_35/JPG/es_ES/9aa6b054e5fae6a2992c89e87c4cb916.jpg"
    },
    "name": "Vaike, Energy Pioneer",
    "elements": {
        "MAIN_COST": "2",
      "RECALL_COST": "2",
      "OCEAN_POWER": "2",
      "FOREST_POWER": "#1#",
      "MOUNTAIN_POWER": "2",
      "MAIN_EFFECT": "You may play exhausted cards from your Reserve.  #{R} [Exhausted Resupply].# (Put the top card of your deck in Reserve, then exhaust it {T}.)"
    },
    "isSuspended": false,
    "isErrated": false,
    "collectorNumberFormatted": "TBF-005-R-EN"
  },
  {
    "@context": "/contexts/Card",
    "@id": "/cards/ALT_ALIZE_A_AX_46_C",
    "@type": "Card",
    "cardType": {
        "@id": "/card_types/01J1Q78N4S1E64PN4T7GB4T59F",
      "@type": "CardType",
      "reference": "LANDMARK_PERMANENT",
      "id": "01J1Q78N4S1E64PN4T7GB4T59F",
      "name": "Landmark Permanent"
    },
    "cardSubTypes": [
      {
        "@type": "CardSubType",
        "@id": "/.well-known/genid/0b4a1c3d72a078964058",
        "reference": "SITE",
        "id": "01J1SYC3P1C9H7CT2H8C0WN9CT",
        "name": "Site"
      }
    ],
    "cardSet": {
        "@id": "/card_sets/ALIZE",
      "@type": "CardSet",
      "id": "01J1Q4NZCDCGMFTFKASM8H29N6",
      "reference": "ALIZE",
      "name": "Trial by Frost"
    },
    "rarity": {
        "@type": "Rarity",
      "@id": "/.well-known/genid/7351ce05abca2b15a14b",
      "reference": "COMMON",
      "id": "01GE7AC9WEQKW1Y1BF8SCY745A",
      "name": "Common"
    },
    "cardRulings": [],
    "imagePa...

< ...etc...>*/