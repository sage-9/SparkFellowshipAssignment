using System.Globalization;
using UnityEngine;

public class ListenerScript : MonoBehaviour
{
    int number2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReceiveBroadcast(Component sender, object data)
    {
        if(data is int) number2 = (int)data;
        Debug.Log(number2);
        Debug.Log("Received broadcast");
        
    }
}
