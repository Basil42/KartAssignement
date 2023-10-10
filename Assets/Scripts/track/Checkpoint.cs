using System;
using UnityEngine;

namespace track
{
    //A script on the start line will keep a list of all of these in the scene and check if the car has triggered all of them before confirming the lap completion
    [RequireComponent(typeof(Collider2D))]
    public class Checkpoint : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            other.GetComponent<ICheckpointDataReceiver>().OnCheckpointPassed(this);
            //if I do need multiple receiver
            // foreach (var receiver in other.GetComponents<ICheckpointDataReceiver>())
            // {
            //     receiver.OnCheckpointPassed(this);
            // }
        }
    }
    public interface ICheckpointDataReceiver
    {
        public void OnCheckpointPassed(Checkpoint cp);

    }
}