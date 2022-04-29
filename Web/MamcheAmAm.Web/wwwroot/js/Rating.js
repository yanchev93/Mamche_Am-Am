const allStars = document.querySelectorAll('li[data-rate]');

allStars.forEach((star, i) => {
    star.onclick = function () {
        let currentStarLevel = star.getAttribute('data-rate');
        console.log(currentStarLevel)
    }
})

// [...allStars].forEach(x => console.log(x))