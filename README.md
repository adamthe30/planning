# OpenCV Témalabor

A témalabor célja megismerkedni az OpenCV (Open Computer Vision Library) képfeldolgozó osztálykönyvtár néhány képességével C++ vagy C# környezetben. Az OpenCV eredetileg robotikai, valós idejű alkalmazásokra készült, de azóta az egyik legszélesebb körben használt képfeldolgozási osztálykönyvtár lett. Színszűrések, elmosás, kontúrkeresés, képmorfológiai művelete (például dilatáció, erózió), mozgó objektumok keresése és követése, képszegmentáció, osztályozás… és még csomó más készen áll a használatra.
A témalabor keretében az alábbiakra fogunk kitérni:
OpenCV beizzítása, a közös projekthez git repository létrehozása (github.com)
Állókép vagy videó betöltése, mentése, megjelenítése, egyszerű rajzolás rájuk (Mat típus, imshow, videocapture, imread, imwrite)
Egyszerű szűrések, transzformációk (threshold, blur, erode és dilate)
Mozgó objektumok keresése (MOG2: Mixture of Gaussians Background Subtractor kipróbálása)
Képszegmentációs módszerek kipróbálása (Canny edge detector, MSER: Maximally Stable Extremal Regions)

# Technikai dolgok

### GitHub classroom

A GitHub classroomba ha regisztrálsz, akkor a kiindulási repositoryról kapsz egy saját változatot (private repo, más nem látja), ahova tudsz dolgozni. Így tudjuk követni az előre haladást. Kérlek, hogy a repositoryba rendszeresen pushold a változásokat, hogy lássuk, ki hogy halad.

Github classroom meghívó link: [https://classroom.github.com/a/HEXhax4D](https://classroom.github.com/a/HEXhax4D)

(Az eredményeket mergelni nem fogjuk a kiindulási repositoryba annak ellenére, hogy a classroom gyakorlatilag forkolja azt a repositoryt.)

### Levlista
opencvtemalabor@googlegroups.com

A levlista arra van, hogy kérdezzetek rajta, osszátok meg, hogy miket találtatok. Nem egyedül kell rájönni mindenre, de azért ne is oldjátok meg egymás helyett a feladatokat. Ja és nem csak egy helyes megoldás van! Ha valamit nem tudtok eldönteni, válasszátok a logikusabbnak tűnő megoldást. Aztán utána megbeszéljük, ki mire jutott.

### Unit tesztek
A kiindulási repositoryban egy kis keretprogram található, valamint egy csomó unit teszt. A feladatok elkészítése során a funkciók egy részét ezek a unit tesztek is ellenőrzik (de nem mindent). A félév során egyrészt ezeket a unit teszteket kell "bezöldíteni". Az elején minden unit teszt előtt van egy "Ignore" attribútum, hogy ne jelezzen hibát, ezeket természetesen el kell távolítani, amint a megoldásodat tesztelni szeretnéd. (Visual Studio alatt a Test Explorerben tudod lefuttatni a solution minden unit tesztjét. Ha esetleg itt semmi nem jelenik meg, fordítsd le a projektet és ellenőrizd, hogy a Teszt menüben a processzor architektúra ugyanarra van-e beállítva, mint amire a projekteket fordítod, pl. x64-re.)

Amellett, hogy a már adott unit teszteket bezöldíted, a feladat része az is, hogy te is gyakorold a megoldásod helyességének ellenőrzését. Ezért arra kérlek, hogy minden egyes feladathoz te magad is készíts 2-3 további unit tesztet, hogy minél alaposabban körbe legyen tesztelve az adott kódrészlet.

Van egy unit teszt, ami már rögtön az elején zöld, ezzel tudod ellenőrizni, hogy a fejlesztő környezet készen áll-e az indulásra: TestIntro

# Feladatok hétről hétre
Az első 2 héten közös előadások vannak, addig nincsen OpenCV-s feladat, bár ha van kedved, természetesen előre is dolgozhatsz. A feladatok egy részéhez kicsit utána is kell olvasni a dolgoknak (pl. az eróziónak, mint képmorfológiai művelet), ilyenkor a Google és az OpenCV dokumentáció egy jó kiinduló pont. Ha pedig megakadsz vele, szólj!

## 3. Hét: Bevezető
OpenCV beizzítása C# alatt, webes dokumentáció (OpenCV 3.0) megkeresése, belenézés.
GIT repository beüzelemése, ebben mindenki nyisson magának egy saját könyvtárat és abba dolgozzon.
Feladat: írjatok egy kis programot, mely parancssori paraméterként kap két fájlnevet (egy létező képet és egy kimeneti képfájlt), ezt betölti, rajzol neki egy sárga keretet, majd elmenti a 2. paraméterként kapott néven.
https://youtu.be/aYuXU1p8u20

Kapcsolódó unit tesztek: TestIntro (Már alapból zöld, ha a fejlesztő környezet működik.)

## 4. Hét: Videó megnyitása, elmentése
Készítsetek egy programot, mely megnyit egy videó fájlt (ha van kamerátok, azt is használhatjátok a feladathoz és akkor élő képpel dolgozik majd), rárajzol egy ellipszist minden képkockára és megjeleníti őket. (A képkockák között vár, hogy meglegyen a 25FPS.) Emellett az elkészült videót el is menti egy videó fájlba.
(A szükséges funkciókhoz kelleni fog egy kis dokumentáció keresés, stackoverflow és társai.)

Kapcsolódó unit teszt: még nincsen

## 5. Hét: Foltok megszámolása
Írj egy programot, mely megszámolja, hogy egy képen hány összefüggő piros folt van. A kis szakadások eltűntetéséhez először válaszd ki a piros részeket, azokat dilatáld, majd számold meg őket. A számolás alapja a floodFill: kezdetben a háttér legyen mindenhol fekete “0”, az előtér “255”. Ezután indulj el a bal felső sarokból pixelenként, és ha egy pont 255, akkor abból a pontból kiindulva a floodFill segítségével színezd át minden pontját 0-ra, és növeld a számlálót 1-gyel. A képen végig érve minden fekete lesz és a számláló az eltűntetett foltok számát jelzi. (Látványosabb megoldás, ha eltérő színűre színezed a foltokat és akkor utána érdemes meg is jeleníteni.)

Miután megvan minden összefüggő folt, határozd meg a bennfoglaló téglalapjukat!

Kapcsolódó unit tesztek (a további, sajátokat is ide írd meg): TestBoundingBox

További unit tesztek: TestConnectedComponents (amik még nem használják a dilatációt és eróziót)

## 6. Hét: kép morfológia, távolságok
Ezen a héten két feladat van: az egyik az erózió és dilatáció, mint képmorfológiai művelet megismerése, melyek a foltokat kicsinyítik és növelik, a másik pedig a distance transform megismerése, mely minden pixelre meghatározza, hogy attól milyen messze van a legközelebbi előtér pont (pl. bináris kép esetén a fekete pontokra megmondja, hogy milyen messze van a legközelebbi fehér, ami egyben az oda mint középpontba beírható maximális kör sugara is).

Kapcsolódó unit tesztek (a további, sajátokat is ide írd meg): TestConnectedComponents, TestDistanceMap

## 7. Hét: Mozgó objektumok keresése
A MOG2 háttéreltávolító algoritmus segítségével egy videón keresd meg a mozgó részeket és úgy jelenítsd meg a videót. (Kiegészítő feladat: a bal felső sarokban jelenítsd meg az 500 pixelnél nagyobb foltok számát.)

Kapcsolódó unit tesztek (a további, sajátokat is ide írd meg): TestMotionTracking

## 8. Hét: Képszegmentációk
A Canny élkereső algoritmus segítségével keresd meg az éleket egy videó minden képkockáján, majd jelenítsd meg az él-pixelek arányát a képen és így jelenítsd meg az “él-videót”. Részletgazdag képet nézve az arány magas lesz, homogén felületek felé forgatva a kamerát (ha kamerát használsz és nem videót) kicsi szám lesz.

Kapcsolódó unit tesztek: még nincsen

## 9. Hét: felhasználói interakció, rajzolás pixelenként
Feladat: készíts egy programot, melyben az egérrel lehet rajzolni. Lehet benne színkiválasztás is, például az R, G és B billentyűkkel…

Kapcsolódó unit tesztek (a további, sajátokat is ide írd meg): TestDrawing

## 10. Hét: Folt mérethisztogram
Egy foltos képen a foltokról méret-hisztogram készítése és kirajzolása (akár a videó képre rárajzolt oszlopdiagram formájában is.) Kőzetek, ötvözetek, vagy légifelvételek elemzésénél gyakran szükség van ilyesmire.

Kapcsolódó unit tesztek (a további, sajátokat is ide írd meg): TestBlobSizeHistogram

## 11. Hét: Turkmesz
A turkmesz egy kis véges állapotú automata jószág, ami egy képen mozog aszerint, hogy milyen színű az alatt álló pixel. Fekete-fehér kép esetén például a legegyszerűbb eset (ami most a feladat is) fekete pixelen állva azt fehérre színezi, balra fordul és megy előre egyet; fehér pixel esetén pedig feketére festi, jobbra fordul és úgy megy előre egyet. Egy idő után érdekes mintázatot fog kirajzolni. (Ha megvan, küldj rója egy screenshotot a levlistára! :) ) (A mozgási szabályok kommentárként szerepelnek a TurkmeszTask osztály kódjában.)

Kapcsolódó unit tesztek (a további, sajátokat is ide írd meg): TestTurkmesz

## 12.-13. Hét: saját feladat
Mindenkivel egyeztetünk egy saját, kedvére való kisfeladatot, amit elkészít. Néhány példa:

  * Mandelbrot halmaz megjelenítő program
  * Videó vágó program: előre-hátra lehet benne mozogni egy videóban és meg lehet neki adni, hogy hol vágja szét darabokra. Utána akár ki is lehet egészíteni, hogy a darabolás után másik sorrendben össze is tudja rakni a darabokat. Vagy csak mentse el őket külön-külön.
  * Kamerás mozgásérzékelő alkalmazás fejlesztése, ami bizonyos méretű mozgó objektum esetén riaszt. (Ki lehet egészíteni úgy, hogy ha a mozgó objektumban sok egy adott szín, akkor mégsem riaszt. Pl. láthatósági mellényben be lehet menni… :) )
  * Jellegzetes színű pont (pl. LED) mozgásának követése a videó képen. (Ki lehet egészíteni úgy, hogy villog a LED, amitől egyértelműbb a felismerés. De akár egy kódot is levilloghat, mint a tanszéki 5G Konvoj autói.)

Ezekhez a feladatokhoz nincsennek unit tesztek, viszont te készíts ezekhez is néhányat!

## 14. Hét: befejezés, konklúziók
Közösen megnézzük az eredményeket, megbeszéljük a tapasztalatokat.
