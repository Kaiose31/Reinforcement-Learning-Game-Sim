using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collisioninfo){
        if(collisioninfo.collider.tag=="Obstacle"){
           UnityEngine.Debug.Log("We hit an obstacle"); 
        }
        
    }
}
