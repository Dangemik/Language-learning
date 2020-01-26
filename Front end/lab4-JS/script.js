// zad1 
function zad1(){
    var num = Math.floor(Math.random() *10) + 1;
    val = document.getElementById("number").value;
    if(val == num){
        alert("zgadles");
    }
    else {
        alert("Nie zgadles" + num);
    }
}

// zad2
function multipy(){
    document.getElementById("demo").innerHTML =  document.getElementById("one").value * document.getElementById("two").value;
}
function divide(){
    document.getElementById("demo").innerHTML =  document.getElementById("one").value / document.getElementById("two").value;
}