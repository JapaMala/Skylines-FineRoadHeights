﻿// Decompiled with JetBrains decompiler
// Type: PublicTransportPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 25DD26D5-8AEC-4F0C-B468-EF9C5665764A
// Assembly location: E:\Games\SteamLibrary\SteamApps\common\Cities_Skylines\Cities_Data\Managed\Assembly-CSharp.dll

using ColossalFramework.UI;
using System;

public sealed class PublicTransportFinePanel : GeneratedScrollPanel
{
  public override ItemClass.Service service
  {
    get
    {
      return ItemClass.Service.PublicTransport;
    }
  }

  protected override void Start()
  {
    this.component.parent.eventVisibilityChanged += (PropertyChangedEventHandler<bool>) ((sender, visible) =>
    {
      if (visible)
        return;
      this.roadsOptionPanel.Hide();
      this.tracksOptionPanel.Hide();
      this.tunnelsOptionPanel.Hide();
    });
    base.Start();
  }

  public override void RefreshPanel()
  {
    base.RefreshPanel();
    this.PopulateAssets((GeneratedScrollPanel.AssetFilter) 7, new Comparison<PrefabInfo>(this.ItemsTypeReverseSort));
  }

  protected override void OnButtonClicked(UIComponent comp)
  {
    object objectUserData = comp.objectUserData;
    BuildingInfo buildingInfo = objectUserData as BuildingInfo;
    NetInfo netInfo = objectUserData as NetInfo;
    TransportInfo transportInfo = objectUserData as TransportInfo;
    if ((UnityEngine.Object) buildingInfo != (UnityEngine.Object) null)
    {
      BuildingTool buildingTool = ToolsModifierControl.SetTool<BuildingTool>();
      if ((UnityEngine.Object) buildingTool != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) this.roadsOptionPanel != (UnityEngine.Object) null)
          this.roadsOptionPanel.isVisible = false;
        if ((UnityEngine.Object) this.tunnelsOptionPanel != (UnityEngine.Object) null)
          this.tunnelsOptionPanel.isVisible = false;
        if ((UnityEngine.Object) this.tracksOptionPanel != (UnityEngine.Object) null)
          this.tracksOptionPanel.isVisible = false;
        buildingTool.m_prefab = buildingInfo;
        buildingTool.m_relocate = 0;
      }
    }
    if ((UnityEngine.Object) transportInfo != (UnityEngine.Object) null)
    {
      TransportTool transportTool = ToolsModifierControl.SetTool<TransportTool>();
      if ((UnityEngine.Object) transportTool != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) this.roadsOptionPanel != (UnityEngine.Object) null)
          this.roadsOptionPanel.isVisible = false;
        if ((UnityEngine.Object) this.tunnelsOptionPanel != (UnityEngine.Object) null)
          this.tunnelsOptionPanel.isVisible = false;
        if ((UnityEngine.Object) this.tracksOptionPanel != (UnityEngine.Object) null)
          this.tracksOptionPanel.isVisible = false;
        transportTool.m_prefab = transportInfo;
      }
    }
    if (!((UnityEngine.Object) netInfo != (UnityEngine.Object) null))
      return;
    NetToolFine netTool = ToolsModifierControl.SetTool<NetToolFine>();
    if (!((UnityEngine.Object) netTool != (UnityEngine.Object) null))
      return;
    ItemClass.SubService subService = netInfo.GetSubService();
    if (subService == ItemClass.SubService.PublicTransportMetro && (UnityEngine.Object) this.tunnelsOptionPanel != (UnityEngine.Object) null)
      this.tunnelsOptionPanel.isVisible = true;
    else if (subService == ItemClass.SubService.PublicTransportTrain && (UnityEngine.Object) this.tracksOptionPanel != (UnityEngine.Object) null)
      this.tracksOptionPanel.isVisible = true;
    else if ((UnityEngine.Object) this.roadsOptionPanel != (UnityEngine.Object) null)
      this.roadsOptionPanel.isVisible = true;
    netTool.m_prefab = netInfo;
  }
}
