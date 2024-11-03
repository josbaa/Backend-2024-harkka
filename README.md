1.Sovelluksen yleinen rakenne
  
Sovellus on rakennettu käyttäen eri moduuleja, joiden avulla palvelin pystyy hallitsemaan viestien ja käyttäjien käsittelyä.

Controllers: Sisältää MessagesController- ja UsersController-luokat, jotka käsittelevät viestien ja käyttäjien hallintaa koskevat API-pyynnöt.

Middleware: ApiKeyMiddleware- ja BasicAuthenticationHandler-moduulit vastaavat käyttöoikeuksien tarkastamisesta, API-avaimien käytöstä sekä perusautentikoinnista.

Models: Määrittelee tiedon rakenteet, joita sovellus käyttää viestien (Message) ja käyttäjien (User) tietojen hallintaan.

Repositories: IMessageRepository, MessageRepository, IUserRepository ja UserRepository hoitavat tietokantakyselyitä ja tietojen käsittelyä käyttäen MessageServiceContext-tietokantayhteyttä.

Services: UserAuthenticationService vastaa käyttäjien autentikoinnista ja oikeuksien tarkastamisesta, erityisesti käyttäjän omistamien viestien suhteen.

Program.cs: Määrittelee sovelluksen alustusprosessin, mukaan lukien tietokantayhteydet, autentikointijärjestelmän sekä välimoduulit.

2. Rajapinnat (API)
     
Käyttäjän luonti: POST /api/users
Käyttäjän tietojen haku: GET /api/users/username
Käyttäjän tietojen päivitys: PUT /api/users/username
  
Viestien käsittely:
Uuden viestin luonti: POST /api/messages
Kaikkien julkisten viestien haku: GET /api/messages
Tietyn viestin haku: GET /api/messages/
  
3. Sovelluksen käyttö

Käyttöprosessin vaiheet:
Käyttäjä lähettää pyynnön POST /api/users-päätepisteeseen, jolloin UsersController luo uuden käyttäjätunnuksen. 
Käytetty UserRepository huolehtii tietojen tallennuksesta.

Autentikointi ja API-avain:
ApiKeyMiddleware varmistaa, että pyynnön mukana on API-avain. BasicAuthenticationHandler varmistaa käyttäjän todennuksen ja huolehtii siitä, että käyttäjä on oikeutettu toimintoihin.

Toimintojen käyttö:
Program.cs määrittelee autentikoinnin, joka tarkistaa käyttöoikeudet kaikkien kutsujen yhteydessä.

4. Esimerkkiprosessi: Viestin lähettäminen

Käyttäjä lähettää POST /api/messages-pyynnön.

Reititys ja kontrollointi:
MessagesController ohjaa pyynnön oikeaan palveluun, ja MessageRepository tallentaa viestin tietokantaan.

Vahvistus ja palautus:
Kun viesti on tallennettu, sovellus palauttaa vahvistusviestin, ja viesti on saatavilla käyttäjälle tulevaisuudessa.
