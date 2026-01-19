using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInfoController : MonoBehaviour
{
    //Texto e painel
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI rarityText;
    [SerializeField] private Image border;

    //Estrelas
    [SerializeField] private List<Image> stars;
    [SerializeField] private Sprite starFilled;
    [SerializeField] private Sprite starEmpty;

    //Cores
    [SerializeField] private Color commonColor = Color.white;
    [SerializeField] private Color uncommonColor = Color.white;
    [SerializeField] private Color rareColor = Color.white;

    [SerializeField] private GameObject panel;

    public void SetVisible(bool isVisible = true)
    {
        panel.SetActive(isVisible);
    }

    public void SetObjectInfo(SOObjectInfo info)
    {
        titleText.text = info.objectName;
        descriptionText.text = info.description;
        SetObjectRarity(info.rarity);
        SetObjectStars(info.rarity);
    }

    public void SetObjectStars()
    {

    }

    public void SetObjectRarity(Rarity rarity)
    {
        if (rarityText == null || border == null || stars == null) return;

        switch (rarity)
        {
            case Rarity.Common:
                rarityText.text = "Comum";
                border.color = commonColor;
                break;
            case Rarity.Uncommon:
                rarityText.text = "Incomum";
                border.color = uncommonColor;
                break;
            case Rarity.Rare:
                rarityText.text = "Raro";
                border.color = rareColor;
                break;
        }
    }

public void SetObjectStars(Rarity rarity)
{
    if (stars == null || stars.Count == 0) return;

    int filledStars = 0;

    switch (rarity)
    {
        case Rarity.Common:
            filledStars = 1;
            break;
        case Rarity.Uncommon:
            filledStars = 2;
            break;
        case Rarity.Rare:
            filledStars = 3;
            break;
    }

    for (int i = 0; i < stars.Count; i++)
    {
        stars[i].sprite = i < filledStars ? starFilled : starEmpty;
    }
}

}
