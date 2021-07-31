using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        doChange();
        
        
        //StartCoroutine("DoStuff");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DoStuff()
    {
        for (; ; )
        {
            doChange();
            yield return new WaitForSeconds(2f);
        }
    }

    void doChange()
    {
        gameObject.GetComponent<SpriteRenderer>().color = ColorProvider.getColor();
    }
}
