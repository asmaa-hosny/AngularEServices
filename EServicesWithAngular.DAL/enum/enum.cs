using System;
using System.Collections.Generic;
using System.Text;

namespace EServicesWithAngular.DAL.Enums
{
    public enum SignatureType
    {
        Manual = 1,
        Automatic = 2,

    }


    public enum IdentificationType
    {
        WithSalary = 1,
        WithoutSalary = 2,
    }


    public enum MissionType
    {
        MandateMissionTypeID = 1004933,
        OverTimeMissionTypeID = 1004969,
        TrainingMissionTypeID = 1004971,
    }
}
