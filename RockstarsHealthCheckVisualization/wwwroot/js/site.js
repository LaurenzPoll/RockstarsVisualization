function createPieChart(dataPoints, id) {
    var _data = JSON.stringify(dataPoints)
    var _json = JSON.parse(_data)

    var chartPie = new CanvasJS.Chart(id, {
        animationEnabled: true,
        title: {
            text: _json[0].text
        },
        toolTip: {
            shared: true
        },
        data: [{
            type: "pie",
            name: "Trend",
            dataPoints: dataPoints
                }]
            });
    chartPie.render();
}


function CreateAverageAnswer(dataPoints) {
    var chart = new CanvasJS.Chart("chartContainer", {
        animationEnabled: true,
        title: {
            text: "Average answers"
        },
        axisY: {
            minimum: -2,
            maximum: 2,
            interval: 1
        },
        toolTip: {
            shared: true
        },
        data: [{
            type: "column",
            name: "Questions",
            dataPoints: dataPoints
}]
        });
chart.render();
}

function createAllPieCharts(data1, data2) {
    for (let i = 0; i < data1.length; i++) {
        createPieChart(data1[i], "chartContainer-" + i);
    }
    CreateAverageAnswer(data2)
}