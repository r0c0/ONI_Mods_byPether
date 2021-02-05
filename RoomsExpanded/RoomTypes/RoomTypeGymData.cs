﻿using System;
using STRINGS;
using System.Collections.Generic;

namespace RoomsExpanded
{
    class RoomTypeGymData : RoomTypeAbstractData
    {
        public static readonly string RoomId = "GymRoom";
        public static readonly string GeneratorTagsName = "ManualGenerator";
        public static readonly string WaterCoolerTagName = "WaterCooler";

        public RoomTypeGymData()
        {
            Id = RoomId;
            Name = STRINGS.ROOMS.TYPES.GYMROOM.NAME;
            Tooltip = STRINGS.ROOMS.TYPES.GYMROOM.TOOLTIP;
            Effect = STRINGS.ROOMS.TYPES.GYMROOM.EFFECT;
            Catergory = Db.Get().RoomTypeCategories.Recreation;
            ConstraintPrimary = new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraintTags.RunningWheelGeneratorTag)), 
                                                            (Func<Room, bool>) null,
                                                            name: STRINGS.ROOMS.CRITERIA.MANUALGENERATOR.NAME,
                                                            description: STRINGS.ROOMS.CRITERIA.MANUALGENERATOR.DESCRIPTION,
                                                            stomp_in_conflict: new List<RoomConstraints.Constraint>()
                                                                { RoomConstraints.REC_BUILDING });
            ConstrantsAdditional = new RoomConstraints.Constraint[4]
                                        {
                                            new RoomConstraints.Constraint((Func<KPrefabID, bool>) (bc => bc.HasTag(RoomConstraintTags.WaterCoolerTag)),
                                                                                (Func<Room, bool>) null,
                                                                                name: STRINGS.ROOMS.CRITERIA.WATERCOOLER.NAME,
                                                                                description: STRINGS.ROOMS.CRITERIA.WATERCOOLER.DESCRIPTION),
                                            RoomConstraints.DECORATIVE_ITEM,
                                            RoomConstraints.MINIMUM_SIZE_12,
                                            RoomConstraintTags.GetMaxSizeConstraint(Settings.Instance.Gym.MaxSize)
                                        };

            RoomDetails = new RoomDetails.Detail[2]
                            {
                                new RoomDetails.Detail((Func<Room, string>) (room => string.Format((string) ROOMS.DETAILS.SIZE.NAME, (object) room.cavity.numCells))),
                                new RoomDetails.Detail((Func<Room, string>) (room => string.Format((string) ROOMS.DETAILS.BUILDING_COUNT.NAME, (object) room.buildings.Count)))
                            };

            Priority = 0;
            Upgrades = null;
            SingleAssignee = false;
            PriorityUse = false;
            Effects = null;
            SortKey = SortingCounter.GetAndIncrement(SortingCounter.RecreationRoom);
        }
    }
}
