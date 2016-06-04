function substitute() {
    $.ajax({ url: "Game/Substitute", type: "POST", data: $('form').serialize() })
     .done(function (data) {
         $('.wizard').wizard('next');
     });
}


//function substitute() {
//    var url = '@Url.Action("Substitute", "Game")';
//    $.post(url, $('form').serialize(), function (view) {
//        $("#Model").val(view);
//    });
//}