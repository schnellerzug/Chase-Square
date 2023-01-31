
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextAndHide : MonoBehaviour, IShowText
{
    
    [SerializeField] private Text text;
    [SerializeField] private Color startColor = Color.clear;
    [SerializeField] private float showTime;
    [SerializeField] private float transitionTime;

    private void Start()
    {
        text.color= startColor;
    }
    public void Show(string content, Color color)
    {
        StopAllCoroutines();
        StartCoroutine(ShowAndHide(text, content,startColor, color, showTime, transitionTime));
    }

    public IEnumerator ShowAndHide(Text text, string content,Color startColor, Color endColor, float showTime, float transitionTime)
    {
        var time = 0f;
        text.text = content;
        while(time < transitionTime)
        {
            time += Time.deltaTime;
            text.color = startColor + (endColor - startColor) * (time/transitionTime);
            yield return null;
        }
        text.color = endColor;
        yield return new WaitForSeconds(showTime);
        time = 0f;
        while (time < transitionTime)
        {
            time += Time.deltaTime;
            text.color = endColor + (startColor - endColor) * (time / transitionTime);
            yield return null;
        }
        text.color = startColor;

    }
}
