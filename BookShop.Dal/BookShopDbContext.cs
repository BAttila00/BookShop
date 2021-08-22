using BookShop.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

//Ati: itt definiáljuk h milyen tábálák legyenek
//Valamint h azokban milyen adatok legyenek.
//Ezt lehet átültetni Add-Migration "migration name" parancsal egy migrációba, ami a migrations mappában fog megjelenni
//pl amikor at Add-Migration Initial parancsot adtuk ki akkor még csak a könyveket létrehozó rész volt itt (public DbSet<Book> Books { get; set; }) így az 20210819202649_Initial.cs fájlban még 
//csak egy Books táblát létrehozó metódus van.

//Viszont  miután betettük ide az "Ati: itt generálunk könyveket" komment alatti részt és kiadtuk az "Add-Migration InitialSeed" parancsot akkor létrejön a ............. fájl és ebben lesz azon rész
//ahol a Books táblát feltöltjük adatokkal.
namespace BookShop.Dal {
    public class BookShopDbContext : DbContext {
        public BookShopDbContext() {

        }

        // ezen options-el az adatbázis-kapcsolat konfigurációs beállításait (timeout, connection string) állíthatjuk be.
        public BookShopDbContext(DbContextOptions options) : base(options) {

        }

        /// <summary>
        /// A könyveket tároló adatbázis tábla
        /// </summary>
        public DbSet<Book> Books { get; set; }

        //Ati: itt generálunk könyveket
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Book>().HasData(
                new Book {
                    Id = 1,
                    Title = @"Személyes feng shui tanácsadó",
                    Author = @"Lam Kam Chuen Mester",
                    Headline = @"Hogyan éljünk egészségesen és harmonikusan",
                    NumberOfPages = 168,
                    Price = 3200,
                    PublishYear = 2004,
                    ShortDescription = @"A Személyes feng shui tanácsadó elmagyarázza a feng shui alapelveit, ugyanakkor új dimenziókat tár fel az érdeklődők számára. Megmutatja, miként befolyásolják egyéni jellemvonásaink a környezetünkhöz való viszonyunkat. A kínai zodiákust tanulmányozva nagyobb önismeretre tehetünk szert, jobban megérthetjük belső erősségeinket. Tudásunkat a ""nyolc körre"" és a nyolc báguára alkalmazva harmóniában élhetünk környezetünkkel, elősegíthetjük személyes fejlődésünket.\n
A könnyen érthető, ábrákkal és fotókkal gazdagon illusztrált könyv segítségével megismerhetjük és elsajátíthatjuk a feng shuit, egészen az alapoktól; ellenőrizhetjük, hogy otthonunk energiamezői harmóniában állnak-e saját energiamintáinkkal; fokozhatjuk hatékonyságunkat munkánk során; bátran használhatjuk a kínai zodiákust baráti, családi és munkakapcsolataink jobb megértéséhez.",
                },

                new Book {
                    Id = 2,
                    Title = @"Az én feng shui-kertem",
                    Author = @"Susanne Schumacher",
                    Headline = @"Ötletek kertekhez, teraszokhoz, erkélyekhez",
                    NumberOfPages = 128,
                    Price = 4900,
                    PublishYear = 2008,
                    ShortDescription = @"Képzelje azt, hogy kertje egy ruhadarab. A kertnek a ruhadarabhoz hasonlóan ""jól kell állnia"" tulajdonosának. Nézzen egy kicsit más szemmel kertjére, erkélyére vagy teraszára. Minden a helyén van? Tükrözi-e a kert a személyiségét?\n
A kötet segít elmélyedni a feng shui nyújtotta lehetőségekben. Ne gondoljon azonnal teljes átalakításra, éppen az óvatos, kisebb javítások a feng shui erősségei. Varázsolja kertjét oázissá, engedje szabadon szárnyalni képzeletét, váljon eggyé a természettel. Tanuljon mások tapasztalatából, olyan emberekéből, akik már rátaláltak a feng shuira, a harmónia és életöröm forrására.",
                },

                new Book {
                    Id = 3,
                    Title = @"Feng Shui",
                    Author = @"Ernest J. Eitel",
                    Headline = @"A természet és az egyensúly kínai tudományával kapcsolatos alapvető tudnivalók",
                    NumberOfPages = 80,
                    Price = 699,
                    PublishYear = 2012,
                    ShortDescription = @"Az ember, az ember által létrehozott környezet, valamint a természet összhangjának több évezredes kínai tudománya már a 19. század közepe óta ismert a nyugati világban. Odaadó hívei a szabályrendszer szigorú betartásával alakítják életüket, lakókörnyezetüket, de még bírálói is kénytelenek elismerni, a megállapítások mélyén bonyolult összefüggések rejlenek.\n
\n
A feng shui nem csupán a lakberendezés ügyes tudománya: jelen van benne az animizmus, a taoizmus, a konfucianizmus és a buddhizmus jónéhány eszméje. Rávilágít a látszólag egymástól távol álló dolgok közötti összefüggésekre, fellebbenti a fátylat a misztikus összefüggésekről, rendszerbe foglalva állítja elénk a hajdanvolt bölcsek megfigyeléseit, a geomanciával, numerológiával és asztrológiával foglalkozó tudósok megállapításait.",
                },

                new Book {
                    Id = 4,
                    Title = @"Fengsuj a gyakorlatban",
                    Author = @"Simon Brown",
                    Headline = @"",
                    NumberOfPages = 160,
                    Price = 3990,
                    PublishYear = 2009,
                    ShortDescription = @"Fengsuj a gyakorlatban\n
- Olyan ősi filozófiát mutat be, melynek követésével irányíthatjuk a pozitív és a negatív energiákat, és ezzel megváltoztathatjuk életünket és sorsunkat.\n
- Praktikus tanácsokkal lát el otthonunk helyiségeinek elhelyezését és berendezését illetően, melyek segíthetnek céljaink megvalósításában, vágyaink kiteljesítésében.\n
- Bemutatja, hogyan tehetjük kellemesebbé otthonunkat és hogyan javíthatunk általános közérzetünkön a megfelelő színek, anyagok és más díszítőelemek kiválasztásával.\n
- A lakás ideális berendezésére vonatkozó javaslatokkal hozzásegít a jó kapcsolatok, a jól menő üzlet kiépítéséhez, a kielégítő szexuális élethez, a jó egészséghez.",
                },

                new Book {
                    Id = 5,
                    Title = @"François Villon versei",
                    Author = @"François Villon",
                    Headline = @"",
                    NumberOfPages = 176,
                    Price = 1650,
                    PublishYear = 1999,
                    ShortDescription = @"François Villon válogatott versei.",
                },

                new Book {
                    Id = 6,
                    Title = @"A nyugati környezetben is használható Feng-Shui",
                    Author = @"Sándor László, Pocsai Katalin",
                    Headline = @"Első kötet - Alapfogalmak I.",
                    NumberOfPages = 152,
                    Price = 2100,
                    PublishYear = 2006,
                    ShortDescription = @"Az elmúlt évezredek során Kelet nagy bölcsei számos tanítással és igazsággal gazdagították az emberiséget. Azt tartották, hogy fejlődésünk célja a tökéletes emberi állapot, a megvilágosodás elérése. A jó energiatérrel, élő és éltető energiákkal rendelkező építmények, helyiségek nagymértékben elősegítik ezt a folyamatot.\n
A feng-shui, ami alapjában véve annyit jelent, hogy az ember összhangban él az őt körülvevő világgal, ennek megvalósításához nyújt aktív és tudatos segítséget.\n
A könyv két szerzője feng-shui mester, szakértő. Munkájukkal egy, az ősi tudásra épülő, de a nyugati életvitel számára is elfogadható új sorozat első kötetét alkották meg. Céljuk, hogy mindazok kezébe és otthonába elkerülhessenek ezek a tanítások, akik szeretnek tanulni, és szívesen tökéletesítik önmagukat, környezetüket valamint kíváncsiak a ""miértekre"".",
                },

                new Book {
                    Id = 7,
                    Title = @"A Feng shui és a siker titka térben és időben",
                    Author = @"Raymond Lo",
                    Headline = @"A Repülő csillagok és a kínai sorselemzés művészete",
                    NumberOfPages = 228,
                    Price = 2780,
                    PublishYear = 2005,
                    ShortDescription = @"Könyvem első részében a Négyoszlopos Sorsmeghatározás különleges módszerét mutatom be, ami újdonság a Kínán kívül élők számára. A Négyoszlopos Sorsmeghatározás klasszikus sorselemzési eljárás, pontos, időpontok szerint behatárolható képet ad az ember képességeiről, lehetőségeiről, élete szerencsés és balszerencsés időszakairól. A technikát néhány híresség és befolyásos politikus sorsának elemzéseivel illusztrálom. Közlöm előzetes jóslataimat az amerikai-iraki összecsapások kimeneteléről az 1990-91-es Öbölháborúban, megtudhatják mekkora szerepe volt az események végeredményére id. Bush elnök és Saddam Hussein sorsának és szerencséjének. Kiderül, milyen végzetes okok vezettek Marilyn Monroe halálához. S amint Karen Carpenter és John Lennon fiatalon elhunyt művészek tragikus sorsának okai, úgy Margaret Thatcher és Mihail Gorbacsov politikai karrierjének alakulása is kikövetkeztethető Sorsuk Négyoszlopából, valamint Szerencseoszlopaikból.\n
A könyv második részében a Feng Shui rejtett szépségeivel foglalkozom, s igyekszem bemutatni a tan kevéssé ismert összefüggéseit és módszereit. Hongkong híres épületeinek Feng Shui elemzésén túl, számos érdekes példán mutatom be, mi mindenre jó a Feng Shui. Szeretném, ha Olvasóim e különleges technika ismeretében boldogabban élhetnének. (Raymond Lo)",
                },

                new Book {
                    Id = 8,
                    Title = @"Feng Shui és kert",
                    Author = @"Jes T. Y. Lim",
                    Headline = @"A taoizmus és a zen a kertművelésben",
                    NumberOfPages = 140,
                    Price = 3580,
                    PublishYear = 2004,
                    ShortDescription = @"""A távol-keleti kertépítés mind a hobbi-, mind a profi kertész számára olyan elmélyült, mégis egyszerű alapelvekkel szolgál, amelyek segítségével szívvel-lélekkel belevethetjük magunkat az érzékeket gyönyörködtető és üdítő légkörű kert megteremtésébe.\n
Szinte az egész világot beutaztam fengshui- és energetikai szakértőként, és szomorúan kellett tapasztalnom, hogy elveszett az a fő cél, amiért az épületeket, illetve a kerteket építjük - tudniillik, hogy olyan energiával és élettel teli helyet hozzunk létre, ahol feltöltődünk és visszanyerjük életkedvünket. (...) 
A könyvemben bemutatott ázsiai kertkialakítási és fengshui-alapelveket bármelyik kertben alkalmazhatjuk típustól és nagyságtól függetlenül, legyen az egy virágos láda az ablakunkban vagy egy park. Különös hangsúlyt helyeztem a kövek kiválasztására és elhelyezésére, ahogy azt a taoisták és a zen követői alkalmazták. A ""Beszélgessünk a növényekkel"" című fejezetben leírtak elolvasása után pedig úgy tekintünk majd a növényekre, ahogy eddig még soha.""",
                },

                new Book {
                    Id = 9,
                    Title = @"Többváltozós függvények analízise - Bolyai-könyvek",
                    Author = @"Fekete Zoltán, Zalay Miklós",
                    Headline = @"Példatár",
                    NumberOfPages = 360,
                    Price = 2050,
                    PublishYear = 2006,
                    ShortDescription = @"",
                },

                new Book {
                    Id = 10,
                    Title = @"Feng Shui az irodában és az üzleti életben",
                    Author = @"Jes T. Y. Lim",
                    Headline = @"",
                    NumberOfPages = 204,
                    Price = 2588,
                    PublishYear = 2002,
                    ShortDescription = @"""E könyvben az üzleti Feng Shui gyakorlati művelésének különböző szempontjait és irányelveit igyekszem érthetően felvázolni, hogy a kedves Olvasó az eddig talán kevésbé ismert szempontokról is áttekintést szerezhessen. Ezáltal elkerülheti a hibákat és adott esetben orvosolhatja a bajt, amelyek miatt szembekerülhetett munkatársaival. Még abban az esetben is, ha elbizonytalanodna, mert üzlete nem megy olyan jól, mint ahogy mehetne, az üzleti Feng Shui kínálta kiváló ötletek kimozdítják az energiát pangó helyzetéből, és a kívánt folyásirányba terelik.""",
                },

                new Book {
                    Id = 11,
                    Title = @"A feng shui nagykönyve",
                    Author = @"Gill Hale, Mark Evans",
                    Headline = @"1800 képpel illusztrált gyakorlati útmutató",
                    NumberOfPages = 512,
                    Price = 7990,
                    PublishYear = 2009,
                    ShortDescription = @"- Az egészség és a jó közérzet ismereteinek tárháza.\n
- Irányítsd ősi technikákkal és évszázadok bölcsességével tested, lelked és otthonod különleges erőit és tulajdonságait.\n
- Részletes útmutatások a feng shui ősi kínai művészetéhez, gyakorlati tanácsok az elvek alkalmazásához a nyugalmas terek és lelkileg tápláló környezet megteremtése érdekében.\n
- Tisztítsd meg a teret, ahol élsz vagy dolgozol. A tömjén és más füstölők, a víz és a hang erejének egyszerű eszközeivel megmozgathatod a stagnáló energiákat, és otthonodban tavaszi nagytakarítást végezhetsz.\n
- Mindaz, amit tudnod kell ahhoz, hogy otthonodat nyugalommal és kiegyensúlyozott energiával telt, pozitív térré változtasd.",
                },

                new Book {
                    Id = 12,
                    Title = @"Feng Shui nőknek - Feng Shui férfiaknak",
                    Author = @"Szilvásy Judit",
                    Headline = @"",
                    NumberOfPages = 152,
                    Price = 1990,
                    PublishYear = 2008,
                    ShortDescription = @"""Ebben a könyvben különleges tematikával mutatom be a Feng Shui egy kis szeletét. Mint látható, a könyv két részből áll. Az egyik fele a nőknek, a másik a férfiaknak szól. Természetesen a nőknek is hasznos - sőt ajánlott - a férfiaknak írt oldalakat elolvasni, hiszen nem ugyanazt a témát magyarázom el kétféleképpen. A témaválasztás is más és más. Nagyon szeretném, ha mind a nők, mind a férfiak - akik eddig kétkedve fogadták a Feng Shuit - kicsit jobban belelátnának e filozófia működésébe."" (a Szerző)",
                },

                new Book {
                    Id = 13,
                    Title = @"Transzlégzés",
                    Author = @"Stanislav Grof, Christina Grof",
                    Headline = @"Holotróp légzéstechnika - az öngyógyítás új útja",
                    NumberOfPages = 256,
                    Price = 2890,
                    PublishYear = 2010,
                    ShortDescription = @"A könyv a holotróp légzéstechnika elméletét és gyakorlatát összegzi. A pszichoterápia és az önmegismerés ezen új módszere magába foglalja a mélylélektan különféle irányzatainak elemeit, emellett merít a modern tudatkutatásból, a kulturális antropológiából és a keleti spirituális gyakorlatokból is.\n
A technikát kidolgozó szerzők esetleírásokkal is alátámasztják a holotróp légzés sokrétű terápiás, valamint az önmegismerést, belső fejlődést elősegítő hatását.",
                },

                new Book {
                    Id = 14,
                    Title = @"Megmagyarázhatatlan jelenségek enciklopédiája",
                    Author = @"Judy Allen",
                    Headline = @"Különös jelenségek, furcsa babonák és ősi rejtélyek",
                    NumberOfPages = 144,
                    Price = 4990,
                    PublishYear = 2007,
                    ShortDescription = @"A rejtélyekkel teli könyv különleges információk tárházát kínálja a paranormális jelenségekről. Lenyűgöző illusztrációk, fényképek és lebilincselő történetek ragadják magukkal az olvasót, hogy gyermek és felnőtt egyaránt ámulva merülhessen el a világegyetem megmagyarázhatatlan titkaiban.\n
Az egyes fejezetek részletesen bemutatják az adott téma leghíresebb jelenségeit, a különleges esetek tényszerű jellemzőit, például az elme fémhajlító erejét, a levitációt, a kísérteties jelenéseket, a rejtélyes eltűnéseket és az ufókat.",
                },

                new Book {
                    Id = 15,
                    Title = @"Buddhizmus és asztrológia",
                    Author = @"Jhampa Shaneman, Jan V. Angel",
                    Headline = @"Horoszkópelemzés buddhista megközelítésben",
                    NumberOfPages = 360,
                    Price = 2799,
                    PublishYear = 2010,
                    ShortDescription = @"Használjuk fel a buddhizmus bölcsességét, az általa hirdetett együttérzést és odaadást asztrológiai ismereteink kiteljesítésére! Jhampa Shaneman a tibeti buddhizmus, Jan V. Angel pedig a nyugati asztrológia szakértője - az ő ismereteik találkoznak ebben a könyvben: az első olyan műben, amely a buddhista gyakorlatot a nyugati asztrológián keresztül közelíti meg.\n
Bár a buddhizmus teológiai és metafizikai szempontból komoly kihívás, egyben roppant gyakorlatias is. A buddhista tanokban megtalálhatjuk a legkülönfélébb tudatállapotok leírását és integráns magyarázatát. A Buddhizmus és asztrológia a buddhista tanítások bölcsességét beépíti a hagyományos asztrológiai felfogásba.\n
A könyvből megtudhatjuk, miként mutatkozik meg a három - a buddhisták által bölcsességnek nevezett - tulajdonság dinamikus összjátéka Sziddhárta herceg horoszkópjában, s hogyan alkalmazható ez az új megközelítés más horoszkópok elemzésében. A buddhista meglátások új fénybe helyezik az asztrológia bolygókkal, házakkal és fényszögekkel kapcsolatos hagyományos tudását, így sokkal holisztikusabb összkép megalkotását téve lehetővé.",
                },

                new Book {
                    Id = 16,
                    Title = @"Asztrológiaiskola II.",
                    Author = @"Horváth Andrea",
                    Headline = @"Tarot és kínai jóstanfolyamok",
                    NumberOfPages = 88,
                    Price = 1750,
                    PublishYear = 2003,
                    ShortDescription = @"""Nagyszerű és szokatlan kalandra hívjuk mindazokat, akiket érdekel az asztrológia, a jóslás, s mindaz, amit ma határtudományoknak neveznek. Ennek az új kiadványsorozatnak a segítségével ugyanis bárki a saját jósává, jósnőjévé válhat. Először megtanul horoszkópot készíteni, bepillantást nyer, más érdekes, a jövőt fürkésző módszerekbe is, mint például a tarot kártyák varázslatos világába, a kínai asztrológiába vagy az ősi kínai Ji King jóslásba.""",
                },

                new Book {
                    Id = 17,
                    Title = @"Mély forrás",
                    Author = @"Claus Reimann",
                    Headline = @"A pszichológiai asztrológia tizenkét archetípusa",
                    NumberOfPages = 276,
                    Price = 2800,
                    PublishYear = 2004,
                    ShortDescription = @"Mi köti össze az asztrológiát a mesék világával? Hogyan tudjuk hasznosítani ezt a kapcsolatot egyéni fejlődésünkben, saját életutunkon?\n
Claus Riemann több mint harminc éve foglalkozik az állatövvel és a bolygókkal, melyeket belső világunk ősképeinek tekint. C. G. Jung nyomán interpretálja a tizenkét állatövi jegyet, azok vonzalmait és ellenszenveit, erősségeit és gyengeségeit. Minden állatövi jegyet mítoszokkal, fabulákkal, mesékkel és legendákkal jellemez, melyek pontosan kifejezik a jegy archetipikus szerkezetét. Így például a Bátor szabólegény meséjében felfedezhetjük az Ikrek furfangosságát és ravaszságát, vagy a piros cipőkről szóló mesében a Kos jellegzetességeit. A tizenkét állatövi jegy és a hozzájuk tartozó élettémák leírása az Olvasót hasznos felismerésekhez vezeti, lehetőséget teremtve arra, hogy jobban megértse önmagát, és új fejlődési lehetőségeket fedezzen fel.",
                },

                new Book {
                    Id = 18,
                    Title = @"Földközeli kalandok",
                    Author = @"Tomasz Lem",
                    Headline = @"",
                    NumberOfPages = 256,
                    Price = 2500,
                    PublishYear = 2010,
                    ShortDescription = @"Stanislaw Lemet hőseiből ismerhettük meg, és bár a hősök sokat elárultak róla, személye és mindennapi körülményei ez ideig ismeretlenek voltak magyar olvasótábora előtt. Fia, Tomasz ugyan fizikusként végzett, ám akárcsak apja, vizsgáit letéve az írói-fordítói hivatást választotta.\n
Hogy milyen ember volt ő a mindennapi helyzetekben, milyen hátteret adott a korszak, melyben élt, rendkívül érdekes olvasnivaló az író rajongói számára, és akik elolvassák, megbizonyosodhatnak róla, hogy az alma nem esett messze a fájától...",
                },

                new Book {
                    Id = 19,
                    Title = @"Kínai örökhoroszkóp",
                    Author = @"Tai San",
                    Headline = @"Tervezze meg jövőjét!",
                    NumberOfPages = 296,
                    Price = 499,
                    PublishYear = 2009,
                    ShortDescription = @"Az okok és okozatok összefüggései a távol-keleti filozófiák és vallási tanítások alapvető tételeit alkotják. A jövőnk jelenségei és eseményei minden esetben a jelenünkben gyökereznek, a jelenünkre pedig komoly hatást gyakorol a múltunk. A múltunk forrása születésünk pillanata - az a különleges másodperc, amikor világra jöttünk, amikor - speciális módon álltak a bolygók, a csillagok, a világmindenség elemei.\n
A múlt, a jelen és a jövő - egyetlen fa gyökere, törzse és ágai.\n
Az ember természetéből fakadóan kíváncsi, és mindig szeretné látni a jövőt, már most szeretne felkészülni arra, ami valamikor később lesz.\n
Ha ismerünk két pontot, meg tudjuk húzni az egyenest.\n
Ha ismerjük azokat a tényezőket, amelyek születésünk pillanatában hatottak ránk, és ha ismerjük a jelenünket, fogalmat alkothatunk a jövőnkről. A születésünk pillanatában ránk ható tényezők esszenciáját megtalálhatjuk a kínai horoszkóp tizenkét jegyében, jegyekhez kapcsolt öt-öt típus leírásában. A leírásokat tanulmányozva megismerhetjük saját képességeinket és tulajdonságainkat - még azokat is, amelyek eddig rejtve maradtak előlünk -, és kiszámíthatjuk, hogy ilyen örökséggel merre tarthatunk.\n
Már a születésünk pillanatában eldől a sorsunk - amin, ha ismerjük, változtathatunk.\n
A ""Kínai örökhoroszkóp"" tartalmazza a kínai horoszkóp tizenkét jegyében születettek öt-öt csoportjára vonatkozó tulajdonságok és képességek felsorolását, az adott időpontok szülötteinek jellemző vonásait; tartalmazza, mire számíthatunk az egyes jegyek és elemek által befolyásolt években - felkészülhetünk a nehézségekre és a boldog napokra, kiszámíthatjuk, várhatóan mikor leszünk mélyponton, és mikor kerülünk fel ismét a csúcsra.\n
A horoszkóp nem felnőtteknek szóló tündérmese - több ezer éves, megfigyeléseken alapuló bölcsesség.",
                },

                new Book {
                    Id = 20,
                    Title = @"A zodiákus története",
                    Author = @"Robert Powell",
                    Headline = @"",
                    NumberOfPages = 228,
                    Price = 3590,
                    PublishYear = 2011,
                    ShortDescription = @"A zodiákus történetének ez a részletes tanulmánya, melyet 2004-ben adott be először Ph.D. munkájaként Robert Powell, az eredeti zodiákusnak megfelelő, méltó helyére állítja vissza a sziderikus zodiákust, nyomon követve történetét a babiloniakhoz, az i.e. ötödik századba. Az eredeti zodiákus újrafelfedezésének óriási jelentősége van, melynek kulcspontja az, hogy a sziderikus zodiákus jegyei mind harminc fok hosszúságúak és közel egybeesnek az azonos nevű tizenkét csillagászati konstellációival, miközben a tropikus zodiákus jegyei, mivel azok a tavaszponthoz képest kerültek meghatározásra, ma nincsenek közvetlen kapcsolatban a nekik megfelelő zodiákusi csillagképekkel, a napéjegyenlőségek precessziójának köszönhetően.",
                },

                new Book {
                    Id = 21,
                    Title = @"Sütő András világa",
                    Author = @"",
                    Headline = @"",
                    NumberOfPages = 144,
                    Price = 4990,
                    PublishYear = 2010,
                    ShortDescription = @"Az egyetemes magyar irodalom kiemelkedő erdélyi képviselője előtt tisztelgő kötet Sütő András életútját, irodalmi pályafutását követi nyomon. Megismerjük a pusztakamarási szülőházban eltöltött gyermekkora, majd nagyenyedi tanulóévei eseményeit, a számos nehézség, akadályoztatás ellenére kibontakozó írói pálya állomásait. Mindez maga az író, Sütő András műveinek idézeteiből, levelezéséből áll össze hiteles életpályaképpé, melyet még közelebb hoz az olvasóhoz a könyvet kísérő mintegy 150 archív fénykép.",
                },

                new Book {
                    Id = 22,
                    Title = @"Asztro pszichológia",
                    Author = @"Bakos Attila",
                    Headline = @"A Dzsotir Vidjá az ősi indiai asztrológia tanítása",
                    NumberOfPages = 208,
                    Price = 2850,
                    PublishYear = 2011,
                    ShortDescription = @"Egy mítosz bölcs üzenete akkor hal meg végleg, amikor az, aki utoljára hallotta, anélkül távozik, hogy az valaha is elmesélte vagy érthetővé tette volna másoknak. Modern korunk egyik legnagyobb tévedése az a vélekedés, hogy az új mindig, mindenben fölötte áll a réginek.\n
E kötet tartalmazza az ősi írásokban fennmaradt évezredes Dzsotir-véda máig ható sors és jellemtani (asztrológiai) hagyatékát, ám elsősorban a mindennapi életben alkalmazható lélektani mesterfogásokat ajánl. Az asztrológia jógájával, a Dzsotir-szádhanával megláthatjuk és megérthetjük önmagunkat a véges és végtelen teremtés gigantikus óralapján. Ahol a nagymutató, a napjegy, a lélek eredendő vágyát és küldetését jelzi. Ezzel szemben a kismutató, az aszcendens, a lelket beburkoló ego állapotát jelenti, megmutatva a szellemi evolúcióban eddig megtett utat. Mivel a végtelent kutatjuk minden születésben érvényesül az előrelendítő tiszta vágy és lelki erő, a Rahu (felszálló vagy északi holdcsomópont) és a múltba visszarántó, karmikus hibáinkat erőnek erejével ismétlő Ketu (leszálló vagy déli holdcsomópont). Ezek ketten egyúttal a külső és belső misztikus életerő, a Kundalini-shakti rejtett iránymutatói is. ",
                },

                new Book {
                    Id = 23,
                    Title = @"Parker Asztrológia",
                    Author = @"Julia Parker, Derek Parker",
                    Headline = @"Hiteles és átfogó útmutató az asztrológia tudományához",
                    NumberOfPages = 496,
                    Price = 9900,
                    PublishYear = 2011,
                    ShortDescription = @"A ""Parker Asztrológia"" a világ egyik legrangosabb asztrológiai tárgyú szakkönyve, mind a gyakorló asztrológusok, mind a téma iránt érdeklődő laikusok számára nélkülözhetetlen kézikönyv.\n
A kötetben az asztrológiai legfrissebb eredményei és technikái is helyet kaptak, a szerzők részletesen ismertetik a Chiron hatásait, valamint az áttelepüléssel foglalkozó asztrológiát.\n
Felelevenítik az óraasztrológia ősi tudományát, és a horoszkópelemzést a felezőpontok, a harmóniák és a Holdcsomópontok vizsgálatával egészítik ki.\n
A kötet 2020-ig érvényes Efemerida-táblázatokat tartalmaz.",
                },

                new Book {
                    Id = 24,
                    Title = @"A gyógyulás szelencéje",
                    Author = @"Kalo Jenő",
                    Headline = @"Az orvosi asztrológia kézikönyve II. kötet",
                    NumberOfPages = 240,
                    Price = 2600,
                    PublishYear = 2011,
                    ShortDescription = @"Az asztrológia a világ leképezését jelenti, utat a transzcendens felé, egyfajta beavatást a Mindenség lényegéhez, az egységhez. Az orvosi asztrológia lehetőséget biztosít, hogy megértsük betegségeink természetét, hogy mi húzódik meg azok lelki hátterében. Megmutatja, melyek azok a belső kényszerítő erők, amelyek következményeként az adott betegség jelentkezik. A betegség azt jelenti, hogy az egyén nem képes arra, hogy egész legyen, vagyis nem a maga útját járja, hanem letér arról. Minden megtorpanás, minden zsákutca minden letérés azokat az erőket mozgósítja, amelyek -olykor akár fájdalommal, akár betegség formájában- abban segítenek, hogy visszatérjünk a saját utunkra. Betegségünk segít, hogy elérjük legfontosabb célunkat: megvalósítani Önmagunkat.\n
\n
A megújult, bővített formában megjelenő első kötet bevezetést ad az asztrológia alapfogalmaiba, létfilozófiájába és bemutatja az orvosi asztrológia gyakorlati alkalmazásának lehetőségeit. A betegségcsoportok közül három nagy területre tér ki: megtárgyalja az idegrendszer idegi és pszichés irányú betegségeit, a belső elválasztású mirigyrendszer legfontosabb betegségeit, és az érzékszervek közül a legfontosabb szem- és fülbetegségeket. Az összefüggések jobb megértése végett közel 50 horoszkópábra és azok értelmezése segíti az olvasót.\n
A második kötet tárgyalja a további testi terültek betegséget, pl. a táplálkozás, a légzés, kiválasztás, a keringés, a bőr és a mozgás szervrendszerének elváltozásait, illetve azok lelki hátterét és asztrológia megfeleltethetőségét.",
                },

                new Book {
                    Id = 25,
                    Title = @"Harmonia Universalis",
                    Author = @"Buji Ferenc",
                    Headline = @"Az asztrológia belső rendje",
                    NumberOfPages = 354,
                    Price = 3900,
                    PublishYear = 2012,
                    ShortDescription = @"Az asztrológia egyediségét - tudós kritikusai szemében botrányát - az adja, hogy idegen test a mai világban, mert az egyetlen olyan tradicionális tudomány, amely túlélte a ""régi világ"" pusztulását, s mind a mai napig képes integrálni azokat az új elemeket, amelyeket segédtudománya: a csillagászat és a pszichológia kínálnak számára.\n
Buji Ferenc legújabb munkája nem asztrológiai tankönyv, hanem az asztrológia belső rendszerének, egyedülállóan összetett és harmonikus szerkezetének bemutatása - s mint ilyen, mindenekelőtt az asztrológia belső működési mechanizmusának megértésében nyújt segítséget. A bolygóknak mint személyiségelemeknek, a jegyeknek mint személyiségtípusoknak, a házaknak mint a sors alapvető szegmenseinek, illetve a fényszögeknek mint ezek egymáshoz való viszonyának értelmezése révén bepillantást nyerhetünk a régi ember gondolkozásmódjába, antropológiai felfogásába, típus- és sorstanába. Ugyanakkor felnyílhat a szemünk egy olyan tudásra, amely a modern tudományokhoz képest is kivételes komplexitásban és mélységben, egyedülálló szisztematikussággal vizsgálja az emberi élet teljességét. ",
                },

                new Book {
                    Id = 26,
                    Title = @"Ájurvédikus asztrológia és marmapunktúra",
                    Author = @"Késmárki László",
                    Headline = @"",
                    NumberOfPages = 290,
                    Price = 4800,
                    PublishYear = 2012,
                    ShortDescription = @"A keleti és a nyugati hagyományos orvoslás is rendelkezett a gyógyító elméletnek és gyakorlatnak megfelelő asztrológiai ismeretekkel. A hagyományos kínai orvoslás alapzata a I Ching és a kínai asztrológia, míg az indiai ájurvédikus gyógyászaté a védikus asztrológia.\n
Az ájurvéda, az Élet Tudománya és az asztrológia, a Fény Tudománya egymásra támaszkodva kereste a betegségeket kialakító okokat és a kedvezőtlen kozmikus hatások kijavítási lehetőségeit, módjait. Ilyen energetikai rendszert kiegyensúlyozó gyógyító eljárás a marmapunktúra és a marmapresszúra.\n
A szerző feltárja a test létfontosságú energiapontjainak asztrológiai vonatkozásait, a bolygók, holdházak, csillagok marma pontokra gyakorolt hatását, az akupunktúrás pontoknál lerakódó, energiatorlaszt okozó, lelki és mentális mérgek természetét, valamint megismertet a pontok kezelési technikáival.\n
A könyv segítség a gyógyító művészetet folytatóknak és a betegeknek egyaránt, hiszen bemutatja a betegségek valamennyi égi (kozmikus, külső hatások által előidézett, lelki és mentális) és földi (testi, biokémiai, táplálkozásbeli, életmódbeli) okát, és azok megszüntetésének legősibb metódusait.",
                },

                new Book {
                    Id = 27,
                    Title = @"Big Shoot",
                    Author = @"Koffi Kwahulé",
                    Headline = @"Drámák",
                    NumberOfPages = 222,
                    Price = 2500,
                    PublishYear = 2012,
                    ShortDescription = @"""A kötetünkben szereplő három színdarabban nem érdemes Afrika számunkra egzotikusnak tűnő tájait keresni. Kwahulé finoman pulzáló szövegei sokkal egyetemesebb kérdéseket feszegetnek. A Sörfőzde akár politikai pamfletnek is beillene, a Big Shoot súrolja az abszurd határait, a Barbárok melankóliája pedig igazi tragédia, amelynek mozgatórugói a hagyomány- és tekintélytisztelet megtagadása, valamint a féltékenység."" (a Kiadó)",
                },

                new Book {
                    Id = 28,
                    Title = @"Az ember tragédiája",
                    Author = @"Madách Imre",
                    Headline = @"Jankovics Marcell animációs filmváltozatának képeivel",
                    NumberOfPages = 320,
                    Price = 4990,
                    PublishYear = 2011,
                    ShortDescription = @"Madách Imre műve Jankovics Marcell animációs filmváltozatának színes képeivel illusztrálva jelent meg. ",
                },

                new Book {
                    Id = 29,
                    Title = @"Drámák V.",
                    Author = @"Spiró György",
                    Headline = @"Az Árpád-ház - A békecsászár - Príma környék",
                    NumberOfPages = 320,
                    Price = 3750,
                    PublishYear = 2012,
                    ShortDescription = @"A Spiró György színpadi műveit bemutató sorozat ötödik kötetében az író küönböző történelmi korokban játszódó művei szerepelnek: két nagylélegzetű, sokszereplős dráma, ""A békecsászár"" és az ""Árpád-ház"", illetve a ""Príma környék"" című napjainkban játszódó komédia, amely most jelenik meg először nyomtatásban.",
                },

                new Book {
                    Id = 30,
                    Title = @"Kísértetek, rejtelmek, átkok",
                    Author = @"Isa Schneider",
                    Headline = @"... egy orvosnő szemével",
                    NumberOfPages = 224,
                    Price = 2200,
                    PublishYear = 2011,
                    ShortDescription = @"Isa Schneider, megannyi regény szerzője ezúttal egészen sajátos művel lepi meg az olvasót. Műve nem regény, és nem is tudományos munka.  Leginkább parapszichológia, paranormális jelenségek leírása, elemzése, vizsgálata, de van benne kevés néprajz, és némi történelem is. Különlegesen érdekes és olvasmányos mű, mert erdélyi emlékeire, történetei fűzi fel gondolatait jóslásról, telepátiáról, varázslatokról - de egy tapasztalt orvos mai tudásával felvértezve.\n   
""Bár évek óta foglalkoztat, hogy egyszer megírom a történetet, de soha nem volt rá időm. Bizonyára nem is került volna rá sor, ha a sors össze nem hoz tudós barátommal, a néprajzkutatóval - mondja az orvos-írónő. - ...beszélgettünk sámánokról, népi gyógyítókról, transzkulturális medicináról megemlítettem neki Rózsi nénit, aki neveltetésem egyik  pillére volt...""\n 
Élvezetes, csevegő stílusú mesékbe (is) foglalt tények Isa Schneider és ismerősei különös  megélései, a gyógyító javasasszony tevékenysége - miközben az olvasó maga is megtanulhatja a kártyavetés, a zaccból, babból jóslás ""titkait"".",
                },

                new Book {
                    Id = 31,
                    Title = @"Belépési pont",
                    Author = @"Solara",
                    Headline = @"Útlevél az új világba",
                    NumberOfPages = 286,
                    Price = 2990,
                    PublishYear = 2006,
                    ShortDescription = @"Manapság sok szó esik a felemelkedésről és a dimenzióváltásról. Úgy tűnik, egyre gyakoribb a planetáris aktiválás, és mintha havonta nyílna egy-egy újabb csillagkapu. Bővelkedünk elméletekben, amelyek az ufók beavatkozásától kezdve a fizikai testünkből való kiszabadulásig terjednek. De hova juttat bennünket a közelgő felemelkedés? Talán egy nagy űrhajóra vagy egy másik dimenzióba? Úgy tűnik, mindenki rendelkezik a válasz egy részével, ez a temérdek információ mégsem áramlik eléggé együtt ahhoz, hogy egy egységes egészt alkosson. A Belépési pont rendet teremt ebben a káoszban.\n
Egy Új Világ várja, hogy megszülessen. Ezt fizikai testünkben kell megtapasztalnunk, ezen a bolygón. Egy Új Világ várja, hogy mi adjunk neki életet. Az energia egy olyan rezgéstartományában található, amelyet Láthatatlannak nevezünk. Ha fel akarjuk fedezni új jövőnket, ha sugárzóan erő- és szeretetteljes életet akarunk élni, meg kell tanulnunk megismerni a Láthatatlant. Ez a kézikönyv útlevélként szolgál, és belépést biztosít egy új területre, amelyet még nem ismerünk...",
                },

                new Book {
                    Id = 32,
                    Title = @"Két ÜBÜ-dráma",
                    Author = @"Alfred Jarry",
                    Headline = @"Schall Eszter rajzaival",
                    NumberOfPages = 144,
                    Price = 1990,
                    PublishYear = 2011,
                    ShortDescription = @"""Alfred Jarry (1873-1907) drámái színháztörténeti jelentőségűek. Olyan szövegek, melyek az elmúlt évszázadban elsősorban nem drámaként, hanem színházi mítoszként foglaltak helyet kulturális emlékezetünkben. Übü rabelais-i monstrum, gyakran Faust, Lucifer, Don Juan figurájához hasonlítják, olyan irodalmi karakterekhez, akik megteremtették saját mítoszukat, s ekként élnek tovább más irodalmi alkotásokban. Übü mítosza azonban színházi mítosz, továbbírni vagy újraírni szövegszerűen senki nem próbálta. Színpadra vinni azonban hamleti kihívást jelent minden rendezőnek."" (Jákfalvi Magdolna)",
                },

                new Book {
                    Id = 33,
                    Title = @"Európai költők antológiája",
                    Author = @"Faludy György",
                    Headline = @"",
                    NumberOfPages = 272,
                    Price = 2980,
                    PublishYear = 2003,
                    ShortDescription = @"Az 1936-os év legvégén vagy talán 1937 januárjában Cserépfalvi Imre kiadó és könyvkereskedő elhatározta, hogy közread egy Európai Költők Antológiája kötetet, a béke és szabadságversek gyűjteményét. 
""Bár nem hiszem, hogy az 1930-as korhoz hasonló időket élünk, mégis úgy érzem, hogy egy nemrég még reménykedő és most már reményvesztett közönségnek vigaszául szolgál ez a kötet."" (Faludy György)",
                },

                new Book {
                    Id = 34,
                    Title = @"Az igazság odaát van",
                    Author = @"Paulinyi Tamás",
                    Headline = @"Pszi-akták",
                    NumberOfPages = 228,
                    Price = 3450,
                    PublishYear = 2012,
                    ShortDescription = @"A tanulmánygyűjteményben elsősorban lélektani jellegű írások sorakoznak, de közös jellemzőjük, hogy kívül esnek a pszichológia hagyományos megközelítésein, vagyis nem pszichológiakönyvvel állunk szemben, hanem olyan ezoterikus írásokkal, melyek tematikájuknál fogva számos értelemben a ma elfogadott tudományos világszemlélettel is szembemennek.\n
A pszi világa, avagy a parapszichológia az ismeretlennel szembesít, ugyanakkor a jelenségek és csodák jó része immáron kísérletileg is bizonyított: a kettősség szintézisében Paulinyi Tamás vallja: nem ismeretelméleti kérdésekről van szó, ezek a mindennapok életszemléletére vannak hatással, hiszen a sorsról, az erkölcsről, az életről és a  halálról alkotott fogalmaink létünk minőségére is kihatnak - értékrendünkön és döntéseinken keresztül. Az egybegyűjtött írások a spirituális bölcsességeket integrálják a tudományos parapszichológia mai ismereteivel.\n
\n
László Ervin filozófus szavaival: ""Azok a jelenségek, amelyeket könyvében Paulinyi Tamás vizsgál, valóban nem illenek sem a tudomány uralkodó felfogásába, sem a józan ész világának fogalmába, viszont érthetővé tehetők a tudomány egy másik, különböző paradigmáján keresztül; egy új, másfajta látásmóddal. Hogy mi jellemzi ezt a látásmódot, azt általános terminusokban is megfogalmazhatjuk. Elsődleges jellemzője az univerzum egy olyan dimenziójának feltételezése, mely valóságos, bár közvetlenül nem figyelhető meg: - ami ""rejtve van"" az ismert észlelési módok elől. Tény, hogy így nem tűnik olyan valóságosnak, mint az észlelhető dimenziók, mégis annál valóságosabb: - ez képezi az alapját a megfigyelhető Univerzumnak, a tapasztalt jelenségek ennek a dimenziónak a manifesztációi, megtestesülései."" ",
                },

                new Book {
                    Id = 35,
                    Title = @"Paranormális erők kézikönyve",
                    Author = @"Brian Haughton",
                    Headline = @"",
                    NumberOfPages = 224,
                    Price = 3500,
                    PublishYear = 2011,
                    ShortDescription = @"-Tüzet kelteni elménk segítségével?\n
-Pszichikus gyógyítás?\n
-Rejtett erők a politika szolgálatában?\n
-Kristálygömbjóslás?\n
\n
A ""Paranormális erők kézikönyve"" bevezet ebbe a titkokkal teli világba.",
                },

                new Book {
                    Id = 36,
                    Title = @"Lelkedhez hűen",
                    Author = @"Ronald H. Hulnick, Mary R. Hulnick",
                    Headline = @"A spirituális pszichológia lényege",
                    NumberOfPages = 260,
                    Price = 3290,
                    PublishYear = 2012,
                    ShortDescription = @"A ""Lelkedhez hűen"" című könyv alapjaiban rengeti meg a bevett pszichológiai gondolkodást azáltal, hogy megmutatja, miként használhatjuk mindennapi tapasztalatainkat a spirituális fejlődés létrafokaiként. A könyvet mindenki örömmel forgathatja, aki meg akarja találni a hidat a fizikai létezésből a spirituális valóságba, és át akar kelni rajta. Ez az út nem arról szól, hogy megtaláljuk a megfelelő munkát, magunkhoz vonzzuk a lelki társunkat, mesés fizetést kapjunk vagy a szív vágyai szerint éljünk - sokkal inkább annak a mély belső éhségnek a csillapításról, amely arra ösztönöz, hogy válaszokat keressünk az élet nagy kérdéseire: Ki vagyok én? Miért vagyok itt? Hogyan élhetnék értelmesebben, és hogyan tehetném jobbá a világomat?\n
\n
A kezedben tartott könyvből megtudhatod, hogyan juthatsz el arra a szent helyre, amely mindenkiben ott rejlik, és amelyre a szerzők Valódi Énként utalnak, ahol többé nem kell érzelmi kínokat átélned, ahol a fenti kérdésekre magától értetődő válaszokat kapsz, és ahol mélységes békesség és szeretet honol.\n
\n
""A ""Lelkedhez hűen"" című könyv káprázatos mestermunka. Kétség sem fér hozzá, hogy ez a mű klasszikusnak született, és előbbre visz az emberi természetnek és az élet kihívásainak megismerésében. A könyv a két szerzőt dicséri, akik évek kemény munkájával megszerzett bölcsességüket a tudati fejlődés kiemelkedő tanítóiként adják át az olvasónak.""",
                },

                new Book {
                    Id = 37,
                    Title = @"Érzékeken túli észlelés José Silva módszerével",
                    Author = @"José ifj. Silva, Ed ifj. Bernd",
                    Headline = @"Használjuk mentális erőnket, hogy sikeresek legyünk az élet minden területén!",
                    NumberOfPages = 272,
                    Price = 2499,
                    PublishYear = 2010,
                    ShortDescription = @"Tegyük jobbá életünket természetes lelki képességeink segítségével!\n
Ha volt már megérzésünk, ami beigazolódott, álmunkban hasznos információhoz jutottunk, esetleg váratlan egybeesést tapasztaltunk, akkor valószínűleg - tudtunkon kívül - az ESP-t alkalmaztuk. Az Érzékeken túli észlelés José Silva módszerével bevezeti olvasóit az ESP fortélyaiba, és segít a rejtett információk megértésében, melyek életünk minden területét jobbá teszik, beleértve egészségi állapotunkat, gazdasági helyzetünket és kapcsolatainkat is.\n
\n
Ifj. José Silva könyvéből megtanulhatjuk, hogyan kapjunk útbaigazítást a magasabb intelligenciától a jobb döntések és céljaink beteljesítése érdekében. A kötet bemutatja a bizonyítottan hatékony dinamikus meditációs rendszert, melyet a világhírű parapszichológus, José Silva fejlesztett ki.\n
\n
Itt az ideje, hogy azt a sikeres életet éljük, melyet egy magasabb intelligencia számunkra megtervezett. Ahogy José Silva mondta: ""Életed hátralévő része legyen a legjobb időszakod!""",
                },

                new Book {
                    Id = 38,
                    Title = @"Az alkotó elem",
                    Author = @"Lou Aronica, Ken, Sir Robinson",
                    Headline = @"Fedezd fel, mire születtél, és minden megváltozik",
                    NumberOfPages = 336,
                    Price = 3900,
                    PublishYear = 2010,
                    ShortDescription = @"""Ha képzeletünket és kíváncsiságunkat szabadjára engedjük, többé semmi sem lehetetlen.""\n
Sir Ken Robinson a kreativitás, az innováció és a humán erőforrások nemzetközileg elismert szakértője rendkívül szellemesen és mély emberséggel arra buzdít bennünket, ne hallgassunk a pesszimistákra, ne sodródjunk a tömeggel, hanem keressük meg igazi alkotó elemünket - képességeink és vágyaink találkozási pontját.\n
A könyvben többek között Paul McCartney, Bob Dylan, Meg Ryan, Jay-Z vallanak tehetségük felfedezése felé vezető útjuk egy-egy fordulópontjáról, vagy éppen zsákutcájáról, végül a megérkezés öröméről és kiteljesedéséről.\n
A szerző szerint mindannyian képesek vagyunk hasonló utakra és teljesítményre, de a modern világ uniformizált oktatása inkább kishitűséget támaszt bennünk saját képességeinket illetően, mintsem bátorítana velünk született tehetségünk kibontakoztatásában. Úgy véli, oktatási rendszerünket mielőbb új alapokra kell helyeznünk, hogy ne ölje ki belőlünk és gyerekeinkből a kreativitást.\n
""Az alkotó elem"" szenvedélyes és meggyőző felhívás arra, hogy másképp gondolkodjunk önmagunkról és a világról. Támpontot ad jövőnk alakításához, gyerekeink kreatív neveléséhez, vágyaink és álmaink megvalósításához, hogy megtaláljuk önmagunkat és saját alkotó elemünket.",
                },

                new Book {
                    Id = 39,
                    Title = @"A materializmus vége",
                    Author = @"Charles T. Tart",
                    Headline = @"A tudomány és a spiritualitás találkozása a paranormális jelenségek bizonyítékainak fényében",
                    NumberOfPages = 384,
                    Price = 4300,
                    PublishYear = 2010,
                    ShortDescription = @"Telepátia, távolbalátás, prekogníció, pszichokinézis, okkult gyógyítás, posztkogníció, testen kívüli és halálközeli élmények, halál utáni élet, médiumitás, reinkarnáció.\n
Paranormális jelenségek, amelyekről napjaink merev természettudományos gondolkodása nem akar tudni, pedig létezésüket emberek millióinak tapasztalatai támasztják alá, és sokuk valós voltát szigorúan tudományos vizsgálatok is igazolják.\n
Charles T. Tart - aki egyben transzperszonális pszichológus is - több mint ötven éve kutatja ezt a területet. Könyvében számos érdekes kísérlet és élmény leírása mellett elmagyarázza, hogy miért és hogyan kell a spirituális világ valóságát racionális nézőpontból vizsgálni. Megmutatja, milyen egyoldalú, önző és sivár a korunkban eluralkodott materializmus mögött meghúzódó világkép, és hogy éppen a paranormális jelenségek létének tudomásul vétele jelenthetné egyfajta spirituális felébredés kezdetét, indíthatná el spirituális képességeink kibontakozását és az életünkben munkálkodó mélyebb erők felfedezését.",
                },

                new Book {
                    Id = 40,
                    Title = @"Kísértetszív",
                    Author = @"Lisa Rogak",
                    Headline = @"Stephen King élete",
                    NumberOfPages = 408,
                    Price = 3500,
                    PublishYear = 2010,
                    ShortDescription = @"Stephen King, a világ egyik legtermékenyebb és legnépszerűbb írója ma már része a popkultúra történetének. De ki ez az ember, aki ezt a rengeteg, borzalommal, gyásszal és természetfölöttivel megspékelt történetet kitalálta? Honnan veszi az ötleteit? És mi hajtja, hogy több mint harmincéves karrier után is egyre ontsa ezeket a rémségeket? Lisa Rogak, a profi biográfus a nyomába eredt, és feltérképezte azt a gondokkal teli előéletet, azokat a félelmeket, amelyek máig inspirálják a 20. század egyik legnagyobb hatású szerzőjét.\n
\n
King származása és ifjúkora nem ígért sokat. Feneketlen szegénység Maine állam isten háta mögötti vidékén, korai házasság: nem éppen egy fényes irodalmi pálya zálogai. Munkamániája és áradó fantáziája mégis korai, váratlan sikert hozott. Talán túl korait is: a hirtelen sztárság, az egyik pillanatról a másikra beköszöntő gazdagság azzal fenyegetett, hogy a munkája, de akár az élete is rámegy. Ám ő túljutott a válságon, s azóta is olyan eredetiséggel alkot, amilyenre kevés író képes.\n
\n
Sötét és felkavaró világa ellenére Stephen Kinget ma már számtalan rajongója és egyre több kritikusa inkább a Mark Twain-i, semmint a H. P. Lovecraft-i hagyományhoz sorolja. A Kísértetszív ennek az embernek a történetét és világát vetíti elénk - azét az emberét, aki kétségkívül a modern irodalom egyik legfelejthetetlenebb és legijesztőbb életművét hozta létre.",
                },

                new Book {
                    Id = 41,
                    Title = @"Egy csecsemő emlékiratai (CD-ROM melléklettel)",
                    Author = @"Kornis Mihály",
                    Headline = @"Képeskönyv",
                    NumberOfPages = 264,
                    Price = 2900,
                    PublishYear = 2007,
                    ShortDescription = @"Anya-könyv? Emlékezés a jóvátehetetlen és boldog gyermekkorra. Kornis Mihály új könyve több is, kevesebb is ennél. Mindenek előtt élvezetes és érzéki próza, hamisíthatatlan kornisi hangon és elbeszélői szenvedéllyel. A kötet számtalan fénykép és személyes dokumentummal jelenik meg, hiszen az író itt a kép és szöveg dialógusát teremti meg. A kortárs próza fontos eseménye az Egy csecsemő emlékiratainak megjelenése.",
                },

                new Book {
                    Id = 42,
                    Title = @"Érettségi, felvételi feladatok: Matematika",
                    Author = @"Börcsök László",
                    Headline = @"",
                    NumberOfPages = 214,
                    Price = 1190,
                    PublishYear = 2002,
                    ShortDescription = @"E kiadvány elsősorban az írásbeli felvételi vizsgára készülőknek kíván segítséget nyújtani, de haszonnal forgathatják az érettségire készülő diákok is. Együttes forgatásuk hatékonyabbá teheti a tanulást és a megoldási módszerek elsajátítását.  A kötetben 250 feladat és azok részletes megoldása található. A feladatok témakörönkét úgy vannak csoportosítva, hogy az önálló tanulást segítsék. Haszonnal forgathatja a könyvet minden diák, öregdiák, és talán még a tanár is.",
                },

                new Book {
                    Id = 43,
                    Title = @"Általános kémia",
                    Author = @"Veszprémi Tamás",
                    Headline = @"",
                    NumberOfPages = 520,
                    Price = 9950,
                    PublishYear = 2008,
                    ShortDescription = @"A könyv több -tipográfiailag is elkülönített- szinten használható. Anyaga a középiskolai kémiától elvezet az egyetemek másod- és harmadéves fizikai kémia tárgyáig. A fontos jelenségek mellé a haladók számára mélyebb magyarázatokat mellékel, melyeket a kezdők nyugodtan átugorhatnak anélkül, hogy ez gátolná a fő gondolatmenet megértését. Az olvasót számos érdekesség, tudománytörténeti kitekintés, rengeteg színes ábra, fénykép és több száz kidolgozott példa is segíti.",
                },

                new Book {
                    Id = 44,
                    Title = @"Robert Merle",
                    Author = @"Pierre Merle",
                    Headline = @"Egy szenvedélyes élet",
                    NumberOfPages = 356,
                    Price = 3500,
                    PublishYear = 2012,
                    ShortDescription = @"Robert Merle-t szívükbe zárták a magyar olvasók, már-már halhatatlannak hitték, mint a nagyon szeretett és csodált öregeket szokta az ámuló fiatal nemzedék. Az író lenyűgöző szellemi frissességgel dolgozott kilencvenedik életévén túl is, közkívánatra gyarapította újabb és újabb kötetekkel a Francia históriá-t. 2004-ben, 95 éves korában bekövetkezett halála pedig valóban nem volt egészen természetes, fedi fel sok egyéb mellett apjáról írott életrajzában második házasságából született fia, Pierre Merle.\n
\n
Robert Merle zárkózott ember volt a magánéletben, féltékenyen őrizte titkait, de nem hagyta veszendőbe menni: amellett, hogy műveiben megörökítette magát (és övéit), gondosan tárolta iratait, leveleit. Pierre Merle pedig ezekre támaszkodva idézi fel apja kivételes pályafutását.\n
\n
Szó esik a Franciaországból Algériába származott szegény felmenőiről, korán elhalt, imádott apjától örökölt nyelvtehetségről, a tanári és írói ambícióiról, németországi fogságáról a második világháború alatt, politikai elkötelezettségeinek viszontagságairól, kiadókkal folytatott patvarkodásairól, házairól, autóiról.\n
És persze az asszonyokról-lányokról az életében, kardos, fukar anyjáról, melegszívű, okos nővéréről, angliai első szerelméről, első feleségéről, aki hűtlen lett hozzá hadifogsága alatt, a fehérneműárus kedvesről, aki a megszállt Párizsban visszaadta életkedvét, a második feleségről, aki vállalta érte az apai kiátkozást, de kapcsolatuk megromlása után ádázul harcolt ellene a gyerekeikért, a tragikus véget ért harmadik feleségről, és egyéb bájos és bajkeverő alakokról.\n
\n
Robert Merle nem volt szent, de egy erényhez utolsó percéig ragaszkodott: az önsajnálatot mélyen megvetette. Mérhetetlen érdeklődéssel fordult szűkebb és tágabb környezete felé. Mesterségem a halál című regényét tartotta legjobb írásának, mert úgy érezte, talán tett-értékű egy jó ügy szolgálatában. Kudarcait és tévedéseit pedig nyíltan beismerte. Nem egy mélypontja volt életének, de műveiben megírta szebbik mását a maga és a mindenkori olvasó örömére.",
                },

                new Book {
                    Id = 45,
                    Title = @"Lázár Ervin élete és munkássága",
                    Author = @"Komáromi Gabriella",
                    Headline = @"",
                    NumberOfPages = 392,
                    Price = 2980,
                    PublishYear = 2011,
                    ShortDescription = @"A könyv ""hőse"" olyan író, akit a mesék emeltek a halhatatlanok sorába. Minden körülmény: a ""rácpácegresi"" örökség, a látásmódja, a fantáziája, a beszédmódja mesemondóvá tette. Gyermekeknek szóló történetei ismertebbek, kanonizálódtak - ""A Négyszögletű Kerek Erdő"" már beletartozik a mitológiánkba -, ezért szinte természetes, hogy műveinek bemutatása során különös hangsúlyt és kitüntetett teret kap gyermekirodalmi munkássága. De életművének a gyermekkönyveken túli része is nagy író alkotása, ugyanabban a fegyverzetben hozta létre azt is, novellái és meséi egy tőről fakadtak. Nemegyszer ""párhuzamos"" történeteket írt, ez e kötet struktúrájában is megjelenik.\n
Az életút rekonstrukciója nem számít a kötelező tennivalók közé, de Lázár esetében a monográfia szerzője nem tekinthetett el az írói életrajz tényeitől, és nem feledkezhetett meg arról, hogy Lázár Ervin történetein áttetszik személyisége, értékvilága, szülőföldje és műveket inspiráló tájélménye. Magától értetődőek az első monográfia nehézségei, de tagadhatatlanok az első monográfus kiváltságai. Még meséltek neki az író élettörténetének szereplői, és ő nyithatta ki először a levelesládáját.\n
Lázár Ervin életműve lezárult, elérkezett az értékelés ideje, helyének kijelölése a világirodalomban, a magyar irodalomban és a gyermekkönyvek írói között. A róla szóló könyv születésének hetvenötödik, halálának ötödik évfordulóján jelenik meg. Elsősorban a tudomány és az irodalom világának szól, de azokra a generációkra is számít olvasóként, amelyek Lázár Ervin művein nőttek fel.",
                },

                new Book {
                    Id = 46,
                    Title = @"Laterna magica",
                    Author = @"Ingmar Bergman",
                    Headline = @"",
                    NumberOfPages = 480,
                    Price = 3500,
                    PublishYear = 2011,
                    ShortDescription = @"A 2007. július 30-án elhunyt Ingmar Bergman önéletrajza a filmekből, forgatókönyvekből, színházi rendezésekből álló páratlan életmű záróköve, ismételt igazolása annak a mindig is sejtett ténynek, hogy A nap vége, A csend, a Persona, a Rítus, a Suttogások, sikolyok, a Fanny és Alexander írója és rendezője valódi anyagból, megélt élményekből, tulajdon életéből építette műveit.\n
Önéletírása számos ponton világítja meg mű és alkotó viszonyát, és fényesen bizonyítja, amit magyarul megjelent forgatókönyvei, filmnovellái óta már nálunk is sokan tudnak: hogy Bergman írónak is kivételes tehetségű.\n
Könyörtelen igazságkereső, aki nem kímél senkit és semmit, legkevésbé önmagát. A lényeget kutatja mindenben, így kerülhet könyvében egymás mellé a legnagyobb természetességgel a megalázó testi bajok leírása és Garbo, Chaplin, Karajan, Oliver portrévázlata, a gyermekkori pofonok és a felnőttkori rendőri meghurcoltatás, kamaszkori élmények a náci Németországban, riasztó tapasztalatok a svéd szocialista ""pokolban"", menedékkeresés és részbeni kirándulás a ""demokratikus"" Münchenben, siker és kudarc, sírás és nevetés. És, talán mondani sem kell, ítélet nincs: Bergman nem dicsőül meg - sőt ellenkezőleg, inkább az esendő, a szenvedő, a gyarló emberi arcát mutatja.",
                },

                new Book {
                    Id = 47,
                    Title = @"Fél lábbal a földön",
                    Author = @"Oliver Sacks",
                    Headline = @"",
                    NumberOfPages = 300,
                    Price = 2500,
                    PublishYear = 2006,
                    ShortDescription = @"A férfi, Oliver Sacks, nemcsak gyakorló ideggyógyász, hanem író is, bizarr neurológiai ""esetek"" lejegyzője, aki ezúttal saját könyve, sorskönyve kényszerű főszereplőjévé, a vele történtek hű krónikásává válik. 
Egy kivételes intelligenciájú és íráskészségű szakember örökíti meg tehát utolsó(nak vélt) órái megrázó élményét, az idő és az emlékek különös összesűrűsödését, lába abszurd ""elvesztésének"", majd ""előkerülésének"" megtapasztalását. Sacks páratlan megjelenítő erővel, helyenként mély öniróniával idézi fel a betegszereppel járó kínzó kiszolgáltatottságot, a világérzékelés radikális megváltozása miatti lelki megpróbáltatásokat s a láb ""megtalálásának"" eufóriáját. Mivel az átéltek pusztán szakmai magyarázatát nem találja kielégítőnek, irodalmi idézetekkel, filozófiatörténeti kitekintéssel keres párhuzamokat helyzetére, s próbálja értelmezni életének sorfordító eseményét, mely ""egy lélek utazása az alvilágba s onnan vissza: spirituális dráma - neurológiai alapon"". ",
                },

                new Book {
                    Id = 48,
                    Title = @"Szeretetről, sötétségről",
                    Author = @"Ámosz Oz",
                    Headline = @"",
                    NumberOfPages = 864,
                    Price = 3500,
                    PublishYear = 2010,
                    ShortDescription = @"Ámosz Oz, a legismertebb izraeli író önéletrajzi munkája, amelyet számos nyelvre lefordítottak, minden idők legnagyobb izraeli könyvsikere. Lebilincselő családtörténet, amely egy dickensi figurákban bővelkedő, nagy ívű elbeszélés keretében mesterien ötvözi a személyes és a történelmi eseményeket. 
Oz családja bevándorló: Mussmanék Ukrajnából menekülnek az antiszemitizmus miatt; előbb Lengyelországba, majd Prágába, végül Jeruzsálembe, ahol az érzékeny, intelligens Fanja férjhez megy Klausnerhez, egy költői vénával megáldott, kétbalkezes szobatudóshoz. Fiuk, Ámosz a negyvenes - ötvenes évek Jeruzsálemében nő fel. A későbbiekben felveszi az Oz (bátorság) nevet és harminc éven keresztül egy kibucban próbálja megvalósítani önmagát.",
                },

                new Book {
                    Id = 49,
                    Title = @"A bolygó fénye",
                    Author = @"Alexander Brody",
                    Headline = @"Hunyady Sándor arcképe",
                    NumberOfPages = 320,
                    Price = 2900,
                    PublishYear = 2011,
                    ShortDescription = @"Alexander Brody könyve egyszerre idézi meg Hunyadi Sándor arcképét és azt a miliőt, ahol és ahogy e jelentős írói életmű létrejött.",
                },

                new Book {
                    Id = 50,
                    Title = @"""Művészet""",
                    Author = @"",
                    Headline = @"Mai francia drámák",
                    NumberOfPages = 564,
                    Price = 3700,
                    PublishYear = 2010,
                    ShortDescription = @"A francia színpadok kínálata stílus és műfaj tekintetében egyaránt elképesztően változatos, közönségük is káprázatosan tarka. Számtalan rekordszériás előadás közül korántsem egyszerű kiszemelni a magyar közönség figyelmére feltétlenül érdemeseket: idő kell ahhoz is, hogy kikristályosodjon, mit tekinthetünk ""mai""-nak (mi nem avul ""tegnapivá"" ténylegesen máról holnapra).\n
\n
Az ezredforduló bő évtizedének terméséből merítő kötet a magyar színházak által már nagy sikerrel bemutatott színművek mellett a legfontosabb műhelyek (Théâtre du Soleil, Bouffes du Nord, Théâtre du Rond-Point) szerzőitől közöl egy-egy jellegzetes darabot. A versszerű történelmi drámától a szlenges szociográfiáig terjed a skála. A szerzők közül nem egy gyakorló rendező, színész.\n
\n
A dráma mindig is dinamikusabban hatott a publikumra a versnél és a prózánál, sőt, napjainkra az irodalmi nyersanyag korántsem előfeltétele egy színházi produkciónak, de ez a tíz színpadi mű olvasmánynak is elsőrangú. A francia színházi szakma az utóbbi évtizedekben különösen fontosnak véli, hogy a modern dráma javát nyomtatásban is hozzáférhetővé tegye a nagyközönség számára.",
                },

                new Book {
                    Id = 51,
                    Title = @"Maria Quisling",
                    Author = @"Cecilie Loveid",
                    Headline = @"Színdarab 4 részben, 35 jelenetben",
                    NumberOfPages = 88,
                    Price = 1490,
                    PublishYear = 2012,
                    ShortDescription = @"Cecile Loveid drámája hiteles kordokumentumokra támaszkodik, de költői-drámaírói fantáziája színes víziókká, képekben gazdag jelenetekké formálja a nagyhatalmi álmokkal megfertőzött népellenség, Vidkun Quisling és két asszonya viharos szerelmiháromszög-történetét. A darabot 1994-ben mutatták be az oslói Nemzeti Színházba.",
                },

                new Book {
                    Id = 52,
                    Title = @"Valaki jön majd",
                    Author = @"Jon Fosse",
                    Headline = @"Hat színmű",
                    NumberOfPages = 416,
                    Price = 3900,
                    PublishYear = 2012,
                    ShortDescription = @"Jos Fosse a legjelentősebb norvég drámaíró Ibsen óta. 1993-ban -drámái első bemutatóján- már Norvégia-szerte elismert szépíró volt. Azóta műveit több, mint negyven nyelvre ordították le, darabjait nagy sikerrel játsszák világszerte.\n
\n
Több esszé tanúskodik arról, hogy Fosséra milyen mély benyomást gyakoroltak magyarországi tartózkodásai. Gyakran említi azt a mondást, amit magyar színházi emberektől hallott: angyal szállt el felettünk, azaz a színpad felett. Akkor mondjuk ezt, ha hirtelen csend lesz, mintha senki sem merne vagy tudna megszólalni, de mégis egyszerre értenénk meg valami eddig nehezen érthetőt. Ez a gondolat lett Fosse drámaírói arc poeticája is: úgy írni, olyan szituációkat teremteni, amelyek egy-egy pillanatra a mélyebb belátás, a felismerés élményét adják. Ezek azok a pillanatok, amikor angyal szállhat, vagy ahogy ő írja, mehet át a színpadon.\n
\n
A kötetben található színművek:\n
-Valaki jön majd\n
-A név\n
-Egy nyári nap\n
-Tél\n
-Halálvariációk\n
-Én vagyok a szél",
                },

                new Book {
                    Id = 53,
                    Title = @"Pokol",
                    Author = @"Alighieri Dante",
                    Headline = @"",
                    NumberOfPages = 280,
                    Price = 3990,
                    PublishYear = 2012,
                    ShortDescription = @"Dante Alighieri Isteni Színjátékát Babits Mihály ""a világirodalom legnagyobb költeményének"", Jorge Luis Borges ""a valaha írt legnagyobb irodalmi műnek"" nevezte. A Szent Poéma a világirodalom azon remekművei közé tartozik, amelyeket sokkal többen ismernek távolról, hallomásból, halványuló iskolai emlékekből, mint közelről, személyesen, olvasmányélmény alapján. Baranyi Ferenc Kossuth-díjas költő új, nagyszerű Pokol-fordítása formailag hűséges és tartalmilag pontos magyarításban, ugyanakkor ihletett költői szépséggel hozza közelebb a mai olvasókhoz a magasságaiban és mélységeiben páratlan, örök-egyetemes értékű dantei poézist. A Baranyi-Dante régóta várt megjelenése ünnepi eseménye a hazai könyvkiadásnak, műfordítás-irodalomnak és dantisztikának. (Madarász Imre)",
                },

                new Book {
                    Id = 54,
                    Title = @"Üvegcserepek",
                    Author = @"Arthur Miller",
                    Headline = @"",
                    NumberOfPages = 144,
                    Price = 1950,
                    PublishYear = 2011,
                    ShortDescription = @"A legnevesebb amerikai drámaíró - a legjobb magyar fordító: Arthur Miller ""Üvegcserepek"" című drámája Ungvári Tamás fordításában!\n
Miller pergő, izgalmas színpadi művet alkotott, mely olvasva is példátlan feszültséget sugároz. Sok gondolkodnivalót ad e kiválóan felépített, számos szimbolikus jelentésréteget hordozó dráma, Ungvári Tamás mesteri fordítása pedig híven adja vissza az eredeti mű szellemes szövegét.\n
1938. november - Kristályéjszaka. A Hitler által felbujtott arctalan tömeg zsidó üzleteket foszt ki, zsinagógákba tör be, öregembereket kényszerít arra, hogy fogkefével sikálják az ""árja"" járdákat. Berlinben és más német nagyvárosokban bokáig érnek a rombolás üvegcserepei. Ugyanekkor egy jómódú zsidó házaspár Brooklynban éli mindennapi életét; épp moziba készülnek, amikor a csinos, kedves asszony - gondos feleség és szerető anya - hirtelen összeesik, és képtelen lábra állni. Hiába a vizsgálatok sora, betegségének fizikai okát nem lelik az orvosok.\n
Arthur Miller darabjában e két esemény fonódik egymásba. A történelem majdhogynem láthatatlan, mégis mindent átható vezérvonalként van jelen a drámában; a szereplők életében ravasz dramaturgiával az Európában zajló borzalmak tükröződnek. Sylvia Gellburg paralízise tökéletesen szimbolizálja a bénultságot, a nácikkal szembeni tehetetlenséget és a zsidóság kiszolgáltatottságát - azt, ahogy az emberek képtelenek voltak szembeszegülni Hitler minden erkölcsöt lábbal tipró gépezetével.",
                },

                new Book {
                    Id = 55,
                    Title = @"A pokol színei",
                    Author = @"dr. Popper Péter",
                    Headline = @"Színes pokol - Útvesztő - Isten komédiásai",
                    NumberOfPages = 288,
                    Price = 2800,
                    PublishYear = 2011,
                    ShortDescription = @"A ""Színes pokol"" olvasmányos, könnyed stílusban megírt művészetpszichológiai tanulmány, a 80-as években íródott és azóta számos kiadást ért meg. Témája a színész és a színház, mint pszichológiai műhely. Komédiás és varázsló, az átváltozások titkai, színésztípusok, a színész méltósága - a tanulmány főbb fejezetei.\n
A kötetben helyet kapott Popper Péter két korábbi drámája, melyet a Pesti Vigadóban mutattak be. Az ""Útvesztő"" egy rendházban történt gyilkosság nyomozásáról, az ""Isten komédiásai"" a színésznő és a ""civil"" kapcsolatáról: szerelméről és szakításáról szól.\n
A mindvégig feszült, izgalmas cselekmény bonyolítása a szerző sokoldalú tehetségéről tanúskodik.",
                },

                new Book {
                    Id = 56,
                    Title = @"A csörgőkígyó útja",
                    Author = @"Tom Bryan",
                    Headline = @"",
                    NumberOfPages = 88,
                    Price = 1260,
                    PublishYear = 2010,
                    ShortDescription = @"Tom Bryan közvetlen hangon megszólaló kortárs skót költő. A kötet sokszínű, multikulturális kaland. Akár New Yorkban, vagy a kanadai indiánok között járunk, akár Spanyolországban, vagy a Skót Felvidék mitikusan suhogó fái alatt sétálunk - a versek az emberihez való viszonyt térképezik föl.",
                },

                new Book {
                    Id = 57,
                    Title = @"Száz vers",
                    Author = @"",
                    Headline = @"Kínai, indiai, görög, latin, angol, francia, német, olasz, spanyol, román, dél-amerikai, orosz, skan",
                    NumberOfPages = 264,
                    Price = 3990,
                    PublishYear = 2010,
                    ShortDescription = @"Lackfi János költő-műfordító, egyetemi oktató arra vállalkozott, hogy a Szerb Antal utáni évtizedek lírájának alakulását is figyelembe véve kiválaszt újabb száz verset, amely mai, közös ""kapcsos könyvünk"" alapja lehet.\n
A válogatás során ugyanazt az önfeledt örömöt és ugyanazokat a kétségeket élte meg, mint kiváló elődje. Vannak a két antológiában átfedések, de jóval több a különbség, s ezt nemcsak az elmúlt hetven év lírájának beemelése okozza, hanem horizontunk tágulása s talán világszemléletünk változása is.",
                },

                new Book {
                    Id = 58,
                    Title = @"Honvágy",
                    Author = @"Röhrig Géza",
                    Headline = @"",
                    NumberOfPages = 112,
                    Price = 1900,
                    PublishYear = 2010,
                    ShortDescription = @"Túl s innen. Messze s nagyon-nagyon belül. A tíz éve New Yorkban élő szerző kortárs líránk egyik legizgalmasabb alakja. Elemi erejű költészetet művel. Az együttérzés csillaga vezérli az emberi vadon legsűrűbbjébe. És nincs ahol ő megtorpanna.\n
A kötet kulcsszava: mezítlét. Ám ennek vad örömét és fájdalmát is meghaladja a megértésükért folyó küzdelem. Röhrig zavarba hoz, mint minden valódi esemény. Sakkból kilépve akar mattot adni.",
                },

                new Book {
                    Id = 59,
                    Title = @"Goethe Hölderlin Heine versei",
                    Author = @"",
                    Headline = @"",
                    NumberOfPages = 232,
                    Price = 1980,
                    PublishYear = 2005,
                    ShortDescription = @"Goethe lángelme. Hányféle szólama van! Elragadtatott dalok, az istenekkel dacoló prométheuszi ember nagy himnuszai, a kései versek mindentudó teljessége! Olimpuszi nyugalma alatt titáni szenvedélyek. Személyes és egyetemes, érzelem és értelem, mulandó és örök feszült egyensúlya. A romantikus Hölderlin jó húsz évvel fiatalabb. Hasadt lélek, az elveszett harmónia, a görög derű visszaálmodója. Nagy képei földöntúli fénnyel ragyognak. Utolsó verseit a téboly mezsgyéjén írta: sötét mélységekből szólnak, homályosan, töredezetten, valami ősi tudással. Heine majd ötven évvel Goethe után született. Híres dalaiban mennyi sóhaj, könny, epekedés!\n
De elandalodásával kaján humor, szikrázó élc felesel. Vérbeli politikai költő is, nagy szatirikus. Hosszú éveken át ágyhoz kötve szenvedett. Fájdalmas, számvető remekeit a halállal szembenézve írta.",
                },

                new Book {
                    Id = 60,
                    Title = @"Dalok és szonettek",
                    Author = @"William Shakespeare",
                    Headline = @"",
                    NumberOfPages = 240,
                    Price = 1980,
                    PublishYear = 2003,
                    ShortDescription = @"William Shakespeare lírai költőként mint a Szonettek szerzője ismert, pedig számos egyéb kisebb költeményt is írt. Csakhogy ezek a versek drámáiban vannak elszórva mint betétdalok. Majdnem minden drámában előfordulnak ilyen lírai versek. Egy részük közvetlenül a drámai cselekményhez kapcsolódik, a szövegkörnyezetből kiszakítva nem állnak meg. Más részük azonban önálló költemények, önmagukban is élvezhető darabok. Ezek a pompás kis dalok, Shakespeare lírai tehetségének remekművei először jelennek meg magyarul egy kötetbe gyűjtve, klasszikus és mai Shakespeare-fordítók átültetésében. Egy-egy verset több fordításban is közlünk, a vers címe után jelölve, hogy melyik darabban hol hangzik el",
                },

                new Book {
                    Id = 61,
                    Title = @"Dsida Jenő versei",
                    Author = @"Dsida Jenő",
                    Headline = @"",
                    NumberOfPages = 264,
                    Price = 2380,
                    PublishYear = 2003,
                    ShortDescription = @"""Rövid az életem: leírni is csak röviden lehet. Tizenöt és fél éves voltam, amikor első versem - valami kis névnapi köszöntő - megjelent Benedek Elek nagyapó Cimborájá-ban, s akkor kaptam az első honoráriumomat. Azóta sem voltam olyan boldogan büszke és magammal megelégedett, mint akkor. Azóta sok mindent láttam a világban, és becsületesen próbáltam írni magamról és arról a sok mindenről, amit láttam. Szülővárosomból, Szatmárról négy éve kerültem Kolozsvárra, most itt végzem a jogi fakultás utolsó esztendejét (...) A szenvedést is megkóstoltam már, néhány évig állandóan levert voltam és szomorú. Most huszonkét éves vagyok..."" (Dsida Jenő fiatalkori önéletrajzából",
                },

                new Book {
                    Id = 62,
                    Title = @"Arany János balladái",
                    Author = @"Arany János",
                    Headline = @"",
                    NumberOfPages = 160,
                    Price = 1650,
                    PublishYear = 2002,
                    ShortDescription = @"A magyar költészetben a ballada fogalma elválaszthatatlan Arany János nevétől. ""A balladai homályt, balladai rövidséget kiválóan alkalmasnak találja, hogy egy sötét bűn és sötét bűnhődés legyen a tárgya... A virtuozitás itt abban van, hogy hogyan tudja a büntetést a bűnből logikával és az őrületnek bizonyos fokozatos bemutatásával kifejteni."" - írja róla Szerb Antal. Kötetünk ezeket a közkedvelt és népszerű verseket tartalmazza a történelmi balladáktól kezdve a népballadáig",
                },

                new Book {
                    Id = 63,
                    Title = @"Kínai és japán költők",
                    Author = @"",
                    Headline = @"",
                    NumberOfPages = 208,
                    Price = 1480,
                    PublishYear = 1999,
                    ShortDescription = @"A kötetben kínai és japán költők versei olvashatók Kosztolányi Dezső fordításában.",
                },

                new Book {
                    Id = 64,
                    Title = @"Matematika 6. tankönyv, bővített változat",
                    Author = @"Andrási Tiborné, Czeglédy István, dr. Czeglédy Istvánné",
                    Headline = @"",
                    NumberOfPages = 304,
                    Price = 2020,
                    PublishYear = 2008,
                    ShortDescription = @"2001-ben a szerzők az 5. és a 6. osztályosoknak szóló tankönyveket a kerettanterv követelményei szerint átdolgozták. Ezek a tankönyvek figyelembe veszik a különböző alsó tagozatos tankönyvekből tanuló osztályok eltérő színvonalát, az alsó tagozatos tananyag-redukciót, másrészt a kerettanterv által előírt új témaköröket. Az átdolgozás során a szerzők aktualizálták a szöveges feladatok adatait is. Az átdolgozott könyvek két (A és B) változatban jelennek meg. Az alapszintű tankönyvből (A változat) kimaradtak azok a fejezetek, amelyeket nem tartalmaz a kerettanterv. A bővített tankönyv (B változat) tartalmaz minden olyan anyagrészt, amely a korábbi tankönyvben is megtalálható volt, és amelyet ezen az évfolyamon a fejlett országokban tanítanak.",
                },

                new Book {
                    Id = 65,
                    Title = @"Matematika 4. Tankönyv, I. kötet",
                    Author = @"",
                    Headline = @"",
                    NumberOfPages = 216,
                    Price = 1470,
                    PublishYear = 2004,
                    ShortDescription = @"A negyedikes tankönyvben az anyagrészek csoportosítása, sorrendje olyan, hogy kellő idő jut az írásbeli műveletek, a kétjegyűvel való szorzás és osztás begyakorlására. Minden témakör ismételten foglalkozik a matematika gyakorlati alkalmazásával szöveges feladatokon, méréseken, statisztikai adatok vizsgálatán keresztül. A tankönyv a megszokottnál több lehetőséget ad a becslés megalapozására, a kerek számokkal történő szóbeli eljárások begyakorlásával. Az átlagosnál alaposabban dolgozza fel a geometria-tananyagot.
A Gyakorlóban megtalálhatók mindazok a feladatok, amelyek szükségesek az alapműveletek algoritmusának elsajátításához és begyakorlásához, a számolási készség fejlesztéséhez. A tankönyv és a gyakorló bőséges feladatválasztéka lehetővé teszi az igény szerinti válogatást.",
                },

                new Book {
                    Id = 66,
                    Title = @"Szöveges ki(s)számoló feladatok 3. osztályosoknak",
                    Author = @"Berkes Klára",
                    Headline = @"",
                    NumberOfPages = 56,
                    Price = 890,
                    PublishYear = 2008,
                    ShortDescription = @"A feladatgyűjtemény segítséget nyújt a kisiskolásoknak a szöveges feladatok értelmezésében, azok matematika nyelvén történő felírásában és a megoldásban; a tanítóknak a gyakorlás megtervezésében és a differenciálásban. E célok elérését eredményessé teszik a gyerekek életkorához, érdeklődési köréhez kapcsolódó mesébe illő feladatok, a kidolgozott mintafeladatok és az irányított példamegoldások.",
                },

                new Book {
                    Id = 67,
                    Title = @"Nagy kérdések: Matematika",
                    Author = @"Tony Crilly",
                    Headline = @"",
                    NumberOfPages = 208,
                    Price = 3500,
                    PublishYear = 2011,
                    ShortDescription = @"A Nagy kérdések sorozat réges-régi, alapvető, makacs és elmepróbáló tudományos talányokat vizsgál. Ebben a kötetben a számolás kezdeteitől és Platón ideáitól eljutunk a káoszelméletig és Fermat nevezetes tételéig; húsz problémát vehetünk szemügyre, csupa olyat, amely máig központi kérdésnek számít a matematikában.\n
\n
-Mire való a matematika?\n
-Honnan erednek a számok?\n
-Miért a prímszámok a matematika atomjai?\n
-Melyek a legkülönösebb számok?\n
-Képzeletbeliek-e a képzetes számok?\n
-Mekkora a végtelen?\n
-Hol találkoznak a párhuzamos egyenesek?\n
-Milyen a világegyetem geometriája?\n
-Csal-e a statisztika?\n
-Gazdaggá tehet-e a matematika?\n
-Van-e mindenre képlet?\n
-Miért nem elég három dimenzió?\n
-Kavarhat-e forgószelet a pillangó szárnycsapása?\n
-Alkothatunk-e feltörhetetlen kódot?\n
-Szép-e a matematika?\n
-Megjósolhatja-e a matematika a jövőt?\n
-Milyen alakú a világegyetem?\n
-Mi a szimmetria?\n
-Igaz-e a matematika?\n
-Maradt-e még megoldanivaló?\n
\n
Tony Crilly jelenleg a londoni Middlesex University matematikatanára. Korábban a University of Michigan, majd a hongkongi City University és az Open University tanáraként is oktatott. Főterülete a matematika tudománytörténete, de a fraktálok, a káosz és a számításelmélet témakörében is sok szakcikknek, kötetnek volt írója, szerkesztője.",
                },

                new Book {
                    Id = 68,
                    Title = @"Nagy kérdések: Világegyetem",
                    Author = @"Stuart Clark",
                    Headline = @"",
                    NumberOfPages = 208,
                    Price = 3500,
                    PublishYear = 2011,
                    ShortDescription = @"A Nagy kérdések sorozat réges-régi, alapvető, makacs és elmepróbáló tudományos talányokat vizsgál. Ebben a kötetben a Világegyetemmel kapcsolatos legizgalmasabb kérdéseket vehetjük sorra; olyan kérdéseket, amelyekre a legnagyobb gondolkodók és tudósok próbáltak választ keresni. Stuart Clark húsz kulcsfontosságú témát vesz górcső alá az asztronómia és a kozmológia tárgyköréből.\n
\n
-Mi a világegyetem?\n
-Mekkora a világegyetem?\n
-Mennyi idős a világegyetem?\n
-Miből vannak a csillagok?\n
-Hogyan alakult ki a Föld?\n
-Miért maradnak pályájukon a bolygók?\n
-Igaza volt-e Einsteinnek?\n
-Mi az a fekete lyuk?\n
-Hogyan keletkezett a világegyetem?\n
-Milyenek voltak az első égitestek?\n
-Mi az a sötét anyag?\n
-Mi a sötét energia?\n
-Csillagporból vagyunk?\n
-Van-e élet a Marson?\n
-Vannak-e odakint más értelmes lények?\n
-Átszelhetjük-e a teret és az időt?\n
-Változhatnak-e a fizika törvényei?\n
-Vannak-e más világegyetemek?\n
-Mi lesz a világegyetem sorsa?\n
-Van-e kozmológiai bizonyítékunk isten létére\n
\n
Stuart Clark szerzőként jegyzi a The Sun Kings, a Deep Space és a Galaxy nagy sikerű köteteit. Szerkesztette Nagy-Britannia legnépszerűbb csillagászati magazinját, cikkeit közölte egyebek közt a New Scientist, a BBC Focus, a The Times, a Guardian és az Economist, s világszerte elismert népszerűsítője a csillagászat tudományának.",
                },

                new Book {
                    Id = 69,
                    Title = @"A számítástudomány alapjai",
                    Author = @"Katona Gyula Y., Recski András, Szabó Csaba",
                    Headline = @"",
                    NumberOfPages = 192,
                    Price = 2900,
                    PublishYear = 2006,
                    ShortDescription = @"A véges matematika különféle lehetőségek összeszámlálásával, különféle struktúrákkal (például gráfelmélet) és algoritmusokkal foglalkozik. A számítógépek elterjedése óta mind a matematikában, mind annak (műszaki, közgazdaságtani, biológiai stb.) alkalmazásaiban különösen fontos szerepet játszik.\n 
A könyv elsősorban ezeket a témákat foglalja össze az ELTE és a BME matematikus, ill. alkalmazott matematikus hallgatói számára tartott Véges matematika vagy Kombinatorika és gráfelmélet című előadásokhoz. Emellett a számelmélet és az absztrakt algebra legfontosabb elemeibe is bevezetőt nyújt, hogy a BME villamosmérnök hallgatói számára tartott ""A számítástudomány elemei című"" tárgy anyagát és a BME műszaki informatikus hallgatói számára tartott Bevezetés a számításelméletbe című tárgy anyagának nagy részét is lefedje.\n
A könyv szerzői évtizedek óta oktatják ezeket a tárgyakat a Budapesti Műszaki és Gazdaságtudományi Egyetemen, valamint az Eötvös Loránd Tudományegyetemen. ",
                },

                new Book {
                    Id = 70,
                    Title = @"Valószínűségszámítás és matematikai statisztika",
                    Author = @"Obádovics J. Gyula",
                    Headline = @"",
                    NumberOfPages = 336,
                    Price = 2990,
                    PublishYear = 2009,
                    ShortDescription = @"A valószínűségszámítás és matematikai statisztika módszereinek alapos ismerete ma már nélkülözhetetlen a gazdasági, műszak, természet- és társadalomtudományi területeken dolgozó szakemberek munkája során. Épp ezért szükséges, hogy az iskolás évek alatt, a középiskolás kortól megismerjék a diákok, egyetemi hallgatók e tudományterület alapjait, azt a gondolkodásmódot, amely világunk működésének megértéséhez, a mindennapi tájékozódáshoz egyre elengedhetetlenebbé válik.",
                },

                new Book {
                    Id = 71,
                    Title = @"A szépség geometriája, a geometria szépsége",
                    Author = @"Halász Ágnes",
                    Headline = @"A rózsaablakok titkai",
                    NumberOfPages = 180,
                    Price = 6800,
                    PublishYear = 2012,
                    ShortDescription = @"A könyvet ajánljuk mindazoknak, akiket lenyűgöz az emberi alkotások sokszínűsége, a szárnyaló fantázia megannyi csodája, a változatosságban rejlő hasonlatosságok felfedezése. A díszítőművészet gazdagsága időrendet és távolságot felrúgva, meglepő módon, újraszüli, sőt ismétli önmagát: mintha egy végtelen logikai láncra kínálkozna.",
                },

                new Book {
                    Id = 72,
                    Title = @"Kémiai elemek",
                    Author = @"Theodore Gray",
                    Headline = @"Kalandozás a Világegyetem atomjai között",
                    NumberOfPages = 240,
                    Price = 5999,
                    PublishYear = 2011,
                    ShortDescription = @"Tiszta tudomány és káprázatos fotóanyag - aki értelmes, érzékeny lény csak a Világegyetemet lakja, mindnek sok örömöt hozhat, sok új ismeretet nyújthat ez a pompás kötet.\n
A periódusos rendszer adta forgatókönyv szerint vonulnak föl előttünk az elemek, ahol csak lehet, rögtön vegytiszta formában, pazar kiállításban. Illegetik magukat kicsit, megmutatják minden hasznukat és tudásukat, kérkednek vegyületeikben betöltött szerepükkel, mindennapi életünkben elfoglalt helyükkel. Természetesen a kelletlen, rejtőzködő, megfoghatatlanul rövid életű elemekről is szó esik, hiszen így teljes a kép.\n
Minden oldalpár egy-egy fényképes igazolvány ebben a kötetben. A fotókhoz mellékelt személyleírás érdekes históriákat közöl, kuriózumokkal szolgál, jellemrajzot taglal - a lehető legalaposabb bemutatóját adja az illető kémiai elemnek. Persze kötelező a természettudományos pontosság: minden fontos és árulkodó tulajdonság - atomtömeg, atomsugár, kristályrácsrajz, elektronhéj-szerkezet, emissziós spektrum, halmazállapot megjelenik az elemek személyi adatai között. Ami pedig magát a periódusos rendszert illeti, ahhoz is használati utasítást mellékel a könyv, egysersmind az elemek egyedi és közös vonásaira is magyarázattal szolgál.",
                },

                new Book {
                    Id = 73,
                    Title = @"Száz kémiai mítosz",
                    Author = @"Lente Gábor, Kovács Lajos, Gunda Tamás, Csupor Dezső",
                    Headline = @"Tévhitek, félreértések, magyarázatok",
                    NumberOfPages = 596,
                    Price = 4200,
                    PublishYear = 2011,
                    ShortDescription = @"""(...) A Szegedi Tudományegyetem és a Debreceni Egyetem négy kutatója ara a feladatra vállalkozott, hogy megpróbál a sok-sok tévhitünk közül száz olyannal szembesíteni bennünket, amelyek valamilyen módon köthetők a kémia tudományához és kémiai ismereteink hiányosságaihoz. Jogos-e a mesterséges anyagoktól való félelmünk? Igaz-e, hogy a természetes anyagok csak jók és egészségesek lehetnek? Mi a veszélyesebb: az ismert mellékhatású gyógyszerek vagy az ismeretlen hatású ""csodaszerek"" szedése? Valóban a ""bio""-e a jövő az élelmiszerek és az üzemanyagok terén? Ilyen és ehhez hasonló kérdések húzódnak meg a tudományos igényesség és az olvasmányosság határán egyensúlyozó írások mögött. (...)"" (Tóth Zoltán) ",
                },

                new Book {
                    Id = 74,
                    Title = @"Elválasztástechnikai módszerek elmélete és gyakorlata",
                    Author = @"Kremmer Tibor, Torkos Kornél",
                    Headline = @"",
                    NumberOfPages = 280,
                    Price = 5200,
                    PublishYear = 2010,
                    ShortDescription = @"""Az elválasztási műveletek kezdetleges vagy kifinomult formái (fajtázás, szitálás, szűrés stb.) ősidők óta az alapvető emberi tevékenységek közé tartoznak. Fejlődésük az ókortól kezdve a középkori alkimistákon keresztül az újkor és az ipari forradalom eredményein át a modern tudományos és technikai eljárásokig az emberiség kultúrtörténetének jelentős részét képezi. Általában megállapítható, hogy a különböző elválasztástechnikák tapasztalati úton, az anyagi világ jelenségeinek és törvényszerűségeinek megismerésével szoros kölcsönhatásban, annak részeként és igényeként alakultak ki.\n
Könyvünk az egyetemi tananyagot kiegészítve az elméleti alapok tárgyalásán túlmenően az elválasztástechnika modern módszereiről (mintaelőkészítés, kromatográfia, elektroforézis és ultracentrifugálás) és fontosabb alkalmazási területeiről kíván áttekintést adni. Az egyes fejezetekben bemutatott gyakorlati példák a (bio)analitikában, a biológiai és biokémiai kutatásokban, laboratóriumi diagnosztikában dolgozó szakemberek széles körének érdeklődését figyelembe véve főleg a biotechnológia, az élettan és a kórélettan szempontjából fontos alkalmazási területeken és vegyületcsoportokon (enzimek, fehérjék, gliko- és lipoproteinek, mono- és oligoszacharidok, nukleozidok, nukleotidok stb.) kívánják bemutatni a korszerű elválasztástechnikai módszerek széles spektrumát és alkalmazhatóságát."" (a Kiadó)",
                },

                new Book {
                    Id = 75,
                    Title = @"Vizsgálódás a nemzetek jólétének természetéről és okairól I-II.",
                    Author = @"Adam Smith",
                    Headline = @"Az eredeti, teljes szöveg új kiadása",
                    NumberOfPages = 1196,
                    Price = 5800,
                    PublishYear = 2011,
                    ShortDescription = @"A kötet, amelyet kezében tart az olvasó, a ""Vizsgálódás..."" 1940-ben megjelent, utolsó teljes magyar kiadásának reprintje. Kiadónk azért vállalkozott a teljes szöveg közlésére ebben a formában, mert úgy vélte, a reprint kiadás hangulata tükrözi a legjobban, hogy egy klasszikus szerző klasszikus köntösben is tud nagyon korszerű és időtálló maradni.\n
A szöveget új előszóval és új tárgymutatóval láttuk el annak érdekében, hogy napjaink közgazdasági nyelvezetére minél könnyebben konvertálható legyen Smith szövege, és ezáltal mind jobban rávilágítsunk, mennyire előremutatóan, időszerűen és modernül gondolkodott a maga korában; nem lekicsinyítve ezzel azt az igen fontos célunkat, hogy minél jobban segítsük korunk diákjait abban, hogy megismerjék és megértsék ezt a minden szavában, mondatában fontos alapművet.",
                },

                new Book {
                    Id = 76,
                    Title = @"Gazdasági kislexikon és képletgyűjtemény",
                    Author = @"Zugorné Rácz Éva",
                    Headline = @"",
                    NumberOfPages = 168,
                    Price = 2910,
                    PublishYear = 2003,
                    ShortDescription = @"Kötetünk két témakörben nyújt segítséget a közgazdaság, a kereskedelem-marketing, valamint a vendéglátás-idegenforgalom szakmacsoporthoz tartozó képzések tanulóinak.",
                },

                new Book {
                    Id = 77,
                    Title = @"Vállalat és vállalkozás",
                    Author = @"Stefan Kassay",
                    Headline = @"Vállalkozói környezet - A tulajdonszerkezet változása a gazdasági átmenet időszakában",
                    NumberOfPages = 706,
                    Price = 8000,
                    PublishYear = 2012,
                    ShortDescription = @"A könyv a széles szakmai közönséget kívánja megszólítani. A posztgraduális képzések, átképző tanfolyamok résztvevőinek, doktoranduszoknak és egyéb felsőfokú tanulmányokat folytató hallgatóknak megkönnyíti e bonyolult problémakör tanulmányozását. A könyv hidat képez elmélet és gyakorlat között, vállalattulajdonosok, részvényesek, vállalati felső- és középvezetők számára használható. Különböző szakterületek szakemberei számára hasznos, ugyanis a tárgyalt témákat szemléletileg az irányítás mint univerzális jelentőségű tudományterület fogja át.",
                },

                new Book {
                    Id = 78,
                    Title = @"A szocialista rendszer",
                    Author = @"Kornai János",
                    Headline = @"",
                    NumberOfPages = 672,
                    Price = 4990,
                    PublishYear = 2012,
                    ShortDescription = @"A kiadvány ""Kornai János válogatott művei"" sorozat második kötete.\n
A szerző számos munkájában foglalkozott a szocializmus egyik vagy másik problémájával. ""A szocialista rendszer"" az a könyv, amelyben a szerző nem csupán összefoglalja sok évtizedes kutatásainak eredményét, de újabb dimenziókkal is gazdagítja a szocialista rendszer elemzését.",
                },

                new Book {
                    Id = 79,
                    Title = @"Aktív szabályozás vagy gazdaságpolitikai nihilizmus?",
                    Author = @"Galbács Péter",
                    Headline = @"",
                    NumberOfPages = 420,
                    Price = 4600,
                    PublishYear = 2012,
                    ShortDescription = @"""Ez a könyv egy igazságkereső mű. Elolvasását javaslom mindazoknak, akik a közgazdaságtan versengő elméleteinek felszínes ismerete alapján arra a következtetésre jutottak, hogy e tudományterületen relatív minden állítás. E könyv nemcsak elmélyítheti tudásunkat, de kiváló módszertanú, logikusan érvelő kritikai elemzéssel rávilágít arra is, hogy melyik irányzat milyen módon és mértékben segítette megismerni -vagy éppen félreismerni- a makrogazdaság működését, s ezáltal hogyan járult hozzá a monetáris és a fiskális politika megalapozásához, illetve hogyan lehetett okozója téves gazdaságpolitikai döntéseknek. A könyv olykor ""csak"" fontos kérdések megfogalmazásáig jut el, megadva a továbbgondolás esélyét az igazság kereséséhez csatlakozó, elmélyült olvasójának."" ( Dr. Pulay Gyula)",
                },

                new Book {
                    Id = 80,
                    Title = @"Az európai közösségi versenyjog közgazdaságtana",
                    Author = @"Simon Bishop, Mike Walker",
                    Headline = @"Alapfogalmak, alkalmazások és mérési módszerek",
                    NumberOfPages = 804,
                    Price = 6000,
                    PublishYear = 2011,
                    ShortDescription = @"A kötet az európai közösségi versenyjog alkalmazásához kapcsolódó közgazdasági elméletet és elemzési módszereket mutatja be. E terület egyre jelentősebbé válik, hiszen a hatóságok a versenykorlátozó viselkedéssel kapcsolatos döntéseikben egyre gyakrabban támaszkodnak közgazdasági érvelésre is.\n
A szerzők, akik munkájuk során a versenyszabályozás közgazdaságtanának alkalmazásában komoly tapasztalatot szereztek, lényegre törően, a könnyebb megértést segítve közelítenek a komplex és bonyolult témához.",
                },

                new Book {
                    Id = 81,
                    Title = @"A nemzetközi és a világgazdaságtan alapjai",
                    Author = @"Csáki György",
                    Headline = @"",
                    NumberOfPages = 400,
                    Price = 4200,
                    PublishYear = 2011,
                    ShortDescription = @"E kötet elsősorban a felsőfokú oktatás céljaira készült tankönyv, de haszonnal forgathatják mindazok az olvasók is, akik szeretnék megismerni és megérteni napjaink világgazdasági történéseinek, a pénzügyi világ eseményeinek hátterét.\n
A kötet tartalmazza a nemzetközi gazdasági kapcsolatok legfőbb elméleti jellemzőit (ez a nemzetközi gazdaságtan), ezen túl azonban azt elméleti kérdésekkel gyakorlatilag azonos terjedelemben tárgyalja a világgazdaság fejlődésének és mai jellemzőinek empirikus leírását - ezt tükrözi az új címben a „világgazdaságtan” kategóriája. A 2007-2008-ban kitört globális válság többoldalú elemzése hozzásegíti az olvasót napjaink legfontosabb világgazdaságtani folyamatainak megértéséhez is.\n
A kötet számos ábrával, táblázattal és a klasszikus és modern szakirodalomból válogatott szemelvényekkel is segíti a logikusan felépített ismeretanyag átláthatóságát és elsajátítását.",
                },

                new Book {
                    Id = 82,
                    Title = @"A közgazdaságtan alapjai",
                    Author = @"N. Gregory Mankiw",
                    Headline = @"",
                    NumberOfPages = 640,
                    Price = 5980,
                    PublishYear = 2011,
                    ShortDescription = @"Mankiw könyvének megjelenése magyarul nagy jelentőségű szakmai esemény. Mankiw nemcsak komoly elméleti szakember, hanem az Egyesült Államok gazdaságpolitikájának aktív formálója is.\n
A közérthető nyelven, de tudományos színvonalon megírt tankönyv tartalmazza a szükséges ismereteket, átfogó képet rajzol, amelybe a hallgató belehelyezheti az egyes tárgyakban megszerzett, mozaikszerű ismereteit.\n
A kiadvány egyaránt ajánlható közgazdászoknak, üzletembereknek, jogászoknak, de szociológusoknak, politológusoknak is.",
                },

                new Book {
                    Id = 83,
                    Title = @"Új közgazdaságtan",
                    Author = @"Kopátsy Sándor",
                    Headline = @"A minőség társadalma",
                    NumberOfPages = 360,
                    Price = 3990,
                    PublishYear = 2011,
                    ShortDescription = @"Magyarország egyik legismertebb közgazdászának több mint fél évszázados pályája a gazdasági reformprogramoktól a rendszerváltás privatizációjának ellenőrzésén át napjaink újszerű közgazdasági szemléletének megalkotásáig ível. A Kádár-korszakban fekete báránynak tartott Kopátsy Sándor munkásságát Matolcsy György nemrégiben ""második alma materének"" nevezte - s hogy miért, az érthetővé válik az ""Új közgazdaságtan - A minőség társadalma"" című kötet olvastán.",
                },

                new Book {
                    Id = 84,
                    Title = @"Gyógynövény embernek, állatnak, növénynek",
                    Author = @"Csurgó Sándor",
                    Headline = @"",
                    NumberOfPages = 172,
                    Price = 2200,
                    PublishYear = 2001,
                    ShortDescription = @"A szerző 20 éve foglalkozik gyógynövényekkel és a természetes gyógyító módszerek megismerésével. Ennek a két évtizednek az esszenciája ez a könyv, hiszen a természet végtelen tárházából csupán 20 gyógynövényt mutat be részletesen. A gyógynövények leírásán, gyűjtésén, felhasználási formáján kívül ismerteti az alkalmazási lehetőségeket a különböző betegségek, tünetek enyhítésére, de kitér a homeopátiás alkalmazási módokra is. Újszerű a könyvben, hogy a gyógynövények állatgyógyászati alkalmazását és a biológiai gazdálkodásban betöltött szerepüket is hangsúlyozza.",
                },

                new Book {
                    Id = 85,
                    Title = @"Szivárványkönyv",
                    Author = @"Dóry Béla",
                    Headline = @"Közjótan és magyar nemzetgazdaság",
                    NumberOfPages = 112,
                    Price = 1800,
                    PublishYear = 2010,
                    ShortDescription = @"E könyvben a közjótan téziseinek tudatos alkalmazása mellett meg kívánjuk alkotni a magyar gazdasági modellt. Ennek külön aktualitást ad a könyv írásának utolsó pillanatában lezajlott magyar országgyűlési választás. A demokrácia diadalaként óriási többséget szerzett egy olyan párt, amelyik a válságból Magyarországot kivezetni kívánja. Ennek a kísérletnek a sikere számos tényezőn múlik, de egy biztos, sikerre csak akkor van remény, ha a magyar értelmiség és a magyar felsőoktatásban tanulók a célkitűzéseket támogatni tudják, és azokkal azonosulni tudnak. Nekik és a döntéshozóknak szól ez a könyv, amely megkísérli a magot az ocsútól elválasztani. Természetesen közjótanunk alkalmazható minden nemzet esetére. Ahány nemzet, annyi megoldás. Egy azonban közös bennük: a javasolt megoldások célfüggvénye a közjó.",
                },

                new Book {
                    Id = 86,
                    Title = @"Vadbiológiai olvasókönyv",
                    Author = @"",
                    Headline = @"",
                    NumberOfPages = 206,
                    Price = 4200,
                    PublishYear = 2010,
                    ShortDescription = @"Ebben a kötetben a Szent István Egyetem Vadvilág Megőrzési Intézete (Gödöllő) munkatársainak az elmúlt években főként a vadászati sajtóban közölt írásait találja az érdeklődő. Megtudhatjuk, hogy mi a vadbiológia, miért érdekes az itt dolgozók munkája és mi az, amivel a legszívesebben foglalkoznak.",
                },

                new Book {
                    Id = 87,
                    Title = @"Emlős ragadozók Magyarországon",
                    Author = @"",
                    Headline = @"",
                    NumberOfPages = 240,
                    Price = 3500,
                    PublishYear = 2010,
                    ShortDescription = @"A hazai emlős ragadozók többnyire rejtett életet élnek és ritkán lehet őket megfigyelni. Az alkalmankénti, általában izgalmas közvetlen találkozások mellett, legtöbbször csak jelekből, nyomokból, zsákmánymaradványokból, kotorékokból vagy odúkból, esetleg a fellelhető ürülékekből következtethetünk egy-egy ragadozó jelenlétére. Ezért aztán nem véletlen, hogy e fajokról ismereteink sokszor még annál is hiányosabbak, mint gondolnánk. A természet és a biológia iránti érdeklődés mellett valószínűleg az ismeretlenség is hozzájárul ahhoz, hogy mintegy negyed évszázaddal ezelőtt az ország több egyetemén, fiatal kutatók figyelme az emlős ragadozók felé fordult.\n
A kötet szerzői az elmúlt bő két évtizedben felhalmozott ismereteiket mutatják be, jó szívvel ajánlva a természetet figyelő és szerető olvasóinknak.",
                },

                new Book {
                    Id = 88,
                    Title = @"Genetika - Képes enciklopédia",
                    Author = @"Enzo Gallori",
                    Headline = @"Az élet kémiai alapjai, az evolúció törvényei, a jövő nagy reményei és aggodalmai",
                    NumberOfPages = 232,
                    Price = 5990,
                    PublishYear = 2010,
                    ShortDescription = @"Az élet misztériuma be van zárva minden sejtünk egy-egy molekulájának szívébe: ezt foglalja el a genetika, az a tudomány, amely - két évszázada - igyekszik megérteni azon törvényeket, melyek a biológiai evolúciót irányítják.\n
Miután Mendel sikeresen elvégezte kísérleteit a borsónövényekkel, úgy tűnhetett, már nem is maradt több felfedezni való. Azonban sok még az ismeretlen terület, és a legkülönlegesebbek elvezetnek bennünket az élet eredetéhez, továbbá az első élőlények kialakulásához, az egyetlenekhez, melyekről biztosan tudjuk, hogy jelen vannak az univerzumban.\n
A gyönyörű és részletekben gazdag ábrák, rajzok és képek, az olvasmányos szöveg elvezet bennünket a szabályok megértéséhez, és közben felfedezhetjük a köztünk és más élőlények közötti különbséget, ami nem is olyan nagy.",
                },

                new Book {
                    Id = 89,
                    Title = @"Génháború",
                    Author = @"Tóth Gábor",
                    Headline = @"A genetikailag módosított élelmiszerek kockázatai",
                    NumberOfPages = 160,
                    Price = 1450,
                    PublishYear = 2004,
                    ShortDescription = @"A genetikai módosítással kapcsolatban egyre több kétely merül fel orvosban, közgazdászban, természetvédőben, gazdálkodóban és fogyasztóban egyaránt. Nem is alaptalanul, hiszen a korábban riogatásnak tartott borúlátó vélekedések igazolódni látszanak a jelenben, és árnyékot vetnek a jövőre. 
A géntechnológián belül a legkritikusabb területet a genetikailag módosított élelmiszerek jelentik. Egyes orvosok és biológusok humán-egészségügyi és ökológiai katasztrófától tartanak, míg a politikusok és a közgazdászok egy része a társadalmi egyenlőtlenségek fokozódását, a hatalom és tőke még teljesebb koncentrálódását jósolja a ""GM"" élelmiszerek elterjedésével párhuzamosan. Valósak-e az aggodalmak? Erre keresnek választ könyvünk első fejezetei.\n
A géntechnológia témakörének igen érdekes és tanulságos gazdaságpolitikai vonatkozásai is vannak. A hatalmi harcok, érdekellentétek, diplomáciai ügyeskedések és tudományos köntösbe bújtatott vonzó ideológiák ezt a területet sem kerülhették el.\n
De óvatosságra intik-e az Európai Unió szakembereit a vészjósló híradások, vagy az öreg kontinens követi az Újvilágot? Miért kell foglalkozni a génmódosítással Magyarországon és a pannon régióban? Jelen vannak-e hazánkban a génmódosított élelmiszerek, és mi várható a jövőben? Ezek a témakörök is kötetünk fókuszába kerültek.\n
A ""génháború"" kimenetelét nem a hatalom vagy a pénz, hanem a fogyasztó döntheti el. De érdekli-e egyáltalán a hétköznapi embert a génmódosítás? Él-e a szabad termékválasztás lehetőségével a vásárló, vagy továbbra is szokásszerűen teszi kosarába az élelmiszereket? Egészségünket és környezetünket meghatározó kérdések lehetnek ezek a közeljövőben, s ez magyarázza, miért is íródott e könyv.",
                },

                new Book {
                    Id = 90,
                    Title = @"Egy klónozó vallomásai",
                    Author = @"Vajta Gábor",
                    Headline = @"A klónozást bemutató CD-filmmelléklettel",
                    NumberOfPages = 304,
                    Price = 2800,
                    PublishYear = 2004,
                    ShortDescription = @"A könyv célja, hogy a klónozás problémáját, a szokásostól eltérően, a klónozók szemszögéből mutassa be, elemezve a tudomány történetében páratlan helyzet okait és lehetséges következményeit. Hogyan fejlődhetett idáig ez az egész? Mi az, amit a klónozók tudnak, és ami az egész világot rettegésben tartja? Mit értenek, és mit értenek félre az emberek a klónozók munkájában? Mi motiválja és mi keseríti el a klónozókat, miként látják a perspektívákat? Mik a klónozás legújabb elméleti és gyakorlati eredményei, és miként befolyásolhatják ezek az eredmények a jövőt? 
A könyv, és az ajándék CD-film, amely a klónozást a gyakorlatban is bemutatja, a megalapozott tudományos ismeretekkel, esetleg tapasztalatokkal rendelkező érdeklődők és a laikusok számára is közérthetően, ritka empátiával szól mindezekről.",
                },

                new Book {
                    Id = 91,
                    Title = @"Száműzött",
                    Author = @"R. A. Salvatore",
                    Headline = @"Sötételf-trilógia II. könyv",
                    NumberOfPages = 344,
                    Price = 2490,
                    PublishYear = 2004,
                    ShortDescription = @"A Do'Urden-ház meghasonlott fia évekig bolyong Mélysötét vadonjában. A túlélésért folytatott kegyetlen harc és a kínzó magány - melyet csupán egyetlen társa, Guenhvywar, a párduc jelenléte enyhít -, kis híján felemészti lelkét. Hogy véget vessen szenvedéseinek, bebocsátást kér Kacsintókőre, a drow-k legádázabb ellenségeinek, a mélységi gnómoknak városába. 
Malice anya keze azonban itt is eléri.",
                },

                new Book {
                    Id = 92,
                    Title = @"Az élet alapkérdései",
                    Author = @"I. N. Smeretle",
                    Headline = @"Gén, ember, társadalom",
                    NumberOfPages = 210,
                    Price = 1970,
                    PublishYear = 2012,
                    ShortDescription = @"""Miben különbözünk a csimpánztól? Hogyan alakult ki az emberiség, és mi teszi az embert emberré? Miért van férfi és nő, miért van vágy és szerelem? Van-e közük a géneknek a viselkedésünkhöz7? Hogyan lehet összeegyeztetni az ember biológiai természetét társadalmi szerepével? Vajon a génjeink mindenbe ""beleszólnak""? Mindenért a génjeink a felelősek és mi semmiért sem? Vagy netán fordítva van? Milyen párhuzamok figyelhetők meg a genetika és az informatika között? Az apró kémiai ""jelek"" láthatatlan sorrendje hogyan képes életet lehelni a holt anyagba? És mindez hová vezet? A magyarság eredetét a nyelvi vagy az etnikai vonalon érdemes követni? Vannak-e külön génjei a magyaroknak? Különböznek-e tőlünk genetikailag a szomszédnépek, a zsidók, a cigányok, a kínaiak vagy a négerek?\n
Az ezredfordulótól kezdve a biológiai tudományok az elektronikáéhoz hasonlítható sebességre kapcsoltak. A DNS-vizsgálatok betekintést engednek a múltba és a jövőbe is: egyrészt az emberiség kialakulására és vándorlásaira következtethetünk vissza, másrészt egyre inkább megjósolhatjuk az újszülöttek jövendő hajlamait és megbetegedéseit. De hogyan fog az új látásmód beszivárogni a kemény magyar koponyákba? Ezt szeretné a szerző elősegíteni ezzel a gondolatébresztő könyvvel. Tankönyv, kézikönyv, vitaindító, vagy ahogy tetszik. Ajánljuk mindazoknak, akik nyitottak az ""új idők új dalai"" iránt, és akik fáradságot nem kímélve a dolgok mélyére kívánnak hatolni."" (a Kiadó)",
                },

                new Book {
                    Id = 93,
                    Title = @"Nautilus és Sapiens",
                    Author = @"Monika Offenberger",
                    Headline = @"Bevezetés az evolúcióelméletbe",
                    NumberOfPages = 128,
                    Price = 1980,
                    PublishYear = 2006,
                    ShortDescription = @"A szerző lépésről lépésre végigköveti azt a fejlődést, melynek során - Darwinnak a ""Beagle"" fedélzetén megtett útjából kiindulva - egyre elfogadottabbá vált a felismerés, mely szerint a szaporodás során, az együttműködési vagy ellenségstratégiák következtében érvényesülő előnyök tették egyáltalán lehetővé az élet sokféleségét.",
                },

                new Book {
                    Id = 94,
                    Title = @"Az emberi test",
                    Author = @"Sarah, dr. Brewer",
                    Headline = @"Bevezetés az emberi anatómiába",
                    NumberOfPages = 224,
                    Price = 6990,
                    PublishYear = 2011,
                    ShortDescription = @"Az emberi test egyedülálló áttekintése a bőrtől a csontvázig.\n
Több mint háromszázötven korszerű anatómiai kép és grafikai illusztráció.\n
Feliratozott ábrák és érdekes tények minden fejezetben.\n
Dr. Sarah Brewer teljes áttekintést ad minden fő testi rendszerről - az izmoktól a védekezési rendszerig, az emésztéstől a szaporodásig.",
                },

                new Book {
                    Id = 95,
                    Title = @"Élő természet: Állatvilág",
                    Author = @"Róbert Ceman",
                    Headline = @"Földrajzi enciklopédia",
                    NumberOfPages = 186,
                    Price = 2999,
                    PublishYear = 2006,
                    ShortDescription = @"A könyv megismerteti az olvasót az élő természet különös jelenségeivel. Az állatvilág rekordjain kívül egységes képet nyújt a Földünkön élő állatokról és egyben rámutat a jelenkori és korábbi környezettel való kapcsolatukra. Mindenkinek szól, akit érdekel a természet, a biológia, a földrajz és jó és jó szolgálatot tesz természettudományos órákon is. A színes fényképeken természetes környezetükben láthatjuk a ma élő állatokat, míg a régmúlt idők állatait a leleteik alapján készített rajzok szemléltetik.\n
A szöveges leírásokat konkrét adatok és érdekes történetek teszik tartalmassá. Az állatföldrajzi övezetek ismertetését látványos térképek egészítik ki.",
                },

                new Book {
                    Id = 96,
                    Title = @"Kukockij esetei",
                    Author = @"Ljudmila Ulickaja",
                    Headline = @"",
                    NumberOfPages = 504,
                    Price = 3490,
                    PublishYear = 0,
                    ShortDescription = @"A Kukockij esetei című regény különleges helyet foglal el az eddigi életműben. Igazi elbeszélőkedvvel, a klasszikus orosz próza legjobb hagyományait követve - és azokat a mai kor embere számára ""fogyaszthatóan"" megújítva - mesél el egy nagy ívű, a XX. század közepének Oroszországában játszódó családtörténetet, amelyben azonban a család csak a legnagyobb jóindulattal nevezhető családnak. A regény főhőse, Pavel Kukockij doktor, a kiváló nőgyógyász különleges képességekkel rendelkezik: ""belső látásával"" - mintha csak röntgenszeme lenne - érzékeli a méhet, a magzatot, a női szervezet felépítését, egészen a sejtszerkezetig. Kukockij doktor mégsem tud boldog, kiteljesedett életet élni: karrierje megbicsaklik a szovjet hivatalokkal az abortusz elismertetéséért folytatott reménytelen küzdelemben, házassága Jelenával, az egyre jobban a látomások világába forduló szeretett nővel fokozatosan tragédiába torkollik, nevelt lányával, akinek életsorsa szintén szövevényessé válik, egyre inkább elveszíti a kapcsolatot - és végül Kukockij doktor a kilátástalan helyzetből az alkoholizmusba menekül.\n
""Életem jelentős része összefonódott a biológiával, de a sors szeszélye folytán más partokra vetődtem. Azok az évek azonban mély nyomot hagytak bennem. Akkoriban döbbentem rá, hogy az orvos foglalkozása az áldozópap tevékenységével áll rokonságban, és akkoriban vetődtek fel bennem először az afféle bonyolult kérdések is, mint hogy hol az emberi szabadság határa, hol húzódik a határ egészség és betegség, élet és halál között... A Kukockij eseteiben nincsenek válaszok ezekre a kérdésekre, csupán gondolatok vannak, belső elmozdulás abba az irányba, ahonnan a válaszok érkezhetnek. Az ember életében előbb-utóbb eljön az a pillanat, amikor e gondolatok megkerülhetetlenné válnak."" - nyilatkozta Ulickaja a regényről.",
                },

                new Book {
                    Id = 97,
                    Title = @"Emma lánya",
                    Author = @"Fábián Janka",
                    Headline = @"",
                    NumberOfPages = 512,
                    Price = 3499,
                    PublishYear = 2011,
                    ShortDescription = @"A számos félreértés és viszontagság után egymásra talált párnak, az elismert gyerekorvosnak, Kóthay Gábornak és feleségének, a sikeres írónőnek, Emmának a három fiú után végre lánya születik. A szépséges, aranyhajú Éva színésznőnek készül, ám közbeszól a háború, majd a kommunista diktatúra. Évát és családját osztályellenségnek minősítik, kitelepítik.  Az 1956-os forradalom után, amelyben ilyen-olyan módon szinte minden Kóthay részt vesz, a família tagjai ismét elszakadnak egymástól. Emma a lányával, Évával és az unokájával egy rövid párizsi megálló után Amerikába emigrál, Tamásék azonban az otthon maradás mellett döntenek.\n
A század második felének eseményeit a szélrózsa minden irányába szétszóródó Kóthay gyerekek és unokák különbözőképpen élik meg. A forradalmat követő megtorlás, 1968 Párizsa, a hatvanas-hetvenes évek Amerikája, a szögesdróton inneni nyomasztó világ, a kései Kádár-korszak békés álarca mögött a szabadság fájó hiánya, majd a rendszerváltás éppen úgy főszereplői a könyvnek, mint az egyre népesebb família. Végül, a fordulat évében egy boldog-szomorú esemény kapcsán újra összegyűlik az egész család a régi, Balaton-parti házban, ahol az is kiderül, hogy habár végleg lezárult egy korszak, lesz, aki továbbviszi Emma örökségét.\n
A történész végzettségű fiatal írónő váratlan fordulatokban, hol vidám, hol felemelő, hol szívszorító pillanatokban bővelkedő regénye befejező része a háromkötetes családregénynek, amely egészen a XX. század végéig követi nyomon a Kóthay család több nemzedékének életét.",
                },

                new Book {
                    Id = 98,
                    Title = @"Rém hangosan és irtó közel",
                    Author = @"Jonathan Safran Foer",
                    Headline = @"A 2 Oscar-díjra jelölt film alapjául szolgáló regény",
                    NumberOfPages = 388,
                    Price = 2990,
                    PublishYear = 2009,
                    ShortDescription = @"A New York Times bestsellere, az év legjobb könyve a Los Angeles Times, a Washington Post Book World, a Chicago Tribune, a St. Louis Post-Dispatch és a Rocky Mountain News szerint.\n
\n
Jonathan Safran Foer már első, ""Minden vilángol"" című nagy sikerű könyvével generációja egyik legeredetibb írójaként tűnt fel. Új regényében humorral, gyengédséggel és félelemmel vegyes tisztelettel néz szembe kortárs történelmünk traumáival.\n
A kilencéves Oskar Schell titkos küldetésre indul, melynek során végigjárja New York öt kerületét. Célja, hogy megtalálja azt a zárat, amelybe beleillik az a rejtélyes kulcs, ami a szeptember 11-én a World Trade Centerben meghalt édesapjáé volt. A látszólag lehetetlen feladatra vállalkozó Oskar számtalan túlélővel kerül kapcsolatba kalandos, megindító és végül megnyugvást hozó utazása során. \n
\n
Mit tegyen az ember, ha Manhattanben él, kilencéves, és feltaláló, ékszertervező, ékszerkészítő, amatőr entomológus, frankomán, vega, origamista, pacifista, dobos, amatőr csillagász, számítógép-tanácsadó, amatőr régész, továbbá ritka pénzérmék, természetes halált halt pillangók, miniatűr kaktuszok, Beatles-kegytárgyak, féldrágakövek és egyebek gyűjtője?\n
Mit tegyen az ember, ha kilencéves, és 2001. szeptember 11-e óta nem látta az apját? Ha nincs más fogódzója, csak a régi holmik, és az üzenetrögzítő magnószalagja apja utolsó telefonhívásaival, amit el kell rejtenie az anyja elől? Mit tegyen, ha talál egy titokzatos borítékot az apja szekrényében, amelyben csak egy kulcs lapul, és a papíron egyetlen szó: Black?\n
Viszonylag egyszerű: fel kell keresni az összes Black nevű embert New Yorkban, és megtudakolni, hogy milyen zárat nyit a kulcs. Ami 216 lakáscím. Vagy megkeresni a zárat, bár minden 2777-ik másodpercben egy újabb zár születik New Yorkban. Kissé bonyolítja a dolgot, hogy hősünk betegesen retteg a tömegközlekedéstől, ezért mindenhova gyalog megy.\n
És persze számos más megválaszolandó kérdés akad. Vajon szerelmes lesz-e még egyszer a mama? Ki a titokzatos bérlő, aki beköltözött a nagyihoz? Mit rejt a magnószalag, amin a papa utolsó üzenetei vannak?\n
Erre ad választ Jonathan Safran Foer több nemzedéken átívelő családtörténete. Egy megrendítő regény, egy elképesztő intelligenciájú és képzelőerejű kisfiú odisszeiája, aki a World Trade Center összeomlásakor eltűnt papáját keresi.\n
\n
A könyv alapján készült, két Oscar-díjra jelölt filmet Sandra Bullock és Tom Hanks főszereplésével március 8-tól játsszák a hazai mozikban.",
                },

                new Book {
                    Id = 99,
                    Title = @"Az angyalos ház",
                    Author = @"Fábián Janka",
                    Headline = @"",
                    NumberOfPages = 384,
                    Price = 3499,
                    PublishYear = 2011,
                    ShortDescription = @"A félreeső budai utcában álló romos házat, amely a homlokzatán lévő angyalszobrokról kapta a nevét, a XXI. század első éveiben életveszélyesnek nyilvánítják, és le akarják bontani, hogy szállodát, vagy lakóparkot építsenek a helyére. A közelben lakók azonban civil mozgalmat indítanak a patinás épület megmentéséért. Az elszánt csapat vezetője Zsuzsa, a gimnáziumi magyartanár, akit - bár nem ott lakik - személyes élmények fűznek az angyalos házhoz. Több mint tíz éve, egyetemista korában ugyanis rendszeresen látogatta az egyik lakót, a százéves Hilda nénit, aki lediktálta neki az emlékeit.\n
Ezek a feljegyzések repítik vissza az olvasót az 1910-es évekbe, amikor az angyalos ház a fénykorát élte. Akkoriban nem csak a szobrok miatt nevezték így, hanem az ott lakó négy lány okán is. Hilda, Klári, Manci és Lina, a négy barátnő együtt élik át a századelőn a felnőtté válás, és persze a szerelem, valamint a vele járó elkerülhetetlen csalódások édes-fájdalmas élményeit. A ház titokzatos új lakója révén azonban akaratukon kívül még a korszak politikai cselszövéseibe is belekeverednek.",
                },

                new Book {
                    Id = 100,
                    Title = @"Emma fiai",
                    Author = @"Fábián Janka",
                    Headline = @"",
                    NumberOfPages = 384,
                    Price = 3499,
                    PublishYear = 2011,
                    ShortDescription = @"A számos félreértés és viszontagság után egymásra talált párnak, az elismert gyerekorvosnak, Kóthay Gábornak és szépséges feleségének, a sikeres írónőnek, Emmának három fai születik. Három különböző jellem, három különböző életút és sors. Mindegyik fiú a maga egyéni módján és eszközeivel keresi boldogulását és boldogságát a húszas-harmincas évek Magyarországán. A legidősebb és legkomolyabb, Tamás, apja nyomdokaiba lépve orvosnak tanul. A középső, a daliás, észbontóan jóképű Péter, akinek egy nő sem tud ellenállni, a Ludovika növendéke, és a berlini olimpiára készül, ahová ki is jut, miközben egyre inkább belesodródik a politikába. A legkisebb, az apja rajztehetségét öröklő, visszahúzódó, álmodozó Öcsi festőnövendékként bontogatja szárnyait. Aztán egy napon találkozik valakivel, aki nemcsak az ő, de a fivérei életét is megváltoztatja...\n
A nagy világégés, Magyarország belépése a háborúba, a keleti fronton harcoló csapatok pusztulása, a német megszállás, majd a nyilas rémuralom történései természetszerűen a Kóthay családot is megrendítik; nem hiányoznak a rosszakarók, és nem maradnak el a tragédiák sem. Az 1945 után kibontakozó új rendszer pedig semmi jót nem ígér az életben maradottaknak.\n
\n
A történész végzettségű fiatal írónő váratlan fordulatokban, hol vidám, hol felemelő, hol szívszorító pillanatokban bővelkedő könyve a második darabja egy háromkötetes családregénynek, amely egészen a XX: század végéig követi nyomon a Kóthay család több nemzedékének életét.",
                },

                new Book {
                    Id = 101,
                    Title = @"Emma szerelme",
                    Author = @"Fábián Janka",
                    Headline = @"",
                    NumberOfPages = 408,
                    Price = 3499,
                    PublishYear = 2011,
                    ShortDescription = @"A tizenhárom éves Emmát apja a halála előtt fiatalkori barátja feleségére és hajdani szerelmére, Kóthay Évára bízza. A Balaton parti festői kisvárosban, ahol még jól emlékeznek Emma világszép édesanyjára és az annak idején róla terjengő pletykákra, féltékenységgel vegyes gyanakvással fogadják a fiatal lányt. Emma élete akkor bolydul fel igazán, amikor váratlanul felbukkan a család régóta Párizsban élő, gyermekorvosként nevet szerzett fia, Gábor. A lányban, aki gyerekkorában súlyos titkok tudója lett, és aki a férfit vádolja anyja haláláért, feltámad a gyűlölet. Ám a szerelmet és a gyűlöletet olykor csak egy hajszál választja el egymástól. Lehet, hogy Emmát és Gábort minden félreértés és tragédia ellenére mégis egymásnak szánta a sors?\n
\n
A fordulatos és megkapó szerelmi történet hátterében ott húzódnak a századforduló eseményei: a magyar millennium, a XX. század beköszönte, majd az első világháború, a Tanácsköztársaság és a Horthy-korszak kezdete. Az események sodrába vetett nem feddhetetlen, de szeretetreméltó és nagyon is emberi hősök sorsa azt bizonyítja, hogy minden személyes tragédiából és történelmi kataklizmából van kiút.\n
\n
A történész végzettségű fiatal írónő első könyve nyitódarabja egy háromkötetes családregénynek, amely egészen XX. század végéig követi nyomon a Kóthay család több nemzedékének az életét.",
                },

                new Book {
                    Id = 102,
                    Title = @"Az isztambuli fattyú",
                    Author = @"Elif Shafak",
                    Headline = @"",
                    NumberOfPages = 472,
                    Price = 3600,
                    PublishYear = 2009,
                    ShortDescription = @"Él egy furcsa török család Isztambulban, négy generáció, és csupa nő - köztük földrajztanárnő, csendes őrült, városszerte híres jósnő, tetoválóművésznő -, a férfitagok ugyanis sajnálatosan rendre korán elhaláloznak. Egy másik furcsa család San Franciscóban él; ők örmények, és nem tudnak, nem is akarnak szabadulni annak emlékétől, hogy Törökországban 1915-ben deportálták és lemészárolták az örményeket. A két családot a köztük lévő hatalmas földrajzi távolság ellenére szoros szálak kötik össze, ám ők erről mit sem tudnak. A tizenkilenc éves, amerikai örmény Armanoush a családi történetek hatására Isztambulba utazik, hogy felkutassa és megismerje a gyökereit. Ott összebarátkozik a vele nagyjából egyidős Asyával, a címbeli fattyúval. Asya sok szempontból Armanoush ellentéte: múltjához nem kötődik, gyökértelenül lézeng, rajong Johnny Cashért és a francia egzisztencialistákat olvassa. Beszélgetéseikben önmagukat és az igazságot keresik, s mindeközben misztikus módon tárul fel a sötét titkokban bővelkedő múlt. A kényelmesen hömpölygő, szövevényes és felettébb izgalmas történet végén sok egyéb mellett az is kiderül, megszakad-e az isztambuli család férfitagjait sújtó átok.",
                },

                new Book {
                    Id = 103,
                    Title = @"Igazgató úr",
                    Author = @"Singer Arje Iván",
                    Headline = @"A Kispesti Textilgyár igazgatójának igaz története",
                    NumberOfPages = 272,
                    Price = 2699,
                    PublishYear = 2012,
                    ShortDescription = @"""Ez a könyv igaz beszámoló arról, mi történt a 20. században. Meg akartam írni az emberiség fájdalmait és szenvedéseit, de arra is rá akartam mutatni, hogy a legszörnyűbb időkben is akadnak jó emberek.""\n
\n
Singer Arje Iván édesapja életét meséli el, a személyes életútba azonban beleszövődik a Kispesti Textilgyár története, valamint a magyar történelem legszörnyűbb évtizedeinek krónikája. Mindezt egy olyan ember szemszögéből láthatjuk, aki zsidó származású textilipari szakemberként megélte és elszenvedte a holokausztot, majd a kommunista diktatúrát. Győr, Berlin, Budapest, Párizs, New York, London, Sydney és Izrael a fő állomásai ennek a kalandos és megdöbbentő életútnak. A kontinenseken átívelő történet egyszerre személyes visszaemlékezés családról, szerelmekről, utazásokról, szenvedésekről, és történelmi dokumentum egy vérzivataros évszázadról, illetve a közép-európai zsidóságról.\n
\n
A szerző fiatalkorában Magyarországról megszökve Izraelbe emigrált, majd sok évvel később, a hatnapos háború után családjával Ausztráliába költözött. Jelenleg Sydney-ben él feleségével, Dvorával. Több szépirodalmi és történelmi témájú könyve jelent meg Ausztráliában.",
                },

                new Book {
                    Id = 104,
                    Title = @"Éjszaka történt",
                    Author = @"Büky Anna",
                    Headline = @"",
                    NumberOfPages = 212,
                    Price = 2990,
                    PublishYear = 2012,
                    ShortDescription = @"""Egy sokévszázados múltra visszatekintő egykor gazdag földbirtokos magyar nemesi família letűnt világa, széthullásának huszadik századi története elevenedik meg e bátor könyv lapjain - családregény, ha tetszik, noha nem szélesen hömpölygő elbeszélés. Inkább két női hangra írott lírai dialógus: mintha nagymama és unokája személyes naplójegyzetei feleselnének egymásnak. A generációk közötti különös párbeszédben kelnek életre az Angyalffyak családi legendáriumának színes figurái. Ám a sok-sok megnyerő vagy bizarr alak és nagy kedvvel elbeszélt mulatságos eseménytöredék fölidézése közben a családi múlt és a nemzeti történelem öncsalásokkal és elhallgatásokkal kísért szörnyű traumái sejlenek fel - s a főhősök reménytelennek tűnő küzdelme azért, hogy virtuális párbeszédük magányában megbirkózzanak velük és mentsék, ami és aki e nehéz múltból még menthető maradt. Bátor könyv, mert szerzője mindezt aligha meríthette pusztán költői fantáziájából: a fölvillantott családtörténet súlyos igazságaiért dikciójának személyessége szavatol."" (Rényi András)",
                },

                new Book {
                    Id = 105,
                    Title = @"Bro útja",
                    Author = @"Vlagyimir Szorokin",
                    Headline = @"",
                    NumberOfPages = 316,
                    Price = 2480,
                    PublishYear = 2007,
                    ShortDescription = @"""Beszélj a szíveddel!"" A jégkalapács végzi a dolgát. Felébreszti és szóra bírja a kiválasztottak szívét. Anyaga a Tunguz meteor nyomába eredő expedíció kitartásának köszönhetően, a vállalkozást elhagyó főhős látomásai és hányattatásai nyomán lesz hozzáférhető.\n
A Magyarországon is nagy sikert aratott ""A jég"" című regény szerzője, Vlagyimir Szorokin a posztmodern orosz irodalom világszerte legismertebb és sokat vitatott alakja. E regényében tovább szövi a Fény Testvériségének mondáját. A Bro útja, bár másodikként íródott, A jég történetének előzményeit mondja el. A főhős a klasszikus családregények elbeszélő modorában járja be a 20. század első felének Oroszországát, majd az űrbéli anyag érintésére szíve felébred, s ő fokozatosan átalakul. Átváltozása nyomán újonnan szerzett társaival együtt apránként elszakad a föld lakóitól, az emberektől. Az emberek világát kívülről látja, célirányosan ténykedő robotokként észleli. Ugyanakkor kitartóan kutatja közöttük a Testvériség tagjait, hogy rátaláljon a Nagy Kör megalkotásához, azaz a világharmónia megteremtéséhez szükséges huszonháromezer kiválasztottra, akik a szív hangján szólnak egymáshoz.",
                },

                new Book {
                    Id = 106,
                    Title = @"A Kaszás vihara",
                    Author = @"Steven Erikson",
                    Headline = @"A Malazai Bukottak Könyvének regéje VII.",
                    NumberOfPages = 1256,
                    Price = 3999,
                    PublishYear = 2011,
                    ShortDescription = @"A Lether Birodalmat csapások sújtják. Rhuland Szengár, a talpnyalókkal körülvett és egy körmönfont kancellár által irányított ezerhalálú császár egyre mélyebbre süllyed az őrületben, miközben a lether titkosrendőrség terrorhadjáratot indít a birodalom lakói ellen. Az egykor oly mesze látó istenség, Kóbor képtelen megfejteni a jövőt, a palotát behálózó összeesküvések közepette pedig nyílt háború fenyeget a szomszédos királyságokkal.\n
Az Edur flotta Letheras felé közeledik, a hajókon ott van Karsa Orlong és Ikárium, az életrabló - sorsuk, hogy összemérjék pengéjüket a halhatatlan császárral. A birodalomból menekültek kicsiny csapata keresi az útját kifelé: egyikük, Fear Szengár arra hivatott, hogy megtalálja Vérszem Szkabandari lelkét. Ám vele utazik Szkabandari ősi ellensége, Dúló Szilkász, aki még mindig hátán viseli a Szkabandari pengéje által ejtett sebeket.\n
El kell jönnie a leszámolásnak - mégpedig akkorának, amibe egész világok rendülnek bele. ""A Kaszás vihara"" háború, intrika és sötét mágia brutális, egyben magával ragadó regénye, az epikus fantasy egyik csúcsteljesítménye.",
                },

                new Book {
                    Id = 107,
                    Title = @"A Hobbit",
                    Author = @"J. R. R. Tolkien",
                    Headline = @"vagy: Oda-vissza",
                    NumberOfPages = 316,
                    Price = 2900,
                    PublishYear = 2012,
                    ShortDescription = @"""Smaug kétségkívül mélyen aludni látszott, jóformán halottnak és sötétnek rémlett, egy-egy láthatatlan gőzpamatnál több a hortyogására sem utalt, amikor Bilbó ismét bekukucskált az ajtónyíláson. Már éppen lelépett volna a padlóra, amikor megpillantotta a Smaug petyhüdt bal szemhéja alól feléje lövellő vékony, átható fénysugarat. Csak színlelte az alvást! Az alagút bejáratát figyelte!...""\n
\n
Amikor gondtalan, minden becsvágy nélküli életéből, meghitt kis zsáklaki hobbitüregéből Gandalf, a mágus és egy csapat törp elragadja, Zsákos Bilbó egy kaland kellős közepébe csöppen: ""betörési szakértőként"" kell közreműködnie a kincs visszaszerzésében, amitől Smaug, a Rettenetes, egy igen nagy és veszedelmes sárkány fosztotta meg hajdanában a Hegymély Királyát. Noha nem szívesen vállalkozik erre a kellemetlen feladatra, Bilbó maga is lépten-nyomon meglepődik tulajdon ügyességén és leleményességén!\n
\n
J. R. R. Tolkien a gyermekeinek írta ezt a meseregényt, de amikor 1937-ben megjelent, azonnal óriási sikert aratott. Később megszületett monumentális folytatása is, és azóta ""a világ két részre oszlik: azokra, akik már olvasták A HOBBIT-ot és A GYűRűK URÁ-t, és azokra, akik eztán fogják elolvasni őket."" (Sunday Times) ",
                },

                new Book {
                    Id = 108,
                    Title = @"Sebes Jimmy",
                    Author = @"Raymond E. Feist, Steve Stirling",
                    Headline = @"A Résháború legendája sorozat",
                    NumberOfPages = 368,
                    Price = 1998,
                    PublishYear = 2004,
                    ShortDescription = @"Sebes Jimmy, a krondori tolvajkölyök csak a város árnyékos oldalát ismeri. Amikor nem a csatornákat járja, egy bolháktól nyüzsgő, patkánybűzös lyukban hajtja álomra a fejét. Noha páratlanul tehetséges, nem más, csak egy eszes utcakölyök, egy ígéretes zsebmetsző. Ám egy nap találkozik Arutha herceggel... 
Miután segít a hercegnek kimenteni Anita hercegnőt Guy du Bas-Tyra fogságából, maga is futni kényszerül Fekete Guy titkosrendőrsége elől, és a helyzete tovább romlik, amikor hetykén semmibe veszi a Pillér parancsát.\n
Csupán két lehetősége van: vagy magától tűnik el a környékről, vagy a Pillér segítségével - a krondori öbölben egy kőkolonccal a lábán. Jimmy az elsőt választja, és délnek indul. A célja Határszéle. Abban bízik, hogy a távoli városka lakói még nem találkoztak hozzá hasonló tehetséges fickóval, aki mindig kiszagolja, hol érdemes kutakodni - mások kincsei után. Jimmy derűlátó, és örül, hogy világot láthat. Ám arra, ami várja, nincs felkészülve...\n
Határszéle már nem szűzföld a magafajták számára; élnek itt már mások, akik nem az egyenes utat járják. Ráadásul van itt még valami: egy titokzatos és veszedelmes sötét erő, amelyről még a helyi tolvajok és csempészek sem tudnak. Jimmy ifjonti hévvel és bátorsággal egyre mélyebbre merészkedik a káosz és halál torkába...",
                },

                new Book {
                    Id = 109,
                    Title = @"Tremorlor kapuja",
                    Author = @"Steven Erikson",
                    Headline = @"A Malazai Bukottak Könyvének regéje II.",
                    NumberOfPages = 672,
                    Price = 2999,
                    PublishYear = 2004,
                    ShortDescription = @"A Malazai Bukottak Könyvének regéje című tetralógia második részét veheti a kezébe az olvasó. A négy részből álló eposz alapján Erikson a fantasyirodalom legnevesebb szerzői közé sorolható. Erikson határtalan fantáziával teremtette meg azt a csodálatos világot, melyben a legkülönfélébb törzsek, kultúrák harcolnak, illetve kötnek szövetséget egymással. A jól megformált karakterek, akiknek útját a mítoszok világában kísérhetjük figyelemmel, nem mindannyian emberek, mégis igen emberiek: megvannak a saját álmaik, félelmeik, reményeik. Sorsuk, mely a tetralógia első részében, A hold udvarában kezdődött, kalandokban, csatákban gazdag történetben bontakozik ki előttünk.",
                },

                new Book {
                    Id = 110,
                    Title = @"Kardok vihara",
                    Author = @"George R. R. Martin",
                    Headline = @"A tűz és jég dala III.",
                    NumberOfPages = 1216,
                    Price = 3499,
                    PublishYear = 2012,
                    ShortDescription = @"Tolkien óta alig született történet, amely annyira rabul ejtené egy egész nemzedék képzeletét, mint A tűz és jég dala, George R. R. Martin hatalmas fantasyeposza.\n
Az első részben, a Trónok harcában megismertük Westeros ősi királyságát, amelyet könyörtelen hatalomvágya marcangolt. A Királyok csatájában kiéhezett ragadozóként söpört végig az uralkodóját vesztett birodalmon a háború, a mágia és az őrület. A Kardok vihara képes még tovább fokozni a feszültséget és még sokkolóbbá tenni Westeros történetét: most közeledik tetőpontjához a hatalomért folytatott embertelen küzdelem. A megosztott, megtépázott királyság eddigi legszörnyűbb ellenségével kénytelen szembenézni, amely a síron túlról érkezik...\n
\n
Martin a fantasy mestere. Kimeríthetetlen fantáziával megírt históriái középkori mintákból merítenek ihletet, és a láthatóság határát súroló plasztikussággal jelenítik meg fiktív világukat. A sodró, szofisztikált történetvezetés, az árnyalt karakterábrázolás és a szexualitásnak a fantasy műfajában szokatlanul nyílt kezelése is fontos szerepet játszik abban, hogy Martin sikert sikerre halmozó újítóként vonulhat be műfaj történetébe.\n
\n
A tűz és jég dala az elmúlt évtized egyik legjelentősebb fantasysorozata, minden kötete letehetetlen olvasmány.",
                },

                new Book {
                    Id = 111,
                    Title = @"A Pilis-összeesküvés",
                    Author = @"Kövesi Péter",
                    Headline = @"",
                    NumberOfPages = 276,
                    Price = 3450,
                    PublishYear = 2011,
                    ShortDescription = @"A kétezer-harmincas években járunk. A technika fejlődésével az élet minden eddiginél kényelmesebb, biztonságosabb és kiszámíthatóbb lett. A Földet a multinacionális nagyvállalatok és világbankok irányítják, a kormányok csak vazallusaik. Az előző években létrejött az Európai Egyesült Államok, aminek azért nem mindenki örül. A névtelen és arctalan Hatalom képes emberek millióit high-tech eszközökkel manipulálni­ - és követni, megfigyelni, ""semlegesíteni"" mindazokat, akinek ez nem tetszik. Orwell és Huxley víziója, a ""szép új világ"" napi valósággá lett.\n
Időközben felnőtt egy generáció, akiket annak idején ""indigó"" gyermekeknek neveztek el. ők lázadnak fel a fogyasztói társadalom léleknyomorító manipulációi ellen. Fegyverük a tiszta lélek, a sámánok, táltosok, druidák ősi tudása, a régi korok spirituális hagyatéka, amelyet a huszonegyedik század technikájának segítségével fordítanak a demagógia, a pénz és hatalom erőivel szembe. Eközben nem mindennapi segítőtársakra tesznek szert, és meglepő kalandokba keverednek. A küzdelemben fontos szerepet kapnak a Pilis hegység barlangjai, az ősi szent helyek, egy titokzatos könyv, egy kard, és a magyar királyok Szent Koronája is. A harc egyenlőtlen esélyekkel folyik, de egyáltalán nem kilátástalan...",
                },

                new Book {
                    Id = 112,
                    Title = @"Vérkőföldek királya",
                    Author = @"R. A. Salvatore",
                    Headline = @"Zsoldosok sorozat III. kötete",
                    NumberOfPages = 504,
                    Price = 2490,
                    PublishYear = 2007,
                    ShortDescription = @"AZ ORGYILKOS 
Egy hideg és szenvtelen gyilkos, aki számára minden léleknek, köztük sajátjának is, ára van, útnak indul, hogy megtudja, mennyit ér. 
A ZSOLDOS 
Egy gátlástalan sötételf kihívást intéz egy királyhoz, és helyet vív ki magának az ellenséges fönti világban. 
ILNEZRA és TAZMIKELLA 
Nagy hatalmú, vénséges sárkányok, akik hozzászoktak, hogy a körülöttük élő embereket irányítsák. Nem mindegyik hagyja azonban, hogy vezessék. Amikor a Vérkőföldek szívébe lökték Entrerit és Jarlaxlét, fogalmuk sem lehetett róla, milyen határtalan az orgyilkos elszántsága, és milyen magasra tör a drow becsvágya.",
                },

                new Book {
                    Id = 113,
                    Title = @"Törött korona",
                    Author = @"Raymond E. Feist",
                    Headline = @"",
                    NumberOfPages = 528,
                    Price = 2998,
                    PublishYear = 2007,
                    ShortDescription = @"A démon halott, éljen a béke! Egy pillanatra fellélegezhet a Szigetkirályság sokat szenvedett népe. Seregeik legyőzték a Smaragd Királynő hordáit, véget érni látszott a háború. Az öröm azonban nem tarthatott sokáig. Fadawah tábornok, a megszállók hadura saját birodalmat akar kiszakítani a Királyság vérző testéből és semmitől, de semmitől sem riad vissza. Mindeközben támadnak a szauruszok, Kesh is lecsapni készül az árnyékból, így Sötétmocsárfy Erik folytatni kénytelen hosszú háborúját. Jimmy és Dash, James herceg két unokája is kiveszi részét a háborúból, vérfagyasztó kalandok várnak rájuk. A kegyetlen és aljas küzdelem tetőpontján aztán Midkemia leghatalmasabb mágusa is rájön arra, hogy nem a démon legyőzése volt élete legnehezebb vállalkozása. Vér, könny és gyász kíséri a törött korona darabjainak összekovácsolását.",
                },

                new Book {
                    Id = 114,
                    Title = @"A királynő mélyén",
                    Author = @"Szappanos Gábor",
                    Headline = @"Erotikus történelmi kalandregény",
                    NumberOfPages = 192,
                    Price = 2990,
                    PublishYear = 0,
                    ShortDescription = @"Két mindenre elszánt, kéjvágyó kalandor mérkőzik egymással életre-halálra, hogy eldöntsék, melyikük az igazi. Ugyanis mindketten ugyanannak a több ezer éves irodalmi hősnek mondják magukat, aki sorra-rendre feltámad halottaiból. Először egy budai orgián hozza őket össze a sors, majd kétezer évet repülnek vissza a múltba, egy azóta letűnt kultúra központjába, a nabateusok lakta Petra városába...",
                },

                new Book {
                    Id = 115,
                    Title = @"Varjak lakomája",
                    Author = @"George R. R. Martin",
                    Headline = @"A tűz és jég dala IV.",
                    NumberOfPages = 896,
                    Price = 2999,
                    PublishYear = 2012,
                    ShortDescription = @"A Varjak lakomája méltó folytatása George R. R. Martin világhírű fantasyciklusának, A tűz és jég dalának.\n
A Trónok harcában megjelenő, az ősi királyságot szétszakító kegyetlen erők, a Királyok csatájának kísértetei, vademberei, boszorkányai, a Kardok viharának a másvilágról előretörő inváziója után a ciklus negyedik kötetében Martin ismét egy sokszereplős, tabudöntögető művel rukkolt elő.\n
Az ősi Westeros földjén lassan véget ér a hosszú, véres háború. Észak ifjú királya halott, családja ősi székhelye romokban hever, a sebeiket nyalogató hadvezérek és királyi házak meghúzzák magukat. A nyugalom azonban csak látszólagos - a koncért mások is vetélkednek. A Vas-szigetek harcias népe a Hét Királyság zöld földjeire vágyik, miközben a kikötőkben egyre több tengerész regél a Sárkánykirálynőről és három sárkányáról...\n
\n
A Varjak lakomája a sorozat előző köteteitől megszokott színvonalű, lebilincselő és egyben felkavaró olvasmány.",
                },

                new Book {
                    Id = 116,
                    Title = @"Pasipanoptikum",
                    Author = @"Király-Acampora Anikó",
                    Headline = @"XXI. századi dekameron",
                    NumberOfPages = 224,
                    Price = 2999,
                    PublishYear = 2010,
                    ShortDescription = @"- Te megőrültél - mondtam a tükörképemnek a fürdőszobában, míg gyorsan rendbe vágtam a mosdót és a zuhanyt.\n
- Nem mondod komolyan! - kiáltott fel Tini - Csak nem lefeküdtél vele?\n 
- Na és ha lefeküdt is, az ő dolga, nem? - érvelt Eleonóra felcsillanó szemmel.\n
- Nem, képzeljétek, nem történt meg a dolog. - itt Angi kicsit hosszúra sikeredett szünetet tartott. - Azóta sem.\n
- És miért nem? - hajolt előre Tini.\n 
- Mert mondom, hogy misztikus... - fényképezőgéppel a nyakában állított be.\n
- Hát ez a hét legjobb vicce. - nevetett Claudia - Kukkoló dugi-muki!\n
\n
A több mint húsz éve külföldön élő, elsőkönyves szerző fiatalos humorral átszőtt története tizenegy mai nőről és az általuk összegyűjtött pasitípusokról szól.",
                },

                new Book {
                    Id = 117,
                    Title = @"A leánycsősz",
                    Author = @"Egon Erwin Kisch",
                    Headline = @"Regény",
                    NumberOfPages = 160,
                    Price = 1790,
                    PublishYear = 2012,
                    ShortDescription = @"Jóllehet a hírhedten elbájoló modorú ""száguldó riporter"", Egon Erwin Kisch (1885-1948) világ életében a nők kedvence volt, életművében, amely elsősorban irodalmi és kultúrtörténeti jellegű riportokból áll, alig érhető tetten valamilyen ""gáláns kaland"". A szexualitás témája korai munkásságában jelenik meg, mégpedig a prostitúcióval összefüggésben. Egyetlen regénye, ""A leánycsősz (1914)"" is ebbe a kategóriába tartozik. Kisch igen élénk, természetes, hamisítatlan, fordulatos, ám mégis feszes formában meséli el Jaroslav Hrapot rövid élettörténetét, az ifjú striciét, aki az Osztrák-Magyar Monarchia Prágájában lányok között nő fel, s ahogy kamaszodik, kénytelen megélni, amint a nincstelenségből is motivált nemi ösztönök hatalmukba kerítik lány barátait.\n
Ez a kurta életpálya nagyrészt belső monológ formájában tárulkozik fel előttünk, s megismerhetjük a fiú karrierjének különböző stációit. Jarda eleinte undorral fogadja a ringyók világát, majd olyannyira megtetszik neki dolog, hogy a nők fölötti mindenható úr szerepében tetszeleg önmaga előtt; aztán végül - egy rendőrségi letartóztatás és egy szifiliszfertőzés nyomán előállt- önmarcangoló lázálom tör rá, amit megbánás követ, sőt, az elfuserált élete miatti kétségbeesés okán tett elkeseredett lépését megelőzően valamiféle ""igaz szerelem"" érzése is megérint.\n
Az olvasó igen plasztikus ábrázolást kap arról, az úrról, amely a fiatal lányokat elvezeti a prostitúcióhoz, s arról az erőszakról és megaláztatásról is, amely ebben a miliőben osztályrészükként várja őket. Politikailag nézve mindez azt jelenti, hogy az első világháború előtti Prága német felső és cseh alsó rétege között egyetlen kapcsolat létezik: az üzletszerű nemi érintkezés.",
                },

                new Book {
                    Id = 118,
                    Title = @"A vadászó préda",
                    Author = @"Szendrődy Szonja",
                    Headline = @"Mit ér a nő a húspiacon?",
                    NumberOfPages = 288,
                    Price = 2499,
                    PublishYear = 2011,
                    ShortDescription = @"""Mindannyian keressük az igazit.\n
Bár mi, 21. századi nők, pontosan tudjuk, hogy nem létezik, mégis lázasan kutatunk utána. Így vagyunk összerakva.\n
Ez a könyv arról szól, ahogy én teszem ezt, és ahogy a legjobb barátomnak teljes őszinteséggel elmesélem. A közelmúlt pasizós történetei abban az időszakban estek meg velem, amikor az addigi életemet romba döntő csalódás után - leszámolva az illúziókkal - úgy határoztam, hogy kezembe veszem a sorsom, és nem várok arra, hogy egy kis királyfi majd felébreszt Csipkerózsika-álmomból. Vagyis én fújtam ébresztőt a pasiknak, hogy használhassam őket arra a szerepre, amit képesek betölteni az életemben - vagy csupán az ágyamban.\n
Mindegyikük azzal az eséllyel indult, hogy ő lehet az igazi. Nem rajtam múlt, hogy a lusta kéjencnek, aki csupán hanyatt feküdni képes, az önálló gondolatok hiányában folyamatosan szerelmes verseket idézgető trubadúrnak vagy a szimpla szélhámosnak, aki hazugságokkal igyekszik pirinyó péniszét megtoldani, ez nem sikerült.\n
Persze ettől még szeretem a férfiakat, hiszen nő vagyok. Férfiak és nők küzdelméről szól ez a könyv, de leginkább egy női lélekről. Kendőzetlenül."" (Sz. Sz.)",
                },

                new Book {
                    Id = 119,
                    Title = @"Vámpírzóna",
                    Author = @"Kresley Cole",
                    Headline = @"Halhatatlanok alkonyat után sorozat 5.",
                    NumberOfPages = 448,
                    Price = 3499,
                    PublishYear = 2011,
                    ShortDescription = @"A RITA-díjat besöprő Kresley Cole egy kegyetlen démon kufár és az őt elbűvölő, gyönyörű fiatal fél lény felvillanyozó történetével folytatja nagy sikerű ""Halhatatlanok alkonyat után"" című sorozatát. Egy igéző szépség, akit nem birtokolhat, de akinek ellen mégsem állhat...\n
Cadeon Woede-nak nincs nyugta, míg ki nem küszöböli a csorbát, mely szüntelen kísérti. Csakhogy amint megszerzi megváltása kulcsát, a fél lény Holly Ashwint, máris rájön, hogy a nő, akit saját céljaira akar használni, majd eldobni, éppúgy kísérti, mint a múltja. \n
Egy megkínzott harcos, akitől rettegnie kéne, de akit megtagadni nem tud...
Az emberként felnevelt Holly-nak sejtelme sincs, hogy a félelmetes legendák a valóságról szólnak, míg össze nem találkozik egy goromba démonnal, s az valami érthetetlen oknál fogva óvja, mint a szeme világát. A mítosz és a hatalom érzéki, új világába taszítva, Holly hamarosan eleped védelmező démona tüzes érintéséért. S megadja magát a sötét vágyaknak... \n
Épp csak kivívja Holly bizalmát, s mondjon le máris róla? Árulja el legvadabb álmai beteljesítőjét, szíve rabul ejtőjét?",
                },

                new Book {
                    Id = 120,
                    Title = @"Szenvedélyes örömök",
                    Author = @"Bertrice Small",
                    Headline = @"Erotika és bujaság",
                    NumberOfPages = 310,
                    Price = 2990,
                    PublishYear = 2011,
                    ShortDescription = @"Az 5 kötetes Örömök-sorozat záró darabja.\n
Lucifer Nicholas, a titkos és interaktív Csatorna Vállalat főigazgatója ördögi módon hálózza be a legvadabb szenvedélyre éhes nőket. Legújabb kiszemelt áldozata Egret Pointe előkelő származású és vonzó könyvtárosnője. A középkorú, egyedül élő Kathryn St. John nappal elégedetten éli őseihez méltó, városi hétköznapjait - és éjjel bekapcsolja a Csatornát, hogy kiélhesse buja vágyait. Mindkettejük élete gyökeres fordulatot vesz, amikor New Yorkból színre lép Timothy Blair, a kék szemű férfi...\n
Bertrice Small, az erotika, szerelem és bujaság koronázatlan királynőjének nészerű sorozata befejező darabjához érkezett, melyben az ördögi erő és az emberekben lakozó jóság száll harcba egymással - érzéki jelenetekkel fűszerezve.",
                },

                new Book {
                    Id = 121,
                    Title = @"Nonstop szerelem",
                    Author = @"Julius J. Coach",
                    Headline = @"",
                    NumberOfPages = 432,
                    Price = 2950,
                    PublishYear = 2012,
                    ShortDescription = @"""Julius J. Coach erotikus könyveinek tizenéves szereplői a fiatalok boldog öntudatlanságával élik át a szerelmet és a testiséget, és teszik meg első lépéseiket a nagybetűs Életben, ahol azonban nemcsak örömökben, hanem csalódásokban, sőt fájdalmas tragédiákban is részük van."" (a Kiadó)",
                },

                new Book {
                    Id = 122,
                    Title = @"Patty Diphusa",
                    Author = @"Pedro Almodóvar",
                    Headline = @"Egy pornósztár vallomásai",
                    NumberOfPages = 208,
                    Price = 1900,
                    PublishYear = 2011,
                    ShortDescription = @"A hedonista Patty Diphusában túlteng az életkedv, sosem alszik; naív, gyengéd, groteszk, narcisztikus lény, aki az összes elképzelhető földi örömet imádja, megéli, és - önnön jól felfogott érdekében - igyekszik mindent a pozitív oldaláról megközelíteni. Személyiségjegyei, szokásai, életszemlélete a nyolcvanas évek szellemi pezsgése, a ""movida"" jellegzetes figurájává teszik. Szókimondó, polgárpukkasztó, vérbő beszámolóiban a madridi éjszaka hajmeresztő történéseit és minden képzeletet felülmúló szereplőit tárja elénk, melyek közül sokan a filmvászonról köszönnek majd vissza. Hogy kicsoda Patty, a magát szexszimbólumként meghatározó provokatív pornósztár? Nem más, mint Almodóvar írói álneve. A rendező ugyanis hősnője bőrébe bújva osztja meg hónapokon keresztül olvasóival madridi élményeit a La Luna című alternatív lap állandó rovatában. A színes, egymással laza kapcsolatban álló, komikus-groteszk írásokból pedig Pedro Almodóvar ars poeticája rajzolódik ki.\n
\n
""Végezetül már csak arra szeretnélek kérni benneteket, hogy igyekezzetek ugyanolyan lazán olvasni a könyvemet, mint ahogyan megírtam.""\n
Pedro Almodóvar",
                },

                new Book {
                    Id = 123,
                    Title = @"Pajkos mesék 4.",
                    Author = @"Cathryn Cooper",
                    Headline = @"Erotikus történetek",
                    NumberOfPages = 336,
                    Price = 2790,
                    PublishYear = 2011,
                    ShortDescription = @"Volt már szex autóban, telefonfülkében, női mosdóban, könyvtárban, konyhában, a legkülönbözőbb testhelyzetekben, bekötött szemmel, netán elfenekeléssel egybekötve... szóval se szeri, se száma az izgalmasabbnál izgalmasabb módozatoknak és azok kombinációinak.\n
Na de...\n
Próbálta már úgy, hogy keze-lába gúzsba kötve, moccanni se tud, és partnere gyakorlatilag azt tesz Önnel, amit akar? Így átélheti a kiszolgáltatottság érzését, fokozva az örömszerzés izgalmait... aztán cserélhetnek is partnerével. Hadd tudja meg ô is, milyen az, ha béklyókban várja az Ön közeledését és rábízza magát az Ön akaratára.\n
A ""Pajkos mesék"" sorozat újabb darabja ismét páratlanul fantáziadús ötleteket ad és megörvendezteti a szerelmi életben igazi változatosságot kedvelőket.",
                },

                new Book {
                    Id = 124,
                    Title = @"Angyali játszma",
                    Author = @"Carlos Ruiz Zafón",
                    Headline = @"",
                    NumberOfPages = 668,
                    Price = 3999,
                    PublishYear = 2010,
                    ShortDescription = @"A húszas évek Barcelonájában egy titokzatos idegen felkeres egy reménytelenül szerelmes fiatal írót. Visszautasíthatatlan ajánlatot tesz neki: rengeteg pénz, és talán egyéb jutalmak is várják, ha megbeszélt időre megírja a Könyvet, amely mindenek feletti hatalommal bír. Az író elvállalja a munkát, és ezzel ördögi csapdába kerül; hidegvérű gyilkosok, kegyetlen kopók, áruló barátok és csalfa szerelmek kísérik temetőkön és kísértetkastélyokon át, hogy végtére is leleplezze azt, aki a szálakat mozgatja.\n
Kezdődjön hát az ANGYALI JÁTSZMA...",
                },

                new Book {
                    Id = 125,
                    Title = @"A tetovált lány",
                    Author = @"Stieg Larsson",
                    Headline = @"A nemzetközi bestseller Millennium-trilógia első kötete",
                    NumberOfPages = 624,
                    Price = 3290,
                    PublishYear = 2012,
                    ShortDescription = @"Negyven éve történt. Az agg milliárdos elveszítette unokahúgát, akit gyermekeként szeretett. S azóta is, évről évre, valaki - mintha az őrületbe akarná kergetni - minden születésnapján emlékezteti az idős urat arra a tragikus napra...\n
Az évek óta tartó nyomozás új lendületet kap, amikor a férfi felfogad egy vesztes sajtóper után állás nélkül maradt, rámenősnek tűnő újságírót, hogy kísérelje meg az igazság kiderítését. Hisz sokan élnek még a rokonságból, akik akkor ott voltak. A gyilkosnak köztük kell lennie...\n
Ugyanakkor egy jó hírű magánnyomozó iroda munkatársnője rááll az újságíróra, s szinte mindent kiderít róla, ahogyan mások sem bízhatnak abban, hogy titkuk rejtve marad a kivételes tehetségű, tetovált lány előtt.",
                },

                new Book {
                    Id = 126,
                    Title = @"Drága kéj",
                    Author = @"Szalai Vivien",
                    Headline = @"Egy magyar luxusprostituált és egy budai milliárdos története",
                    NumberOfPages = 224,
                    Price = 2699,
                    PublishYear = 2011,
                    ShortDescription = @"A nő a legkeresettebb magyar luxusprostituált. A férfi budai milliárdos, a leggazdagabb üzletemberek egyike. Túlfűtött, durva szenvedélyen alapuló viszonyuk során elmerülnek a legmélyebb perverzióban, s közben a nő megjárja a poklok poklát...\n
\n
A Hamis gyönyörben megismert Szofi igaz története révén bepillantást nyerünk a hazai felső tízezer és a politikai elit eltitkolt, mocskos világába, Tel-Aviv luxusszállodáiba vagy éppen a Párizsban magyar szexrabszolgákat tartó szaúdi herceg hálószobájába. Az utazás végén ugyanúgy levonhatjuk a tanulságot, mint Szofi: az életben mindennek ára van, s mindenért meg kell fizetnünk...\n
\n
Szalai Vivien újságíró első könyvében, a Hamis gyönyörben megismerhették a legkeresettebb hazai luxusprostituáltat, Szofit. Igaz történetének folytatása, a Drága kéj élete későbbi szakaszát dolgozza fel: mindennapjait egy nős milliárdos oldalán.\n
""A téma nem hagyott nyugodni, számos modellel, fodrásszal, ruhatervezővel, ötcsillagos szálloda londinerével és elit ügyfelek számára lányokat biztosító futtatóval készítettem interjút: ezekből a beszélgetésekből megismert tények is belekerültek a második részbe"" - ígéri a szerző új regényében.\n
\n
Szofi sorsa szorosan összefonódik más prostituáltakéval és szexrabszolgákéval, és egy nőével, akit vele szemben örök piedesztálra emel a társadalom: a feleséggel.\n
""Sokan azt hiszik, a prostituáltak egy életre meggyűlölik a férfiakat azért, ahogyan velük bánnak. Pedig én nem gyűlölöm, inkább csak jobban ismerem őket, mint a többi nő. Az elmúlt években arra jöttem rá, hogy minden egyes férfi-nő kapcsolat az alapvető igények kielégítésére épül: a nők erőforrásokat, a férfiak pedig szolgáltatásokat várnak el a másik nemtől. Nem más ez is, mint színtiszta üzlet."" - Szofi vallomását ajánljuk minden egyes nőnek és férfinak, aki kapcsolatok hálójában él. És mindazoknak, akik többet szeretnének tudni a hazai felső tízezer titkolt világáról.\n
\n
Szalai Vivien egy országos hetilap főszerkesztő-helyettese, oknyomozó riporter. A Drága kéj a második kötete.",
                },

                new Book {
                    Id = 127,
                    Title = @"A pokol tornácán",
                    Author = @"George P. Pelecanos",
                    Headline = @"",
                    NumberOfPages = 360,
                    Price = 2699,
                    PublishYear = 2010,
                    ShortDescription = @"Derek Strange és Terry Quinn nyomozópáros ezúttal azt a megbízást kapja, hogy kutasson fel egy tizennégy éves kamaszlányt, aki elszökött otthonról. Strange és Quinn hamar rájön, hogy a lány prostituáltként dolgozik Washingtonban, a mentőakció azonban már komoly fejtörést okoz számukra. A két egykori zsaru azt hiszi, jól ismerik az őket körülvevő világot, ám semmi sem készítheti fel őket Worldwide Wilsonra, akinek beleköpnek a levesébe, s aki ezért szörnyű bosszút forral...\n
\n
George P. Pelecanos regényei nem pusztán az izgalmas krimiszál miatt érdemelnek figyelmet, hanem azért is, mert pontos képet adnak az amerikai nagyváros, Washington pokláról. A szerző ezúttal azoknak a hátrányos helyzetű fekete gyerekeknek a sorsán keresztül mutatja be a világ sötét oldalát, akik többet érdemelnének az élettől, de nem emelkedhetnek ki a bűnnel fertőzött gettó szennyéből...",
                },

                new Book {
                    Id = 128,
                    Title = @"Szemérmes barack és gyilkosság",
                    Author = @"Joanne Fluke",
                    Headline = @"Hannah Swensen titokzatos esetei 7.",
                    NumberOfPages = 304,
                    Price = 2590,
                    PublishYear = 2010,
                    ShortDescription = @"A válság a Süti Édent sem kerüli el. Hannah és társa Lisa azért küzdenek nap, mint nap, hogy Lake Eden egykor népszerű cukrászdáját ne kelljen bezárniuk. De a válság oka nem gazdasági. Shawna Lee, nem csak a szerelemben akar Hannah vetélytársa lenni, hanem desszert fronton is. A Magnóliaszirom cukrászda pedig - amelyet a rivális az utca túloldalán nyitott - sikeresnek bizonyul. A vendégek elpártolnak a Süti Édentől, a csőd felé sodorva ezzel a szingli cukrászlányt. A krízis olyannyira mély, hogy Hannah fejében még a házasság gondolata is megfordul...\n
\n
A Lake Eden-i hullafogó - ahogyan Hannah-t a háta mögött nevezik - azonban mégis kap egy új esélyt a sorstól. Ugyanis Lisa Valentin napi esküvőjén nem jelenik meg Shawna Lee a beígért barackos vargabélessel.\n
\n
Remények, szerelem, féltékenység és természetesen egy gyilkosság fűszerezi a Valentin napra készülő kisváros újabb izgalmas történetét. De a vörös hajú cukrászlány nemcsak a nyomozásban erős. A sütemény csatát is megnyeri, hiszen a Szemérmes barack kreatív receptje visszacsábítja a látogatókat a Süti Édenbe.",
                },

                new Book {
                    Id = 129,
                    Title = @"A bűnös",
                    Author = @"Gerritsen Tess",
                    Headline = @"",
                    NumberOfPages = 480,
                    Price = 3499,
                    PublishYear = 2011,
                    ShortDescription = @"Egy zord téli hajnalon vérbe fagyott apácát találnak egy New England-i zárda kápolnájában. A brutális támadás indítéka ismeretlen, és a klastrom lakói is titokzatos hallgatásba burkolóznak. A halott apáca boncolása megdöbbentő eredményt hoz: a huszonnégy éves Camille nővér gyermeket szült, mielőtt meggyilkolták...\n
Egy elhagyatott épületben a felismerhetetlenségig megcsonkított női holttestre bukkannak. Maura Isles, a halottkém, Jane Rizzoli nyomozó segítségével olyan bűnt tár fel, amely a múltban gyökerezik, és ha kitudódik, alapjaiban rengetheti meg sokak életét...\n
\n
Tess Gerritsen a New York Times bestsellerszerzője, tíz világsikerű orvosi thriller írója, akinek vérfagyasztó regényei 33 nyelven, több mint húszmillió példányban keltek el világszerte.\n
\n
A regényből készült tévésorozat, a ""Született detektívek"" a VIASAT3 -on fut.",
                },

                new Book {
                    Id = 130,
                    Title = @"Belphegor",
                    Author = @"Arthur Bernéde",
                    Headline = @"A Louvre fantomja",
                    NumberOfPages = 260,
                    Price = 2000,
                    PublishYear = 2012,
                    ShortDescription = @"1965 tavaszán egész Európát lázba hozta Claude Barma filmsorozata Juliette Grecóval a főszerepben. A színészeket az utcán ostromolták válaszért a mindenkit izgalomban tartó kérdésre: kicsoda Belphegor? Pszichológusok Belphegor-tesztet végeztettek a gyerekekkel, az iskolások nem tudtak aludni, és Belphegort játszottak, néha az akaratlan öngyilkosságig. A belphegorizmus elterjedt az egész világon.\n
A film még mindig sokak emlékezetében él, mint a legnépszerűbb misztikus tévésorozat. Számos alkalommal újra műsorra tűzték és vetítik ma is.\n
Kicsoda Belphegor? Elsősorban moábita isten, akinek a Phegor-hegyen (a mai Jordániában) hódoltak erkölcstelen módon.  Ma a franciáknak egy televíziós sorozat - pontosabban már kettő. Az elsőt, a hatvanötöst 1989-ben a Louvre piramisának felavatására kissé korszerűsítették, és tízedik évfordulójára újra vetítették, 1999 áprilisában. A nézőtér zsúfolt volt:  Belphegor még mindig sikert arat.\n
És a fantom 2001-ben visszatért a képernyőre, a Sophie Marceau főszereplésével készült új változatot a magyar nézők is csillagos ötösre értékelték.  Azóta a Belphegorból rajzfilm is készült.\n
A regényben - melyet Magyarországon eddig még soha nem adtak ki -, akár egy kalandfilm-sorozatban, az események egyre sűrűbben követik egymást, a feszültség fejezetről-fejezetre nő, az olvasó alig várja, hogy előbbre jusson és megtudja a titkot.\n
A Belphegor-láz rendületlenül tartja magát.",
                },

                new Book {
                    Id = 131,
                    Title = @"A másik férfi",
                    Author = @"Ross Macdonald",
                    Headline = @"",
                    NumberOfPages = 440,
                    Price = 2600,
                    PublishYear = 2012,
                    ShortDescription = @"""A sétány macskakövet utánzó burkolata sima és hézagmentes volt, mégis úgy éreztem, mintha térdig ürgelyukakban járnék.""\n
\n
Egy végsőkig elkeseredett fiatalember arra kéri Lew Archert, a magánnyomozót, hogy segítsen előkeríteni eltűnt feleségét - akivel csak pár napja házasodott össze. Gyanúsított ugyan hamar akad egy kétes múltú csavargó személyében, de az is korán kiderül, hogy nem történt gyilkosság - egyelőre. Dolly, a feleség újra felbukkan a közeli egyetemen, ahová nemrég iratkozott át egy távolabbi intézményből. A labilis személyiségű, múltját titkoló lány, úgy látszik, folyton menekül valami elől - s talán nem is sejti, hogy a legrosszabb helyen kötött ki: az egyetem egyik, szintén messziről érkezett fiatal tanárnője hamarosan bestiális merényletnek esik áldozatul, a kezdetben oly egyszerű ügyet nyomozó Archer pedig egy betegesen zárt közösség bűnfertőjének kellős közepébe csöppen...\n
\n
Ross Macdonald (1915-1983) Agatha Christie-hez és Raymond Chandlerhez hasonlóan elnyerte az Amerikai Krimiírók Szövetségének Nagymester-díját. ",
                },

                new Book {
                    Id = 132,
                    Title = @"Nincs menedék",
                    Author = @"Bernard Knight",
                    Headline = @"John koroner nyomoz",
                    NumberOfPages = 320,
                    Price = 1890,
                    PublishYear = 2004,
                    ShortDescription = @"1194 novemberében a devoni lápon, Widecomb közelében egy ismeretlen holttestére lelnek a parasztok. John de Wolfe, a király újonnan kinevezett koronere nyomozni kezd a gyilkos után. Sógorának, az exeteri serifnek nincs ínyére, hogy az új intézmény, a koroneri rendszer korlátozza hatáskörét, és megnyirbálja bevételeit, ezért mindent elkövet, hogy a nyomozás sikertelenül záruljon. John, a koroner, azonban egy sokat megélt katona anatómiai ismereteivel és makacsságával felvértezve lépésről lépésre közelebb kerül a gyilkoshoz.\n
\n
Olyan könyvet vehet most a kezébe az olvasó, amelyben a XII. századi Anglia hétköznapjai elevenednek meg, olyan könyvet, melyben egy kérlelhetetlenül logikus elme nyomozását kísérheti végig.",
                },

                new Book {
                    Id = 133,
                    Title = @"Halál a felhők között",
                    Author = @"Agatha Christie",
                    Headline = @"",
                    NumberOfPages = 320,
                    Price = 2200,
                    PublishYear = 2010,
                    ShortDescription = @"Beszállás! A Prometheus utasszállító repülőgép rögtön indul Párizsból Croydonba! Huszonegy utas és két légiutas-kísérő elfoglalja a helyét, és a gép a magasba emelkedik. Két kabinjából a hátsóban vegyes társaság gyűlik össze: angol fodrász kislány, francia régészek, angol fogorvos, két arisztokrata hölgy, francia öregasszony - és egy nagy bajszú kis belga. A második ülésen az ebéd utáni kávé mellett elszunyókál az öregasszony. A kilencedik ülésen szenved a kis belga. Az ötödik és hatodik ülésen vitatkozik a két régész. A tizenkettedik ülésen a fogorvos udvarolni próbál a tizenhatodik ülésen a fodrászlánynak. A légiutas-kísérők fel-alá rohangálnak. Egy darázs döng, majd ""csatt!"", lecsapja valaki. A második ülésen - csak nincs valami baj? Feje félrebillen... nem mozdul...\n
\n
Micsoda szerencse, hogy a kilencedik ülésen a kis belga azonnal magához tér, amint földet ér a gép. Poirot életében először gyanúsítottként kezdi a nyomozást, de szerencsére nem úgy fejezi be.\n
\n
A kötethez ajándék jubileumi füzet is tartozik az írónő eddig magyarul megjelent köteteinek leírásaival, receptekkel és hasznos háttérinformációkkal.\n ",
                },

                new Book {
                    Id = 134,
                    Title = @"Megtört csend",
                    Author = @"Linda Castillo",
                    Headline = @"",
                    NumberOfPages = 304,
                    Price = 2800,
                    PublishYear = 2012,
                    ShortDescription = @"Painters Millben, Ohio egy nyugodt kisvárosában négy amish gyermek marad árván, miután szüleiket és nagybátyjukat holtan találták a házuk melletti csűrben. Az ügy első ránézésre balesetnek tűnik, de a boncolás során az egyik áldozaton olyan sérüléseket találnak, amelyek gyanút ébresztenek Kate Burkholder rendőrfőnökben. A nő amish kötelékei miatt jól ismeri a közösség zártságát, ismeri démonaikat és a külvilág démonait, amelyek tragikus sebeket ejthetnek az egyedül maradt gyermekeken.\n
Vajon hármas gyilkosság történt? Ha igen, talán kapcsolódik az utóbbi időben az amishok ellen elkövetett bűncselekményekhez? A rendőrfőnöknek és segítőjének, John Tomasettinek ártatlanság és gonoszság között kell navigálniuk az ügyet a megoldás felé, amelynek egyre nagyobb tétje van, hiszen újabb emberéletek kerülnek veszélybe.\n
\n
Linda Castillo (Néma eskü, Könyörgés) korábbi regényeihez hasonlóan lenyűgözően bonyolítja a szálakat, hogy aztán a könyv végére a legmegdöbbentőbb, legmegrázóbb felfedezésig juttassa az olvasót.",
                },

                new Book {
                    Id = 135,
                    Title = @"A holtak szolgálata",
                    Author = @"Martin Delrio",
                    Headline = @"Northwind trilógia III. kötet",
                    NumberOfPages = 224,
                    Price = 2490,
                    PublishYear = 2004,
                    ShortDescription = @"A Northwind bolygót alaposan megtizedelték az Acélfarkasok ellen vívott harcok - és a klánharcosok most a Terrára fenik a fogukat. A bolygó sorsa három mechharcos között fog eldőlni:\n
Ezekiel Crow - aki elárulta a felföldi alakulatokat, és most bujkálnia kell politikai és katonai ellenfelei elől. 
Anasztázia Kerenszkij - az Acélfarkasok irgalmatlan vezére, és ha sikerrel jár, ő lesz a Terra következő meghódítója.\n
Tara Campbell - a Norhwindi Felföldiek vezére, és a Terra egyetlen reménye ebben a kétségbeejtő helyzetben.\n
\n
A Northwind trilógia befejező része. A trilógia eddig megjelent kötetei: A menny csöndje és az Igazság és Árnyak.",
                },

                new Book {
                    Id = 136,
                    Title = @"A Frolix-8 küldötte",
                    Author = @"Philip K. Dick",
                    Headline = @"",
                    NumberOfPages = 224,
                    Price = 2880,
                    PublishYear = 2012,
                    ShortDescription = @"Nick Appleton egyszerű kétkezi munkás, az élete csalódások sorozata, és reménye sincs rá, hogy valaha feljebb kerülhet a szigorú társadalmi ranglétrán. Willis Gram igazi kényúr, az evolúciós fejlődésben kiemelt elit élén áll, és az egész Földet irányítja. Amikor mindketten beleszeretnek ugyanabba a lányba - aki ráadásul a kormány ellen lázító propagandát terjeszt - sorsuk összefonódik.\n
Ráadásul éppen ekkor tér vissza az űrből az elveszettnek hitt forradalmi vezér, Thors Provoni, méghozzá nem egyedül: egy minden tekintetben idegen lényt hoz magával, hogy segítségével megváltoztassa a merev, zsarnoki világrendet. Ez azonban csak az egész világ megváltoztatása árán lehetséges.",
                },

                new Book {
                    Id = 137,
                    Title = @"Pengefutár",
                    Author = @"Alan E. Nourse, William S. Burroughs",
                    Headline = @"Az igazi Blade Runner",
                    NumberOfPages = 288,
                    Price = 2990,
                    PublishYear = 2010,
                    ShortDescription = @"A 21. századi Amerika egészségügyi rendszere összeomlott, a törvénykezés az ellátást az állampolgárok teljes és végleges sterilizálásához köti, a kórházakban pedig az orvosokat komputerek és robotok váltják föl. Mindezzel a kormányzat a vérengzésbe torkolló Egészséglázadásokra keresett megoldást, de a helyzetet némiképp túlreagálta.\n
A rendszerből kikerültekkel illegalitásba menekült orvosok foglalkoznak csak, akik ha kell, műtenek a konyhaasztalon is. Ám az egészségügyi készleteket a hatóságok szigorúan felügyelik, rendelkezéseik kijátszása csupán alvilági módszerekkel sikerülhet.\n
Billy az ellenálló orvosok köré szerveződött földalatti mozgalom tagja, ""pengefutár"". Az életét kockáztatja azért, hogy mások megmenekülhessenek. A rendszer ellensége ő, mégis az amerikai nép egyik utolsó reménysége.",
                },

                new Book {
                    Id = 138,
                    Title = @"Örvény",
                    Author = @"Robert Charles Wilson",
                    Headline = @"",
                    NumberOfPages = 288,
                    Price = 2990,
                    PublishYear = 2011,
                    ShortDescription = @"Évtizedekkel a Pörgés kezdete után járunk, és a Földet még mindig a Feltételezettek titokzatos civilizációja óvja a jelenség pusztító hatásaitól. Persze az emberiség attól még szorgosan pusztítja magát és környezetét.\n
Dr. Sandra Cole pszichiáter keze alá egy érdekes fiú kerül, Orrin Mather, aki Findleyről, akit a Feltételezettek tízezer évnyire ragadtak előre az időben. Ebben a távoli világban az emberiség már bolygók egész láncolatán él, melyeket Átjárók kötnek össze egymással - egyedül a haldokló Földre nem juthat el senki, mert azt karanténná nyilvánították. Törököt és fiatal barátját, Isaac Dvalit egy fanatikus közösség fogadja be, akik mégiscsak el akarnak jutni az anyabolygóra, mert egy prófécia szerint ott végre szemtől szembe találkozhatnak a Feltételezettekkel.\n
Dr. Cole a kézirat olvasása közben egyre több apró jelre figyel fel, melyek arra utalnak, hogy Orrin történetének köze lehet a valósághoz. Sőt a valóság egynémely tragikus eseményeihez...",
                },

                new Book {
                    Id = 139,
                    Title = @"Nyugtalanság",
                    Author = @"Arkagyij Sztrugackij, Borisz Sztrugackij",
                    Headline = @"",
                    NumberOfPages = 368,
                    Price = 2990,
                    PublishYear = 2011,
                    ShortDescription = @"A Pandora bolygó teljes egészében dzsungellel borított kontinensén csak egyetlen hely emelkedik a fák koronája fölé: egy magányos sziklaszirt, amelyen a földiek kutatóállomása fölépült. Leonyid Gorbovszkij is a bázis dolgozója, de míg társai szívesebben foglalkoznak az egzotikus vadászkalandokra vágyó turistákkal, ő megszállottan tanulmányozza az erdőt és annak emberi elmével szinte felfoghatatlan élővilágát, mert úgy érzi, valami készül odalent, valami véget fog vetni a bolygó látszólag méltóságteljes nyugalmának.\n
Korábban többeknek is nyoma veszett a rengetegben, és noha a hivatalos álláspont szerint halottnak nyilvánították őket, van, aki még reménykedik visszatértükben. A felderítők időnként meg-megpillantanak humanoidokat a fák között, de hogy ezek vajon az eltűntek, vagy valami helyi civilizáció képviselői, mindeddig nem sikerült kideríteni. ",
                },

                new Book {
                    Id = 140,
                    Title = @"Régmúlt napok fénye",
                    Author = @"Arthur C. Clarke, Stephen Baxter",
                    Headline = @"",
                    NumberOfPages = 400,
                    Price = 3490,
                    PublishYear = 2011,
                    ShortDescription = @"Mi lenne, ha a világon minden esemény visszanézhetővé válna? Hozzáférhetővé válna az az információ, hogy ki gázolt cserbenhagyásosan az előző héten, éppúgy, mint az, hogy mi történt meg valójában a bibliai események közül.\n
Amikor a féregjárat-technológián alapuló időlencse találmánya nyilvánosságra kerül, mind szélesebb igény mutatkozik a használatára. Házastársi viták kibogozására, bűnesetek felderítésére vagy akár puszta nosztalgiázás céljaira is igénybe venné a Föld szinte teljes népessége. De vajon az emberek kezébe adható-e egy ilyen kényes eszköz, amely fenekestül fordíthatja föl nemcsak mindennapi életünket, de egész történelemszemléletünket is?\n
\n
A két díjnyertes SF-szerző közös műve egyszerre kalandos és filozofikus történet az információ szabadságáról és az igazság szubjektivitásáról.",
                },

                new Book {
                    Id = 141,
                    Title = @"Pörgés",
                    Author = @"Robert Charles Wilson",
                    Headline = @"",
                    NumberOfPages = 432,
                    Price = 2990,
                    PublishYear = 2007,
                    ShortDescription = @"Egy októberi éjszakán a tízéves Tyler Dupree döbbenten nézte végig, ahogy a csillagok sorra kihunynak az égen. Az űr egy csapásra valóban üres lett.\n
Tyler azóta felnőtt, és ahogy valamennyi embernek a Földön, neki is meghatározó élményévé vált a Nagy Elsötétedés néven elhíresült jelenség. A Nap csupán egy halvány korong az égen, a Hold eltűnt, a mesterséges űrobjektumok pedig kivétel nélkül lezuhantak, és maradványaik olyan vénséges-vénnek tűnnek, mintha a nyilvántartottnál sokkal régebben keringtek volna bolygónk körül.\n
Kutatók próbálják megfejteni a rejtélyt, és amire bukkannak, az tragikus jövőt vázol föl az emberi faj előtt: a Földet egy idegen lények építette fal szigeteli el a világegyetem többi részétől, és odakint sokkal gyorsabban telik az idő - egy nap alatt mintegy százmillió év! Ebben az iramban csillagunk életéből nem lehet több hátra negyven esztendőnél!",
                },

                new Book {
                    Id = 142,
                    Title = @"Éjszakai őrség",
                    Author = @"Szergej Lukjanyenko",
                    Headline = @"Az őrség-tetralógia első kötete",
                    NumberOfPages = 444,
                    Price = 2990,
                    PublishYear = 2007,
                    ShortDescription = @"Moszkva utcáin a hétköznapi emberek között természetfölötti lények járnak észrevétlen. A Sötétség és a Fény erői egyaránt jelen vannak, s a két tábor közötti törékeny fegyverszünetet az Éjszakai és a Nappali őrség vigyázza.\n
Most azonban viharfelhők gyülekeznek a város komor bérkaszárnyái felett: a varázslók, vámpírok, alakváltók és boszorkányok hidegháborúja forrósodni kezdett. Ha összecsapásuknak nem sikerül elejét venni, maga a pokol szabadul el a földön.\n
A szerző sorozatindító regénye hihetetlen népszerűségre tett szert az első megjelenése óta eltelt években, és rajongótábora már nem korlátozódik Oroszországra. A könyvből készült film elvitte hírét Amerikába és a világ szinte minden szegletébe. Azóta az Éjszakai őrség már valamennyi fontosabb nyelven olvasható.",
                },

                new Book {
                    Id = 143,
                    Title = @"A Dűne istencsászára",
                    Author = @"Frank Herbert",
                    Headline = @"4. kötet",
                    NumberOfPages = 330,
                    Price = 3600,
                    PublishYear = 2004,
                    ShortDescription = @"Paul Atreides homokféreggé vált fia, II. Leto három és félezer éve uralkodik az egykori Impérium felett. Birodalmában béke honol, a színfalak mögött azonban a régi világrend hatalmai az istencsászár uralmának megdöntésére szövetkeznek. Ha tervük sikerül, és a császár elpusztul, a világegyetem felszabadul a zsarnokság alól.\n
Csakhogy Leto a Dűne utolsó homokférge. Férgek nélkül pedig a bolygón soha nem lesz újra melanzs, és a készletek kimerülése káoszba taszítja a fűszer különleges hatásaira épülő multigalaktikus társadalmat.\n 
\n
A Dűne és annak folytatása - Frank Herbert klasszikussá vált regényciklusa - minden idők legsikeresebb science fiction remekének számítanak. A Dűne istencsászárával e nagy ívű sorozat negyedik kötetét nyújtjuk át az Olvasónak.",
                },

                new Book {
                    Id = 144,
                    Title = @"Predator: Betondzsungel",
                    Author = @"Nathan Archer",
                    Headline = @"",
                    NumberOfPages = 260,
                    Price = 2890,
                    PublishYear = 2011,
                    ShortDescription = @"New York. Forró nyár a betondzsungelben. Emelkedő hő- és bűnözési hullám. Schaefer és Rasche nyomozóknak azonban nem ez a legnagyobb gondja.\n
Mennyezetekről lelógó, megnyúzott testek jelzik az utóbbi évek legbrutálisabb gyilkosának útját, és ők kétlik, hogy közönséges sorozatgyilkos rejlik az esetek mögött.\n
Schaefer felidézi mindazt, amit évekkel azelőtt öccse egy földön kívüli vadászatról és az ügy kormány általi eltussolásáról mesélt, s érzi, hogy a történet még korántsem ért véget...",
                },

                new Book {
                    Id = 145,
                    Title = @"A gonosz csábítása",
                    Author = @"Lisa Jackson",
                    Headline = @"",
                    NumberOfPages = 464,
                    Price = 2980,
                    PublishYear = 2012,
                    ShortDescription = @"Az illat összetéveszthetetlen - gardénia. Édes, finom illat. Jennifer, az első felesége is mindig ilyen parfümöt használt.\n
Rick Bentz, a New Orleans-i nyomozó egy baleset után kinyitja a szemét a kórházban, meglátja Jennifert, aki az ajtóban áll, csókot dob neki, azután eltűnik. Csakhogy ez lehetetlen. Jennifer ugyanis tizenkét éve halott...\n
Amikor Bentznek csomagot hoz a posta Jennifer halotti bizonyítványával, amelyre valaki piros tollal hatalmas kérdőjelet firkált, a bélyeg Los Angelesbe vezeti a tapasztalt zsarut. Ott egy sor gyilkosság történik gyors egymásutánban, az áldozatok mind Jennifer múltjához köthető emberek, a szörnyű holttestek egytől egyig Bentzre terelik a gyanút. Valaki csendben, türelmesen vár - és Bentz minden egyes lépését előre kiszámítja. Hamarosan Bentzen a sor, hogy megfizessen a bűneiért...",
                },

                new Book {
                    Id = 146,
                    Title = @"Túlpart",
                    Author = @"Jónás Zsolt",
                    Headline = @"",
                    NumberOfPages = 368,
                    Price = 2490,
                    PublishYear = 2007,
                    ShortDescription = @"Harminc éve Túlparton baleset történt, aminek sosem lett volna szabad megesnie. A tragédiának nem maradt nyoma - a titkot őrző tó felszínén elsimultak a hullámok. Csak az öregek emlékeznek, akik egykor az esetet eltemették, és ők készek arra, hogy magukkal vigyék emlékeiket a sírba. 
A titok azonban nem akar nyugodni a mélyben.\n
Egy csavargó járja a falu utcáit. Udvarias. Nem kér sokat. Hangja szelíd. Ám csak arra vár, hogy valaki hibázzon, mert akkor az emlékek újra felélednek, és kitör a vihar, amely elsöpri a hallgatást, a falut és a gondosan óvott életeket.\n
Túlpart utolsó napja virradt fel.",
                },

                new Book {
                    Id = 147,
                    Title = @"Szarvak",
                    Author = @"Joe Hill",
                    Headline = @"",
                    NumberOfPages = 504,
                    Price = 3200,
                    PublishYear = 2012,
                    ShortDescription = @"Ignatius Perrish egy részeg éjszaka után arra ébred, hogy irtózatosan fáj a feje... és a tükörbe nézve azt látja, hogy szarvak nőttek a halántékán.\n
Ig először azt hiszi, hallucinál, a gyász és a harag elvette az eszét. Hiszen az utóbbi egy évet a maga privát purgatóriumában töltötte: egy esztendővel ezelőtt erőszakolták és gyilkolták meg brutális módon, felfoghatatlanul a szerelmét, Merrin Williamset. A teljes idegösszeomlás is szinte természetes lenne nála. Csakhogy ezek a szarvak valódiak...\n
Azelőtt Ig a boldogok gondtalan életét élte: gazdag szülők gyermekeként, tévésztár báty öccseként megvolt mindene, pénz, biztonság, megbecsülés. Megvolt mindene, sőt annál több is - Merrin szerelme, akivel együtt osztoztak romantikán, diákkori felelőtlenségeken, egy csakis kettejüknek kijutó, varázsos kalandon.\n
Merrin halálával mindez oda lett. Noha Ig volt az egyetlen gyanúsított, bíróság elé sohasem került, de fel sem mentette soha a kisváros, Gideon közvéleménye: persze hogy azért úszta meg, mert befolyásos szülei vannak! Mintha mindenki elhagyta volna Iget, még az Isten is. Talán csak egyvalaki nem: a benne lakozó ördög...\n
És most, ezekkel a szarvakkal, Ig rettenetes erőre tesz szert - olyan tehetségre, amellyel végre kinyomozhatja, ki ölte meg Merrint, ki tette tönkre az életét. És bosszút állhat. A templomba járás, az ima nem segített. Jöjjön hát a Sátán!\n
\n
""A szív alakú doboz"" szerzőjének második regénye jóformán csupa négy- és ötcsillagos értékelést kapott az amazon.com-on, és a kritika is egyöntetű elismeréssel fogadta.",
                },

                new Book {
                    Id = 148,
                    Title = @"Sub Rosa",
                    Author = @"Bíró Szabolcs",
                    Headline = @"",
                    NumberOfPages = 336,
                    Price = 3499,
                    PublishYear = 2012,
                    ShortDescription = @"A templomos lovagok titkát évszázadok óta próbálják megfejteni. Történészek, valláskutatók, kalandorok. Kik is voltak ők valójában? Mitikus hősök, Jedi-lovagokhoz hasonló harcművészek, varázslók, alkimisták, súlyos titkok őrzői, ősi vallások örökösei, világrengető összeesküvések kiötlői?\n
Ennek az izgató és -mind kiderül- veszedelmes titoknak a nyomába ered a fiatal prágai antikvárius, aki egy nap különös megrendelést kap: kis cédulát hagynak az asztalán, rajta egy telefonszámmal és a Sub Rosa felirattal. Az antikvárius megpróbálja felkutatni az ismeretlen könyvet a száztornyú arany Prága kusza labirintusában, de lassan rá kell ébrednie, hogy a titokzatos mű vagy nem létezik, vagy valakik nem akarják, hogy létezzen. Csehország, Svájc, Ausztria és Magyarország titokzatos, történelmi helyszínein követi a nyomokat, miközben furcsa alakok és egy gyönyörű szőke nő keresztezi az útját, és mindegyikük egyet akar: a templomosok titkát, a tiltott tudást, a Sub Rosát.\n
\n
Bíró Szabolcs Umberto Ecó-i ihletésű, lélegzetelállítóan izgalmas művészettörténeti thrillere tisztelgés a könyvek és Európa szellemi-kulturális öröksége előtt. Az eddig Francis W. Scott álnéven publikáló fiatal író regényében bizonyára Steve Berry és Carlos Ruiz Zafón rajongói sem fognak csalódni.",
                },

                new Book {
                    Id = 149,
                    Title = @"Csont és bőr",
                    Author = @"Kathy Reichs",
                    Headline = @"",
                    NumberOfPages = 560,
                    Price = 3499,
                    PublishYear = 2012,
                    ShortDescription = @"A kissé tüskés modorú Dr. Brennan törvényszéki patológus éppen egy XIX. században elhunyt apáca földi maradványainak kihantolását végzi Montrealban, amikor tűzesethez riasztják. Porig égett egy családi ház. A szakértők gázrobbanásra gyanakodnak.\n
A romok között több holttestet találnak, s a maradványok vizsgálata közben nem egy gyanús körülmény felmerül. Például a tűz fellobbanása előtt miért lőtték agyon az egyik áldozatot, egy hetvenéves hölgyet? Egyáltalán, kié a ház? Miért nem elérhető a tulajdonosa?\n
Megindul a nyomozás, s nem sokra rá előkerül egy iszonyatosan megcsonkított fiatal nő holtteste is.\n
Tempe megszállottan dolgozik - bizonyos nyomok rituális gyilkosságra utalnak.\n
Egyetemista lányok tűnnek el nyomtalanul, akiknek az ismerősei nem hajlandók segíteni a rendőröknek. Miért olyan riadtak, és ki félemlítette meg őket?\n
A szálak Dél-Karolinába vezetnek, ahol hasonló esetek történtek. A szövevényes bűntény felderítése során Tempe is nemegyszer veszélybe kerül, ráadásul kissé kelekótya húga miatt is aggódnia kell, aki váratlanul megjelenik nála...",
                },

                new Book {
                    Id = 150,
                    Title = @"Sasok és angyalok",
                    Author = @"Juli Zeh",
                    Headline = @"",
                    NumberOfPages = 344,
                    Price = 2490,
                    PublishYear = 2004,
                    ShortDescription = @"Max, a szakmájában ismert jogász szerelmes a hatalommal felvértezett drogkereskedő lányába, Jessie-be. A lány kedvéért még a család sötét ügyleteibe is belekeveredik, de mialatt drogmámorban csempészkednek, Jessie úgy dönt, kiszáll. Max őrangyalként vigyáz a lányra, állását és karrierjét feladva Lipcsébe menekíti, de a múlt árnyaitól üldözött barátnő, egy telefonbeszélgetés során golyót ereszt a fejébe. Az önvád súlya alatt Max megpróbálja rekonstruálni kedvese életútját, de a növekvő kokainadagok végképp összemossák benne a valóságos és a paranoia-szülte világot. Max önromboló menekülési kísérlete a maffia hálójából, a politikai cselszövés és a pénz labirintusából eleve kudarcra van ítélve.\n
\n
Juli Zeh szövevényes utalásai és felfokozott ritmusú prózája, magas irodalmi alkotássá emelik ezt a thrillernek is kiváló regényt, amely számos nemzetközi díjat nyert, és amelyet több mint húsz nyelven adtak ki. Michel Houellebecq, Bret Easton Ellis és Quentin Tarantino rajongóknak kötelező.",
                },

                new Book {
                    Id = 151,
                    Title = @"A velencei árulás",
                    Author = @"Steve Berry",
                    Headline = @"",
                    NumberOfPages = 656,
                    Price = 3999,
                    PublishYear = 2010,
                    ShortDescription = @"Miután Egyiptomtól Indiáig meghódította a világ nagy részét, macedóniai Nagy Sándor i. e. 323-ban rejtélyes, lázas betegségben meghalt. Senki sem tudja, hol van eltemetve, de sírját azóta is rengetegen keresik, tudósok éppúgy, mint kalandorok és kincsvadászok.\n
E több évezredes titok nyomába ered Cotton Malone is, az egykori amerikai titkos ügynök. Miután majdnem odavész egy dániai múzeumban kitörő hatalmas tűzvészben, Malone megtudja, hogy a tűz nem volt véletlen, csupán egy hatalmas, Közép-Ázsiától az Egyesült Államok elnökéig terjedő játszma egyetlen lépése. Nemcsak Nagy Sándor kincseiről van szó, hanem arról a számtalan betegséget gyógyító csodaszerről is, amelynek receptjét állítólag az uralkodó sírjába temették. Míg Malone az életét kockáztatva próbálja felderíteni a rejtélyt, egy biológiaifegyver-arzenált fölhalmozó főminiszter asszony, az AIDS ellenszerének megtalálója, a Vatikán képviselője és az amerikai titkosszolgálatok hol szövetkezve, hol egymással harcolva keresik Nagy Sándor földi maradványait.\n
Az író korábbi könyveihez hasonlóan A velencei árulás is egyszerre politikai hátterű izgalmas krimi, történelmi adatok és feltevések valóságos lelőhelye, amiből persze a szerelmi szál sem hiányzik.\n
\n
Steve Berrynek, a politikai thriller nagymesterének regényeit már harmincnyolc nyelvre fordították le, és ötven országban aratnak sikereket.",
                },

                new Book {
                    Id = 152,
                    Title = @"A makedón összeesküvés",
                    Author = @"Zima Szabolcs",
                    Headline = @"",
                    NumberOfPages = 302,
                    Price = 3499,
                    PublishYear = 2012,
                    ShortDescription = @"A londoni székhelyű British Library bőkezű támogatójának lányát elevenen sütik meg egy antik ércbikában. Az ókori kéziratok után kutató Enid Markopoulos feltehetően olyan leletre bukkant, amely nem csupán világraszóló irodalmi csemege és kultúrtörténeti szenzáció, hanem potenciális fegyver is - az árából akarják fedezni egy őrült politikai játszma költségeit. Minderről azonban fogalma sincs a könyvtár ifjú munkatársának, akiket a másik főszponzor, egy különc MI6-ügynök lord állít rá az esetre. Pat Foster könyvtári mindenes és Bertie Hook restaurátor, akik kalandos küldetéseiken már bizonyították rátermettségüket, Európa legizgalmasabb városaiban követik a halott lány verses rejtvényüzeneteinek nyomát. A szédületes száguldás közben Pathez csapódik egy titokzatos, gyönyörű nő, Rómában pedig feltűnik a halott lány húga, aki nem marad közömbös Bertie iránt. A CIA is tud a kézirat létezéséről, ám érdekeik azt diktálják, hogy az ősi pergamen ne kerüljön nyilvánosságra. A klónozott Qayin ügynököt vetik be, aki mindig egy lépéssel a könyvtárosok előtt járva gyilkol. Két ember látta eddig a kéziratot, már mindkettő halott... ",
                },

                new Book {
                    Id = 153,
                    Title = @"A Bankár",
                    Author = @"Frei Tamás",
                    Headline = @"",
                    NumberOfPages = 624,
                    Price = 3499,
                    PublishYear = 2011,
                    ShortDescription = @"Jamaicán a rendőrségi terepjárók már dübörögnek, hogy kézre kerítsék a Magyarországról óriási vagyont ""kimenekítő"" és a távoli karibi szigeten bujkáló, korrupt pesti bankárt.\n
Az Országos Jelzáloghitelbank elnökének privát gépén irtózatos erejű pokolgépet rejtettek el, és csupán percek kérdése, hogy Magyarország egyik legbefolyásosabb milliárdosát a feleségével együtt a levegőbe repítsék.\n
André, a leszerelt légiós és szerelme, Adrienn e pillanatban fordul rá a genovai főutcára, de a rövid mézesheteknek egy orosz bérgyilkos vet véget, aki már a nyomukban liheg.\n
""A Megmentő""-ből megismert André sorsdöntő válaszút elé kerül; cserbenhagyja Adriennt, amint korábbi élete megkísérti? Megtalálja a bankárt, akinek kapzsi mohósága Magyarországot végveszélybe sodorja? És mindezek után vajon visszatalál önmagához, vagy a dühödt bosszú olyan helyekre hajtja, ahonnan már nincs visszaút?\n
\n
Frei Tamás első regénye, ""A Megmentő"" hónapokig vezette a hazai sikerlistákat. A ""konspirációs akcióthriller"" meghonosítójaként Frei Tamás második sikerkönyvében ismét az ""itt és most""-ot tárja fel olvasóinak, torokszorító izgalmak közepette. Fordulatos érzelmi hullámvasúton repít minket az amerikai ultragazdagok csillogó villáitól az Everglades bűzös mocsaráig, a lélektelen emberrablók világvégi rejtekhelyétől a tőzsdecápák konspirációinak fehér abroszos asztaláig, a politika és bűnözés, a bosszú és leszámolás, a hatalmi és szerelmi játszmák terepére, aminek értő és érző ismerője, és amelynek a világa, egy államcsőd árnyékában, sokkal közelebb van a mai Magyarországhoz, mint gondolnánk... ",
                },

                new Book {
                    Id = 154,
                    Title = @"Holtomiglan",
                    Author = @"Árpa Attila",
                    Headline = @"",
                    NumberOfPages = 400,
                    Price = 3499,
                    PublishYear = 2012,
                    ShortDescription = @"Három gondtalan kamasz teker a rákospalotai naplementében.\n
Nem sejtik, hogy életük talán legboldogabb napját hagyják maguk mögött.\n
Nem sejtik, hogy alig pár év múlva a 90-es évek pesti alvilágában próbálnak majd felfelé törni, vagy legalább életben maradni. Lesz közülük, aki az ország legrettegettebb bérgyilkosává válik, lesz, aki nem éri meg a harmincas éveit, és lesz, akinek döntenie kell: hatalom vagy szerelem. Barátság vagy halál.\n
Árpa Attila első regénye Levi alvilági karrierjének és szerelmének történetével mutatja be hitelesen a magyar olajmaffia korszakát, amikor milliárdok forogtak kockán, és a kivégzések mindennaposok voltak, sokszor mégis az emberi értékek és érzelmek döntöttek a bűnözők életéről vagy haláláról.\n
Levi kamasz, aki vonzódik a bűnözőkhöz és vadregényes, izgalmas életükhöz. Felküzdi magát a pesti maffia elitjébe, de beleszeret az egyik nagyfőnök lányába. Hamarosan lehetetlen döntés előtt találja magát: ha megöli szerelme apját, ő lesz az új helytartó, de örökre elveszíti a lányt. Ha nem, egy csapásra véget ér a pályafutása, és ő maga válik célponttá. Regény a bűnöző lelkéről és az alvilág szívéről. Letehetetlen, különleges, izgalmas és legfőképp hiteles. A fikcióba a magyar valóság keveredik, és ezáltal olyan egyedi világot teremt, mely egyszerre romantikus és hátborzongatóan igaz.",
                },

                new Book {
                    Id = 155,
                    Title = @"A birodalom hajnala",
                    Author = @"Sam Barone",
                    Headline = @"",
                    NumberOfPages = 624,
                    Price = 3498,
                    PublishYear = 2010,
                    ShortDescription = @"Ötezer évvel ezelőtt, a Tigris keleti partján az emberiség történelme új szakaszba lépett... Két életforma, két jelentőssé vált népcsoport: a ""sártúrók"" és a nomád harcos ""barbárok"" csapnak össze az emberiség történelmének hajnalán. A ""sártúró"" falusiaknak hatékonyabb fegyverük van, mint az íj és a kard: a táplálékot adó föld, mely lehetővé teszi számukra a jólétet és számbeli gyarapodást. Orak faluja már túl nagyra nőtt ahhoz, hogy Thutmose-sin, a barbár harcosok vezére figyelmen kívül hagyhatná az erejét.\n Hatalmas seregével megsemmisítő csatára készül ellenük. A falu sorsa Eskkaron, a számkivetett barbáron és szerelmén, a ""tudással áldott"" rabszolgalányon, Trellan áll vagy bukik, illetve azon, hogy védelmi tervük meg tudja-e állítani a gyilkos hordát.\n
A barbárok könyörtelenül nyomulnak előre, támadás támadást követ, miközben a történelem menete nem fordul vissza, sőt még kérlelhetetlenebbül halad előre a maga útján.",
                },

                new Book {
                    Id = 156,
                    Title = @"Férjem, Bár Kochbá",
                    Author = @"Andrew Sanders",
                    Headline = @"Zsidó és római levelek a II. századból",
                    NumberOfPages = 296,
                    Price = 2900,
                    PublishYear = 2004,
                    ShortDescription = @"A Férjem, Bár Kochbá egy forradalmi dráma epikus története. Michálnak, egy zsidó arisztokrata nőnek elbeszéléséből és leveleiből ismerjük meg a Bár Kochbá felkelés történetét. Michál, nagyapja intése ellenére férjhez megy Simon bár Koszivához, később ismertté vált nevén Bár Kochbához, a rómaiak elleni legnagyobb zsidó felkelés vezetőjéhez.\n
Andres Sandersnek - a Kedves Majmonidész és a Fiam, Chániná szerzőjének - ez a történelmi regénye Bár Kochbá korába visz bennünket. Megelevenednek a kor híres történelmi figurái. A főhős mellett közelebbről megismerhetjük Hadrianus római császárt, és rabbi Ákkívát, a híres talmudi bölcset, aki jelentős szerepet játszott a forradalom kirobbantásában.\n
A zsidó történelem egyik legizgalmasabb korszakának ábrázolásakor Sanders bemutatja a ""felvilágosodott"" Római Birodalom és a monoteizmushoz rendíthetetlenül ragaszkodó zsidó nép kibékíthetetlen világnézeti küzdelmét. A könyv érzékletesen ábrázolja a szerelem és bánat, forradalom és háború, győzelem és vereség kalandos világát.",
                },

                new Book {
                    Id = 157,
                    Title = @"A hölgy és az egyszarvú",
                    Author = @"Tracy Chevalier",
                    Headline = @"",
                    NumberOfPages = 296,
                    Price = 2990,
                    PublishYear = 2009,
                    ShortDescription = @"Jean Le Viste, a 15. századi nemesúr, a király bizalmas embere felkér egy becsvágyó művészt, tervezzen számára faliszőnyegeket, amelyek hírnevét dicsőítik. A tehetséges miniatűrfestő, Nicolas des Innocents épp csak magához tér a nagy megtiszteltetéstől, amikor megpillantja a nemesúr gyönyörű lányát, Claude-ot. E perctől fogva nincs más vágya, mint megkapni a szépséges hölgyet...",
                },

                new Book {
                    Id = 158,
                    Title = @"Milyen édes az élet a pálmafák árnyékában",
                    Author = @"Christian Jacq",
                    Headline = @"Legújabb egyiptomi elbeszélések",
                    NumberOfPages = 208,
                    Price = 2600,
                    PublishYear = 2007,
                    ShortDescription = @"Christian Jacq világában egybeszövődik múlt és jelen, mítosz és valóság, ahol árnyék nélküli bölcsek jelenhetnek meg a földművesnek, turisták válhatnak kiválasztottá, akik felszállhatnak az aranybárkára, s egy tetőfedő véget vethet az elöljáró és ellenzéke ádáz szembenállásának. A nagy mesélőkedvvel előadott történetek közül van, amelyik a múltba varázsol, s a szerző regényeiből ismerős témákat dolgoz fel: az Egyiptomot vezérlő igazságért végsőkig küzdő oázislakót vagy az ország fennmaradásáért életveszélyes feladatra vállalkozó Kheopsz fáraó fiának fantasztikus kalandját követhetjük végig, a jelenben játszódó rövid novellákban pedig derűsebb jelenetek villannak föl az utazók, régészek, kalandvágyók életéből. Christian Jacq első novelláskötete meglepetés a szerző bőven áradó regényfolyamai után. A hang, a táj - Egyiptom és a Közel-Kelet, a természet, az állatok, a békés, igaz élet, a tudás szeretete, a bölcsesség keresése ugyanaz. A témák, a műfajok változatosak, a novellákban, negatív utópiákban, csodás mesékben, karcolatokban a valóságot izgalmasan fűszerezi a misztikum, egyszerű hétköznapi jelenetek keverednek káprázatként megjelenő fantasztikummal, sugallva, hogy az utazó Egyiptomban mindenkor az Istenek Földjén jár.",
                },

                new Book {
                    Id = 159,
                    Title = @"Miksa és Sarolta",
                    Author = @"André Castelot",
                    Headline = @"Habsburg pár Mexikó trónján",
                    NumberOfPages = 524,
                    Price = 3600,
                    PublishYear = 2008,
                    ShortDescription = @"Habsburg Miksa alig-alig ismerős a magyar olvasó számára, hacsak nem Hasek Svejkjének szájából, aki a kocsmában a szarajevói merénylet apropóján a szánakozást Ferenc József családi gyászain azzal kezdi, hogy az öccsét, a mexikói császárt falhoz állították valami várban és agyonlőtték. A derék katona a fonákjáról most is a lényegre tapint. Miksa, akit bátyja lemondatott főhercegi jogairól, neje ösztökélésére fogadta el III. Napóleontól Mexikó trónját, noha különösebb tehetség, ambíció nem szorult belé, és fogalma sem volt, micsoda tűzfészekben válik a nagy Napóleon idejétől fogva dédelgetett francia hódító ambíció eszközévé. Az amerikai polgárháború kimenetele úgy hozta, hogy a Miksa uralmát biztosító francia csapatok szedték a sátorfájukat. Miksa maradt, ezért végezte Juárez kivégzőosztaga előtt. Az esztelen kalandra bujtó feleség beleőrült abba, hogy az európai királyi udvarokban hiába kilincsel segítségért. A nagyravágyás e kisszerűségtől korántsem mentes drámáját feltárva André Castelot, akitől Napóleon személyéről, szerelmeiről, koráról már sokat megtudhattunk, ezúttal részben a mi házunk tájáról szolgál érdekes adalékokkal, de a messzi országról is érdekfeszítően számol be, a krónikát útirajzzal színesítve.",
                },

                new Book {
                    Id = 160,
                    Title = @"Körforgás",
                    Author = @"J. M. G. Le Clézio",
                    Headline = @"",
                    NumberOfPages = 568,
                    Price = 2800,
                    PublishYear = 2008,
                    ShortDescription = @"Jean-Marie Gustave Le Clézio az élő francia irodalom egyik legnagyobb alakja. Mesésen áradó regénye - egy önmagát és gyökereit kereső, félig angol, félig francia fiatalember bolyongásainak története - két évszázad egyetemes és személyes históriájának lenyűgöző freskóját festi elénk. Emberi sorsok keresztezik egymást korszakokon és kontinenseken át, a francia forradalomtól a 68-as párizsi eseményekig, a mauritiusi rabszolgafelkeléstől az algériai háborúig, Nizzától Mexikóig, Londontól Mauritiusig. Forradalmak és háborúk, eszmék és személyes küzdelmek, megtalált és elvesztett álmok váltják egymást nemzedékek során át örök körforgásban.",
                },

                new Book {
                    Id = 161,
                    Title = @"A velencei bába",
                    Author = @"Roberta Rich",
                    Headline = @"",
                    NumberOfPages = 280,
                    Price = 3570,
                    PublishYear = 2011,
                    ShortDescription = @"Hannát csodásan ügyes kezű bábaként ismerik Velence-szerte, aki a legmakacsabb babákat is képes csalogatni. Egy ködös éjszakán egy velencei nemesember kopogtat Hanna gettóbeli viskójának ajtaján. A felesége napok óta vajúdik, s ha Hanna nem segít, belehal a szülésbe. A fiatal bába nehéz döntés elé kerül. Az inkvizíció szigorúan tiltja, sőt akár halállal is büntetheti az efféle orvosi beavatkozást. Ha Hanna zsidó létére segít egy keresztény asszonynak a szülésnél, ezzel nemcsak önmagát, de az egész gettót veszélybe sodorhatja. Csakhogy a gróf szolgálataiért cserébe jókora összeget ajánl, mely elegendő lenne ahhoz, hogy Máltára utazzon, és kiválthassa férjét, Izsákot a kalózok rabságából.\n
Hanna semmire sem vágyik jobban, mint hogy újra együtt lehessen azzal a férfival, akit mindenkinél jobban szeret, s aki őt is mindenkinél jobban szereti, hiszen hozomány nélkül is elvette feleségül, s azután is kitartott mellette, hogy Hanna nem tudta gyermekkel megajándékozni.\n 
A rabbi heves tiltakozása ellenére Hanna dönt: beledobja vászontáskájába a szülőfogót, s elindul a gróffal, hogy megmentse egy asszony és születendő gyermeke életét.\n
A lélegzetelállítóan izgalmas, fordulatokban bővelkedő regény élénk képet fest a 16. századi Velencéről, ám mindenekelőtt dicshimnuszt zeng a nőkről, akik mindenre képesek a szerelmükért. ",
                },

                new Book {
                    Id = 162,
                    Title = @"Medici Katalin vallomásai",
                    Author = @"C. W. Gortner",
                    Headline = @"",
                    NumberOfPages = 552,
                    Price = 3970,
                    PublishYear = 2011,
                    ShortDescription = @"A magával ragadó regény a történelem egyik legvitatottabb, ugyanakkor legbefolyásosabb királynőjének, Medici Katalinnak az életét beszéli el.\n
Egyesek szerint kegyetlen királynő volt, aki a méregtől a gyilkosságig minden eszközt bevetett, hogy megőrizze a hatalmát, míg mások a monarchia szenvedélyes megmentőjeként tartják számon, aki eltökélte, hogy megvédi a családi trónt.\n
Medici Katalin serdülőlányként kerül a francia udvarba, de negyvenévesen már megözvegyül, s hat kicsi gyerek marad rá. Uralkodnia kell egy vallási háborúkkal sújtott országban. Miközben hajthatatlanul békére és a monarchia megőrzésére törekszik, nem látja, milyen sors vár rá: ha meg akarja menteni Franciaországot, fel kell adnia az eszméit, a jó hírnevét, a saját boldogságát.\n
A naplószerűen megírt regényben egy szenvedélyes asszony drámai fordulatokban bővelkedő élettörténete elevenedik meg. A személyes hangvételnek köszönhetően részesei lehetünk a Loire völgyében megbúvó meseszerű kastély életének, elvegyülhetünk a tömeggel a reneszánsz kori párizsi utcákon.				 ",
                },

                new Book {
                    Id = 163,
                    Title = @"Assassin's Creed: Testvériség",
                    Author = @"Oliver Bowden",
                    Headline = @"",
                    NumberOfPages = 474,
                    Price = 3790,
                    PublishYear = 2011,
                    ShortDescription = @"Az Assassin's Creed videójáték sorozat az utóbbi évek legnépszerűbb új sorozata az egész világon, néhány év alatt több mint 30 millió példányban fogytak a játékok. A ""Testvériség"" című kötet, a közvetlen folytatása az előző, ""Reneszánsz"" című, a magyarországi könyvpiacon is kiemelkedően teljesítő regénynek. Mivel az Assassin's Creed sorozat következő játéka a ""Revelations"" 2011. november 15-én jelenik meg, és óriási várakozással tekintenek rá a rajongók, így a ""Testvériség"" kötet megjelenését úgy időzítettük, hogy ez a játék megjelenésével összecsengjen, és így kiemelkedő hírverést kaphasson.\n
\n
Tartalom:\n
""Alászállok egy romlott birodalom fekete szívébe, hogy eltapossam ellenségeimet. De Rómát nem egy nap alatt építették, és egyetlen magányos orgyilkos nem lesz képes visszaállítani régi fényét. A nevem Ezio Auditore da Firenze. Ez az én testvériségem.""\n
Az egykor oly dicsőséges Róma romokban hever. A városban szenvedés és pusztulás az úr, polgárai a kegyetlen Borgia család tehetetlen bábjai. Csak egyvalaki mentheti meg őket a Borgiák zsarnokságától - Ezio Auditore, a orgyilkos hagyományok mestere.\n
Küldetése során Eziónak latba kell vetnie minden képességét. Cesare Borgia, aki apjánál, a pápánál is elvetemültebb és veszélyesebb, nem nyugszik, amíg egész Itáliát meg nem hódította. Mivel ez a köpönyegforgatók kora, az összeesküvők mindenhová befészkelik magukat, még a Testvériség soraiba is...",
                },

                new Book {
                    Id = 164,
                    Title = @"Assassin's Creed: Reneszánsz",
                    Author = @"Oliver Bowden",
                    Headline = @"",
                    NumberOfPages = 480,
                    Price = 3790,
                    PublishYear = 2011,
                    ShortDescription = @"Egy bosszúszomjas fiatalember eposzi méretű küldetésre indul, miután Itália uralkodó dinasztiái elárulták őt. Ám ahhoz, hogy visszaállítsa családja becsületét, és véget vessen hazája romlásának, ki kell tanulnia az orgyilkosok mesterségét.\n
Miközben a szabadságért és az igazságért harcol, Ezio útját olyan kiváló elmék segítik, mint Leonardo da Vinci és Niccoló Machiavelli, akik -mint koruk legbölcsebb gondolkodói- beavatják a túlélés fortélyaiba.\n
Társai számára Ezio fogja megtestesíteni az erőt, mely elsöpri a régit, és újat hoz a helyébe. Ellenségei szemében pedig fenyegető jelképpé válik, kinek rendeltetése, hogy eltiporja a zsarnokságot, mely Itália népét sanyargatja.\n
Kezdődjék a hatalom, az összesküvés és a bosszú örök színjátékának reneszánsz krónikája.",
                }
            );
        }
    }
}
