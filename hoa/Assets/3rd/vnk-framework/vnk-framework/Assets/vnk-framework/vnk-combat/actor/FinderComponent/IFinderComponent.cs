
using UnityEngine;

namespace Yoolax.Framework
{
    public interface IFinderComponent
    {
        Actor Target { set; get; }
        float Radius { set; get; }
        bool AutoFindTarget { set; get; }
    }

}