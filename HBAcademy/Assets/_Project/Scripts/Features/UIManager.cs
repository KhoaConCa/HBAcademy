using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using Vox.Ultilities.DesignPatterns.Singleton;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] TextMeshProUGUI coinText;

    public void SetCoin(int coin)
    {
        coinText.text = coin.ToString();
    }
}
