const allStars = document.querySelectorAll('li[data-rate]');

allStars.forEach((star) => {
    star.onclick = function () {
        let currentStarLevel = star.getAttribute('data-rate');

        allStars.forEach((star, i) => {
            if (currentStarLevel >= i + 1) {
                star.firstChild.className = "bi bi-star-fill";
            } else {
                star.firstChild.className = "bi bi-star";
            }
        })
    }
});
