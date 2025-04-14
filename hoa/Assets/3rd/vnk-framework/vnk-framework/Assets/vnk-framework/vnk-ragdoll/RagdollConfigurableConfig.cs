using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yoolax.Framework
{
    [System.Serializable]
    public class RagdollConfigurableConfig
    {
        public bool autoConfigureConnectedAnchor;

        public ConfigurableJointMotion xMotion;
        public ConfigurableJointMotion yMotion;
        public ConfigurableJointMotion zMotion;

        public ConfigurableJointMotion angularXMotion;
        public ConfigurableJointMotion angularYMotion;
        public ConfigurableJointMotion angularZMotion;

        public SoftJointLimit lowAngularXLimit;
        public SoftJointLimit highAngularXLimit;

        public SoftJointLimit angularYLimit;
        public SoftJointLimit angularZLimit;

        public JointDrive angularXDrive;
        public JointDrive angularYZDrive;

        public Quaternion targetRotation;
        public JointProjectionMode projectionMode;

        public RagdollConfigurableConfig(bool autoConfigureConnectedAnchor
            , ConfigurableJointMotion xMotion , ConfigurableJointMotion yMotion , ConfigurableJointMotion zMotion
            , ConfigurableJointMotion angularXMotion, ConfigurableJointMotion angularYMotion, ConfigurableJointMotion angularZMotion
            , SoftJointLimit lowAngularXLimit, SoftJointLimit highAngularXLimit
            , SoftJointLimit angularYLimit, SoftJointLimit agularZLimit
            , JointDrive angularXDrive
            , JointDrive angularYZDrive
            , Quaternion targetRotation
            , JointProjectionMode jointProjectionMode)
        {
            this.autoConfigureConnectedAnchor = autoConfigureConnectedAnchor;
            this.xMotion = xMotion;
            this.yMotion = yMotion;
            this.zMotion = zMotion;
            this.angularXMotion = angularXMotion;
            this.angularYMotion = angularYMotion;
            this.angularZMotion = angularZMotion;
            this.lowAngularXLimit = lowAngularXLimit;
            this.highAngularXLimit = highAngularXLimit;
            this.angularYLimit = angularYLimit;
            this.angularZLimit = agularZLimit;
            this.angularXDrive = angularXDrive;
            this.angularYZDrive = angularYZDrive;
            this.targetRotation = targetRotation;
            this.projectionMode = jointProjectionMode;
        }
    }

}