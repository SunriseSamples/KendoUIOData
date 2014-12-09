(function ($) {
    var kendo = window.kendo;

    $.extend(true, kendo.data, {
        schemas: {
            odataCors: {
                type: "json",
                data: "d.results",
                total: "d.__count"
            }
        },
        transports: {
            odataCors: {
                read: {
                    cache: true, // to prevent jQuery from adding cache buster
                    dataType: "json",
                },
                dialect: function (options) {
                    var result = ["$inlinecount=allpages"],
                        data = options || {};

                    //...detail omitted..

                    return result.join("&");
                }
            }
        }
    });
})(jQuery);