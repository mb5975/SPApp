function showResults() {
    document.getElementById('result-container').style.visibility = 'visible';
}

//za post je treba sam prvega dat praznega (value) in required na select in bo delal
function validate_search() {
    var selectedIndex = document.querySelector('#category-and-search-input-container select').selectedIndex;
    var selectedValue = document.querySelector('#category-and-search-input-container select').value;

    //var searchFilter = document.getElementById('search-filter').value;
    //if (selectedIndex == 0 || searchFilter == "") {
    if (selectedValue == 'disabled') { //dela tudi tam, kjer ni prvega disabled za razliko od indexa
        return false;
    }
    else {
        return true;
    }
}

function submit_search() {
    var validation_successful = validate_search();
    if (validation_successful) {
        //submit
        console.log("validation successful");
        showResults();
        return true;
    }
    else {
        //set custom valididty
        return false;
    }
}