using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    public class RagdollCreator : MonoBehaviour
    {
        [SerializeField] private RagdollCharacter ragdollCharacter;
        #region Data
        [SerializeField] private RagdollConfigurableConfig body
            = new RagdollConfigurableConfig(true
                , ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked
                , ConfigurableJointMotion.Free, ConfigurableJointMotion.Free, ConfigurableJointMotion.Free
                , new SoftJointLimit() { limit = 0 }
                , new SoftJointLimit() { limit = 0}
                , new SoftJointLimit() { limit = 0}
                , new SoftJointLimit() { limit = 0 }
                , new JointDrive() { positionSpring = 500, positionDamper = 10}
                , new JointDrive() { positionSpring = 500, positionDamper = 10}
                , new Quaternion(-0.1f, 0, 0, 1)
                , JointProjectionMode.PositionAndRotation
                );
        [SerializeField]
        private RagdollConfigurableConfig pelvis
           = new RagdollConfigurableConfig(true
               , ConfigurableJointMotion.Free, ConfigurableJointMotion.Free, ConfigurableJointMotion.Free
               , ConfigurableJointMotion.Free, ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked
               , new SoftJointLimit() { limit = 0 }
               , new SoftJointLimit() { limit = 0 }
               , new SoftJointLimit() { limit = 0 }
               , new SoftJointLimit() { limit = 0 }
                , new JointDrive() { positionSpring = 300, positionDamper = 100 }
                , new JointDrive() { positionSpring = 0, positionDamper = 0 }
               , new Quaternion(0, 0, 0, 1)
                , JointProjectionMode.PositionAndRotation
               );
        [SerializeField]
        private RagdollConfigurableConfig arm_1
          = new RagdollConfigurableConfig(true
              , ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked
              , ConfigurableJointMotion.Limited, ConfigurableJointMotion.Locked, ConfigurableJointMotion.Limited
              , new SoftJointLimit() { limit = -90 }
              , new SoftJointLimit() { limit = 170 }
              , new SoftJointLimit() { limit = 10 }
              , new SoftJointLimit() { limit = 45 }
              , new JointDrive() { positionSpring = 50, positionDamper = 0 }
              , new JointDrive() { positionSpring = 320, positionDamper = 0 }
              , new Quaternion(0, 0, 0, 1)
              , JointProjectionMode.PositionAndRotation
              );

        [SerializeField]
        private RagdollConfigurableConfig arm_2
       = new RagdollConfigurableConfig(true
           , ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked
           , ConfigurableJointMotion.Free, ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked
           , new SoftJointLimit() { limit = 0 }
           , new SoftJointLimit() { limit = 0 }
           , new SoftJointLimit() { limit = 0 }
           , new SoftJointLimit() { limit = 0 }
           , new JointDrive() { positionSpring = 50, positionDamper = 0 }
           , new JointDrive() { positionSpring = 320, positionDamper = 0 }
           , new Quaternion(0, 0, 0, 1)
           , JointProjectionMode.PositionAndRotation
           );
        [SerializeField]
        private RagdollConfigurableConfig leg_1
           = new RagdollConfigurableConfig(false
               , ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked
               , ConfigurableJointMotion.Free, ConfigurableJointMotion.Free, ConfigurableJointMotion.Free
               , new SoftJointLimit() { limit = 0}
               , new SoftJointLimit() { limit = 0 }
               , new SoftJointLimit() { limit = 0 }
               , new SoftJointLimit() { limit = 0 }
               , new JointDrive() { positionSpring = 300, positionDamper = 0 }
               , new JointDrive() { positionSpring = 600, positionDamper = 10 }
               , new Quaternion(0.18f, 0, 0, 1)
               , JointProjectionMode.PositionAndRotation
               );
        [SerializeField]
        private RagdollConfigurableConfig leg_2
         = new RagdollConfigurableConfig(false
             , ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked
             , ConfigurableJointMotion.Limited, ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked
             , new SoftJointLimit() { limit = -170 }
             , new SoftJointLimit() { limit = -10 }
             , new SoftJointLimit() { limit = 0 }
             , new SoftJointLimit() { limit = 0 }
             , new JointDrive() { positionSpring = 300, positionDamper = 0 }
             , new JointDrive() { positionSpring = 300, positionDamper = 0 }
             , new Quaternion(-0.3f, 0, 0, 1)
             , JointProjectionMode.PositionAndRotation
             );
        [SerializeField]
        private RagdollConfigurableConfig foot
          = new RagdollConfigurableConfig(true
              , ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked, ConfigurableJointMotion.Locked
              , ConfigurableJointMotion.Free, ConfigurableJointMotion.Free, ConfigurableJointMotion.Free
              , new SoftJointLimit() { limit = 0 }
              , new SoftJointLimit() { limit = 0 }
              , new SoftJointLimit() { limit = 0 }
              , new SoftJointLimit() { limit = 0 }
              , new JointDrive() { positionSpring = 50, positionDamper = 0 }
              , new JointDrive() { positionSpring = 50, positionDamper = 0 }
              , new Quaternion(0.11f, 0, 0, 1)
              , JointProjectionMode.PositionAndRotation
              );
        #endregion
        [Button]
        void GenerateRagdoll()
        {
            InitComponent();
            InitRigidBody();
            InitConfigurationData();
        }
        void InitComponent()
        {
            ragdollCharacter = GetComponent<RagdollCharacter>();
            ragdollCharacter.body_Joint = ragdollCharacter.body.GetComponent<ConfigurableJoint>();
            ragdollCharacter.pelvis_Joint = ragdollCharacter.pelvis.GetComponent<ConfigurableJoint>();

            ragdollCharacter.arm_r_Joint = ragdollCharacter.arm_r.GetComponent<ConfigurableJoint>();
            ragdollCharacter.arm_r_2_Joint = ragdollCharacter.arm_r_2.GetComponent<ConfigurableJoint>();
            ragdollCharacter.arm_l_Joint = ragdollCharacter.arm_l.GetComponent<ConfigurableJoint>();
            ragdollCharacter.arm_l_2_Joint = ragdollCharacter.arm_l_2.GetComponent<ConfigurableJoint>();

            ragdollCharacter.leg_r_1_Joint = ragdollCharacter.leg_r_1.GetComponent<ConfigurableJoint>();
            ragdollCharacter.leg_r_2_Joint = ragdollCharacter.leg_r_2.GetComponent<ConfigurableJoint>();
            ragdollCharacter.leg_foot_r_Joint = ragdollCharacter.leg_foot_r.GetComponent<ConfigurableJoint>();

            ragdollCharacter.leg_l_1_Joint = ragdollCharacter.leg_l_1.GetComponent<ConfigurableJoint>();
            ragdollCharacter.leg_l_2_Joint = ragdollCharacter.leg_l_2.GetComponent<ConfigurableJoint>();
            ragdollCharacter.leg_foot_l_Joint = ragdollCharacter.leg_foot_l.GetComponent<ConfigurableJoint>();


            if (ragdollCharacter.body_Joint == null)
                Debug.LogError("Cant find body_Joint");
            if (ragdollCharacter.pelvis_Joint == null)
                Debug.LogError("Cant find pelvis_Joint");
            if (ragdollCharacter.arm_r_Joint == null)
                Debug.LogError("Cant find arm_r_Joint");
            if (ragdollCharacter.arm_l_Joint == null)
                Debug.LogError("Cant find arm_l_Joint");

            if (ragdollCharacter.leg_r_1_Joint == null)
                Debug.LogError("Cant find leg_r_1_Joint");
            if (ragdollCharacter.leg_r_2_Joint == null)
                Debug.LogError("Cant find leg_r_2_Joint");
            if (ragdollCharacter.leg_foot_r_Joint == null)
                Debug.LogError("Cant find leg_foot_r_Joint");

            if (ragdollCharacter.leg_l_1_Joint == null)
                Debug.LogError("Cant find leg_l_1_Joint");
            if (ragdollCharacter.leg_l_2_Joint == null)
                Debug.LogError("Cant find leg_l_2_Joint");
            if (ragdollCharacter.leg_foot_l_Joint == null)
                Debug.LogError("Cant find leg_foot_l_Joint");

            Debug.LogError("Generate Ragdoll Success");
        }
        void InitRigidBody()
        {
            ragdollCharacter.body_Joint.connectedBody = ragdollCharacter.pelvis;

            ragdollCharacter.arm_r_Joint.connectedBody = ragdollCharacter.body;
            ragdollCharacter.arm_r_2_Joint.connectedBody = ragdollCharacter.arm_r;
            ragdollCharacter.arm_l_Joint.connectedBody = ragdollCharacter.body;
            ragdollCharacter.arm_l_2_Joint.connectedBody = ragdollCharacter.arm_l;

            ragdollCharacter.leg_r_1_Joint.connectedBody = ragdollCharacter.pelvis;
            ragdollCharacter.leg_r_2_Joint.connectedBody = ragdollCharacter.leg_r_1;
            ragdollCharacter.leg_foot_r_Joint.connectedBody = ragdollCharacter.leg_r_2;

            ragdollCharacter.leg_l_1_Joint.connectedBody = ragdollCharacter.pelvis;
            ragdollCharacter.leg_l_2_Joint.connectedBody = ragdollCharacter.leg_l_1;
            ragdollCharacter.leg_foot_l_Joint.connectedBody = ragdollCharacter.leg_l_2;
        }
        void InitConfigurationData()
        {
            OnInitConfiguration(ragdollCharacter.body_Joint, body);
            OnInitConfiguration(ragdollCharacter.pelvis_Joint, pelvis);

            OnInitConfiguration(ragdollCharacter.arm_r_Joint, arm_1);
            OnInitConfiguration(ragdollCharacter.arm_r_2_Joint, arm_2);
            OnInitConfiguration(ragdollCharacter.arm_l_Joint, arm_1);
            OnInitConfiguration(ragdollCharacter.arm_l_2_Joint, arm_2);

            OnInitConfiguration(ragdollCharacter.leg_r_1_Joint, leg_1);
            OnInitConfiguration(ragdollCharacter.leg_r_2_Joint, leg_2);
            OnInitConfiguration(ragdollCharacter.leg_foot_r_Joint, foot);

            OnInitConfiguration(ragdollCharacter.leg_l_1_Joint, leg_1);
            OnInitConfiguration(ragdollCharacter.leg_l_2_Joint, leg_2);
            OnInitConfiguration(ragdollCharacter.leg_foot_l_Joint, foot);
        }
        void OnInitConfiguration(ConfigurableJoint configurableJoint, RagdollConfigurableConfig ragdollConfigurableConfig)
        {
            configurableJoint.autoConfigureConnectedAnchor = ragdollConfigurableConfig.autoConfigureConnectedAnchor;

            configurableJoint.xMotion = ragdollConfigurableConfig.xMotion;
            configurableJoint.yMotion = ragdollConfigurableConfig.yMotion;
            configurableJoint.zMotion = ragdollConfigurableConfig.zMotion;

            configurableJoint.angularXMotion = ragdollConfigurableConfig.angularXMotion;
            configurableJoint.angularYMotion = ragdollConfigurableConfig.angularYMotion;
            configurableJoint.angularZMotion = ragdollConfigurableConfig.angularZMotion;

            configurableJoint.lowAngularXLimit = new SoftJointLimit() 
            {
                limit = ragdollConfigurableConfig.lowAngularXLimit.limit,
                bounciness = configurableJoint.lowAngularXLimit.bounciness,
                contactDistance = configurableJoint.lowAngularXLimit.contactDistance
            };
            configurableJoint.highAngularXLimit = new SoftJointLimit()
            {
                limit = ragdollConfigurableConfig.highAngularXLimit.limit,
                bounciness = configurableJoint.highAngularXLimit.bounciness,
                contactDistance = configurableJoint.highAngularXLimit.contactDistance
            };

            configurableJoint.angularYLimit = new SoftJointLimit()
            {
                limit = ragdollConfigurableConfig.angularYLimit.limit,
                bounciness = configurableJoint.angularYLimit.bounciness,
                contactDistance = configurableJoint.angularYLimit.contactDistance
            };
            configurableJoint.angularZLimit = new SoftJointLimit()
            {
                limit = ragdollConfigurableConfig.angularZLimit.limit,
                bounciness = configurableJoint.angularZLimit.bounciness,
                contactDistance = configurableJoint.angularZLimit.contactDistance
            };

            configurableJoint.angularXDrive = new JointDrive()
            {
                positionSpring = ragdollConfigurableConfig.angularXDrive.positionSpring,
                positionDamper = ragdollConfigurableConfig.angularXDrive.positionDamper,
                maximumForce = configurableJoint.angularXDrive.maximumForce,
                mode = configurableJoint.angularXDrive.mode
            };
            configurableJoint.angularYZDrive = new JointDrive()
            {
                positionSpring = ragdollConfigurableConfig.angularYZDrive.positionSpring,
                positionDamper = ragdollConfigurableConfig.angularYZDrive.positionDamper,
                maximumForce = configurableJoint.angularYZDrive.maximumForce,
                mode = configurableJoint.angularYZDrive.mode
            };

            configurableJoint.targetRotation = ragdollConfigurableConfig.targetRotation;
            configurableJoint.projectionMode = ragdollConfigurableConfig.projectionMode;
        }
    }

}