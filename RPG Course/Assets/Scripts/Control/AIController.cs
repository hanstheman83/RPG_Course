using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        GameObject player;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
        }
        private void Update()
        {
            if (DistanceToPlayer() < chaseDistance)
            {
                print(transform.name +" Give chase!");
            }
        }
        private float DistanceToPlayer()
        {
            return Vector3.Distance(player.transform.position, transform.position);
        }
    }
}

