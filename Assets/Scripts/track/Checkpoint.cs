using UnityEngine;

namespace track
{
    //A script on the start line will keep a list of all of these in the scene and check if the car has triggered all of them before confirming the lap completion
    [RequireComponent(typeof(Collider2D))]
    public class Checkpoint : MonoBehaviour
    {
        
    }
}