function createPieChart(dataPoints, id) {
    console.log(id)
    var chartPie = new CanvasJS.Chart(id, {
        animationEnabled: true,
        title: {
            text: "Trend Pie Chart"
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

function createAllPieCharts(data) {
    for (let i = 0; i < data.length; i++) {
        console.log(data[i]);
        createPieChart(data[i], "chartContainer-" + i);
    }
}