namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Common;

public enum BeaconType
{
    NULL = 0,
    VOR = 1,
    DME = 2, 
    VOR_DME = 3, 
    TACAN = 4,
    VORTAC = 5, 
    RSBN = 32 ,
    BROADCAST_STATION = 1024 ,
    HOMER = 8 ,
    AIRPORT_HOMER = 4104 ,
    AIRPORT_HOMER_WITH_MARKER = 4136 ,
    ILS_FAR_HOMER = 16408 ,
    ILS_NEAR_HOMER = 16456 ,
    ILS_LOCALIZER = 16640 ,
    ILS_GLIDESLOPE = 16896 ,
    NAUTICAL_HOMER = 32776,
}
