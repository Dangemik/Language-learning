-- laboratorium 5
--zad 1
select * from studenci
where kierunek like 'INFORMATYKA' and data_urodzenia=(select min(data_urodzenia) from studenci
where kierunek like 'INFORMATYKA');
--zad 2
select extract(year from czas) rok, gatunki.nazwa Gatunek, dlugosc,nazwisko, lowiska.nazwa
from Rejestry 
join Wedkarze using (id_wedkarza) 
join Gatunki using (id_gatunku)
join lowiska using (id_lowiska)
where (extract(year from czas),id_gatunku,dlugosc) in
(
  select extract(year from czas),id_gatunku,max(dlugosc)
  from REJESTRY
  group by extract (year from czas),id_gatunku
);

--zad 3
select * from REJESTRY 
where extract (month from czas )=5 and extract (day from czas) in(6,7)
and waga=(
select max(waga) from rejestry
where extract (month from czas )=5 and 
extract (day from czas) in(6,7)
);
--zad 4
select kierunek,tryb,nr_indeksu,nazwisko,srednia from studenci 
where rok=2 and stopien=1 and (kierunek,tryb,srednia) in(
select kierunek,tryb, min(srednia) from studenci
where rok=2 and stopien=1
group by kierunek,tryb)
order by srednia ;
--zad 5
select kierunek, srednia, nazwisko, imiona ,nr_indeksu, stopien, rok, tryb from studenci
where (kierunek,srednia) in (
select kierunek, max(srednia) from studenci
where imiona like '%a'
group by Kierunek
)
order by kierunek,srednia;
-- zad 6
select id_kierowcy, nazwisko, imie,adres, count(nr_rejestr) as "Liczba pojazdow" 
from pojazdy join kierowcy on(wlasciciel=id_kierowcy)
where typ like 'samochod osobowy' or typ like 'motocykl'
group by id_kierowcy, nazwisko, imie,adres
having count(nr_rejestr)=4;
--zad 7
select id_kierowcy, nazwisko, imie,adres,count(nr_rejestr),
(select count(nr_rejestr) from Pojazdy where typ like 'samochod osobowy' and wlasciciel = id_kierowcy) as sam,
(select count(nr_rejestr) from Pojazdy where typ like 'motocykl' and wlasciciel = id_kierowcy) as mot
from kierowcy join pojazdy on (wlasciciel= id_kierowcy)
where typ like 'samochod osobowy' or typ like 'motocykl'
group by id_kierowcy ,nazwisko ,imie ,adres
having count (nr_rejestr) = 
(
select max(count(wlasciciel)) from pojazdy
where typ like 'samochod osobowy' or typ like 'motocykl'
group by wlasciciel
);
--zad 8
select gatunki.nazwa,trunc(czas), floor(sysdate-trunc(czas)) as Dni, nazwisko,imie
from rejestry right join gatunki using(id_gatunku) join Wedkarze using(id_wedkarza) join Lowiska
using(id_lowiska)
where (id_gatunku,czas) in(
select id_gatunku, max(czas) from rejestry
group by id_gatunku)
order by 1;
--zad 11
select * from 
(
select typ,max(liczba) maxLiczba from 
(select typ,marka,modell, count(modell) liczba from pojazdy
group by typ,marka,modell)
group by typ) t1
join (select typ,marka,modell, count(modell) liczba from pojazdy
group by typ,marka,modell) t2 on (t1.typ=t2.typ and liczba=maxLiczba); 
--zad 12
--??
--zad 13
select * from 
(select id_gatunku,id_wedkarza,id_lowiska,dlugosc,
extract (year from czas) rok 
from rejestry) t1 join
(select id_gatunku,extract (year from czas) rok,avg(dlugosc) srednia
from rejestry
where dlugosc is not null
group by id_gatunku,extract(year from czas)
)t2 on (t1.id_gatunku=t2.id_gatunku and t1.rok=t2.rok and dlugosc >srednia);
--zad 14
select * from 
(select id_okregu,max(laczna_waga) maks_waga from
(select id_okregu,id_lowiska,nazwa, sum(waga) laczna_waga from lowiska join rejestry using(id_lowiska)
where id_okregu like 'PZW%'
group by id_okregu,id_lowiska,nazwa)
group by id_okregu) t1 join  
(select id_okregu,id_lowiska,nazwa, sum(waga) laczna_waga from lowiska join rejestry using(id_lowiska)
where id_okregu like 'PZW%'
group by id_okregu,id_lowiska,nazwa) t2 
on (t1.id_okregu=t2.id_okregu and maks_waga=laczna_waga);
--zad 15
select tryb,stopien,kierunek,rok,count(nr_indeksu) liczba_studentow from studenci
group by rollup (tryb,stopien,kierunek,rok);
-- zad 16
select decode (grouping_id(tryb,stopien,kierunek,rok),
0,'TSK',1,'TS',3,'T',7,'w danym trybie',15,'ogolem') komentarz,
tryb,stopien,kierunek,rok, count(*) from studenci
group by rollup (tryb,stopien,kierunek,rok);
--zad 17
select decode(grouping_id (typ,marka,id_kierowcy),7,'podsumowanie',2,'po marce','inne')komentarz,
nazwisko,id_kierowcy,typ,marka,count(nr_rejestr)
from pojazdy join kierowcy on(id_kierowcy=wlasciciel)
group by grouping sets((typ,marka),(typ),(marka),(id_kierowcy,nazwisko),());

