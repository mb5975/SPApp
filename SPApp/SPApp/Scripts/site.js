window.addEventListener('scroll', animate_elems);

function animate_elems() {
    var elements = document.getElementsByClassName('animateblock');
    var winheight = window.innerHeight;

    wintop = (window.pageYOffset !== undefined) ? window.pageYOffset : (document.documentElement || document.body.parentNode || document.body).scrollTop; // calculate distance from top of window

    // loop through each item to check when it animates
    for (var i = 0; i < elements.length; i++) {
        animate_element(elements[i], winheight);
    }
} // 


function animate_element(item, winheight) {
    if (item.classList.contains('animated')) { return true; }

    topcoords = getElemDistance(item); // element's distance from top of page
    if (wintop > (topcoords - (winheight * 0.70))) {
        item.classList.add('animated');
    }
}

// Get an element's distance from the top of the page
var getElemDistance = function (elem) {
    var location = 0;
    if (elem.offsetParent) {
        do {
            location += elem.offsetTop;
            elem = elem.offsetParent;
        } while (elem);
    }
    return location >= 0 ? location : 0;
};