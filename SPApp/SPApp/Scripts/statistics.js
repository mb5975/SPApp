var graphShown = false;
var graphSize = 0; //1,2 prvi ali drugi trenutno narisan
window.onload = function () {
    ShowGraph(graphShown);
    graphShown = true;
}

window.addEventListener('resize', ShowGraph);

//https://docs.amcharts.com/javascriptcharts/AmGraph

function ShowGraph() {
    if (graphShown && ((graphSize == 1 && screen.width <= 480) || (graphSize == 2 && screen.width > 480))) {
        return;
    }
    if (screen.width <= 480) {
        graphSize = 1;
        var chart = AmCharts.makeChart("chart-top-month", {
            "type": "serial",
            "theme": "light",
            "marginRight": 40,
            "dataProvider": [{
                "title": "Davincijeva šifra",
                "rents": 5
            }, {
                "title": "Z idejo do bogastva",
                "rents": 3

            }, {
                "title": "Programming the World Wide Web",
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
                "type": "column",
                "balloonText": "<b>[[category]]: [[value]]</b>",
                "fillAlphas": 0.6,
                "lineAlpha": 1,
                "valueField": "rents",
                "bullet": "none"
            }],
            "chartCursor": {
                "categoryBalloonEnabled": false,
                "cursorAlpha": 0,
                "zoomable": false
            },
            "categoryField": "title",
            "categoryAxis": {
                "gridPosition": "start",
                "labelRotation": -45
            }
        });

        var chart2 = AmCharts.makeChart("chart-number-rents-per-month", {
            "type": "serial",
            "theme": "light",
            "marginRight": 40,
            "dataProvider": [{
                "month": "Avgust",
                "rents": 5
            }, {
                "month": "September",
                "rents": 9

            }, {
                "month": "Oktober",
                "rents": 8
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
                "labelRotation": -45
            }
        });
    }
    else {
        graphSize = 2;
        var chart = AmCharts.makeChart("chart-top-month", {
            "type": "serial",
            "theme": "light",
            "marginRight": 40,
            "dataProvider": [{
                "title": "Davincijeva šifra",
                "rents": 5
            }, {
                "title": "Z idejo do bogastva",
                "rents": 3

            }, {
                "title": "Programming the World Wide Web",
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
                "type": "column",
                "balloonText": "<b>[[category]]: [[value]]</b>",
                "fillAlphas": 0.6,
                "lineAlpha": 1,
                "valueField": "rents",
                "bullet": "none"
            }],
            "chartCursor": {
                "categoryBalloonEnabled": false,
                "cursorAlpha": 0,
                "zoomable": false
            },
            "categoryField": "title",
            "categoryAxis": {
                "gridPosition": "start",
                "labelRotation": 0
            }
        });

        var chart2 = AmCharts.makeChart("chart-number-rents-per-month", {
            "type": "serial",
            "theme": "light",
            "marginRight": 40,
            "dataProvider": [{
                "month": "Avgust",
                "rents": 5
            }, {
                "month": "September",
                "rents": 9

            }, {
                "month": "Oktober",
                "rents": 8
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
                "labelRotation": 0
            }
        });
    }
}


