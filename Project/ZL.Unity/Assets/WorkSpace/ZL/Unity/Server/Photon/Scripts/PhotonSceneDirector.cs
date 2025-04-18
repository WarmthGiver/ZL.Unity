using Photon.Pun;

using UnityEngine;

namespace ZL.Unity.Server.Photon
{
    [AddComponentMenu("ZL/Server/Photon/Photon Scene Director (Singleton)")]

    public class PhotonSceneDirector : PhotonSceneDirector<PhotonSceneDirector>
    {

    }

    [RequireComponent(typeof(PhotonView))]

    public abstract class PhotonSceneDirector<TPhotonSceneDirector> : SceneDirector<TPhotonSceneDirector>
        
        where TPhotonSceneDirector : PhotonSceneDirector<TPhotonSceneDirector>
    {
        [SerializeField]

        [UsingCustomProperty]

        [GetComponent]

        [ReadOnly(true)]

        private PhotonView photonView;

        public void RPCFadeScene(string loadSceneName)
        {
            photonView.RPC(nameof(FadeScene), RpcTarget.All, loadSceneName);
        }

        [PunRPC]

        public override void FadeScene(string loadSceneName)
        {
            base.FadeScene(loadSceneName);
        }
    }
}