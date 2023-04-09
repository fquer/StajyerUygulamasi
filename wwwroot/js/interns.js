window.addEventListener('load', () => {
    const cards = document.querySelectorAll('.card');
    cards.forEach((card) => {
        card.addEventListener('click', () => {
            console.log(card.id)
            // id ile url param koyup redirect et ayrintilar sayfasini goster.
            window.location.href = "/internsdetail?internID=" + card.id
        })
    })
})