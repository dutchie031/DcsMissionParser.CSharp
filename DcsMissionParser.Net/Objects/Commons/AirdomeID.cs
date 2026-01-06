using DcsMissionParser.Net.Annotations;

namespace DcsMissionParser.Net.Objects.Commons;


public abstract class AirdromeId : IntEnum
{
    internal AirdromeId(int value) : base(value) {}
}

public class CaucasusAirdromeId : AirdromeId
{
    private CaucasusAirdromeId(int value) : base(value) {}

    public static readonly CaucasusAirdromeId AnapaVityazevo = new(12);
    public static readonly CaucasusAirdromeId KrasnodarCenter = new(13);
    public static readonly CaucasusAirdromeId Novorossiysk = new(14);
    public static readonly CaucasusAirdromeId Krymsk = new(15);
    public static readonly CaucasusAirdromeId MaykopKhanskaya = new(16);
    public static readonly CaucasusAirdromeId Gelendzhik = new(17);
    public static readonly CaucasusAirdromeId SochiAdler = new(18);
    public static readonly CaucasusAirdromeId KrasnodarPashkovsky = new(19);
    public static readonly CaucasusAirdromeId SukhumiBabushara = new(20);
    public static readonly CaucasusAirdromeId Gudauta = new(21);
    public static readonly CaucasusAirdromeId Batumi = new(22);
    public static readonly CaucasusAirdromeId SenakiKolkhi = new(23);
    public static readonly CaucasusAirdromeId Kobuleti = new(24);
    public static readonly CaucasusAirdromeId Kutaisi = new(25);
    public static readonly CaucasusAirdromeId MineralnyeVody = new(26);
    public static readonly CaucasusAirdromeId Nalchik = new(27);
    public static readonly CaucasusAirdromeId Mozdok = new(28);
    public static readonly CaucasusAirdromeId TbilisiLochini = new(29);
    public static readonly CaucasusAirdromeId Soganlug = new(30);
    public static readonly CaucasusAirdromeId Vaziani = new(31);
    public static readonly CaucasusAirdromeId Beslan = new(32);

}

public class NevadaAirdromeId : AirdromeId
{
    private NevadaAirdromeId(int value) : base(value) {}
    public static readonly NevadaAirdromeId CreechAFB = new(1);
    public static readonly NevadaAirdromeId GroomLakeAFB = new(2);
    public static readonly NevadaAirdromeId McCarranInternationalAirport = new(3);
    public static readonly NevadaAirdromeId NellisAFB = new(4);
    public static readonly NevadaAirdromeId BeattyAirport = new(5);
    public static readonly NevadaAirdromeId BoulderCityAirport = new(6);
    public static readonly NevadaAirdromeId EchoBay = new(7);
    public static readonly NevadaAirdromeId HendersonExecutiveAirport = new(8);
    public static readonly NevadaAirdromeId JeanAirport = new(9);
    public static readonly NevadaAirdromeId LaughlinAirport = new(10);
    public static readonly NevadaAirdromeId LincolnCounty = new(11);
    public static readonly NevadaAirdromeId Mesquite = new(13);
    public static readonly NevadaAirdromeId MinaAirport3Q0 = new(14);
    public static readonly NevadaAirdromeId NorthLasVegas = new(15);
    public static readonly NevadaAirdromeId PahuteMesaAirstrip = new(16);
    public static readonly NevadaAirdromeId TonopahAirport = new(17);
    public static readonly NevadaAirdromeId TonopahTestRangeAirfield = new(18);
}

public class NormandyAirdromeId : AirdromeId
{
    private NormandyAirdromeId(int value) : base(value) {}
    public static readonly NormandyAirdromeId SaintPierreDuMont = new(1);
    public static readonly NormandyAirdromeId Lignerolles = new(2);
    public static readonly NormandyAirdromeId Cretteville = new(3);
    public static readonly NormandyAirdromeId Maupertus = new(4);
    public static readonly NormandyAirdromeId Brucheville = new(5);
    public static readonly NormandyAirdromeId Meautis = new(6);
    public static readonly NormandyAirdromeId CricquevilleEnBessin = new(7);
    public static readonly NormandyAirdromeId Lessay = new(8);
    public static readonly NormandyAirdromeId SainteLaurentSurMer = new(9);
    public static readonly NormandyAirdromeId Biniville = new(10);
    public static readonly NormandyAirdromeId Cardonville = new(11);
    public static readonly NormandyAirdromeId DeuxJumeaux = new(12);
    public static readonly NormandyAirdromeId Chippelle = new(13);
    public static readonly NormandyAirdromeId Beuzeville = new(14);
    public static readonly NormandyAirdromeId Azeville = new(15);
    public static readonly NormandyAirdromeId Picauville = new(16);
    public static readonly NormandyAirdromeId LeMolay = new(17);
    public static readonly NormandyAirdromeId LonguesSurMer = new(18);
    public static readonly NormandyAirdromeId Carpiquet = new(19);
    public static readonly NormandyAirdromeId Bazenville = new(20);
    public static readonly NormandyAirdromeId SainteCroixSurMer = new(21);
    public static readonly NormandyAirdromeId BenySurMer = new(22);
    public static readonly NormandyAirdromeId Rucqueville = new(23);
    public static readonly NormandyAirdromeId Sommervieu = new(24);
    public static readonly NormandyAirdromeId Lantheuil = new(25);
    public static readonly NormandyAirdromeId Evreux = new(26);
    public static readonly NormandyAirdromeId Chailey = new(27);
    public static readonly NormandyAirdromeId NeedsOarPoint = new(28);
    public static readonly NormandyAirdromeId Funtington = new(29);
    public static readonly NormandyAirdromeId Tangmere = new(30);
    public static readonly NormandyAirdromeId Ford = new(31);
    public static readonly NormandyAirdromeId Argentan = new(32);
    public static readonly NormandyAirdromeId Goulet = new(33);
    public static readonly NormandyAirdromeId Barville = new(34);
    public static readonly NormandyAirdromeId Essay = new(35);
    public static readonly NormandyAirdromeId Hauterive = new(36);
    public static readonly NormandyAirdromeId Lymington = new(37);
    public static readonly NormandyAirdromeId Vrigny = new(38);
    public static readonly NormandyAirdromeId Odiham = new(39);
    public static readonly NormandyAirdromeId Conches = new(40);
    public static readonly NormandyAirdromeId WestMalling = new(41);
    public static readonly NormandyAirdromeId Villacoublay = new(42);
    public static readonly NormandyAirdromeId Kenley = new(43);
    public static readonly NormandyAirdromeId BeauvaisTille = new(44);
    public static readonly NormandyAirdromeId CormeillesEnVexin = new(45);
    public static readonly NormandyAirdromeId Creil = new(46);
    public static readonly NormandyAirdromeId Guyancourt = new(47);
    public static readonly NormandyAirdromeId Lonrai = new(48);
    public static readonly NormandyAirdromeId DinanTrelivan = new(49);
    public static readonly NormandyAirdromeId Heathrow = new(50);
    public static readonly NormandyAirdromeId FecampBenouville = new(51);
    public static readonly NormandyAirdromeId Farnborough = new(52);
    public static readonly NormandyAirdromeId Friston = new(53);
    public static readonly NormandyAirdromeId Deanland = new(54);
    public static readonly NormandyAirdromeId Triqueville = new(55);
    public static readonly NormandyAirdromeId Poix = new(56);
    public static readonly NormandyAirdromeId Orly = new(57);
    public static readonly NormandyAirdromeId StoneyCross = new(58);
    public static readonly NormandyAirdromeId AmiensGlisy = new(59);
    public static readonly NormandyAirdromeId Ronai = new(60);
    public static readonly NormandyAirdromeId RouenBoos = new(61);
    public static readonly NormandyAirdromeId Deauville = new(62);
    public static readonly NormandyAirdromeId SaintAubin = new(63);
    public static readonly NormandyAirdromeId Flers = new(64);
    public static readonly NormandyAirdromeId AvranchesLeValSaintPere = new(65);
    public static readonly NormandyAirdromeId Gravesend = new(66);
    public static readonly NormandyAirdromeId BeaumontLeRoger = new(67);
    public static readonly NormandyAirdromeId Broglie = new(68);
    public static readonly NormandyAirdromeId BernaySaintMartin = new(69);
    public static readonly NormandyAirdromeId SaintAndreDeLEure = new(70);
}

public class PersianGulfAirdromeId : AirdromeId
{
    private PersianGulfAirdromeId(int value) : base(value) {}
    
    public static readonly PersianGulfAirdromeId AbuMusaIsland = new(1);
    public static readonly PersianGulfAirdromeId BandarAbbasIntl = new(2);
    public static readonly PersianGulfAirdromeId BandarLengeh = new(3);
    public static readonly PersianGulfAirdromeId AlDhafraAFB = new(4);
    public static readonly PersianGulfAirdromeId DubaiIntl = new(5);
    public static readonly PersianGulfAirdromeId AlMaktoumIntl = new(6);
    public static readonly PersianGulfAirdromeId FujairahIntl = new(7);
    public static readonly PersianGulfAirdromeId TunbIslandAFB = new(8);
    public static readonly PersianGulfAirdromeId Havadarya = new(9);
    public static readonly PersianGulfAirdromeId Khasab = new(10);
    public static readonly PersianGulfAirdromeId Lar = new(11);
    public static readonly PersianGulfAirdromeId AlMinhadAFB = new(12);
    public static readonly PersianGulfAirdromeId QeshmIsland = new(13);
    public static readonly PersianGulfAirdromeId SharjahIntl = new(14);
    public static readonly PersianGulfAirdromeId SirriIsland = new(15);
    public static readonly PersianGulfAirdromeId TunbKochak = new(16);
    public static readonly PersianGulfAirdromeId SirAbuNuayr = new(17);
    public static readonly PersianGulfAirdromeId Kerman = new(18);
    public static readonly PersianGulfAirdromeId ShirazIntl = new(19);
    public static readonly PersianGulfAirdromeId SasAlNakheel = new(20);
    public static readonly PersianGulfAirdromeId BandareJask = new(21);
    public static readonly PersianGulfAirdromeId AbuDhabiIntl = new(22);
    public static readonly PersianGulfAirdromeId AlBateen = new(23);
    public static readonly PersianGulfAirdromeId KishIntl = new(24);
    public static readonly PersianGulfAirdromeId AlAinIntl = new(25);
    public static readonly PersianGulfAirdromeId LavanIsland = new(26);
    public static readonly PersianGulfAirdromeId Jiroft = new(27);
    public static readonly PersianGulfAirdromeId RasAlKhaimahIntl = new(28);
    public static readonly PersianGulfAirdromeId LiwaAFB = new(29);
}

public class TheChannelAirdromeId : AirdromeId
{
    private TheChannelAirdromeId(int value) : base(value) {}
    
    public static readonly TheChannelAirdromeId AbbevilleDrucat = new(1);
    public static readonly TheChannelAirdromeId MervilleCalonne = new(2);
    public static readonly TheChannelAirdromeId SaintOmerLonguenesse = new(3);
    public static readonly TheChannelAirdromeId DunkirkMardyck = new(4);
    public static readonly TheChannelAirdromeId Manston = new(5);
    public static readonly TheChannelAirdromeId Hawkinge = new(6);
    public static readonly TheChannelAirdromeId Lympne = new(7);
    public static readonly TheChannelAirdromeId Detling = new(8);
    public static readonly TheChannelAirdromeId HighHalden = new(12);
}

public class SyriaAirdromeId : AirdromeId
{
    private SyriaAirdromeId(int value) : base(value) {}
    
    public static readonly SyriaAirdromeId AbuAlDuhur = new(1);
    public static readonly SyriaAirdromeId AdanaSakirpasa = new(2);
    public static readonly SyriaAirdromeId AlQusayr = new(3);
    public static readonly SyriaAirdromeId AnNasiriyah = new(4);
    public static readonly SyriaAirdromeId Thalah = new(5);
    public static readonly SyriaAirdromeId BeirutRaficHariri = new(6);
    public static readonly SyriaAirdromeId Damascus = new(7);
    public static readonly SyriaAirdromeId MarjAsSultanSouth = new(8);
    public static readonly SyriaAirdromeId AlDumayr = new(9);
    public static readonly SyriaAirdromeId EynShemer = new(10);
    public static readonly SyriaAirdromeId Gaziantep = new(11);
    public static readonly SyriaAirdromeId H4 = new(12);
    public static readonly SyriaAirdromeId Haifa = new(13);
    public static readonly SyriaAirdromeId Hama = new(14);
    public static readonly SyriaAirdromeId Hatay = new(15);
    public static readonly SyriaAirdromeId Incirlik = new(16);
    public static readonly SyriaAirdromeId Jirah = new(17);
    public static readonly SyriaAirdromeId Khalkhalah = new(18);
    public static readonly SyriaAirdromeId KingHusseinAirCollege = new(19);
    public static readonly SyriaAirdromeId KiryatShmona = new(20);
    public static readonly SyriaAirdromeId BasselAlAssad = new(21);
    public static readonly SyriaAirdromeId MarjAsSultanNorth = new(22);
    public static readonly SyriaAirdromeId MarjRuhayyil = new(23);
    public static readonly SyriaAirdromeId Megiddo = new(24);
    public static readonly SyriaAirdromeId Mezzeh = new(25);
    public static readonly SyriaAirdromeId Minakh = new(26);
    public static readonly SyriaAirdromeId Aleppo = new(27);
    public static readonly SyriaAirdromeId Palmyra = new(28);
    public static readonly SyriaAirdromeId QabrAsSitt = new(29);
    public static readonly SyriaAirdromeId RamatDavid = new(30);
    public static readonly SyriaAirdromeId Kuweires = new(31);
    public static readonly SyriaAirdromeId Rayak = new(32);
    public static readonly SyriaAirdromeId ReneMouawad = new(33);
    public static readonly SyriaAirdromeId RoshPina = new(34);
    public static readonly SyriaAirdromeId Sayqal = new(35);
    public static readonly SyriaAirdromeId Shayrat = new(36);
    public static readonly SyriaAirdromeId Tabqa = new(37);
    public static readonly SyriaAirdromeId Taftanaz = new(38);
    public static readonly SyriaAirdromeId Tiyas = new(39);
    public static readonly SyriaAirdromeId WujahAlHajar = new(40);
    public static readonly SyriaAirdromeId Gazipasa = new(41);
    public static readonly SyriaAirdromeId DeirEzZor = new(42);
    public static readonly SyriaAirdromeId Nicosia = new(43);
    public static readonly SyriaAirdromeId Akrotiri = new(44);
    public static readonly SyriaAirdromeId Kingsfield = new(45);
    public static readonly SyriaAirdromeId Paphos = new(46);
    public static readonly SyriaAirdromeId Larnaca = new(47);
    public static readonly SyriaAirdromeId Lakatamia = new(48);
    public static readonly SyriaAirdromeId Ercan = new(49);
    public static readonly SyriaAirdromeId Gecitkale = new(50);
    public static readonly SyriaAirdromeId Pinarbashi = new(51);
    public static readonly SyriaAirdromeId Naqoura = new(52);
    public static readonly SyriaAirdromeId H3 = new(53);
    public static readonly SyriaAirdromeId H3Northwest = new(54);
    public static readonly SyriaAirdromeId H3Southwest = new(55);
    public static readonly SyriaAirdromeId Ruwayshid = new(57);
    public static readonly SyriaAirdromeId Sanliurfa = new(58);
    public static readonly SyriaAirdromeId KharabIshk = new(59);
    public static readonly SyriaAirdromeId TalSiman = new(60);
    public static readonly SyriaAirdromeId AtTanf = new(63);
    public static readonly SyriaAirdromeId PrinceHassan = new(64);
    public static readonly SyriaAirdromeId KingAbdullahII = new(65);
    public static readonly SyriaAirdromeId Herzliya = new(66);
    public static readonly SyriaAirdromeId Amman = new(67);
    public static readonly SyriaAirdromeId MuwaffaqSalti = new(68);
}

public class MarianasIslandAirdromeId : AirdromeId
{
    private MarianasIslandAirdromeId(int value) : base(value) {}
    
    public static readonly MarianasIslandAirdromeId RotaIntl = new(1);
    public static readonly MarianasIslandAirdromeId SaipanIntl = new(2);
    public static readonly MarianasIslandAirdromeId TinianIntl = new(3);
    public static readonly MarianasIslandAirdromeId AntonioBWonPatIntl = new(4);
    public static readonly MarianasIslandAirdromeId OlfOrote = new(5);
    public static readonly MarianasIslandAirdromeId AndersenAFB = new(6);
    public static readonly MarianasIslandAirdromeId PaganAirstrip = new(7);
    public static readonly MarianasIslandAirdromeId NorthWestField = new(8);
}

public class SouthAtlanticAirdromeId : AirdromeId
{
    private SouthAtlanticAirdromeId(int value) : base(value) {}
    
    public static readonly SouthAtlanticAirdromeId PortStanley = new(1);
    public static readonly SouthAtlanticAirdromeId MountPleasant = new(2);
    public static readonly SouthAtlanticAirdromeId SanCarlosFOB = new(3);
    public static readonly SouthAtlanticAirdromeId RioGallegos = new(5);
    public static readonly SouthAtlanticAirdromeId RioGrande = new(6);
    public static readonly SouthAtlanticAirdromeId Ushuaia = new(7);
    public static readonly SouthAtlanticAirdromeId UshuaiaHeloPort = new(8);
    public static readonly SouthAtlanticAirdromeId PuntaArenas = new(9);
    public static readonly SouthAtlanticAirdromeId PampaGuanaco = new(10);
    public static readonly SouthAtlanticAirdromeId SanJulian = new(11);
    public static readonly SouthAtlanticAirdromeId PuertoWilliams = new(12);
    public static readonly SouthAtlanticAirdromeId PuertoNatales = new(13);
    public static readonly SouthAtlanticAirdromeId ElCalafate = new(14);
    public static readonly SouthAtlanticAirdromeId PuertoSantaCruz = new(15);
    public static readonly SouthAtlanticAirdromeId ComandanteLuisPiedrabuena = new(16);
    public static readonly SouthAtlanticAirdromeId AerodromoDeTolhuin = new(17);
    public static readonly SouthAtlanticAirdromeId PorvenirAirfield = new(18);
    public static readonly SouthAtlanticAirdromeId AlmiranteSchroeders = new(19);
    public static readonly SouthAtlanticAirdromeId RioTurbio = new(20);
    public static readonly SouthAtlanticAirdromeId RioChico = new(21);
    public static readonly SouthAtlanticAirdromeId CaletaTortel = new(22);
    public static readonly SouthAtlanticAirdromeId FrancoBianco = new(23);
    public static readonly SouthAtlanticAirdromeId GooseGreen = new(24);
    public static readonly SouthAtlanticAirdromeId HipicoFlyingClub = new(25);
    public static readonly SouthAtlanticAirdromeId AeropuertoDeGobernadorGregores = new(26);
    public static readonly SouthAtlanticAirdromeId AerodromoOHiggins = new(27);
    public static readonly SouthAtlanticAirdromeId CullenAirport = new(28);
    public static readonly SouthAtlanticAirdromeId GullPoint = new(29);
}

public class SinaiAirdromeId : AirdromeId
{
    private SinaiAirdromeId(int value) : base(value) {}
    
    public static readonly SinaiAirdromeId DifarsuwarAirfield = new(1);
    public static readonly SinaiAirdromeId AbuSuwayr = new(2);
    public static readonly SinaiAirdromeId AsSalihiyah = new(3);
    public static readonly SinaiAirdromeId AlIsmailiyah = new(4);
    public static readonly SinaiAirdromeId Melez = new(5);
    public static readonly SinaiAirdromeId Fayed = new(6);
    public static readonly SinaiAirdromeId Hatzerim = new(7);
    public static readonly SinaiAirdromeId Nevatim = new(8);
    public static readonly SinaiAirdromeId RamonAirbase = new(9);
    public static readonly SinaiAirdromeId Ovda = new(10);
    public static readonly SinaiAirdromeId KibritAirBase = new(11);
    public static readonly SinaiAirdromeId Kedem = new(12);
    public static readonly SinaiAirdromeId WadiAlJandali = new(13);
    public static readonly SinaiAirdromeId AlMansurah = new(14);
    public static readonly SinaiAirdromeId AzZaqaziq = new(15);
    public static readonly SinaiAirdromeId BilbeisAirBase = new(16);
    public static readonly SinaiAirdromeId CairoInternationalAirport = new(17);
    public static readonly SinaiAirdromeId CairoWest = new(18);
    public static readonly SinaiAirdromeId InshasAirbase = new(19);
    public static readonly SinaiAirdromeId Hatzor = new(20);
    public static readonly SinaiAirdromeId Palmachim = new(21);
    public static readonly SinaiAirdromeId SdeDov = new(22);
    public static readonly SinaiAirdromeId TelNof = new(23);
    public static readonly SinaiAirdromeId BenGurion = new(24);
    public static readonly SinaiAirdromeId StCatherine = new(25);
    public static readonly SinaiAirdromeId AbuRudeis = new(26);
    public static readonly SinaiAirdromeId Baluza = new(27);
    public static readonly SinaiAirdromeId BirHasanah = new(28);
    public static readonly SinaiAirdromeId ElArish = new(29);
    public static readonly SinaiAirdromeId ElGora = new(30);
    public static readonly SinaiAirdromeId AlKhatatbah = new(31);
    public static readonly SinaiAirdromeId AlRahmaniyahAirBase = new(32);
    public static readonly SinaiAirdromeId BeniSuef = new(33);
    public static readonly SinaiAirdromeId BirmaAirBase = new(34);
    public static readonly SinaiAirdromeId BorjElArabInternationalAirport = new(35);
    public static readonly SinaiAirdromeId ElMinya = new(36);
    public static readonly SinaiAirdromeId GebelElBasurAirBase = new(37);
    public static readonly SinaiAirdromeId HurghadaInternationalAirport = new(38);
    public static readonly SinaiAirdromeId JianklisAirBase = new(39);
    public static readonly SinaiAirdromeId KomAwshim = new(40);
    public static readonly SinaiAirdromeId RamonInternationalAirport = new(41);
    public static readonly SinaiAirdromeId SharmElSheikhInternationalAirport = new(42);
    public static readonly SinaiAirdromeId WadiAbuRish = new(43);
    public static readonly SinaiAirdromeId AlBahrAlAhmar = new(44);
    public static readonly SinaiAirdromeId Quwaysina = new(45);
}

public class KolaAirdromeId : AirdromeId
{
    private KolaAirdromeId(int value) : base(value) {}
    
    public static readonly KolaAirdromeId Lakselv = new(1);
    public static readonly KolaAirdromeId Rovaniemi = new(2);
    public static readonly KolaAirdromeId KemiTornio = new(3);
    public static readonly KolaAirdromeId Bas100 = new(4);
    public static readonly KolaAirdromeId Kiruna = new(5);
    public static readonly KolaAirdromeId Severomorsk3 = new(6);
    public static readonly KolaAirdromeId Bodo = new(7);
    public static readonly KolaAirdromeId Severomorsk1 = new(8);
    public static readonly KolaAirdromeId Olenegorsk = new(9);
    public static readonly KolaAirdromeId Monchegorsk = new(10);
    public static readonly KolaAirdromeId Jokkmokk = new(11);
    public static readonly KolaAirdromeId MurmanskInternational = new(12);
    public static readonly KolaAirdromeId Kalixfors = new(13);
}

public class GermanyCWAirdromeId : AirdromeId
{
    private GermanyCWAirdromeId(int value) : base(value) {}
    
    public static readonly GermanyCWAirdromeId Wittstock = new(1);
    public static readonly GermanyCWAirdromeId AltesLager = new(2);
    public static readonly GermanyCWAirdromeId Barth = new(3);
    public static readonly GermanyCWAirdromeId Zerbst = new(4);
    public static readonly GermanyCWAirdromeId Bremen = new(5);
    public static readonly GermanyCWAirdromeId Briest = new(6);
    public static readonly GermanyCWAirdromeId Buckeburg = new(7);
    public static readonly GermanyCWAirdromeId Celle = new(8);
    public static readonly GermanyCWAirdromeId Cochstedt = new(9);
    public static readonly GermanyCWAirdromeId Damgarten = new(10);
    public static readonly GermanyCWAirdromeId Fassberg = new(11);
    public static readonly GermanyCWAirdromeId Finow = new(12);
    public static readonly GermanyCWAirdromeId Garz = new(13);
    public static readonly GermanyCWAirdromeId Gatow = new(14);
    public static readonly GermanyCWAirdromeId Templin = new(15);
    public static readonly GermanyCWAirdromeId Gutersloh = new(16);
    public static readonly GermanyCWAirdromeId Hamburg = new(17);
    public static readonly GermanyCWAirdromeId HamburgFinkenwerder = new(18);
    public static readonly GermanyCWAirdromeId Hannover = new(19);
    public static readonly GermanyCWAirdromeId Laage = new(20);
    public static readonly GermanyCWAirdromeId Larz = new(21);
    public static readonly GermanyCWAirdromeId Mahlwinkel = new(22);
    public static readonly GermanyCWAirdromeId Neubrandenburg = new(23);
    public static readonly GermanyCWAirdromeId Neuruppin = new(24);
    public static readonly GermanyCWAirdromeId Peenemunde = new(25);
    public static readonly GermanyCWAirdromeId Schonefeld = new(26);
    public static readonly GermanyCWAirdromeId Stendal = new(27);
    public static readonly GermanyCWAirdromeId Tegel = new(28);
    public static readonly GermanyCWAirdromeId Tempelhof = new(29);
    public static readonly GermanyCWAirdromeId Tutow = new(30);
    public static readonly GermanyCWAirdromeId Werneuchen = new(31);
    public static readonly GermanyCWAirdromeId Wunstorf = new(32);
    public static readonly GermanyCWAirdromeId HFRG01 = new(53);
    public static readonly GermanyCWAirdromeId HFRG02 = new(54);
    public static readonly GermanyCWAirdromeId HFRG03 = new(55);
    public static readonly GermanyCWAirdromeId HFRG04 = new(56);
    public static readonly GermanyCWAirdromeId HFRG05 = new(57);
    public static readonly GermanyCWAirdromeId HFRG06 = new(58);
    public static readonly GermanyCWAirdromeId HFRG07 = new(59);
    public static readonly GermanyCWAirdromeId HFRG08 = new(60);
    public static readonly GermanyCWAirdromeId HFRG09 = new(61);
    public static readonly GermanyCWAirdromeId HFRG10 = new(62);
    public static readonly GermanyCWAirdromeId HFRG12 = new(64);
    public static readonly GermanyCWAirdromeId HFRG13 = new(65);
    public static readonly GermanyCWAirdromeId HFRG14 = new(66);
    public static readonly GermanyCWAirdromeId HGDR01 = new(67);
    public static readonly GermanyCWAirdromeId HGDR02 = new(68);
    public static readonly GermanyCWAirdromeId HGDR03 = new(69);
    public static readonly GermanyCWAirdromeId HGDR04 = new(70);
    public static readonly GermanyCWAirdromeId HGDR05 = new(71);
    public static readonly GermanyCWAirdromeId HGDR06 = new(72);
    public static readonly GermanyCWAirdromeId HGDR07 = new(73);
    public static readonly GermanyCWAirdromeId HGDR08 = new(74);
    public static readonly GermanyCWAirdromeId HGDR09 = new(75);
    public static readonly GermanyCWAirdromeId HGDR10 = new(76);
    public static readonly GermanyCWAirdromeId HGDR11 = new(77);
    public static readonly GermanyCWAirdromeId HFRG15 = new(78);
    public static readonly GermanyCWAirdromeId GrossMohrdorf = new(80);
    public static readonly GermanyCWAirdromeId Lubeck = new(81);
    public static readonly GermanyCWAirdromeId Kothen = new(82);
    public static readonly GermanyCWAirdromeId Dessau = new(83);
    public static readonly GermanyCWAirdromeId Parchim = new(84);
    public static readonly GermanyCWAirdromeId HGDR12 = new(85);
    public static readonly GermanyCWAirdromeId Uetersen = new(86);
    public static readonly GermanyCWAirdromeId Luneburg = new(89);
    public static readonly GermanyCWAirdromeId Northeim = new(90);
    public static readonly GermanyCWAirdromeId HGDR13 = new(91);
    public static readonly GermanyCWAirdromeId HGDR14 = new(92);
    public static readonly GermanyCWAirdromeId HGDR15 = new(93);
    public static readonly GermanyCWAirdromeId HGDR16 = new(94);
    public static readonly GermanyCWAirdromeId HGDR17 = new(95);
    public static readonly GermanyCWAirdromeId HFRG16 = new(96);
    public static readonly GermanyCWAirdromeId HFRG17 = new(97);
    public static readonly GermanyCWAirdromeId HFRG18 = new(98);
    public static readonly GermanyCWAirdromeId HFRG19 = new(99);
    public static readonly GermanyCWAirdromeId HFRG11 = new(100);
    public static readonly GermanyCWAirdromeId Sperenberg = new(101);
    public static readonly GermanyCWAirdromeId Uelzen = new(102);
    public static readonly GermanyCWAirdromeId Dedelow = new(103);
    public static readonly GermanyCWAirdromeId Kammermark = new(104);
    public static readonly GermanyCWAirdromeId WeserWumme = new(106);
    public static readonly GermanyCWAirdromeId Braunschweig = new(107);
    public static readonly GermanyCWAirdromeId Wismar = new(108);
    public static readonly GermanyCWAirdromeId WarenVielist = new(109);
    public static readonly GermanyCWAirdromeId Bienenfarm = new(110);
    public static readonly GermanyCWAirdromeId Pinnow = new(111);
    public static readonly GermanyCWAirdromeId Gardelegen = new(112);
    public static readonly GermanyCWAirdromeId Glindbruchkippe = new(113);
    public static readonly GermanyCWAirdromeId Ummern = new(114);
    public static readonly GermanyCWAirdromeId Hildesheim = new(115);
    public static readonly GermanyCWAirdromeId VerdenScharnhorst = new(116);
    public static readonly GermanyCWAirdromeId Rinteln = new(117);
    public static readonly GermanyCWAirdromeId Holzdorf = new(118);
    public static readonly GermanyCWAirdromeId HMedGDR01 = new(119);
    public static readonly GermanyCWAirdromeId HMedGDR02 = new(120);
    public static readonly GermanyCWAirdromeId HMedGDR03 = new(121);
    public static readonly GermanyCWAirdromeId HGDR33 = new(122);
    public static readonly GermanyCWAirdromeId AirracingKoblenz = new(123);
    public static readonly GermanyCWAirdromeId HGDR34 = new(124);
    public static readonly GermanyCWAirdromeId HMedGDR08 = new(126);
    public static readonly GermanyCWAirdromeId HMedGDR09 = new(127);
    public static readonly GermanyCWAirdromeId HMedGDR10 = new(128);
    public static readonly GermanyCWAirdromeId HMedFRG01 = new(129);
    public static readonly GermanyCWAirdromeId HMedFRG02 = new(130);
    public static readonly GermanyCWAirdromeId HMedFRG04 = new(132);
    public static readonly GermanyCWAirdromeId HMedFRG06 = new(134);
    public static readonly GermanyCWAirdromeId HMedFRG11 = new(139);
    public static readonly GermanyCWAirdromeId Hasselfelde = new(140);
    public static readonly GermanyCWAirdromeId GrosseWiese = new(141);
    public static readonly GermanyCWAirdromeId HGDR18 = new(142);
    public static readonly GermanyCWAirdromeId HFRG20 = new(143);
    public static readonly GermanyCWAirdromeId HMedFRG12 = new(144);
    public static readonly GermanyCWAirdromeId HGDR19 = new(145);
    public static readonly GermanyCWAirdromeId HGDR30 = new(146);
    public static readonly GermanyCWAirdromeId HMedGDR11 = new(147);
    public static readonly GermanyCWAirdromeId HFRG21 = new(148);
    public static readonly GermanyCWAirdromeId HFRG50 = new(149);
    public static readonly GermanyCWAirdromeId HFRG23 = new(150);
    public static readonly GermanyCWAirdromeId HFRG39 = new(151);
    public static readonly GermanyCWAirdromeId HGDR21 = new(152);
    public static readonly GermanyCWAirdromeId HGDR22 = new(153);
    public static readonly GermanyCWAirdromeId Fritzlar = new(154);
    public static readonly GermanyCWAirdromeId Hahn = new(155);
    public static readonly GermanyCWAirdromeId Sembach = new(156);
    public static readonly GermanyCWAirdromeId Allstedt = new(157);
    public static readonly GermanyCWAirdromeId Zweibrucken = new(158);
    public static readonly GermanyCWAirdromeId Giebelstadt = new(159);
    public static readonly GermanyCWAirdromeId Schweinfurt = new(160);
    public static readonly GermanyCWAirdromeId Haina = new(161);
    public static readonly GermanyCWAirdromeId Spangdahlem = new(162);
    public static readonly GermanyCWAirdromeId Frankfurt = new(163);
    public static readonly GermanyCWAirdromeId Bindersleben = new(164);
    public static readonly GermanyCWAirdromeId Ramstein = new(165);
    public static readonly GermanyCWAirdromeId Fulda = new(166);
    public static readonly GermanyCWAirdromeId ObermehlerSchlotheim = new(167);
    public static readonly GermanyCWAirdromeId Mendig = new(168);
    public static readonly GermanyCWAirdromeId Merseburg = new(169);
    public static readonly GermanyCWAirdromeId Wiesbaden = new(170);
    public static readonly GermanyCWAirdromeId LeipzigHalle = new(171);
    public static readonly GermanyCWAirdromeId HMedGDR12 = new(180);
    public static readonly GermanyCWAirdromeId HMedGDR13 = new(181);
    public static readonly GermanyCWAirdromeId HMedGDR14 = new(182);
    public static readonly GermanyCWAirdromeId HMedGDR16 = new(184);
    public static readonly GermanyCWAirdromeId HGDR24 = new(185);
    public static readonly GermanyCWAirdromeId HMedFRG13 = new(186);
    public static readonly GermanyCWAirdromeId HMedFRG14 = new(187);
    public static readonly GermanyCWAirdromeId HMedFRG15 = new(188);
    public static readonly GermanyCWAirdromeId HMedFRG16 = new(189);
    public static readonly GermanyCWAirdromeId HMedFRG17 = new(190);
    public static readonly GermanyCWAirdromeId HFRG25 = new(191);
    public static readonly GermanyCWAirdromeId HRadarGDR01 = new(193);
    public static readonly GermanyCWAirdromeId HRadarGDR02 = new(194);
    public static readonly GermanyCWAirdromeId HRadarGDR03 = new(195);
    public static readonly GermanyCWAirdromeId HRadarGDR04 = new(196);
    public static readonly GermanyCWAirdromeId HRadarGDR05 = new(197);
    public static readonly GermanyCWAirdromeId HRadarGDR06 = new(198);
    public static readonly GermanyCWAirdromeId HRadarGDR07 = new(199);
    public static readonly GermanyCWAirdromeId Bitburg = new(200);
    public static readonly GermanyCWAirdromeId AirracingLubeck = new(201);
    public static readonly GermanyCWAirdromeId HFRG27 = new(202);
    public static readonly GermanyCWAirdromeId AirracingFrankfurt = new(204);
    public static readonly GermanyCWAirdromeId HMedFRG21 = new(208);
    public static readonly GermanyCWAirdromeId HFRG30 = new(211);
    public static readonly GermanyCWAirdromeId HFRG31 = new(212);
    public static readonly GermanyCWAirdromeId HFRG32 = new(213);
    public static readonly GermanyCWAirdromeId HFRG34 = new(215);
    public static readonly GermanyCWAirdromeId HFRG51 = new(218);
    public static readonly GermanyCWAirdromeId HFRG38 = new(219);
    public static readonly GermanyCWAirdromeId HFRG48 = new(220);
    public static readonly GermanyCWAirdromeId HFRG49 = new(221);
    public static readonly GermanyCWAirdromeId HMedFRG24 = new(222);
    public static readonly GermanyCWAirdromeId HRadarFRG02 = new(223);
    public static readonly GermanyCWAirdromeId HMedFRG26 = new(225);
    public static readonly GermanyCWAirdromeId HGDR25 = new(226);
    public static readonly GermanyCWAirdromeId HGDR26 = new(227);
    public static readonly GermanyCWAirdromeId HGDR31 = new(229);
    public static readonly GermanyCWAirdromeId HGDR32 = new(230);
    public static readonly GermanyCWAirdromeId HMedFRG27 = new(231);
    public static readonly GermanyCWAirdromeId Pferdsfeld = new(232);
    public static readonly GermanyCWAirdromeId HMedFRG29 = new(233);
    public static readonly GermanyCWAirdromeId HFRG40 = new(234);
    public static readonly GermanyCWAirdromeId Buchel = new(235);
    public static readonly GermanyCWAirdromeId LeipzigMockau = new(236);
    public static readonly GermanyCWAirdromeId HFRG43 = new(237);
    public static readonly GermanyCWAirdromeId HFRG44 = new(238);
    public static readonly GermanyCWAirdromeId HFRG45 = new(239);
    public static readonly GermanyCWAirdromeId HFRG46 = new(240);
    public static readonly GermanyCWAirdromeId HFRG47 = new(241);
    public static readonly GermanyCWAirdromeId BadDurkheim = new(242);
    public static readonly GermanyCWAirdromeId Gelnhausen = new(243);
    public static readonly GermanyCWAirdromeId Herrenteich = new(244);
    public static readonly GermanyCWAirdromeId Hockenheim = new(245);
    public static readonly GermanyCWAirdromeId Langenselbold = new(246);
    public static readonly GermanyCWAirdromeId Walldorf = new(247);
    public static readonly GermanyCWAirdromeId OberMorlen = new(248);
    public static readonly GermanyCWAirdromeId Pottschutthohe = new(249);
    public static readonly GermanyCWAirdromeId Worms = new(250);
    public static readonly GermanyCWAirdromeId HRadarGDR09 = new(251);
    public static readonly GermanyCWAirdromeId HRadarGDR08 = new(252);
    public static readonly GermanyCWAirdromeId HFRG41 = new(253);
    public static readonly GermanyCWAirdromeId HFRG42 = new(254);
}