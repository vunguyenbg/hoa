//using EasyCharacterMovement;
using System;
using UnityEngine;

namespace Yoolax.Framework
{
    public sealed class MovementComponent3D : BaseComponent, IMovementComponent, IUpdate
    {
        //[SerializeField] private EasyCharacterMovement.CharacterMovement characterMovement;
        [SerializeField] private float speed = 10;
        [SerializeField] private bool isLocked;
        [SerializeField] private bool freeze;

        public float Speed
        {
            get => speed;
            set => speed = value;
        }

        public bool IsLocked
        {
            get => isLocked;
            set => isLocked = value;
        }

        public bool Freeze { get => freeze; set => freeze = value; }

        [Tooltip("Setting that affects movement control. Higher values allow faster changes in direction.")]
        public float groundFriction = 8.0f;

        [Tooltip("Max Acceleration (rate of change of velocity).")]
        public float maxAcceleration = 20.0f;

        [Tooltip("The character's gravity.")] public Vector3 gravity = Vector3.down * 9.81f;

        [Range(0.0f, 1.0f)]
        [Tooltip("When falling, amount of horizontal movement control available to the character.\n" +
                 "0 = no control, 1 = full control at max acceleration.")]
        public float airControl = 0.3f;

        [Tooltip("Friction to apply when falling.")]
        public float airFriction = 0.1f;

        public Vector3 movementDirection;
        private bool isGround;


        private void GroundedMovement(Vector3 desiredVelocity)
        {
            //if (!isGround)
            //{
            //    isGround = true;
            //    actor.ActorAction.OnGroundChanged?.Invoke(isGround);
            //}
            //characterMovement.velocity = Vector3.Lerp(characterMovement.velocity, desiredVelocity,
            //    1f - Mathf.Exp(-groundFriction * Time.deltaTime));
        }

        /// <summary>
        /// Move the character when falling or on not-walkable ground.
        /// </summary>
        private void NotGroundedMovement(Vector3 desiredVelocity)
        {
            //if (isGround)
            //{
            //    isGround = false;
            //    actor.ActorAction.OnGroundChanged?.Invoke(isGround);
            //}
            //// Current character's velocity

            //Vector3 velocity = characterMovement.velocity;

            //// If moving into non-walkable ground, limit its contribution.
            //// Allow movement parallel, but not into it because that may push us up.

            //if (characterMovement.isOnGround && Vector3.Dot(desiredVelocity, characterMovement.groundNormal) < 0.0f)
            //{
            //    Vector3 groundNormal = characterMovement.groundNormal;
            //    Vector3 groundNormal2D = groundNormal.onlyXZ().normalized;

            //    desiredVelocity = desiredVelocity.projectedOnPlane(groundNormal2D);
            //}

            //// If moving...

            //if (desiredVelocity != Vector3.zero)
            //{
            //    // Accelerate horizontal velocity towards desired velocity

            //    Vector3 horizontalVelocity = Vector3.MoveTowards(velocity.onlyXZ(), desiredVelocity,
            //        maxAcceleration * airControl * Time.deltaTime);

            //    // Update velocity preserving gravity effects (vertical velocity)

            //    velocity = horizontalVelocity + velocity.onlyY();
            //}

            //// Apply gravity

            //velocity += gravity * Time.deltaTime;

            //// Apply Air friction (Drag)

            //velocity -= velocity * airFriction * Time.deltaTime;

            //// Update character's velocity

            //characterMovement.velocity = velocity;
        }

        /// <summary>
        /// When use move need use UpdateMove Method
        /// </summary>
        /// <param name="dir"></param>
        public void Move(Vector3 dir)
        {
            if (isLocked)
                return;
            movementDirection = dir;
        }

        public void UpdateMove()
        {
            //Vector3 desiredVelocity = movementDirection * speed;

            //if (characterMovement.isGrounded)
            //    GroundedMovement(desiredVelocity);
            //else
            //    NotGroundedMovement(desiredVelocity);

            //characterMovement.Move();
        }

        public void UpdateComponent()
        {
            if (freeze)
                return;

            UpdateMove();
        }

        public void RotateTowards(Vector3 worldDirection, float maxDegreesDelta, bool updateYawOnly = true)
        {
            //if (freeze)
            //    return;
            //characterMovement.RotateTowards(worldDirection, maxDegreesDelta, updateYawOnly);
        }
    }
}