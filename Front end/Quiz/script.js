function submitA() {
	//variables
	var total = 5;
	var score = 0;
	//get user input
	var q1 = document.forms.quizJS.qu1.value;
	var q2 = document.forms.quizJS.qu2.value;
	var q3 = document.forms.quizJS.qu3.value;
	var q4 = document.forms.quizJS.qu4.value;
	var q5 = document.forms.quizJS.qu5.value;
	
	for(i = 1;i<=total;i++){
		if(eval("q"+i) == "" || eval("q"+i) == null){
			alert("You missed question "+i);
			return false;
		}
	}
	
	//correct answers
	var answers = ["d","a","c","d","b"];
	//check answers
	for(i = 1;i<=total;i++){
		if(eval("q"+i) == answers[i-1]){
			score++;
		}
	}
	
	//Display score
	var results = document.getElementById('results');
	results.innerHTML = "<h2>You scored <strong>"+score+"/"+total+"</strong></h2>";
	
	alert("You scored "+score+"/"+total);
	
	return false;
}
