using System;

namespace DcsMissionParser.Net.Objects.Coalitions.Routes.Plane.Tasks.Options;

[Flags]
public enum WeaponType : ulong
{
    NoWeapon = 0,
    
    // Bombs
    LGB = 2,
    TvGB = 4,
    SNSGB = 8,
    HEBomb = 16,
    Penetrator = 32,
    NapalmBomb = 64,
    FAEBomb = 128,
    ClusterBomb = 256,
    Dispencer = 512,
    CandleBomb = 1024,
    ParachuteBomb = 2147483648,
    
    // Rockets
    LightRocket = 2048,
    MarkerRocket = 4096,
    CandleRocket = 8192,
    HeavyRocket = 16384,
    
    // Air-to-Surface Missiles
    AntiRadarMissile = 32768,
    AntiShipMissile = 65536,
    AntiTankMissile = 131072,
    FireAndForgetASM = 262144,
    LaserASM = 524288,
    TeleASM = 1048576,
    CruiseMissile = 2097152,
    AntiRadarMissile2 = 1073741824,
    Decoys = 8589934592,
    
    // Air-to-Air Missiles
    SRAAM = 4194304,
    MRAAM = 8388608,
    LRAAM = 16777216,
    IR_AAM = 33554432,
    SAR_AAM = 67108864,
    AR_AAM = 134217728,
    
    // Cannons
    GUN_POD = 268435456,
    BuiltInCannon = 536870912,
    
    // Torpedo
    Torpedo = 4294967296,
    
    // Shells
    SmokeShell = 17179869184,
    IlluminationShell = 34359738368,
    MarkerShell = 51539607552,
    SubmunitionDispenserShell = 68719476736,
    GuidedShell = 137438953472,
    ConventionalShell = 206963736576,
    
    // Bomb Combinations
    GuidedBomb = LGB | TvGB | SNSGB, // 14
    AnyUnguidedBomb = HEBomb | Penetrator | NapalmBomb | FAEBomb | ClusterBomb | Dispencer | CandleBomb | ParachuteBomb, // 2147485680
    AnyBomb = GuidedBomb | AnyUnguidedBomb, // 2147485694
    
    // Rocket Combinations
    AnyRocket = LightRocket | MarkerRocket | CandleRocket | HeavyRocket, // 30720
    
    // ASM Combinations
    GuidedASM = LaserASM | TeleASM, // 1572864
    TacticalASM = GuidedASM | FireAndForgetASM, // 1835008
    AnyASM = AntiRadarMissile | AntiShipMissile | AntiTankMissile | FireAndForgetASM | GuidedASM | CruiseMissile, // 4161536
    
    // AAM Combinations
    AnyAAM = IR_AAM | SAR_AAM | AR_AAM | SRAAM | MRAAM | LRAAM, // 264241152
    AnyMissile = AnyASM | AnyAAM, // 268402688
    AnyAutonomousMissile = IR_AAM | AntiRadarMissile | AntiShipMissile | FireAndForgetASM | CruiseMissile, // 36012032
    
    // Cannon Combinations
    Cannons = GUN_POD | BuiltInCannon, // 805306368
    
    // Shell Combinations
    AnyShell = SmokeShell | IlluminationShell | MarkerShell | SubmunitionDispenserShell | GuidedShell | ConventionalShell, // 258503344128
    
    // Weapon Category Combinations
    AnyAGWeapon = BuiltInCannon | GUN_POD | AnyBomb | AnyRocket | AnyASM, // 2956984318
    AnyAAWeapon = BuiltInCannon | GUN_POD | AnyAAM, // 264241152
    UnguidedWeapon = Cannons | BuiltInCannon | GUN_POD | AnyUnguidedBomb | AnyRocket, // 2952822768
    GuidedWeapon = GuidedBomb | AnyASM | AnyAAM, // 268402702
    AnyWeapon = AnyBomb | AnyRocket | AnyMissile | Cannons, // 3221225470
    MarkerWeapon = MarkerRocket | CandleRocket | CandleBomb, // 13312
    ArmWeapon = AnyWeapon & ~MarkerWeapon // 209379642366 (AnyWeapon - MarkerWeapon)
}
