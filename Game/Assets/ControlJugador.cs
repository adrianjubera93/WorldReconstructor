using UnityEngine;
using UnityEngine.InputSystem;
public class ControlJugador : MonoBehaviour
{
    [SerializeField] private float velocidad = 8f; 
    [SerializeField] private float fuerzaSalto = 12f;
    private Rigidbody2D rb; 
    private float entradaHorizontal;
    private void Awake()
{
    // Le decimos al script: "Busca el componente físico que tienes pegado"
    rb = GetComponent<Rigidbody2D>(); 
}
    public void OnMove(InputValue value)
{
    // Leemos el valor del teclado (Vector2 porque lee X e Y)
    Vector2 v = value.Get<Vector2>();
    
    // Guardamos solo la X en nuestra variable de clase
    entradaHorizontal = v.x; 
}
public void OnJump(InputValue value)
{
    // Si el botón se acaba de pulsar...
    if (value.isPressed)
    {
        // ...le damos un impulso hacia arriba al músculo (Rigidbody2D)
        // Usamos la variable fuerzaSalto que creamos antes
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
    }
}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
{
    // Aplicamos la velocidad al Rigidbody2D (rb)
    // El nuevo vector dice: (Dirección * Velocidad, Mantén la caída actual en Y)
    rb.linearVelocity = new Vector2(entradaHorizontal * velocidad, rb.linearVelocity.y);
}
}
