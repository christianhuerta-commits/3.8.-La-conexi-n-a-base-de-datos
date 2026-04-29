using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class PruebaFirebase : MonoBehaviour
{
    DatabaseReference reference;
    
    [Header("Configuración UI")]
    public UnityEngine.UI.Text textoMonedas; // Ya configurado como 'Text (Legacy)'
    
    private int contadorMonedas = 0;

   void Start()
{
    FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
        if (task.Result == DependencyStatus.Available) {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            
            // ASEGÚRATE DE QUE ESTA URL SEA LA TUYA EXACTA
            string url = "https://conexionbd-ff0e9-default-rtdb.firebaseio.com/";
            app.Options.DatabaseUrl = new System.Uri(url);
            
            // USAMOS GET INSTANCE CON LA APP PARA FORZAR LA CONEXIÓN
            reference = FirebaseDatabase.GetInstance(app, url).RootReference;
            
            Debug.Log("¡Conexión forzada con éxito!");
            
            // Intentamos enviar un mensaje de prueba inmediato
            reference.Child("conexion_test").SetValueAsync("Funcionando");
            
            CargarMonedasDeLaNube();
        }
    });
}

    public void GanarMoneda()
    {
        contadorMonedas++;
        ActualizarTextoUI();
        
        // 3. GUARDADO: Cada vez que tocas una moneda, se envía a Firebase inmediatamente
        if (reference != null) {
            reference.Child("total_monedas").SetValueAsync(contadorMonedas);
        }
    }

    // 4. PERSISTENCIA: Esta función descarga el número de la nube al abrir el juego
    void CargarMonedasDeLaNube()
    {
        if (reference == null) return;

        reference.Child("total_monedas").GetValueAsync().ContinueWithOnMainThread(task => {
            if (task.IsCompleted && task.Result.Exists) {
                // Convertimos el dato de la nube a un número para Unity
                contadorMonedas = int.Parse(task.Result.Value.ToString());
                ActualizarTextoUI();
                Debug.Log("Monedas recuperadas: " + contadorMonedas);
            }
        });
    }

    void ActualizarTextoUI() {
        if (textoMonedas != null) {
            textoMonedas.text = "Monedas: " + contadorMonedas;
        }
    }
}