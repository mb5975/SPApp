var graphShown = false;
var graphSize = 0; //1,2 prvi ali drugi trenutno narisan
window.onload = function () {
    ShowGraph(graphShown);
    graphShown = true;
}

window.addEventListener('resize', ShowGraph);


function ShowGraph() {
    if (graphShown && ((graphSize == 1 && screen.width <= 480) || (graphSize == 2 && screen.width > 480))) {
        return;
    }
    if (screen.width <= 480) {
        graphSize = 1;
        var chart = AmCharts.makeChart("chartdiv", {
            "type": "serial",
            "theme": "light",
            "marginRight": 40,
            "dataProvider": [{
                "month": "Avgust",
                "rents": 2
            }, {
                "month": "September",
                "rents": 3
            }, {
                "month": "Oktober",
                "rents": 1
            }],
            "valueAxes": [{
                //"axisAlpha": 0,
                "precision": "0",
                "position": "left",
                //"title": "Število izposoj v zadnjih 3 mesecih"
            }],
            "startDuration": 1,
            "graphs": [{
                "type": "line",
                "balloonText": "<b>[[category]]: [[value]]</b>",
                "fillAlphas": 0,
                "lineAlpha": 1,
                "valueField": "rents",
                "bullet": "round"
            }],
            "chartCursor": {
                "categoryBalloonEnabled": false,
                "cursorAlpha": 0,
                "zoomable": false
            },
            "categoryField": "month",
            "categoryAxis": {
                "gridPosition": "start",
                "labelRotation": 45
            }
        });
    }
    else {
        graphSize = 2;
        var chart = AmCharts.makeChart("chartdiv", {
            "type": "serial",
            "theme": "light",
            "marginRight": 40,
            "dataProvider": [{
                "month": "Oktober",
                "rents": 2
            }, {
                "month": "November",
                "rents": 3
            }, {
                "month": "December",
                "rents": 2
            }, {
                "month": "Januar",
                "rents": 2
            }, {
                "month": "Februar",
                "rents": 1
            }, {
                "month": "Marec",
                "rents": 3
            }, {
                "month": "April",
                "rents": 2
            }, {
                "month": "Maj",
                "rents": 4
            }, {
                "month": "Junij",
                "rents": 6
            }, {
                "month": "Julij",
                "rents": 5
            }, {
                "month": "Avgust",
                "rents": 2
            }, {
                "month": "September",
                "rents": 3
            }, {
                "month": "Oktober",
                "rents": 1
            }],
            "valueAxes": [{
                //"axisAlpha": 0,
                "precision": "0",
                "position": "left",
                //"title": "Število izposoj v zadnjih 3 mesecih"
            }],
            "startDuration": 1,
            "graphs": [{
                "type": "line",
                "balloonText": "<b>[[category]]: [[value]]</b>",
                "fillAlphas": 0,
                "lineAlpha": 1,
                "valueField": "rents",
                "bullet": "round"
            }],
            "chartCursor": {
                "categoryBalloonEnabled": false,
                "cursorAlpha": 0,
                "zoomable": false
            },
            "categoryField": "month",
            "categoryAxis": {
                "gridPosition": "start",
                "labelRotation": 45
            }
        });
    }
}


