using Photon.Pun;

using Photon.Realtime;

using UnityEngine;

using ZL.Unity.Pooling;

namespace ZL.Unity.Server.Photon
{
    [AddComponentMenu("ZL/Server/Photon/Photon Player List Displayer")]

    public sealed class PhotonPlayerListDisplayer : PhotonPlayerListDisplayer<PhotonPlayerListItem> { }

    public abstract class PhotonPlayerListDisplayer<TPlayerListItem> : MonoBehaviour

        where TPlayerListItem : ManagedPooledObject<int>
    {
        [Space]

        [ReadOnlyIfPlayMode]

        [UsingCustomProperty]

        [SerializeField]

        protected ManagedObjectPool<int, TPlayerListItem> playerListItemPool = null;

        public void Refresh()
        {
            playerListItemPool.CollectAll();

            foreach (var player in PhotonNetwork.PlayerList)
            {
                Add(player);
            }
        }

        public virtual void Add(Player player)
        {
            playerListItemPool.TryClone(player.ActorNumber, out var item);

            item.transform.SetAsLastSibling();

            item.Appear();
        }

        public void Remove(Player player)
        {
            playerListItemPool[player.ActorNumber].Disappear();
        }
    }
}