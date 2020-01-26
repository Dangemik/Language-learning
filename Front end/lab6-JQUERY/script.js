$(document).ready(function() {
  $("#zmienKolor").click(function() {
    $("p").css("color", "blue");
    $("div").css("color", "red");
    $(".orange").css("color", "orange");
  });

  $("#first").click(function() {
    $("ul li:eq(0)").before("<li>" + $("#ListText").val() + "</li>");
  });

  $("#end").click(function() {
    $("ul").append("<li>" + $("#ListText").val() + "</li>");
  });

  $("#mojDiv").before("<div><p>Jestem p wstawionym przed mojDiv</p></div>");

  $("p")
    .last()
    .addClass("req6");

  $("#mojZnacznik")
    .parent()
    .css("border", "2px solid red");

  $(".container > *").css("color", "green");

  $("#hide").click(function() {
    $(".hideShow").hide();
  });

  $("#show").click(function() {
    $(".hideShow").show();
  });

  $("#fade").click(function() {
    $(".hideShow").fadeOut("slow");
  });

  $(".hideShow").click(function() {
    $(".panel").slideToggle("slow");
  });

  $("#animation").click(function() {
    $(".anima").animate({
      left: "250px",
      height: "150px",
      width: "150px",
      fontSize: "3em"
    });
  });
});
