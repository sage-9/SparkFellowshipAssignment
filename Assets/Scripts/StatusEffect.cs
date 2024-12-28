using UnityEditor.UIElements;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float effectAmount;
    public string playerTag;
    


    float PlayerHealth;
    float PlayerSpeed;
    public enum Effect
    {
        AddHealth,
        ReduceHealth,
        AddSpeed,
        reduceSpeed,
        stopSpeed
    }
    public Effect effect;

   
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("I hit the player");
            PlayerHealth = other.GetComponent<PlayerController3d>().CurrentHealth;
            PlayerSpeed = other.GetComponent<PlayerController3d>().speed;
            UseEffect(effect);
            other.GetComponent<PlayerController3d>().CurrentHealth = PlayerHealth;
            other.GetComponent<PlayerController3d>().speed = PlayerSpeed;
            Destroy(gameObject,0.05f);
        }
    }

    float UseEffect(Effect effectStatus)
    {
        if (effectStatus == Effect.ReduceHealth) return PlayerHealth=DecreaseHealth(PlayerHealth);
        if (effectStatus == Effect.AddHealth) return PlayerHealth=AddHealth(PlayerHealth);
        if (effectStatus == Effect.reduceSpeed) return PlayerSpeed=DecreaseSpeed(PlayerSpeed);
        if (effectStatus == Effect.stopSpeed) return PlayerSpeed=StopSpeed(PlayerSpeed);
        if (effectStatus == Effect.AddSpeed) return PlayerSpeed=AddSpeed(PlayerSpeed);
        return 0;
    }
    float AddHealth(float playerHealth)
    {
        playerHealth += effectAmount;
        Debug.Log("I added health");
        return playerHealth ;
    }
    float DecreaseHealth(float playerHealth)
    {
        playerHealth -= effectAmount;
        return  playerHealth;            
    }

    float AddSpeed(float playerSpeed)
    {
        playerSpeed += effectAmount;
        return playerSpeed;
    }

    float DecreaseSpeed(float playerSpeed)
    {
        playerSpeed -= effectAmount;
        return playerSpeed;
    }

    float StopSpeed(float playerSpeed)
    {
        playerSpeed = 0;
        return playerSpeed;
    }

}
