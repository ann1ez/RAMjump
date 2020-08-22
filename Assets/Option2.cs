using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Option2 : MonoBehaviour
{
    public TextMeshPro textMesH;
    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        
        textMesH = GetComponent<TextMeshPro>();
        score = 0;
        textMesH.text = score.ToString();
        var parent = transform.parent;
 
         var parentRenderer = parent.GetComponent<Renderer>();
         var renderer = GetComponent<Renderer>();
         renderer.sortingLayerID = parentRenderer.sortingLayerID;
         renderer.sortingOrder = parentRenderer.sortingOrder;
         var spriteTransform = parent.transform;
         var pos = spriteTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        textMesH.text = score.ToString();
    }

    public void changeOption1(int s)
    {
        score = s;
    }
}
