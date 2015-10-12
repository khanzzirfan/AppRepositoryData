$(document).ready(function() {

    //$(document).on("click", ".nav.navbar-nav li", function(e) {
    //    alert("clicked event");
    //});
    $('#order').hide();

    $('.nav.navbar-nav').on("click", "li", function() {

        var current = $('.nav.navbar-nav li.active a').text();
        if (current == "Home") {
            $('#home').hide();
        }
        else if (current == "Order") {
            $('#order').hide();
        }
        $('.nav.navbar-nav li.active').removeClass('active');
        $(this).addClass('active');

        var item = $('.nav.navbar-nav li.active a').text();
        if (item == "Home") {
            $('#home').show();
        }
        else if (item == "Order") {
            $('#order').show();
        }
    });

});