--Laboratorium 6

--zad 1
select to_char(czas,'YYYY-MM-DD HH24:MI') Czas,dlugosc,'Ponizej sredniej' from rejestry
where id_gatunku = 10 and dlugosc < 58
Union
select to_char(czas,'YYYY-MM-DD HH24:MI') Czas,dlugosc,'Rowna sredniej' from rejestry
where id_gatunku = 10 and dlugosc = 58
Union
select to_char(czas,'YYYY-MM-DD HH24:MI') Czas,dlugosc,'Powyzej sredniej' from rejestry
where id_gatunku = 10 and dlugosc > 58;
--zad 2
select to_char(czas,'YYYY-MM-DD HH24:MI') "Czas Polowu", dlugosc, 
case
when dlugosc < (select avg(dlugosc )from  Rejestry join gatunki using(id_gatunku) where nazwa='SANDACZ') then 'ponizej sredniej'
when dlugosc = (select avg(dlugosc )from  Rejestry join gatunki using(id_gatunku) where nazwa='SANDACZ') then 'rowna sredniej'
else 'powyzej sredniej'
end komentarz
from Rejestry join gatunki using(id_gatunku);

--zad 3 
select tab.id_gatunku,tab.nazwa,count(rs.id_gatunku) from rejestry rs
right join(
select id_gatunku,nazwa from gatunki
minus
select id_gatunku,nazwa from gatunki left join rejestry using(id_gatunku)
group by id_gatunku,nazwa
having count(id_gatunku)>5) tab on (rs.id_gatunku=tab.id_gatunku)
group by tab.id_gatunku,tab.nazwa;
--zad 4
select id_kierowcy,nazwisko,imie,count(nr_rejestr) Liczba_Pojazdow from pojazdy po join (
select id_kierowcy,nazwisko,imie from kierowcy join pojazdy on(id_kierowcy=wlasciciel)
where typ like 'motocykl'
group by id_kierowcy,nazwisko,imie
having count(nr_rejestr)=1
Intersect
select id_kierowcy,nazwisko,imie from kierowcy join pojazdy on(id_kierowcy=wlasciciel)
where typ like 'samochod osobowy'
group by id_kierowcy,nazwisko,imie
having count(nr_rejestr)>=1
intersect
select id_kierowcy,nazwisko,imie from kierowcy join pojazdy on(id_kierowcy=wlasciciel)
where typ like 'samochod ciezarowy'
group by id_kierowcy,nazwisko,imie
having count(nr_rejestr)>=2) t2 on (po.wlasciciel=t2.id_kierowcy)
group by id_kierowcy,nazwisko,imie;
--zad 5

select t1.id_gatunku,t1.nazwa,count(re.id_gatunku) "Liczba ryb" from rejestry re join(
select id_gatunku, gatunki.nazwa from rejestry join gatunki using(id_gatunku) join lowiska using(id_lowiska)
where lowiska.nazwa like 'Poraj'
Intersect
select id_gatunku, gatunki.nazwa from rejestry join gatunki using(id_gatunku) join lowiska using(id_lowiska)
where lowiska.nazwa like 'Pilica'
minus
select id_gatunku, gatunki.nazwa from rejestry join gatunki using(id_gatunku) join wedkarze using(id_wedkarza)
where nazwisko like 'Andrysiak') t1 on (re.id_gatunku=t1.id_gatunku) join lowiska lo
on(re.id_lowiska=lo.id_lowiska) where lo.nazwa in('Poraj','Pilica')
group by t1.id_gatunku,t1.nazwa;




--zad 8
select ROK,round(avg(suma),2) "srednia waga",'srednia waga' from (
select extract(year from czas) ROK,id_wedkarza,sum(waga) suma from rejestry
group by extract(year from czas),id_wedkarza)
group by rok
union
select ROK,max(suma) "srednia waga",'Max waga' from (
select extract(year from czas) ROK,id_wedkarza,sum(waga) suma from rejestry
group by extract(year from czas),id_wedkarza)
group by rok;

--zad 12
select re.id_wedkarza, nazwisko,
case (
select count(czas) from rejestry join lowiska using (id_lowiska)
where id_wedkarza=re.id_wedkarza and id_okregu like 'PZW Czestochowa'
)
when 0 then 'Nie'
else 'Tak'
end "PZW Czestochowa", 
(
select count(czas) from rejestry join lowiska using (id_lowiska)
where id_wedkarza=re.id_wedkarza and id_okregu like 'PZW Czestochowa'
) as "Polowów CZ",

case (
select count(czas) from rejestry join lowiska using (id_lowiska)
where id_wedkarza=re.id_wedkarza and (id_okregu is null or id_okregu not like 'PZW')
)
when 0 then 'Nie'
else 'Tak'
end "Inne", 
(
select count(czas) from rejestry join lowiska using (id_lowiska)
where id_wedkarza=re.id_wedkarza and (id_okregu is null or id_okregu not like 'PZW')
) as "Polowów CZ"

from rejestry re join wedkarze we on(re.id_wedkarza=we.id_wedkarza)
join lowiska using (id_lowiska) 
group by re.id_wedkarza, nazwisko;

--zad 14
select g1.nazwa, g1.wymiar,
case 
when g1.wymiar<g2.wymiar then 'mniejszy'
when g1.wymiar>g2.wymiar then 'wiekszy'
else 'rowny'
end Komentarz,
g2.nazwa,g2.wymiar, abs(g1.wymiar-g2.wymiar) from gatunki g1 cross join gatunki g2
where g1.dpo is not null and g2.dpo is not null and abs(g1.wymiar-g2.wymiar) <=10;