using Google.Protobuf.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ItemController : CreatureController
{
    protected GameObject item;

    protected override void Init()
    {
        State = CreatureState.Moving;
        base.Init();
    }

    protected override void UpdateAnimation()
    {
        // 추후 기능 추가
    }
    
    protected void ActiveItem(GameObject player)
    {
        // 추후 기능 추가
        MyPlayerController mc = player.GetComponent<MyPlayerController>();

        C_ItemGet clientPacket = new C_ItemGet() { Iteminfo = new ItemInfo() };
        Debug.Log($"{Id} Get Item");

        clientPacket.Iteminfo.ItemId = Id;
        clientPacket.Iteminfo.Name = "Coin";
        clientPacket.Iteminfo.PosInfo = PosInfo;
        clientPacket.PlayerObejctId = mc.Id;
        Managers.Network.Send(clientPacket);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActiveItem(other.gameObject);
        }
    }

}



