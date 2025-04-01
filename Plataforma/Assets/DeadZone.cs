using UnityEngine;

public class DeadZone : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.tag == "Player")
        {
            Time.timeScale = 0;
            Debug.Log("Perdeu Mano :(");
        }
    }

}
