-- laboratorium 7

--zad 1
select * from wedkarze
where id_wedkarza = any (
select ID_WEDKARZA from rejestry join gatunki using(id_gatunku)
where nazwa like 'SANDACZ');

--zad 3
select stanowisko,placa_min,placa_max,staz_min,dod_funkcyjny
from stanowiska s_zew
where placa_min<=all
(select placa from pracownicy where stanowisko=s_zew.stanowisko
and (data_zwol is null or data_zwol>=sysdate)) and
placa_max>=all
(select placa from pracownicy where stanowisko=s_zew.stanowisko
and (data_zwol is null or data_zwol>=sysdate));

--ZAD 6
select DISTINCT id_okregu, ga.nazwa from lowiska lo cross join gatunki ga
where id_okregu like 'PZW%'
and Exists(
select * from lowiska join rejestry using(id_lowiska)
join gatunki using (id_gatunku)
where id_okregu like 'PZW%' and gatunki.nazwa=ga.nazwa and id_okregu=lo.id_okregu
);
--zad 7
select DISTINCT id_okregu, ga.nazwa from lowiska lo cross join gatunki ga
where id_okregu like 'PZW%'
and Exists(
select gatunki.nazwa,id_okregu,extract(year from czas),count(DISTINCT id_wedkarza)
from lowiska join rejestry using(id_lowiska)
join gatunki using (id_gatunku)
where id_okregu like 'PZW%' and gatunki.nazwa=ga.nazwa and id_okregu=lo.id_okregu
group by gatunki.nazwa,id_okregu,extract(year from czas) 
having count(DISTINCT id_wedkarza)>=3
);
--zad 14
select nazwa, count(*),listagg(nazwisko,',') within group(order by nazwisko) Lowcy
from rejestry join gatunki using (id_gatunku) join wedkarze using( id_wedkarza)
group by nazwa;

--zad 15

select nazwa,sum(liczba), listagg(nazwisko||' '||litera||'('||liczba||')',' ') within group
(order by liczba desc)
from(
select nazwa, count(*),id_wedkarza,nazwisko,
substr(imie,1,1)||'.' litera,count(*) liczba
from rejestry join gatunki using (id_gatunku) join wedkarze using( id_wedkarza)
group by nazwa,id_wedkarza,nazwisko,substr(imie,1,1)||'.'
)
group by nazwa;

--zad 10

select * from WEDKARZE t1 join (
select  id_wedkarza from rejestry join wedkarze using(id_wedkarza)
group by id_wedkarza
having count(id_gatunku)=0) t2 on (t1.id_wedkarza=t2.id_wedkarza);




