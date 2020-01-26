var gridDataFetch = [];
var butt = document.getElementById("butt");
var search = document.getElementById("search");
//BUTTON
// butt.addEventListener("click", async function() {
//Without button
async function loadPage() {
  // fetch promise
  //   fetch(
  //     "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/products.json"
  //   )
  //     .then(response => {
  //       response.json().then(json => {
  //         gridDataFetch = json;
  //         console.log("data downloaded by fetch");
  //         console.log(gridDataFetch);
  //       });
  //     })
  //     .catch(err => console.error(err));

  // fetch await
  try {
    var response = await fetch(
      "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/products.json"
    );
    gridDataFetch = await response.json();
    console.log("data downloaded by fetch await");
    console.log(gridDataFetch);
  } catch (error) {
    console.error(error);
  }

  //   fetch ajax
  //   $.ajax({
  //     url:
  //       "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/products.json",
  //     dataType: "json",
  //     method: "get"
  //   }).done(res => console.log(res));

  for (i = 0; i < gridDataFetch.length; i++) {
    $("#catalog").append(
      "<tr><td>" +
        (i + 1) +
        "</td><td>" +
        gridDataFetch[i].title +
        "</td><td>" +
        gridDataFetch[i].type +
        "</td><td>" +
        gridDataFetch[i].description +
        "</td><td>" +
        gridDataFetch[i].filename +
        "</td><td>" +
        gridDataFetch[i].height +
        "</td><td>" +
        gridDataFetch[i].width +
        "</td><td>" +
        gridDataFetch[i].price +
        "</td><td>" +
        gridDataFetch[i].rating +
        "</td></tr>"
    );
  }
}

search.addEventListener("click", async function() {
  $("#catalog").empty();
  var word = $("#searchWord").val();
  var choice = $("#choice").val();
  if (choice == "contains") {
    for (i = 0; i < gridDataFetch.length; i++) {
      if (gridDataFetch[i].description.includes(word)) {
        $("#catalog").append(
          "<tr><td>" +
            (i + 1) +
            "</td><td>" +
            gridDataFetch[i].title +
            "</td><td>" +
            gridDataFetch[i].type +
            "</td><td>" +
            gridDataFetch[i].description +
            "</td><td>" +
            gridDataFetch[i].filename +
            "</td><td>" +
            gridDataFetch[i].height +
            "</td><td>" +
            gridDataFetch[i].width +
            "</td><td>" +
            gridDataFetch[i].price +
            "</td><td>" +
            gridDataFetch[i].rating +
            "</td></tr>"
        );
      }
    }
  } else if (choice == "startWith") {
    for (i = 0; i < gridDataFetch.length; i++) {
      if (gridDataFetch[i].description.startsWith(word)) {
        $("#catalog").append(
          "<tr><td>" +
            (i + 1) +
            "</td><td>" +
            gridDataFetch[i].title +
            "</td><td>" +
            gridDataFetch[i].type +
            "</td><td>" +
            gridDataFetch[i].description +
            "</td><td>" +
            gridDataFetch[i].filename +
            "</td><td>" +
            gridDataFetch[i].height +
            "</td><td>" +
            gridDataFetch[i].width +
            "</td><td>" +
            gridDataFetch[i].price +
            "</td><td>" +
            gridDataFetch[i].rating +
            "</td></tr>"
        );
      }
    }
  } else if (choice == "endWith") {
    for (i = 0; i < gridDataFetch.length; i++) {
      if (gridDataFetch[i].description.endsWith(word)) {
        $("#catalog").append(
          "<tr><td>" +
            (i + 1) +
            "</td><td>" +
            gridDataFetch[i].title +
            "</td><td>" +
            gridDataFetch[i].type +
            "</td><td>" +
            gridDataFetch[i].description +
            "</td><td>" +
            gridDataFetch[i].filename +
            "</td><td>" +
            gridDataFetch[i].height +
            "</td><td>" +
            gridDataFetch[i].width +
            "</td><td>" +
            gridDataFetch[i].price +
            "</td><td>" +
            gridDataFetch[i].rating +
            "</td></tr>"
        );
      }
    }
  }
});
