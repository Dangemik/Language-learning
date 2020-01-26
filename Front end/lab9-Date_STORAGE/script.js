var lista = [];

function addForm() {
  lista.push([$("#firstn").val(), $("#lastn").val(), $("#salary").val()]);

  $("#lista").empty();
  var i;
  for (i = 0; i < lista.length; i++) {
    $("#lista").append(
      "<li>" + lista[i][0] + " " + lista[i][1] + " " + lista[i][2] + "</li>"
    );
  }
}
// 6
function setItem(name, value, storage) {
  if (storage == localStorage) {
    localStorage.setItem(name, value);
  } else if (storage == sessionStorage) {
    sessionStorage.setItem(name, value);
  }
}
function getItem(name, storage) {
  if (storage == localStorage) {
    return localStorage.getItem(name);
  } else if (storage == sessionStorage) {
    return sessionStorage.getItem(name);
  }
}
// 7
function setCookie(name, value) {
  Cookies.set(name, value);
}
function getCookie(name) {
  return Cookies.get(name);
}
//8
console.log("local: ", getItem("zm", localStorage));
console.log("sesion: ", getItem("zm", sessionStorage));
console.log("cookies: ", getCookie("zm"));
