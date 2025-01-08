# Document/View Architecture - Signals  

Ez az alkalmazás a **Document/View Architectúra** mintát használja az adatok megjelenítéséhez és kezeléséhez. Az adatok egy fájlba menthetők vagy fájlból betölthetők. A fájl típusának **.txt**-nek kell lennie, és az adatok a következő formátumban tárolódnak:  

## Funkciók  

### Fájlműveletek  
- **Új fájl létrehozása:**  
  - A **File > New** menüpont segítségével új fájlt hozhat létre, amely betölti az alapértelmezett adatokat.  

- **Fájl megnyitása:**  
  - A **File > Open** menüponttal egy korábban elmentett fájlt nyithat meg.  
  - A fájlkezelő ablak segítségével választhatja ki a megnyitni kívánt fájlt.  

- **Fájl mentése:**  
  - A **File > Save** menüponttal mentheti az aktuális fájlt.  
  - A mentéskor egy felugró ablakban meg kell adnia a fájl nevét.  

- **Fájl bezárása:**  
  - A **File > Close** menüponttal az aktuálisan megnyitott fájlt bezárhatja.  

---

### Zoom funkciók  
- **Nagyítás/Kicsinyítés:**  
  - A megnyitott fájl tartalmát a bal felső sarokban található **+** és **-** gombokkal nagyíthatja vagy kicsinyítheti.  

---

## Használat  

1. **Alkalmazás indítása:**  
   - Nyissa meg az alkalmazást a futtatható fájl segítségével.  

2. **Fájlműveletek végrehajtása:**  
   - Használja a **File** menü megfelelő menüpontjait (New, Open, Save, Close) az adatok kezeléséhez.  

3. **Adatok nagyítása/kicsinyítése:**  
   - A megnyitott fájl tartalmát a **+** és **-** gombok segítségével nagyíthatja vagy kicsinyítheti.  

---

## Fájlformátum  

Az alkalmazás által kezelt fájlok formátuma a következő:  
- Minden sor tartalmaz egy **double** típusú értéket és egy **DateTime** típusú időbélyeget, tabulátorral elválasztva.

---

## Rendszerkövetelmények  

- **Operációs rendszer:** Windows  
- **.NET Framework 4.7.2 vagy újabb**  
- **Programozási nyelv:** C#  

