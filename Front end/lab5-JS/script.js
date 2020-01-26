function zad1() {
  document.getElementById("p1").style.fontSize = "20px";
  document.getElementById("p1").style.color = "red";
}
function zad2() {
  value = document.getElementById("imageValue").value;
  document.getElementById("image").src = value;
}
function zad3() {
  var tab = document.getElementById("listUl");
  adres = document.getElementById("adres").value;
  nazwaLink = document.getElementById("nazwaLink").value;

  var a = document.createElement("a");
  a.innerText = nazwaLink;
  a.href = adres;
  var elem = document.createElement("li");
  elem.appendChild(a);
  //   tab.appendChild(elem);
  tab.insertBefore(elem, tab.childNodes[0]);
}
function mOver(obj) {
  obj.innerHTML = Date();
}
function mOut(obj) {
  obj.innerHTML =
    "Nulla suscipit odio quis dui luctus ornare non in ante. Vestibulum tempor ex at erat pellentesque hendrerit. Fusce ut quam vel velit consequat euismod. In iaculis dolor tortor, eget congue ipsum pretium non. Proin nunc ante, consectetur sed erat eu, porta rhoncus urna. Etiam hendrerit ultricies nulla. Praesent sagittis elementum dictum. In lacinia rhoncus ante a finibus. Nunc ornare neque nec leo fermentum, aliquam ornare nisi dictum. Mauris at ultrices quam.";
}
function clickText(obj) {
  document.getElementById("demo").innerHTML = Date();
}
