using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileBehavior : MonoBehaviour
{
    public float Speed = 8f;
    public int lifetime = 2500;
    public Vector3 direction;
    

    private void Update(){
        transform.position += transform.right * Time.deltaTime * Speed;
        lifetime--;
        if(lifetime <= 0){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Weapon"){
            Destroy(gameObject);
            if(collision.gameObject.GetComponent("Enemy") != null && collision.gameObject.GetComponent("Enemy") is Enemy) {
                (collision.gameObject.GetComponent("Enemy") as Enemy).takeDamage(10);
                // Debug.Log(collision.gameObject.name);
            }
        }
    }
}
