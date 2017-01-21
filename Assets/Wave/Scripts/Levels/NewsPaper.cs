using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NewsPaper : MonoBehaviour
{
    public Text headline;
    string winHigh = "Electors remain faithful to Trump and select him as official winner";
    string winLow = "ZZZZZZzzzzz. Audience falling asleep at low energy event. Trump’s highly anticipated speech gets subdued response.";
    string loose = "When Trump hit a rough patch in his approval ratings, he said the rules were rigged against him and labeled the whole game a \"scam\" perpetrated by shaddy developers.";


    public void Init(bool isWinner, float score)
    {
        gameObject.SetActive(true);
        var text = loose;
        if (isWinner)
        {
            text = score >= 0.5 ? winHigh : winLow;
        }
        headline.text = text;
    }
}
