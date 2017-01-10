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
        //izbrana kategorija
        var selectedCategory = document.querySelector('#category-and-search-input-container select').value;
        var searchFilter = $('#search-filter').val();

        var parameters = {
            url: "/Home/SearchItems",
            type: "POST",
            dataType: "json",
            data: { searchQuery: searchFilter, category: selectedCategory },
            success: function (data) {
                //console.log(data.list);

                $("#result-container").empty();
                var list = data.list;

                if (list.length == 0) {
                    $("#result-container").append("<span>Ni zadetkov</span>");
                }
                else {
                    var div = document.createElement("div");
                    div.id = "table-container";
                    var table = document.createElement("table");
                    var trHead = document.createElement("tr");
                    var thName = document.createElement("th");
                    thName.append("Naziv");
                    var thRentlength = document.createElement("th");
                    thRentlength.append("Čas izposoje");
                    var thIsAvailable = document.createElement("th");
                    thIsAvailable.append("Status");
                    trHead.append(thName);
                    trHead.append(thRentlength);
                    trHead.append(thIsAvailable);
                    table.append(trHead);
                    div.append(table);
                    $("#result-container").append(div);

                    for (var i = 0; i < list.length; i++) {
                        //console.log(list[i].Name);
                        //console.log(list[i].RentLength);


                        var tr = document.createElement("tr");
                        //dodaj tri tdje
                        var tdName = document.createElement("td");
                        var aName = document.createElement("a");
                        aName.href = list[i].Url; //TODo get code
                        aName.append(list[i].Name);
                        tdName.append(aName);
                        //td2
                        var tdRentLength = document.createElement("td");
                        tdRentLength.append(list[i].RentLength);
                        //td3
                        var tdIsAvailable = document.createElement("td");
                        if (list[i].IsAvailable) {
                            tdIsAvailable.append("Prosto");
                        }
                        else {
                            tdIsAvailable.append("Izposojeno");
                        }

                        tr.appendChild(tdName);
                        tr.appendChild(tdRentLength);
                        tr.appendChild(tdIsAvailable);

                        $('#table-container table').append(tr); //apendam tr-je z vsebino
                    }
                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        }
        $.ajax(parameters);

        //submit
        showResults();
        return true;
    }
    else {
        //set custom valididty
        return false;
    }
}