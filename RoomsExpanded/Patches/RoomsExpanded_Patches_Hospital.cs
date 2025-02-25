﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace RoomsExpanded
{
    class RoomsExpanded_Patches_Hospital
    {
        public static void UpdateRoom(ref RoomTypes __instance)
        {
            if (Settings.Instance.HospitalUpdate.IncludeRoom)
            {
                for (int i = 0; i < __instance.Hospital.additional_constraints.Length; i++)
                {
                    if (__instance.Hospital.additional_constraints[i] == RoomConstraints.TOILET)
                        __instance.Hospital.additional_constraints[i] = RoomConstraints.ADVANCED_WASH_STATION;
                    if (__instance.Hospital.additional_constraints[i] == RoomConstraints.MESS_STATION_SINGLE)
                        __instance.Hospital.additional_constraints[i] = RoomConstraints.DECORATIVE_ITEM;
                    if (__instance.Hospital.additional_constraints[i] == RoomConstraints.MAXIMUM_SIZE_96)
                        __instance.Hospital.additional_constraints[i] = RoomConstraintTags.GetMaxSizeConstraint(Settings.Instance.HospitalUpdate.MaxSize);
                }
            }
        }
    }
}
