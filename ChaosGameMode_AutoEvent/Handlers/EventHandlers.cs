using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using System.Collections.Generic;
using InventorySystem.Items.Usables.Scp330;
using PlayerRoles;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using PluginAPI.Core.Zones;
using UnityEngine;
using MEC;
using System.Linq;
using PluginAPI.Roles;
using System;
using GameCore;

namespace ChaosGameMode_AutoEvent.Handlers
{
    public class EventHandlers
    {
        static bool IsChaosGameModeGoingOn = false;
        public static void StartEvent()
        {

            IsChaosGameModeGoingOn = true;

        }
        public void EndEvent(RoundEndedEventArgs ev)
        {


            IsChaosGameModeGoingOn = false;


        }
        public void EventEndOnRoundRestarted()
        {


            IsChaosGameModeGoingOn = false;


        }

        public static void StopChaoticStateCommand()
        {


            IsChaosGameModeGoingOn = false;


        }

        public void OnEventStart()
        {
            if (IsChaosGameModeGoingOn == true)
            {
                Timing.CallDelayed(10, ChaoticEngine);
            }
        }

        public void ChaoticEngine()
        {
            if (IsChaosGameModeGoingOn == true)
            {
                Timing.CallPeriodically(1500, Config.TimeBetweenChaoticWaves, ChaoticGameMode);
            }
        }


        public void ChaoticGameMode()
        {
            System.Random rand = new System.Random();

            if (IsChaosGameModeGoingOn == true)
            {
                foreach (Player player in Player.List)
                {
                    int ChaoticChance = rand.Next(1, 3);

                    if (ChaoticChance == 1)
                    {
                        int ChaoticState = rand.Next(1, 21);

                        if (ChaoticState > 0 && ChaoticState < 19)
                        {
                            int ChaoticBuff = rand.Next(1, 6);

                            if (ChaoticBuff == 1)
                            {
                                int RandomItem = rand.Next(1, 12);

                                if (RandomItem == 1)
                                {
                                    player.TryAddCandy(CandyKindID.Pink);
                                    player.AddItem(ItemType.SCP500, 5);
                                }
                                else if (RandomItem == 2)
                                {
                                    player.AddItem(ItemType.KeycardO5);
                                    player.AddItem(ItemType.GrenadeHE, 2);
                                }
                                else if (RandomItem == 3)
                                {
                                    player.AddItem(ItemType.ParticleDisruptor);
                                }
                                else if (RandomItem == 4)
                                {
                                    player.AddItem(ItemType.GunLogicer);
                                    for (int i = 0; i < 10; i++)
                                    {
                                        player.AddItem(ItemType.Ammo762x39);
                                    }
                                }
                                else if (RandomItem == 5)
                                {
                                    player.AddItem(ItemType.Jailbird);
                                }
                                else if (RandomItem == 6)
                                {
                                    player.AddItem(ItemType.MicroHID);
                                }
                                else if (RandomItem == 7)
                                {
                                    player.AddItem(ItemType.SCP018, 2);
                                }
                                else if (RandomItem == 8)
                                {
                                    player.AddItem(ItemType.GunFSP9);
                                    for (int i = 0; i < 10; i++)
                                    {
                                        player.AddItem(ItemType.Ammo9x19);
                                    }
                                }
                                else if (RandomItem == 9)
                                {
                                    player.AddItem(ItemType.GunCom45);
                                    for (int i = 0; i < 10; i++)
                                    {
                                        player.AddItem(ItemType.Ammo9x19);
                                    }
                                }
                                else if (RandomItem == 10)
                                {
                                    player.AddItem(ItemType.GunAK);
                                    for (int i = 0; i < 10; i++)
                                    {
                                        player.AddItem(ItemType.Ammo762x39);
                                    }
                                }
                                else if (RandomItem == 11)
                                {
                                    player.AddItem(ItemType.GunE11SR);
                                    for (int i = 0; i < 10; i++)
                                    {
                                        player.AddItem(ItemType.Ammo556x45);
                                    }
                                }
                            }
                            else if (ChaoticBuff == 2)
                            {
                                if (player.Role != RoleTypeId.Overwatch)
                                {
                                    if (Warhead.IsDetonated == false)
                                    {
                                        int RandomChaoticClass = rand.Next(1, 36);

                                        if (RandomChaoticClass > 0 && RandomChaoticClass < 5)
                                        {
                                            if (player.Role == RoleTypeId.Spectator || player.Role == RoleTypeId.Scp079)
                                            {
                                                if (Round.ElapsedTime.TotalSeconds < 480 && Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                                {
                                                    player.Role.Set(RoleTypeId.ClassD, RoleSpawnFlags.All);
                                                }
                                                else if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                                {
                                                    player.Role.Set(RoleTypeId.ClassD, RoleSpawnFlags.None);
                                                    player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.FacilityGuard).Position;
                                                }
                                                else
                                                {
                                                    player.Role.Set(RoleTypeId.ClassD, RoleSpawnFlags.None);
                                                    player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.ChaosConscript).Position;
                                                }
                                            }
                                            else
                                            {
                                                player.Role.Set(RoleTypeId.ClassD, RoleSpawnFlags.None);
                                            }
                                        }
                                        else if (RandomChaoticClass > 4 && RandomChaoticClass < 9)
                                        {
                                            if (player.Role == RoleTypeId.Spectator || player.Role == RoleTypeId.Scp079)
                                            {
                                                player.Role.Set(RoleTypeId.ChaosRepressor, RoleSpawnFlags.All);
                                            }
                                            else
                                            {
                                                player.Role.Set(RoleTypeId.ChaosRepressor, RoleSpawnFlags.None);
                                            }
                                        }
                                        else if (RandomChaoticClass > 8 && RandomChaoticClass < 13)
                                        {
                                            if (player.Role == RoleTypeId.Spectator || player.Role == RoleTypeId.Scp079)
                                            {
                                                if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                                {
                                                    player.Role.Set(RoleTypeId.FacilityGuard, RoleSpawnFlags.All);
                                                }
                                                else
                                                {
                                                    player.Role.Set(RoleTypeId.FacilityGuard, RoleSpawnFlags.None);
                                                    player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.NtfPrivate).Position;
                                                }
                                            }
                                            else
                                            {
                                                player.Role.Set(RoleTypeId.FacilityGuard, RoleSpawnFlags.None);
                                            }
                                        }
                                        else if (RandomChaoticClass > 12 && RandomChaoticClass < 17)
                                        {
                                            if (player.Role == RoleTypeId.Spectator || player.Role == RoleTypeId.Scp079)
                                            {
                                                if (Round.ElapsedTime.TotalSeconds < 480 && Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                                {
                                                    player.Role.Set(RoleTypeId.Scientist, RoleSpawnFlags.All);
                                                }
                                                else if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                                {
                                                    player.Role.Set(RoleTypeId.Scientist, RoleSpawnFlags.None);
                                                    player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.FacilityGuard).Position;
                                                }
                                                else
                                                {
                                                    player.Role.Set(RoleTypeId.Scientist, RoleSpawnFlags.None);
                                                    player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.ChaosRepressor).Position;
                                                }
                                            }
                                            else
                                            {
                                                player.Role.Set(RoleTypeId.Scientist, RoleSpawnFlags.None);
                                            }
                                        }
                                        else if (RandomChaoticClass == 17)
                                        {
                                            if (player.Role == RoleTypeId.Spectator || player.Role == RoleTypeId.Scp079)
                                            {
                                                if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                                {
                                                    player.Role.Set(RoleTypeId.Scp0492, RoleSpawnFlags.All);
                                                }
                                                else
                                                {
                                                    player.Role.Set(RoleTypeId.Scp0492, RoleSpawnFlags.None);
                                                    player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.ChaosRepressor).Position;
                                                }
                                            }
                                            else
                                            {
                                                player.Role.Set(RoleTypeId.Scp0492, RoleSpawnFlags.None);
                                            }
                                        }
                                        else if (RandomChaoticClass == 18)
                                        {
                                            if (player.Role == RoleTypeId.Spectator || player.Role == RoleTypeId.Scp079)
                                            {
                                                if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                                {
                                                    player.Role.Set(RoleTypeId.Scp106, RoleSpawnFlags.All);
                                                }
                                                else
                                                {
                                                    player.Role.Set(RoleTypeId.Scp106, RoleSpawnFlags.AssignInventory);
                                                    player.Teleport(DoorType.EscapePrimary);
                                                }
                                            }
                                            else
                                            {
                                                player.Role.Set(RoleTypeId.Scp106, RoleSpawnFlags.AssignInventory);
                                            }
                                        }
                                        else if (RandomChaoticClass == 19)
                                        {
                                            player.Role.Set(RoleTypeId.Scp079);
                                        }
                                        else if (RandomChaoticClass == 20)
                                        {
                                            if (player.Role == RoleTypeId.Spectator || player.Role == RoleTypeId.Scp079)
                                            {
                                                if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                                {
                                                    player.Role.Set(RoleTypeId.Scp096, RoleSpawnFlags.All);
                                                }
                                                else
                                                {
                                                    player.Role.Set(RoleTypeId.Scp096, RoleSpawnFlags.AssignInventory);
                                                    player.Teleport(DoorType.EscapeSecondary);
                                                }
                                            }
                                            else
                                            {
                                                player.Role.Set(RoleTypeId.Scp096, RoleSpawnFlags.AssignInventory);
                                            }
                                        }
                                        else if (RandomChaoticClass == 21)
                                        {
                                            if (player.Role == RoleTypeId.Spectator || player.Role == RoleTypeId.Scp079)
                                            {
                                                if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                                {
                                                    player.Role.Set(RoleTypeId.Scp049, RoleSpawnFlags.All);
                                                }
                                                else
                                                {
                                                    player.Role.Set(RoleTypeId.Scp049, RoleSpawnFlags.AssignInventory);
                                                    player.Teleport(DoorType.EscapeSecondary);
                                                }
                                            }
                                            else
                                            {
                                                player.Role.Set(RoleTypeId.Scp049, RoleSpawnFlags.AssignInventory);
                                            }
                                        }
                                        else if (RandomChaoticClass == 22)
                                        {
                                            if (player.Role == RoleTypeId.Spectator || player.Role == RoleTypeId.Scp079)
                                            {
                                                if (Round.ElapsedTime.TotalSeconds < 480 && Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                                {
                                                    player.Role.Set(RoleTypeId.Scp173, RoleSpawnFlags.All);
                                                }
                                                else if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                                {
                                                    player.Role.Set(RoleTypeId.Scp173, RoleSpawnFlags.AssignInventory);
                                                    player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.Scp049).Position;
                                                }
                                                else
                                                {
                                                    player.Role.Set(RoleTypeId.Scp173, RoleSpawnFlags.AssignInventory);
                                                    player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.ChaosRifleman).Position;
                                                }
                                            }
                                            else
                                            {
                                                player.Role.Set(RoleTypeId.Scp173, RoleSpawnFlags.AssignInventory);
                                            }
                                        }
                                        else if (RandomChaoticClass == 23)
                                        {
                                            if (player.Role == RoleTypeId.Spectator || player.Role == RoleTypeId.Scp079)
                                            {
                                                if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                                {
                                                    player.Role.Set(RoleTypeId.Scp939, RoleSpawnFlags.All);
                                                }
                                                else
                                                {
                                                    player.Role.Set(RoleTypeId.Scp939, RoleSpawnFlags.AssignInventory);
                                                    player.Teleport(DoorType.NukeSurface);
                                                }
                                            }
                                            else
                                            {
                                                player.Role.Set(RoleTypeId.Scp939, RoleSpawnFlags.AssignInventory);
                                            }
                                        }
                                        else if (RandomChaoticClass > 23 && RandomChaoticClass < 28)
                                        {
                                            if (player.Role == RoleTypeId.Spectator || player.Role == RoleTypeId.Scp079)
                                            {
                                                player.Role.Set(RoleTypeId.NtfCaptain, RoleSpawnFlags.All);
                                            }
                                            else
                                            {
                                                player.Role.Set(RoleTypeId.NtfCaptain, RoleSpawnFlags.None);
                                            }
                                        }
                                        else if (RandomChaoticClass > 27 && RandomChaoticClass < 32)
                                        {
                                            if (player.Role == RoleTypeId.Spectator || player.Role == RoleTypeId.Scp079)
                                            {
                                                player.Role.Set(RoleTypeId.ChaosConscript, RoleSpawnFlags.All);
                                            }
                                            else
                                            {
                                                player.Role.Set(RoleTypeId.ChaosConscript, RoleSpawnFlags.None);
                                            }
                                        }
                                        else if (RandomChaoticClass > 31 && RandomChaoticClass < 36)
                                        {
                                            if (player.Role == RoleTypeId.Spectator || player.Role == RoleTypeId.Scp079)
                                            {
                                                player.Role.Set(RoleTypeId.NtfSpecialist, RoleSpawnFlags.All);
                                            }
                                            else
                                            {
                                                player.Role.Set(RoleTypeId.NtfSpecialist, RoleSpawnFlags.None);
                                            }
                                        }
                                    }
                                }
                            }
                            else if (ChaoticBuff == 3)
                            {
                                int RandomTeleport = rand.Next(1, 19);

                                if (RandomTeleport == 1)
                                {
                                    if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.CheckpointEzHczB);
                                    }
                                    else
                                    {
                                        player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.ChaosRepressor).Position;
                                    }
                                }
                                else if (RandomTeleport == 2)
                                {
                                    if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.CheckpointEzHczA);
                                    }
                                    else
                                    {
                                        player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.ChaosRepressor).Position;
                                    }
                                }
                                else if (RandomTeleport == 3)
                                {
                                    player.Teleport(DoorType.NukeSurface);
                                }
                                else if (RandomTeleport == 4)
                                {
                                    if (Round.ElapsedTime.TotalSeconds < 480 && Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.Scp914Gate);
                                    }
                                    else if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.Intercom);
                                    }
                                    else
                                    {
                                        player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.ChaosConscript).Position;
                                    }
                                }
                                else if (RandomTeleport == 5)
                                {
                                    if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.ServersBottom);
                                    }
                                    else
                                    {
                                        player.Teleport(DoorType.NukeSurface);
                                    }
                                }
                                else if (RandomTeleport == 6)
                                {
                                    if (Round.ElapsedTime.TotalSeconds < 480 && Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.Scp173Bottom);
                                    }
                                    else if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.HczArmory);
                                    }
                                    else
                                    {
                                        player.Teleport(DoorType.EscapePrimary);
                                    }
                                }
                                else if (RandomTeleport == 7)
                                {
                                    if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.Scp939Cryo);
                                    }
                                    else
                                    {
                                        player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.NtfSergeant).Position;
                                    }
                                }
                                else if (RandomTeleport == 8)
                                {
                                    if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.Scp096);
                                    }
                                    else
                                    {
                                        player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.NtfSergeant).Position;
                                    }
                                }
                                else if (RandomTeleport == 9)
                                {
                                    if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.Scp049Armory);
                                    }
                                    else
                                    {
                                        player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.ChaosRepressor).Position;
                                    }
                                }
                                else if (RandomTeleport == 10)
                                {
                                    if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.NukeArmory);
                                    }
                                    else
                                    {
                                        player.Teleport(DoorType.SurfaceGate);
                                    }
                                }
                                else if (RandomTeleport == 11)
                                {
                                    if (Round.ElapsedTime.TotalSeconds < 480 && Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.GR18Inner);
                                    }
                                    else if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.ElevatorScp049);
                                    }
                                    else
                                    {
                                        player.Teleport(DoorType.SurfaceGate);
                                    }
                                }
                                else if (RandomTeleport == 12)
                                {
                                    if (Round.ElapsedTime.TotalSeconds < 480 && Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.Airlock);
                                    }
                                    else if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.GateB);
                                    }
                                    else
                                    {
                                        player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.NtfCaptain).Position;
                                    }
                                }
                                else if (RandomTeleport == 13)
                                {
                                    if (Round.ElapsedTime.TotalSeconds < 480 && Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.LczWc);
                                    }
                                    else if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.GateA);
                                    }
                                    else
                                    {
                                        player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.NtfCaptain).Position;
                                    }
                                }
                                else if (RandomTeleport == 14)
                                {
                                    if (Round.ElapsedTime.TotalSeconds < 480 && Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.HczArmory);
                                    }
                                    else if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.ElevatorGateA);
                                    }
                                    else
                                    {
                                        player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.ChaosMarauder).Position;
                                    }
                                }
                                else if (RandomTeleport == 15)
                                {
                                    if (Round.ElapsedTime.TotalSeconds < 480 && Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.Scientist).Position;
                                    }
                                    else if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.HIDRight);
                                    }
                                    else
                                    {
                                        player.Teleport(DoorType.NukeSurface);
                                    }
                                }
                                else if (RandomTeleport == 16)
                                {
                                    if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.Scp079First);
                                    }
                                    else
                                    {
                                        player.Teleport(DoorType.SurfaceGate);
                                    }
                                }
                                else if (RandomTeleport == 17)
                                {
                                    if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.ElevatorNuke);
                                    }
                                    else
                                    {
                                        player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.ChaosMarauder).Position;
                                    }
                                }
                                else if (RandomTeleport == 18)
                                {
                                    if (Round.ElapsedTime.TotalSeconds < 480 && Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.Scp330Chamber);
                                    }
                                    else if (Warhead.IsInProgress == false && Warhead.IsDetonated == false)
                                    {
                                        player.Teleport(DoorType.Intercom);
                                    }
                                    else
                                    {
                                        player.Position = RoleExtensions.GetRandomSpawnLocation(RoleTypeId.NtfCaptain).Position;
                                    }
                                }
                            }
                            else if (ChaoticBuff == 4)
                            {
                                int RandomBuff = rand.Next(1, 3);

                                if (RandomBuff == 1)
                                {
                                    player.EnableEffect(EffectType.MovementBoost, 1200);
                                    player.ChangeEffectIntensity(EffectType.MovementBoost, 60, 1200);
                                }
                                else if (RandomBuff == 2)
                                {
                                    if (player.Health < 350)
                                    {
                                        player.Health = 350;
                                    }
                                }
                            }
                            else if (ChaoticBuff == 5)
                            {
                                int RandomSizes = rand.Next(1, 4);

                                if (RandomSizes == 1)
                                {
                                    player.Scale = new Vector3(1.2f, 1.1f, 1.2f);
                                }
                                else if (RandomSizes == 2)
                                {
                                    player.Scale = new Vector3(1.2f, 0.5f, 1);
                                }
                                else if (RandomSizes == 3)
                                {
                                    player.Scale = new Vector3(0.2f, 1.1f, 1.2f);
                                }
                                else if (RandomSizes == 4)
                                {
                                    player.Scale = new Vector3(0.5f, 0.5f, 0.5f);
                                }
                            } 
                        }
                        else
                        {
                            int zonetype = rand.Next(1, 6);

                            if (zonetype == 1)
                            {
                                Map.TurnOffAllLights(1);
                            }
                            else if (zonetype == 2)
                            {
                                Map.TurnOffAllLights(1, ZoneType.Entrance);
                            }
                            else if (zonetype == 3)
                            {
                                Map.TurnOffAllLights(1, ZoneType.HeavyContainment);
                            }
                            else if (zonetype == 4)
                            {
                                Map.TurnOffAllLights(1, ZoneType.LightContainment);
                            }
                            else if (zonetype == 5)
                            {
                                Map.TurnOffAllLights(1, ZoneType.Surface);
                            }
                        }
                    }
                }
            }
        }
    }
}