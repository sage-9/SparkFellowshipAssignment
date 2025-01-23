using UnityEngine;

public class BroadcastScript : MonoBehaviour
{
    public GameEvent testEvent;

    int number = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            number++;
            Debug.Log("Broadcast sent");
            testEvent.Raise(this,number);
            
        }
        
    }
}
