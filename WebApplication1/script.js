let currentIndex = 0;

function moveSlide(direction) {
    const carousel = document.querySelector('.carousel');
    const totalCards = document.querySelectorAll('.carousel-card').length;
    currentIndex = (currentIndex + direction + totalCards) % totalCards;
    const offset = -currentIndex * 100;
    carousel.style.transform = `translateX(${offset}%)`;
}
