
![Näyttökuva 2024-11-03 115416](https://github.com/user-attachments/assets/78b27ac8-aee5-4b71-86d9-29449166db84)

1.Sovelluksen yleinen rakenne

Tämä sovellus on viestintäsovellus, joka vastaa viestien hallinnasta, käyttäjätilien luomisesta ja niiden hallinnasta sekä tietojen pysyvästä tallentamisesta tietokantaan.

Controllers: Sisältää MessagesController- ja UsersController-luokat, jotka käsittelevät viestien ja käyttäjien hallintaa koskevat API-pyynnöt.

Middleware: ApiKeyMiddleware- ja BasicAuthenticationHandler-moduulit vastaavat käyttöoikeuksien tarkastamisesta, API-avaimien käytöstä sekä perusautentikoinnista.

Models: Määrittelee tiedon rakenteet, joita sovellus käyttää viestien (Message) ja käyttäjien (User) tietojen hallintaan.

Repositories: IMessageRepository, MessageRepository, IUserRepository ja UserRepository hoitavat tietokantakyselyitä ja tietojen käsittelyä käyttäen MessageServiceContext-tietokantayhteyttä.

Services: Näihin tiedostoihin on sijoitettu liiketoimintalogiikka, eli varsinaiset toiminnot, kuten viestin lähetys, viestien haku, käyttäjän luonti ja kirjautuminen.

Program.cs: Määrittelee sovelluksen alustusprosessin, mukaan lukien tietokantayhteydet, autentikointijärjestelmän sekä välimoduulit.

2. Rajapinnat (API)
     
Käyttäjän luonti: POST /api/users

![Näyttökuva 2024-11-03 121111](https://github.com/user-attachments/assets/4c96f23f-2cb0-4665-ae60-2e05fef20f43)

Käyttäjän tietojen haku: GET /api/users/username

![Näyttökuva 2024-11-03 121220](https://github.com/user-attachments/assets/b27cbb81-8dc5-4684-a9e0-5d148a25c3e7)

Käyttäjän tietojen päivitys: PUT /api/users/username

![Näyttökuva 2024-11-03 120525](https://github.com/user-attachments/assets/15745e6e-9497-4ce8-9347-88530485f366)

Viestien käsittely:
Uuden viestin luonti: POST /api/messages

![Näyttökuva 2024-11-03 121352](https://github.com/user-attachments/assets/5fb5cf5a-ce70-4bd9-a3f7-ea1098c3dd55)


Kaikkien julkisten viestien haku: GET /api/messages

![Näyttökuva 2024-11-03 121455](https://github.com/user-attachments/assets/c061df8c-2d61-4397-a861-7b3baa645a85)

  
3. Sovelluksen käyttö

Käyttöprosessin vaiheet:
Käyttäjä lähettää pyynnön POST /api/users-päätepisteeseen, jolloin UsersController luo uuden käyttäjätunnuksen. 
Käytetty UserRepository huolehtii tietojen tallennuksesta.

Autentikointi ja API-avain:
ApiKeyMiddleware varmistaa, että pyynnön mukana on API-avain. BasicAuthenticationHandler varmistaa käyttäjän todennuksen ja huolehtii siitä, että käyttäjä on oikeutettu toimintoihin.

Toimintojen käyttö:
Program.cs määrittelee autentikoinnin, joka tarkistaa käyttöoikeudet kaikkien kutsujen yhteydessä.

4. Käytimme Postman nimistä työkalua mm. API-Pyyntöjen testaamiseen.

![Näyttökuva 2024-11-03 122753](https://github.com/user-attachments/assets/46243874-ac32-4513-815b-b2d02b51184b)


5. Esimerkkiprosessi: Viestin lähettäminen

Käyttäjä lähettää POST /api/messages-pyynnön.

Reititys ja kontrollointi:
MessagesController ohjaa pyynnön oikeaan palveluun, ja MessageRepository tallentaa viestin tietokantaan.

Vahvistus ja palautus:
Kun viesti on tallennettu, sovellus palauttaa vahvistusviestin, ja viesti on saatavilla käyttäjälle tulevaisuudessa.

Esimerkkiprosessi: Käyttäjätietojen haku

![Näyttökuva 2024-11-03 123246](https://github.com/user-attachments/assets/92247195-73b3-4089-a420-a67d3f56d433)


Käyttäjän pyyntö: Käyttäjä lähettää GET-pyynnön /api/users/{username}-päätepisteeseen.

Reititys ja kontrollointi: UsersController ohjaa pyynnön oikeaan palveluun, joka tarkistaa käyttäjätietojen saatavuuden.

Tietojen haku: UserRepository hakee pyydetyn käyttäjän tiedot tietokannasta.

Palautus: Sovellus palauttaa käyttäjätiedot JSON-muodossa, tai ilmoittaa virheestä, jos käyttäjää ei löydy.


