
/*
  Rozwi¹zania zadañ 
  z
  Laboratorium 2  
*/


--Zad 1.1
select Count(*) as "liczba studentek" from studenci
where imiona like '%a' and tryb like 'STACJONARNY' and rok=3 and stopien=1 and kierunek like 'INFORMATYKA';
--Zad 1.2
select count(nazwisko) as "liczba Nowakowskich" from studenci
where lower(nazwisko) like 'nowak' and imiona not like '%a';
--Zad 1.3
select count(*) as "liczba studentów na Litere M", count(distinct imiona) as "Liczba ro¿nych imion na M"
from studenci
where imiona like 'M%' and imiona not like '%a';
--Zad 1.4
select concat(nazwisko,concat(' ',imiona)) as "Personalia studentow" from studenci
where rok=4 and STOPIEN=3 order by nazwisko;
--Zad 1.5
select substr(imiona,1,3) as "3 litery imiona", 
substr(nazwisko,length(nazwisko)-2,length(nazwisko)) as "3 ostatnie litery nazwiska",
imiona, nazwisko
from studenci
where specjalnosc is null;
--Zad 1.6
select substr(nazwisko,1,1)||'.'||substr(imiona,1,1)||'.' as "Inicialy",imiona, nazwisko,length(concat(nazwisko,imiona)) 
from studenci
where length(concat(nazwisko,imiona)) IN(9,11,13);
--Zad 1.7
select distinct initcap(kierunek) as Kierunek from studenci;
select distinct Concat(Upper(Substr(kierunek,1,1)),lower(substr(kierunek,2,length(kierunek)-1))) Kierunek
from studenci;

--Zad 1.8
select Replace(nazwisko,'Ko') as "nazwisko bez KO", replace(imiona,'sz') as "imie bez SZ",
concat(nazwisko,concat(' ',imiona)) as "Personalia"
from studenci
where nazwisko like 'Ko%' and imiona like '%sz';
--Zad 1.9
select nazwisko, length(nazwisko) as Liczba_liter,
instr(nazwisko,'a',1,1) as "Pozycja A w nazwisku"
from studenci
where rok=2 and length(nazwisko) between 6 and 9 and nazwisko like '%a%'
order by Liczba_liter desc;
--Zad 1.10
select nazwisko, Replace(nazwisko,'Ba','Start') as "Po zmianie", imiona,
concat(Rtrim(imiona,'a'),'End') as "Po zmianie im"
from studenci
where nazwisko like 'Ba%' and imiona like '%a';
--Zad 1.11
select rpad(lpad(nazwisko,length(nazwisko)+3,'*'),
length(nazwisko)+7,'+')
from studenci;
--zad 2.1
select * from pojazdy
where nr_rejestr  between 'SC0%' and 'SC9%' and pojemnosc Between 1000 and 2000;


select * from pojazdy
where nr_rejestr like 'SC%' and
substr(nr_rejestr,3,1) in ('0','1','2','3','4','5','6','7','8','9')
and pojemnosc between 1000 and 2000;
-- zad 2.2
select nr_rejestr, substr(nr_rejestr,length(nr_rejestr)-3,2) as Liczba, marka,kolor
from pojazdy
where marka like 'Ford' and kolor like '%metalik%' and 
(to_number(substr(nr_rejestr,length(nr_rejestr)-3,1))+ to_number(substr(nr_rejestr,length(nr_rejestr)-2,1)))/3 in(0,3,6,9,12,15);
--zad 2.3
select * from pojazdy
where length(replace(nr_rejestr,'6'))=7 and pojemnosc between 250 and 500 and kolor like '% %';

--zad 2.4
select marka,modell,typ,pojemnosc,decode(pojemnosc,1000,'maly pojazd',2000,'sredni samochod',
3000,'duzy samochod')
from pojazdy
where typ not like 'samochod ciezarowy' and pojemnosc in(1000,2000,3000);
--zad 2.5
select nr_rejestr, modell, pojemnosc, 
decode(substr(nr_rejestr,1,2),'SC','slaskie','OP','opolskie','DW','dolnoslaskie','KR','malopolskie','niezindyfikowany')
as województwo
from pojazdy
where marka like 'Opel' and pojemnosc not between 1600 and 2200;
--zad 3.1
select 'od '||Trunc(Min(czas))||' do '||Trunc(Max(czas))||
' odnotowano '||Count(czas)||' polowow w tym udanych '||
Count(id_gatunku)||' na wodach '|| count(distinct(substr(id_lowiska,1,1)))|| 'zarzadcow.'
from rejestry;
--zad 3.2
select * from rejestry
where id_gatunku in(1,3,9,10) and id_lowiska like 'C%' and dlugosc between 40 and 60
and mod(waga,0.1)=0;
--zad 3.3

select count(*) as "liczba ryb",
count(distinct id_wedkarza) as "liczba lowcow",
count(distinct id_lowiska) as "liczba lowisk",
sum(waga) as "Laczna waga",
round(avg(waga),3) as "Srednia waga",
round(avg(dlugosc)) as "srednia dlugosc "
from rejestry;

--zad 3.2

select * from rejestry
where id_gatunku in (1,3,9,10) and id_lowiska like 'C%' and 
dlugosc between 40 and 60 and mod(waga,0.1)=0;

--zad 3.4
select trunc(czas) as "dzien polowu",id_gatunku, decode(id_gatunku,2,'lin',4,'amur',15,'ploc',17,'okon','Brak polowu')
from rejestry where id_gatunku in(2,4,15,17) or id_gatunku is null
order by czas desc;

