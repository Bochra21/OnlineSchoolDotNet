$(".sidebar ul li").on('click', function () {
    $(".sidebar ul li.active").removeClass('active');
    $(this).addClass('active');
});

$('.open-btn').on('click', function () {
    $('#side_nav').addClass('active');
});

$('.close-btn').on('click', function () {
    $('#side_nav').removeClass('active');
});
