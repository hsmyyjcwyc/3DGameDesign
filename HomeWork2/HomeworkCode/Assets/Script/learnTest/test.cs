using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 编写一个代码，使用 debug 语句来验证 MonoBehaviour 基本行为或事件触发的条件
// 基本行为包括 Awake() Start() Update() FixedUpdate() LateUpdate()
// 常用事件包括 OnGUI() OnDisable() OnEnable()

public class test : MonoBehaviour
{
    // Awake is called before any Start function
    void Awake()
    {
        Debug.Log("awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
    }

    void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    void OnGUI()
    {
        Debug.Log("OnGUI");
    }
    
    void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable");
    }
}
