
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMover : MonoBehaviour, IMoveDesign
{

    //[SerializeField] private Sprite[] sprites;
    private Sprite[] icons;
    private int actuelicon;

    private GameObject[] designs;
    private int actuelDesign;

    [SerializeField] private int designsInRow;
    [SerializeField] private float dis;
    [SerializeField] private float scaleMult;

    private bool isRunning;
    private bool isMoving;

    private Queue<int> queue;

    private void Awake()
    {
        //goes later to a Input Script
        queue= new Queue<int>();
  
    }
    public void Move(int x, int y)
    {
        if (queue.Count >= 1)
            return;
        queue.Enqueue(x);
        if (isRunning)
            return;
        StartCoroutine(Movedesigns());
    }

    private void Size(Transform target)
    {
        var size = 1 / (1 + Mathf.Sqrt(target.position.x * target.position.x));
        target.localScale = new Vector3(size, size, 1);
    }

    public IEnumerator LerpPosition(Transform target, Vector3 endPosition, float duration)
    {
        var time = 0f;

        var startPosition = target.position;
        while (time < duration)
        {
            Size(target);
            target.position = startPosition + (endPosition - startPosition) * (time / duration);
            time += Time.deltaTime;
            yield return false;
        }

        target.transform.position = endPosition;
        Size(target);
        isMoving = false;
    }


    public IEnumerator Movedesigns()
    {
        isRunning= true;
        while (queue.Count > 0)
        {
            
            var x = queue.Dequeue();
            isMoving = true;
            foreach (var planet in designs)
            {
                StartCoroutine(LerpPosition(planet.transform, new Vector3(planet.transform.position.x + dis * x, 0, 0), 0.5f));
            }
            while (isMoving)
            {
                yield return null;
            }
            Move(x);

        }
        isRunning= false;
    }


    public void Move(int value)
    {

        
        //old Design
        var oldDesign = actuelDesign + designsInRow * value;
        if (oldDesign < 0)
            oldDesign += designs.Length;
        else if (oldDesign > designs.Length - 1)
            oldDesign -= designs.Length;
        designs[oldDesign].SetActive(false);

        //new Design
        var newDesign = actuelDesign - (designsInRow + 1) * value;
        if (newDesign < 0)
            newDesign += designs.Length;
        else if (newDesign > designs.Length - 1)
            newDesign -= designs.Length;
        //new Icon
        //make a extra method
        var newIcon = actuelicon - (designsInRow + 1) * value ;
        if (newIcon < 0)
            newIcon += icons.Length;
        else if (newIcon > icons.Length - 1)
            newIcon -= icons.Length;
        designs[newDesign].SetActive(true);
        designs[newDesign].GetComponent<SpriteRenderer>().sprite = icons[newIcon];
        designs[newDesign].transform.position = new Vector3(designsInRow * dis * -value, 0, 0);
        Size(designs[newDesign].transform);


        actuelDesign -= value;
        actuelicon -= value;
        if (actuelDesign < 0)
        {
            actuelDesign = designs.Length - 1;
        }
        else if(actuelDesign > designs.Length - 1)
        {
            actuelDesign = 0;
        }
        if (actuelicon < 0)
        {
            actuelicon = icons.Length - 1;
        }
        else if (actuelicon > icons.Length - 1)
        {
            actuelicon = 0;
        }

    }

    public void StartPosition(Sprite[] design) 
    {
        designs = new GameObject[2 * designsInRow + 1];
        icons = design;
        
        for (int i = 0; i <= designsInRow; i++)
        {
            var o = new GameObject(icons[i].name);
            o.AddComponent<SpriteRenderer>().sprite = icons[i];
            Size(o.transform);
            o.SetActive(true);
            o.transform.position = new Vector2(dis * i,0);
            o.transform.parent = transform;
            designs[i] = o;
            if(i > 0)
            {
                var osym = new GameObject(icons[^i].name);
                osym.AddComponent<SpriteRenderer>().sprite = icons[^i];
                Size(osym.transform);
                osym.SetActive(true);
                osym.transform.position = new Vector2(dis * -i, 0);
                designs[^i] = osym;
            }
        }
    }
}
