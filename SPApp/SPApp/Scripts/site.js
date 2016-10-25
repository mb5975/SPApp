//register fading of background image
document.addEventListener('scroll', fader);

    //register scroll event 
window.addEventListener("scroll", toggleFixedMenu);
window.addEventListener('scroll', animate_elems);




function fader() {
    var scrolledFromTop = (window.pageYOffset !== undefined) ? window.pageYOffset : (document.documentElement || document.body.parentNode || document.body).scrollTop;
    console.log(scrolledFromTop);
    if (scrolledFromTop > 200) {
        document.getElementsByClassName("divWithBackgroundImage")[0].style.opacity = Math.min(1, Math.max(1 - scrolledFromTop / 500 + 0.4, 0));
    }
    else {
        document.getElementsByClassName("divWithBackgroundImage")[0].style.opacity = 1;
    }

}

function toggleFixedMenu() {
    var fromTop = (window.pageYOffset !== undefined) ? window.pageYOffset : (document.documentElement || document.body.parentNode || document.body).scrollTop;
    if (fromTop > 800) {
        document.getElementsByClassName("fixed-index-header")[0].style.visibility = 'visible';
    }
    else if (fromTop < 800) {
        var m = document.getElementsByClassName("fixed-index-header")[0].style.visibility = 'hidden';
    }

}


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
    if (wintop > (topcoords - (winheight * .60))) {
        // window is 3/4 above the element
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