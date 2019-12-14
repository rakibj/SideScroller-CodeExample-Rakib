using System;
using RakibUtils;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private static readonly int Death = Animator.StringToHash("death");

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Trap"))
            {
                Die();
            }
        }

        private void Die()
        {
            GameEvents.OnGameOver(Mathf.FloorToInt(transform.position.x));
            GetComponent<Animator>().SetBool(Death, true);   
        }
    }
}
