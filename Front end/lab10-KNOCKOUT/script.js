function PersonViewModel () {
  this.firstName = ko.observable(),
  this.lastName =  ko.observable(),
  this.fullName = ko.pureComputed(()=> `${this.firstName()} ${this.lastName()}`,this),
  this.dateOfBirth =  ko.observable(),
  this.age = ko.pureComputed(
      ()=> new Date().getFullYear() - new Date(this.dateOfBirth).getFullYear(), this
  ),
  this.computedLog = ko.observable('Log: '),
  this.compute= ko.pureComputed(function (){
      this.computedLog(this.computedLog.peek()+this.fullName+this.age+';');
      return this.fullName;
  })
}
var appVm = {
  persons: ko.observableArray()
}
var personVm = new PersonViewModel()
personVm.firstName("Jan")
personVm.lastName("Kowalski");
personVm.dateOfBirth(new Date(1980, 2, 15))

var personVm2 = new PersonViewModel()
personVm2.firstName("Adam")
personVm2.lastName("Nowak");
personVm2.dateOfBirth(new Date(1985, 2, 15))

appVm.persons.push(personVm);
appVm.persons.push(personVm2);
ko.applyBindings(personVm, document.querySelector(".zad3"));
ko.applyBindings(appVm, document.querySelector(".zad4"));


function AppData() {
  this.firstName = ko.observable('John');
  this.lastName = ko.observable('Burns');
  this.dateOfBirth = ko.observable('12.12.2010');
  this.computedLog = ko.observable('Log: ');
  this.fullName = ko.pureComputed(function () {
      var value = this.dateOfBirth() + " " + this.firstName() + " " + this.lastName();
      // Normally, you should avoid writing to observables within a pure computed 
      // observable (avoiding side effects). But this example is meant to demonstrate 
      // its internal workings, and writing a log is a good way to do so.
      this.computedLog(this.computedLog.peek() + value + '; ');
      return value;
  }, this);

  this.step = ko.observable(0);
  this.next = function () {
      this.step(this.step() === 3 ? 0 : this.step()+1);
  };
};
ko.applyBindings(new AppData(),document.querySelector("#zad8"));