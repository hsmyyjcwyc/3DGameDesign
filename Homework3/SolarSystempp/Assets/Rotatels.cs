using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatels : MonoBehaviour
{

    void Start()
    {
   
    }

    void Update()
    {
        //太阳只需要自转就可以了
        GameObject.Find("Sun").transform.Rotate(Vector3.up * Time.deltaTime * 5 );

        //水星，它的自转周期是58.646天，我们取58就好
        //公转周期因为要让效果明显一点，所以我们没有按照标准的来
        GameObject.Find("Mercury").transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), 70 * Time.deltaTime);
        GameObject.Find("Mercury").transform.Rotate(Vector3.up * Time.deltaTime * 8000 / 58);

        //金星，和水星一样，除了自转周期和公转周期
        GameObject.Find("Venus").transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0.1f, 1, 0), 60 * Time.deltaTime);
        GameObject.Find("Venus").transform.Rotate(Vector3.up * Time.deltaTime * 8000 / 243);

        //地球
        GameObject.Find("Earth").transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0.2f, 1, 0.2f), 55 * Time.deltaTime);
        GameObject.Find("Earth").transform.Rotate(Vector3.up * Time.deltaTime * 8000);

        //火星
        GameObject.Find("Mars").transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0.2f, 1, -0.1f), 50 * Time.deltaTime);
        GameObject.Find("Mars").transform.Rotate(Vector3.up * Time.deltaTime * 8000);

        //木星
        GameObject.Find("Jupiter").transform.RotateAround(new Vector3(0, 0, 0), new Vector3(-0.1f, 1, 0), 45 * Time.deltaTime);
        GameObject.Find("Jupiter").transform.Rotate(Vector3.up * Time.deltaTime * 8000 / 0.3f);

        //土星
        GameObject.Find("Saturn").transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0.2f, 1, 0.1f), 40 * Time.deltaTime);
        GameObject.Find("Saturn").transform.Rotate(Vector3.up * Time.deltaTime * 8000 / 0.4f);

        //天王星
        GameObject.Find("Uranus").transform.RotateAround(new Vector3(0, 0, 0), new Vector3(-0.1f, 1, -0.1f), 30 * Time.deltaTime);
        GameObject.Find("Uranus").transform.Rotate(Vector3.up * Time.deltaTime * 8000 / 0.6f);

        //海王星
        GameObject.Find("Nepture").transform.RotateAround(new Vector3(0, 0, 0), Vector3.up, 28 * Time.deltaTime);
        GameObject.Find("Nepture").transform.Rotate(Vector3.up * Time.deltaTime * 8000 / 0.7f);

    }
}
