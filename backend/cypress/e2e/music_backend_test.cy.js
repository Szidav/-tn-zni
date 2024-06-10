describe('Alap végpont', () => {
  it('Kezdőoldal', () => {
    cy.request('GET','http://localhost:8000/')
    .its('body')
  })
})