using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCoins : MonoBehaviour
{
    private Text text;
    private float actuelCoins;


    private void OnEnable()
    {
        text = GetComponent<Text>();
        text.text = GameManager.instance.coins.ToString();
        GameManager.instance.OnCoinsChange += ChangeText;
    }

    private void OnDisable()
    {
        GameManager.instance.OnCoinsChange -= ChangeText;
    }

    void ChangeText(int coins)
    {
        actuelCoins = int.Parse(text.text);
        StartCoroutine(ChangeFloat(actuelCoins, actuelCoins + coins, 1 ));
    }

    IEnumerator ChangeFloat(float start, float end, float duration)
    {
        var time = 0f;

        while (time < duration)
        {
            text.text = (start + (end - start) * (time/duration)).ToString("#");
            time += Time.deltaTime;
            yield return null;
        }
        text.text = end.ToString("#");

    }
}
