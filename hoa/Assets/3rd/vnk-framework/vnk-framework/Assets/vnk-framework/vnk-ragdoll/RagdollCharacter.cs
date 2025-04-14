using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class RagdollCharacter : MonoBehaviour
    {
        [SerializeField, FoldoutGroup("Reference")] private Rigidbody rb;
        [SerializeField, FoldoutGroup("Reference")] private Transform tfCom;
        [SerializeField, FoldoutGroup("Reference")] private Transform tfCam;
        [SerializeField, FoldoutGroup("Reference")] private Transform tfCamTarget;
        [FoldoutGroup("Reference")] public Rigidbody body, pelvis, arm_r, arm_r_2, arm_l, arm_l_2, leg_r_1, leg_r_2, leg_foot_r, leg_l_1, leg_l_2, leg_foot_l;

        [FoldoutGroup("Config")]
        [SerializeField, FoldoutGroup("Config")] private float TouchForce = 200;
        [SerializeField, FoldoutGroup("Config")] private float slerpBackX = -0.1f;
        [SerializeField, FoldoutGroup("Config")] private float slerpForwardX = 0;
        [SerializeField, FoldoutGroup("Config")] private float FallFactor = 0.4f;
        [SerializeField, FoldoutGroup("Config")] private float TimeStep = 0.2f;
        [SerializeField, FoldoutGroup("Config")] private float LegsHeight = 1;
        [SerializeField, FoldoutGroup("Config")] private float positionSpring_1 = 0, positionSpring_2 = 150, positionSpring_3 = 300, positionSpring_4 = 320;
        [SerializeField, FoldoutGroup("Config")] private float positionDamper_1 = 0, positionDamper_2 = 0, positionDamper_3 = 100, positionDamper_4 = 0;

        [FoldoutGroup("ConfigurableJoint")]
        public ConfigurableJoint body_Joint, pelvis_Joint, arm_r_Joint, arm_r_2_Joint, arm_l_Joint, arm_l_2_Joint
            , leg_r_1_Joint, leg_r_2_Joint, leg_foot_r_Joint, leg_l_1_Joint, leg_l_2_Joint, leg_foot_l_Joint;

        private JointDrive jointSpring_1, jointSpring_2, jointSpring_3, jointSpring_4;
        private Vector3 COM;

        private bool WalkBack, WalkForward, Falling, Fall;
        private bool StepR, StepL, Flag_Leg_R, Flag_Leg_L;
        private float Step_R_Time, Step_L_Time;

        private Quaternion StartLegR1, StartLegR2;
        private Quaternion StartLegL1, StartLegL2;

        private void Awake()
        {
            Init();
        }
        private void Update()
        {
            tfCamTarget.transform.position = Vector3.Lerp(tfCamTarget.transform.position, arm_r.transform.position, 2 * Time.unscaledDeltaTime);
            OnInput();
            OnCalculatorCOM();
            Balance();
            tfCam.transform.LookAt(tfCom.transform.position);
            if (!WalkForward && !WalkBack)
            {
                StepR = false;
                StepL = false;
                Step_R_Time = 0;
                Step_L_Time = 0;
                Flag_Leg_R = false;
                Flag_Leg_L = false;
                body_Joint.targetRotation = Quaternion.Lerp(body_Joint.targetRotation
                    , new Quaternion(-0.1f
                    , body_Joint.targetRotation.y
                    , body_Joint.targetRotation.z
                    , body_Joint.targetRotation.w)
                    , 6 * Time.fixedDeltaTime);
            }
        }
        private void FixedUpdate()
        {
            LegsMoving();
        }
        void Init()
        {
            Physics.IgnoreCollision(arm_r.GetComponent<Collider>(), leg_r_1.GetComponent<Collider>(), true);
            Physics.IgnoreCollision(arm_l.GetComponent<Collider>(), leg_l_1.GetComponent<Collider>(), true);
            StartLegR1 = leg_r_1_Joint.targetRotation;
            StartLegR2 = leg_r_2_Joint.targetRotation;
            StartLegL1 = leg_l_1_Joint.targetRotation;
            StartLegL2 = leg_r_2_Joint.targetRotation;

            jointSpring_1 = new JointDrive();
            jointSpring_1.positionSpring = positionSpring_1;
            jointSpring_1.positionDamper = positionDamper_1;
            jointSpring_1.maximumForce = Mathf.Infinity;

            jointSpring_2 = new JointDrive();
            jointSpring_2.positionSpring = positionSpring_2;
            jointSpring_2.positionDamper = positionDamper_2;
            jointSpring_2.maximumForce = Mathf.Infinity;

            jointSpring_3 = new JointDrive();
            jointSpring_3.positionSpring = positionSpring_3;
            jointSpring_3.positionDamper = positionDamper_3;
            jointSpring_3.maximumForce = Mathf.Infinity;

            jointSpring_4 = new JointDrive();
            jointSpring_4.positionSpring = positionSpring_4;
            jointSpring_4.positionDamper = positionDamper_4;
            jointSpring_4.maximumForce = Mathf.Infinity;
        }
        void OnInput()
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = Vector3.forward * TouchForce * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = Vector3.back * TouchForce * Time.deltaTime;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector3.up * TouchForce * 5 * Time.deltaTime;
            }
        }
        void OnCalculatorCOM()
        {

            COM
                = (
                body.mass * body.transform.position
                + pelvis.mass * pelvis.transform.position

                + arm_r.mass * arm_r.transform.position
                + arm_l.mass * arm_l.transform.position

                + leg_r_1.mass * leg_r_1.transform.position
                + leg_r_2.mass * leg_r_2.transform.position
                + leg_foot_r.mass * leg_foot_r.transform.position

                + leg_l_1.mass * leg_l_1.transform.position
                + leg_l_2.mass * leg_l_2.transform.position
                + leg_foot_l.mass * leg_foot_l.transform.position)

                /

                (
                body.mass
                + pelvis.mass
                + arm_r.mass
                + arm_l.mass
                + leg_r_1.mass
                + leg_r_2.mass
                + leg_foot_r.mass

                + leg_l_1.mass
                + leg_l_2.mass
                + leg_foot_l.mass
                );

            tfCom.position = COM;
        }
        void Balance()
        {
            //Check COM vs Foot
            if (COM.z < leg_foot_r.transform.position.z && COM.z < leg_foot_l.transform.position.z)
            {
                WalkBack = true;
                body_Joint.targetRotation = Quaternion.Lerp(
                    body_Joint.targetRotation
                    , new Quaternion(slerpBackX, body_Joint.targetRotation.y, body_Joint.targetRotation.z, body_Joint.targetRotation.w)
                    , 6 * Time.fixedDeltaTime);
            }
            else
            {
                WalkBack = false;
            }

            if (COM.z > leg_foot_r.transform.position.z && COM.z > leg_foot_l.transform.position.z)
            {
                WalkForward = true;
                body_Joint.targetRotation = Quaternion.Lerp(
                    body_Joint.targetRotation
                    , new Quaternion(slerpForwardX, body_Joint.targetRotation.y, body_Joint.targetRotation.z, body_Joint.targetRotation.w)
                    , 6 * Time.fixedDeltaTime);
            }
            else
            {
                WalkForward = false;
            }

            //Check Falling
            if (COM.z > leg_foot_r.transform.position.z + FallFactor && COM.z > leg_foot_l.transform.position.z + FallFactor
             || COM.z < leg_foot_r.transform.position.z - FallFactor && COM.z < leg_foot_l.transform.position.z - FallFactor)
            {
                Falling = true;
            }
            else
            {
                Falling = false;
            }

            if (Falling)
            {
                LegsHeight = 5;
                pelvis_Joint.angularXDrive = jointSpring_1;
                pelvis_Joint.angularYZDrive = jointSpring_1;

                arm_r_Joint.angularXDrive = jointSpring_1;
                arm_r_Joint.angularYZDrive = jointSpring_2;
                arm_r_Joint.targetRotation = Quaternion.Lerp(arm_r_Joint.targetRotation
                    , new Quaternion(0, arm_r_Joint.targetRotation.y
                    , arm_r_Joint.targetRotation.z
                    , arm_r_Joint.targetRotation.w)
                    , 6 * Time.fixedDeltaTime);

                arm_l_Joint.angularXDrive = jointSpring_1;
                arm_l_Joint.angularYZDrive = jointSpring_2;
                arm_l_Joint.targetRotation = Quaternion.Lerp(arm_l_Joint.targetRotation
                   , new Quaternion(0, arm_l_Joint.targetRotation.y
                   , arm_l_Joint.targetRotation.z
                   , arm_l_Joint.targetRotation.w)
                   , 6 * Time.fixedDeltaTime);
            }
            else
            {
                LegsHeight = 1;
                pelvis_Joint.angularXDrive = jointSpring_3;
                pelvis_Joint.angularYZDrive = jointSpring_3;
            }

            if (body.transform.position.y - 0.1f <= pelvis.transform.position.y)
            {
                Fall = true;
            }
            else
            {
                Fall = false;
            }

            if (Fall)
            {
                pelvis_Joint.angularXDrive = jointSpring_1;
                pelvis_Joint.angularYZDrive = jointSpring_1;
                StandUping();
            }
        }
        void StandUping()
        {
            if (WalkForward)
            {
                arm_r_Joint.angularXDrive = jointSpring_4;
                arm_r_Joint.angularYZDrive = jointSpring_4;
                arm_l_Joint.angularXDrive = jointSpring_4;
                arm_l_Joint.angularYZDrive = jointSpring_4;
                body_Joint.targetRotation = Quaternion.Lerp(body_Joint.targetRotation
                    , new Quaternion(-0.1f
                    , body_Joint.targetRotation.y
                    , body_Joint.targetRotation.z
                    , body_Joint.targetRotation.w)
                    , 6 * Time.fixedDeltaTime);

                if (arm_r_Joint.targetRotation.x < 1.7f)
                {
                    arm_r_Joint.targetRotation = new Quaternion(arm_r_Joint.targetRotation.x + 0.07f, arm_r_Joint.targetRotation.y,
                        arm_r_Joint.targetRotation.z, arm_r_Joint.targetRotation.w);
                }

                if (arm_l_Joint.targetRotation.x < 1.7f)
                {
                    arm_l_Joint.targetRotation = new Quaternion(arm_l_Joint.targetRotation.x + 0.07f, arm_l_Joint.targetRotation.y,
                        arm_l_Joint.targetRotation.z, arm_l_Joint.targetRotation.w);
                }
            }
            if (WalkBack)
            {
                arm_r_Joint.angularXDrive = jointSpring_4;
                arm_r_Joint.angularYZDrive = jointSpring_4;
                arm_l_Joint.angularXDrive = jointSpring_4;
                arm_l_Joint.angularYZDrive = jointSpring_4;

                if (arm_r_Joint.targetRotation.x > -1.7f)
                {
                    arm_r_Joint.targetRotation = new Quaternion(arm_r_Joint.targetRotation.x - 0.09f, arm_r_Joint.targetRotation.y,
                        arm_r_Joint.targetRotation.z, arm_r_Joint.targetRotation.w);
                }

                if (arm_l_Joint.targetRotation.x > -1.7f)
                {
                    arm_l_Joint.targetRotation = new Quaternion(arm_l_Joint.targetRotation.x - 0.09f, arm_l_Joint.targetRotation.y,
                        arm_l_Joint.targetRotation.z, arm_l_Joint.targetRotation.w);
                }
            }
        }
        void LegsMoving()
        {
            if (WalkForward)
            {
                if (leg_foot_r.transform.position.z < leg_foot_l.transform.position.z && !StepL && !Flag_Leg_R)
                {
                    StepR = true;
                    Flag_Leg_R = true;
                    Flag_Leg_L = true;
                }
                if (leg_foot_r.transform.position.z > leg_foot_l.transform.position.z && !StepR && !Flag_Leg_L)
                {
                    StepL = true;
                    Flag_Leg_L = true;
                    Flag_Leg_R = true;
                }
            }

            if (WalkBack)
            {
                if (leg_foot_r.transform.position.z > leg_foot_l.transform.position.z && !StepL && !Flag_Leg_R)
                {
                    StepR = true;
                    Flag_Leg_R = true;
                    Flag_Leg_L = true;
                }
                if (leg_foot_r.transform.position.z < leg_foot_l.transform.position.z && !StepR && !Flag_Leg_L)
                {
                    StepL = true;
                    Flag_Leg_L = true;
                    Flag_Leg_R = true;
                }
            }

            if (StepR)
            {
                Step_R_Time += Time.fixedDeltaTime;

                if (WalkForward)
                {
                    leg_r_1_Joint.targetRotation = new Quaternion(leg_r_1_Joint.targetRotation.x + 0.07f * LegsHeight
                        , leg_r_1_Joint.targetRotation.y, leg_r_1_Joint.targetRotation.z, leg_r_1_Joint.targetRotation.w);
                    leg_r_2_Joint.targetRotation = new Quaternion(leg_r_2_Joint.targetRotation.x - 0.04f * LegsHeight * 2
                        , leg_r_2_Joint.targetRotation.y, leg_r_2_Joint.targetRotation.z, leg_r_2_Joint.targetRotation.w);

                    leg_l_1_Joint.targetRotation = new Quaternion(leg_l_1_Joint.targetRotation.x - 0.02f * LegsHeight / 2
                        , leg_l_1_Joint.targetRotation.y, leg_l_1_Joint.targetRotation.z, leg_l_1_Joint.targetRotation.w);
                }

                if (WalkBack)
                {
                    leg_r_1_Joint.targetRotation = new Quaternion(leg_r_1_Joint.targetRotation.x - 0.00f * LegsHeight
                        , leg_r_1_Joint.targetRotation.y, leg_r_1_Joint.targetRotation.z, leg_r_1_Joint.targetRotation.w);
                    leg_r_2_Joint.targetRotation = new Quaternion(leg_r_2_Joint.targetRotation.x - 0.06f * LegsHeight * 2
                        , leg_r_2_Joint.targetRotation.y, leg_r_2_Joint.targetRotation.z, leg_r_2_Joint.targetRotation.w);

                    leg_l_1_Joint.targetRotation = new Quaternion(leg_l_1_Joint.targetRotation.x + 0.02f * LegsHeight / 2
                        , leg_l_1_Joint.targetRotation.y, leg_l_1_Joint.targetRotation.z, leg_l_1_Joint.targetRotation.w);
                }

                if (Step_R_Time > TimeStep)
                {
                    Step_R_Time = 0;
                    StepR = false;

                    if (WalkBack || WalkForward)
                    {
                        StepL = true;
                    }
                }
            }
            else
            {
                leg_r_1_Joint.targetRotation = Quaternion.Lerp(leg_r_1_Joint.targetRotation, StartLegR1, (8f) * Time.fixedDeltaTime);
                leg_r_2_Joint.targetRotation = Quaternion.Lerp(leg_r_2_Joint.targetRotation, StartLegR2, (17f) * Time.fixedDeltaTime);
            }

            if (StepL)
            {
                Step_L_Time += Time.fixedDeltaTime;

                if (WalkForward)
                {
                    leg_l_1_Joint.targetRotation = new Quaternion(leg_l_1_Joint.targetRotation.x + 0.07f * LegsHeight
                        , leg_l_1_Joint.targetRotation.y, leg_l_1_Joint.targetRotation.z, leg_l_1_Joint.targetRotation.w);
                    leg_l_2_Joint.targetRotation = new Quaternion(leg_l_2_Joint.targetRotation.x - 0.04f * LegsHeight * 2
                        , leg_l_2_Joint.targetRotation.y, leg_l_2_Joint.targetRotation.z, leg_l_2_Joint.targetRotation.w);

                    leg_r_1_Joint.targetRotation = new Quaternion(leg_r_1_Joint.targetRotation.x - 0.02f * LegsHeight / 2
                        , leg_r_1_Joint.targetRotation.y, leg_r_1_Joint.targetRotation.z, leg_r_1_Joint.targetRotation.w);
                }

                if (WalkBack)
                {
                    leg_l_1_Joint.targetRotation = new Quaternion(leg_l_1_Joint.targetRotation.x - 0.00f * LegsHeight
                        , leg_l_1_Joint.targetRotation.y, leg_l_1_Joint.targetRotation.z, leg_l_1_Joint.targetRotation.w);
                    leg_l_2_Joint.targetRotation = new Quaternion(leg_l_2_Joint.targetRotation.x - 0.06f * LegsHeight * 2
                        , leg_l_2_Joint.targetRotation.y, leg_l_2_Joint.targetRotation.z, leg_l_2_Joint.targetRotation.w);

                    leg_r_1_Joint.targetRotation = new Quaternion(leg_r_1_Joint.targetRotation.x + 0.02f * LegsHeight / 2
                        , leg_r_1_Joint.targetRotation.y, leg_r_1_Joint.targetRotation.z, leg_r_1_Joint.targetRotation.w);
                }

                if (Step_L_Time > TimeStep)
                {
                    Step_L_Time = 0;
                    StepL = false;

                    if (WalkBack || WalkForward)
                    {
                        StepR = true;
                    }
                }
            }
            else
            {
                leg_l_1_Joint.targetRotation = Quaternion.Lerp(leg_l_1_Joint.targetRotation, StartLegL1, (8) * Time.fixedDeltaTime);
                leg_l_2_Joint.targetRotation = Quaternion.Lerp(leg_l_2_Joint.targetRotation, StartLegL2, (17) * Time.fixedDeltaTime);
            }
        }
    }

}