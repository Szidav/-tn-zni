describe('GET /', () => {
  it('Kezdőoldal', () => {
      cy.request('GET', 'http://localhost:8000/')
          .its('body')
          .should('deep.equal', { message: "Backend vizsgafeladat" });
  });
});

describe('GET /artists', () => {
  it('Előadók listája', () => {
      cy.request('GET', 'http://localhost:8000/artists')
          .its('status')
          .should('equal', 200);
  });
});

describe('GET /genre-tracks/:genreId', () => {
  it('Műfaj keresés id szerint', () => {
      cy.request('GET', 'http://localhost:8000/genre-tracks/1')
          .its('status')
          .should('equal', 200);
  });
});

describe('Artist post teszt', () => {
  it('artist poszt', () => {
    cy.request({
      method:'POST',
      url:'http://localhost:8000/artist',
      body:{name:'Han Yolo'}
    }).as('artistpost');
    cy.get('@artistpost').then(
      res=>{
        expect(res.status).to.eq(201);
        expect(res.body).has.property('message','Beszúrás rendben ')
      }
    );
  })
})
