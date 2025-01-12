Hvordan systemet sættes op og startes:
Jeg har opdelt programmet i forskellige mapper. I mappen CSS, har jeg alt det css som hjemmesiden bruger. Dvs. alle sider bruger CSS fra det dokument. Images mappen, indeholder alle de billeder jeg bruger i projektet. Js filen indeholder REGX, og Ajax til levering dato og beregninger. 
 
Der er 2 modeller som jeg har lavet, en af dem hedder UserContext.cs, og den anden hedder Users.cs. Users model indeholder alle de variabler som skal gemmes i databasen. Derefter har jeg View mappe, som indeholder HTML for alle de sider som bliver brugt i hjemmesiden. 
Hjemmesiden starter på Index siden, som bruger Home controller. Denne controller styrre hvilket views skal blive fremvist: 
 
Users controller, giver muligheden for at registrere men også login som brugere på hjemmesiden. Der bliver også anvendt Session til UserID, for at gemme denne variable når sessionen er i gang.
Hvor kan man finde de enkelte sider med implementering af afleveringens krav:

•	Formular til registrering af brugere
 Denne formular kan blive fundet i Index.cshtml siden. Dette formular bruger controller user, metode post og en funktion som hedder validateRegistrationForm(). Brugeren får muligheden for at registrer og blive gemt i database.

•	Formular til login
 Denne formular kan blive fundet i Index.cshtml siden. Ligesom registrering forum, virker login lidt på samme måde. Formularen tager fat i Databasen, og tjekker om koden og navnet på brugeren findes i databasen, hvis den gør, så logger man ind som en exciterende bruger. Når man er logget ind, kan man se sit eget unik leverings label, og leverings dato. 

•	Formularer skal bruge JavaScript og RegEx til at validere brugerinput
REGEX kan blive fundet i site.js filen.
 
Funktionen virker meget let. For at gøre det nemmere for brugeren at vide, hvad de mangler at tilføje til koden for at blive registreret, så tager vi alt skridt vist. Først tjekker vi om username er mindre end 3 bogstaver, og om koden er mindre end 5 bogstaver. Hvis de er mindre, får brugeren besked om at de skal få deres kode til at være længere. Derefter er der flere REGX tjek, som brugeren får besked på hvis der er fejl.

•	I skal sikre jer mod Cross-Site Scripting (CXX)
Kan blive fundet i UserController.cs. Her bruger jeg Hashing, hvor jeg ændrer kodeordet. Dvs. det er meget svært at hacke nu.
 

•	I skal sikre jer mod SQL Injection
Kan blive fundet i UserController.cs. Alle kodeord er hashed. REGEX hjælper også med at finde ud af, om personen er i gang med at skrive SQL injektion.

•	Man skal kunne se en liste over brugere et sted
Liste af alle brugere kan blive fundet på PgAdmin4. 
 
•	Noget skal være responsivt
I CSS, burger jeg mange Flex bokse, som justerer baseret på størrelsen af fanen. Jeg bruger også @media, til at tjekke størrelsen af fanen og justere størrelsen af indholdet. 
 
•	I skal selv skrive både noget CSS og Javascript, men der må gerne suppleres med jQuery, Bootstrap & Fontawesome
I site.css, kan man finde alt det CSS jeg har skrevet til projektet. I site.js, kan man se alt det JavaScript jeg har skrevet.

•	Der skal laves et ajax kald
funktionener bliver lavet i UserController.cs, og i site.js. getDeliveryInfoAjax() og GetDeliveryInfo(). Den ene skaber JSON fil, men den anden afhenter informationen.

•	Hvad har du selv lavet som er forskelligt fra det din makker har lavet:
Jeg har lavet alt selv
