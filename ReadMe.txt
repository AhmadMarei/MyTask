
Hur började jag lösa den här uppgiften?

När jag har tittat på den här uppgiften trodde jag att det är realtidsfall(real time task) så jag tror att jag behöver teknik i realtid och bestämde
 mig för att använda (SignalR-bibliotek med Asp.net-core) på serversidan (back-end) och till (Client side ) och  använda (Angular 8 med paketet aspnet/signalr).
Jag tror att jag måste få data i realtid från källan(source) så jag bestämde mig för att använda postman (ett lämpligt verktyg)som ett alternativ till verklig datakälla:
källa (Postman och inom det vi kan  lägga olika information i olika tid ett rum som finns i databas ) ---> server -----> client side (Angular8).
Jag ska också  lägga  till en enkel databas för att kontrollera data som ska jag få  från datakälla och använde (Sqlite) till detta.

Jag använde Visual Studio Code för att utveckla lösningen.
1- Vad jag har använt för (Client side)implementering:
-Angular8.
-Bootstrap 4.
-Aspnet/signalr@1.1.0(paketet)
-Fontawesome@4.7.0
2-Vad jag har använt för (Server side)implementering:
-Asp.NetCore 2.1
-SignalR(bibliotek)
-AutoMapper(bibliotek)
-Sqlite(vi kan använder (DB Browser for SQLite) för att ange eller byta data inom databas)
3-Vad jag har använt för att få kontinuerlig information:
-Postman(ett lämpligt verktyg)

Exempel på hur applikationen kan köras via:
-öppna mapp (Task)
(det kan  begöver (restore) pakages)
-För att starta Api (server): öppna (TaskApp.API) i terminal ---> (dotnet watch run) eller (dotnet run).
-För att starta Angular (Client): öppna (TaskApp-SPA) i terminal ---> (ng serve -o)
- För att ändra rumsinformation jag läggade  två alternativ eftersom jag har inte verklig datakälla :

1-Standard alternativ ska visar falska(fake) data automatiskt .
2-Andra alternativ med Postman ---> PUT / api / home / {id} där id (integer value (1,2,3,4,5...))betyder nummer av
 rum och det är unikt nummer .t.ex (http: // localhost: 5000 / api / home / 1)
ange  t.ex {"temperatur": 31, "fuktighet": 0,9} i request-body (JSON (Application / json)).för att man kan göra det här alternativ man måste titta på kommentarer 
som finns i koden i(AutoMapperProfiles).

Obs! (nummer av rum är: 1-Vardagsrum 2-Kök 3-Sovrummet 4-Badrummet) Jag lägger till tre rum men du kan lägga till mer om du behöver om du använder (DB Browser för SQLite).

Obs! Jag skriver alla kommentarer i koden på engelska 
Obs! Jag lägga DataBas med data inom projekt du  kan köra direckt (databas numn:TaskApp.db)
Obs! För att köra min client App du måste ha (nodejs v10.16.0 eller V10.16.x )