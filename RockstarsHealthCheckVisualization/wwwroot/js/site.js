// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function createPieChart(dataPoints) {
    var chartPie = new CanvasJS.Chart("chartContainer", {
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