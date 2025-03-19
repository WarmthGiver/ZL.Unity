using System.Collections;

using UnityEngine;

using ZL.Unity.Server.Photon;

namespace ZL.Unity.PhotonServerConnectorDemo
{
    [AddComponentMenu("")]

    [DisallowMultipleComponent]

    public sealed class PhotonServerConnectorDemoSceneDirector :
        
        SceneDirector<PhotonServerConnectorDemoSceneDirector>
    {
        protected override IEnumerator Start()
        {
            yield return base.Start();

            ISingleton<PhotonServerConnector>.Instance.TryConnect();
        }
    }
}