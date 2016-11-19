//register fading of background image
document.addEventListener('scroll', fader);

//register scroll event 
window.addEventListener("scroll", toggleFixedMenu);





function fader() {
    var scrolledFromTop = (window.pageYOffset !== undefined) ? window.pageYOffset : (document.documentElement || document.body.parentNode || document.body).scrollTop;
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