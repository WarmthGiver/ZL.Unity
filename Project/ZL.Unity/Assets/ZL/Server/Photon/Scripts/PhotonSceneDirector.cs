using Photon.Pun;

using UnityEngine;

namespace ZL.Unity.Server.Photon
{
    [AddComponentMenu("ZL/Server/Photon/Photon Scene Director (Singleton)")]

    public class PhotonSceneDirector : PhotonSceneDirector<PhotonSceneDirector>
    {

    }

    public abstract class PhotonSceneDirector<TPhotonSceneDirector> : SceneDirector<TPhotonSceneDirector>

        where TPhotonSceneDirector : PhotonSceneDirector<TPhotonSceneDirector>
    {
        [GetComponent]

        [ReadOnly(true)]

        [UsingCustomProperty]

        [SerializeField]

        private PhotonView photonView = null;

        public void RPCLoadScene(string loadSceneName)
        {
            photonView.RPC(nameof(LoadScene), RpcTarget.All, loadSceneName);
        }

        [PunRPC]

        public override void LoadScene(string loadSceneName)
        {
            base.LoadScene(loadSceneName);
        }
    }
}