$(function () {
    $(function () {
        getGrid();
    });
});

function getGrid() {
    var gridRequest = $.get('/api/grid');

    $.when(gridRequest).done(function (gridResponse) {
        initGrid(gridResponse.columns);
    });
};

function initGrid(columns) {
    $("#div-grid").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    type: "GET",
                    url: "/api/data",
                    dataType: "json"
                }
            },
            schema: {
                data: "data",
                total: "total"
            },
            serverPaging: true,
            serverSorting: true,
            pageSize: 50
        },
        height: 700,
        groupable: true,
        sortable: true,
        reorderable: true,
        resizable: true,
        pageable: {
            refresh: true,
            pageSizes: true,
            buttonCount: 5
        },
        scrollable: true,
        columnMenu: true,
        sort: function (e) {
            consoleLog(e.sort.field + ' sorted in direction -> ' + e.sort.dir);
        },
        columnReorder: function (e) {
            consoleLog(e.column.title + ' reordered.');
        },
        columnResize: function (e) {
            consoleLog(e.column.title + ' resized.');
        },
        columns: columns
    });

    var grid = $("#div-grid").data("kendoGrid");

    $(".btn-save-state").click(function (e) {
        e.preventDefault();
        localStorage["kendo-grid-options"] = kendo.stringify(grid.getOptions());

        consoleLog("State saved.");
    });

    $(".btn-load-state").click(function (e) {
        e.preventDefault();
        var options = localStorage["kendo-grid-options"];

        if (options) {
            grid.setOptions(JSON.parse(options));

            consoleLog("State loaded.");
        }
    });

    $(".theme-list ul li").click(function (e) {
        var self = $(this);
        var skinName = self.data('skin-name');

        $(".theme-list ul li").removeClass('active');
        self.addClass('active');

        changeTheme(skinName);

        consoleLog("Skin updated.");
    });
};

function changeTheme(skinName, animate) {
    var doc = document,
        kendoLinks = $("link[href*='kendo.']", doc.getElementsByTagName("head")[0]),
        commonLink = kendoLinks.filter("[href*='kendo.common']"),
        skinLink = kendoLinks.filter(":not([href*='kendo.common'])"),
        skinRegex = /kendo\.\w+(\.min)?\.css/i,
        extension = skinLink.attr("rel") === "stylesheet" ? ".css" : ".less",
        url = commonLink.attr("href").replace(skinRegex, "kendo." + skinName + "$1" + extension);

    function replaceTheme() {
        $("div-grid").fadeOut(250);

        var oldSkinName = $(doc).data("kendoSkin"),
            newLink;

        if ($.browser && $.browser.msie) {
            newLink = doc.createStyleSheet(url);
        } else {
            newLink = skinLink.eq(0).clone().attr("href", url);
        }

        newLink.insertBefore(skinLink[0]);
        skinLink.remove();

        $(doc.documentElement).removeClass("k-" + oldSkinName).addClass("k-" + skinName);

        $("div-grid").fadeIn(250);
    }

    replaceTheme();
};

function consoleLog(message) {
    $(".console-log span").text(message).fadeIn(250);

    setTimeout(function () {
        $(".console-log span").fadeOut(500);
    }, 1000);
}