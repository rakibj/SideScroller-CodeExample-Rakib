using System;
using _Project.Scripts.Generic;
using RakibUtils;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        /// <summary>
        /// Run speed of the player
        /// </summary>
        [SerializeField] private float runSpeed;
        
        /// <summary>
        /// Jump speed of player
        /// </summary>
        [SerializeField] private float jumpSpeed;

        /// <summary>
        /// The factor to which the gravity will scale down when jumping up. This improves game feel
        /// </summary>
        [SerializeField] private float gravitySlowdownFactorWhenJumpingUp;

        /// <summary>
        /// This is a Scriptable Object which contains score, which in turn is player distance
        /// </summary>
        [SerializeField] private IntVariable playerDistance;
        
        //private Cached references
        private Rigidbody2D m_rigidbody;
        private Animator m_animator;
        private Collider2D m_collider;
        
        //Cached property indices for animator parameters
        private static readonly int Running = Animator.StringToHash("running");
        private static readonly int JumpingUp = Animator.StringToHash("jumpingUp");
        private static readonly int JumpingDown = Animator.StringToHash("jumpingDown");

        /// <summary>
        /// Used to determine if player is alive
        /// </summary>
        private bool m_isDead;
        
        private void Awake()
        {
            //Cache the variables
            m_rigidbody = GetComponent<Rigidbody2D>();
            m_animator = GetComponent<Animator>();
            m_collider = GetComponent<Collider2D>();
            m_isDead = false;
        }

        private void OnEnable()
        {
            GameEvents.gameOver += DeactivatePlayer;
        }

        private void OnDisable()
        {
            GameEvents.gameOver -= DeactivatePlayer;
        }

        private void DeactivatePlayer(int score)
        {
            m_isDead = true;
        }

        private void Update()
        {
            if (m_isDead) return;
            Run();
            Jump();
            //Non-Physics Updates
            SetMovementAnimations();
            playerDistance.value = Mathf.FloorToInt(transform.position.x);
        }

        private void Run()
        {
            //Set constant velocity on x
            var playerVelocity = new Vector2(runSpeed * Time.fixedDeltaTime, m_rigidbody.velocity.y);
            m_rigidbody.velocity = playerVelocity;
        }

        private void Jump()
        {
            //We slowdown gravity when jumping up only to increase the feel of the game
            var isJumpingUp = m_rigidbody.velocity.y > .1f;
            m_rigidbody.gravityScale = isJumpingUp ? gravitySlowdownFactorWhenJumpingUp : 1;
            
            //If player is not touching ground we won't take jump input. Thus we exit early
            if (!IsTouchingGround()) return;
            
            //If player clicks anywhere we jump
            if (Input.GetMouseButtonDown(0))
            {
                var jumpVelocity = new Vector2(0f, jumpSpeed);
                m_rigidbody.velocity += jumpVelocity;
            }
        }

        /// <summary>
        /// Determines if player is touching the ground
        /// </summary>
        /// <returns></returns>
        private bool IsTouchingGround()
        {
            return m_collider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        }
        
        /// <summary>
        /// Set the animator transitions 
        /// </summary>
        private void SetMovementAnimations()
        {
            m_animator.SetBool(Running, Math.Abs(m_rigidbody.velocity.y) < .05f);
            m_animator.SetBool(JumpingUp, m_rigidbody.velocity.y > .5f);
            m_animator.SetBool(JumpingDown, m_rigidbody.velocity.y < -.5f);
        }
    }
}
