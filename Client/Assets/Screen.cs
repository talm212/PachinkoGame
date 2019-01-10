using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    private GameObject num1obj;
    private GameObject num2obj;
    private GameObject num3obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spin(int num1, int num2, int num3)
    {
        if (num1obj) Destroy(num1obj);
        if (num2obj) Destroy(num2obj);
        if (num3obj) Destroy(num3obj);

        num1obj = Instantiate(Resources.Load("num" + num1)) as GameObject;
        num2obj = Instantiate(Resources.Load("num" + num2)) as GameObject;
        num3obj = Instantiate(Resources.Load("num" + num3)) as GameObject;

        GameObject num1ph = this.gameObject.transform.Find("SmallScreenLeft").gameObject;
        GameObject num2ph = this.gameObject.transform.Find("BigScreen").gameObject;
        GameObject num3ph = this.gameObject.transform.Find("SmallScreenRight").gameObject;

        num1obj.transform.parent = num1ph.transform;
        num2obj.transform.parent = num2ph.transform;
        num3obj.transform.parent = num3ph.transform;

        num1obj.transform.position = num1ph.transform.position;
        num2obj.transform.position = num2ph.transform.position;
        num3obj.transform.position = num3ph.transform.position;

        num1obj.transform.eulerAngles = num1ph.transform.eulerAngles + new Vector3(0,270,0);
        num2obj.transform.eulerAngles = num2ph.transform.eulerAngles + new Vector3(0, 270, 0);
        num3obj.transform.eulerAngles = num3ph.transform.eulerAngles + new Vector3(0, 270, 0);

    }
}
