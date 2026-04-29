using UnityEngine;

public class Moneda : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // 1. Verifica que el personaje tenga el Tag "Player"
        if (other.CompareTag("Player")) 
        {
            // 2. Busca al objeto GameManager en la escena
            GameObject gm = GameObject.Find("GameManager");
            
            if (gm != null) {
                // 3. Llama a la función GanarMoneda del script PruebaFirebase
                gm.GetComponent<PruebaFirebase>().GanarMoneda();
                Debug.Log("Moneda enviada al GameManager");
            } else {
                Debug.LogError("¡No encontré el objeto GameManager en la escena!");
            }
            
            // 4. Desaparece la moneda
            Destroy(gameObject); 
        }
    }
}