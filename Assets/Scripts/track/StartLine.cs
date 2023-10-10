using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;

namespace track
{
    [RequireComponent(typeof(Collider2D))]
    public class StartLine : MonoBehaviour
    {
        private HashSet<Checkpoint> _checkpointSet;
        private void Awake()
        {
            Assert.IsTrue(gameObject.layer == LayerMask.NameToLayer("checkpoints"));//checking the GO is correctly setup
            _checkpointSet = new HashSet<Checkpoint>(Resources.FindObjectsOfTypeAll<Checkpoint>());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //No need for a layer check only the player can trigger this
            other.GetComponent<IStartLineDataReceiver>().OnStartLinePassed(_checkpointSet);
            //as for the checkpoints I could have other receivers on the car by getting all the components with the interface
        }
    }
    public interface IStartLineDataReceiver
    {
        public void OnStartLinePassed(HashSet<Checkpoint> requiredCPs);
    }
}