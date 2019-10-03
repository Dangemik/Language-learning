-- LAB 4
--zad 1
select * from pojazdy join kierowcy on(wlasciciel = id_kierowcy)
where extract (year from data_prod) = 2018;
--zad 2
select nr_rejestr,marka,modell,data_prod,wlasciciel, nazwisko,imie ,data_urodzenia,data_urodzenia-data_prod as Dni,
extract(year from data_urodzenia)-extract(year from data_prod) AS LAT
from pojazdy join kierowcy on(wlasciciel= id_kierowcy)
where data_prod<data_urodzenia;
--zad 3
select * from pracownicy;
select * from stanowisko;

select * from pracownicy join stanowiska using (stanowisko)
where placa not between placa_min and placa_max;
--zad 4
select trunc(czas),nazwisko,imie,gatunki.nazwa,lowiska.nazwa,waga,dlugosc 
from Rejestry join wedkarze using(id_wedkarza) left join gatunki using(id_gatunku)
join lowiska using (id_lowiska)
where gatunki.nazwa is not null
order by trunc(czas);
--zad 5
select trunc(czas),nazwisko, nvl(gatunki.nazwa,'Brak polowu')
from REJESTRY join wedkarze using(ID_WEDKARZA) left join gatunki using(id_gatunku)
join lowiska using (id_lowiska)
where czas>= sysdate - interval '1' year;
--zad 6
select id_wedkarza, nazwisko, imie ,id_licencji,id_okregu
from Licencje join wedkarze using(id_wedkarza)
where rodzaj like 'podstawowa' and licencje.id_okregu like 'PZW%';
--zad 7
select id_wedkarza, nazwisko,id_okregu,id_licencji,
od_dnia||'-'|| extract(year from sysdate) as Poczatek, 
do_dnia||'-'|| extract(year from sysdate) as Koniec
from Licencje join wedkarze using(id_wedkarza)
where rok=extract(year from sysdate);
--zad 8
select id_wedkarza,nazwisko,id_okregu,id_licencji,
od_dnia||'-'||rok as Poczatek ,do_dnia||'-'||rok as Koniec,
to_date(do_dnia||'-'||rok,'DD-MM-YYYY')-to_date(od_dnia||'-'||rok,'DD-MM-YYYY') +1  as "Liczba dni",
(to_date(do_dnia||'-'||rok,'DD-MM-YYYY')-to_date(od_dnia||'-'||rok,'DD-MM-YYYY') +1)*oplaty.dzienna_oplata as "koszt Licencji"
from licencje join oplaty using(rok,id_okregu)join wedkarze using(id_wedkarza)
where not(od_dnia like'01-01'and do_dnia like'31-12');
--zad 9 
select p.ID_DZIALU,p.nazwisko, p.NR_AKT, p.placa,
p1.id_dzialu, p1.NR_AKT,p1.NAZWISKO,p1.PLACA
from pracownicy p cross join pracownicy p1
where p.id_dzialu =20 and p1.id_dzialu=30;
--zad 10
select p1.nr_akt,p1.nazwisko,p1.imiona,p2.nr_akt,p2.nazwisko,p2.imiona 
from pracownicy p1 left join pracownicy p2 on(p1.przelozony=p2.nr_akt);
--zad 11
select rok, count(*) from studenci
where kierunek like 'INFORMATYKA'
group by rok;
--zad 12
select tryb,kierunek,count(kierunek) from studenci
group by kierunek,tryb
having count(kierunek)>=100;
--zad 13
select rok,stopien,gr_dziekan,count(*)liczba_studentek,round(avg(srednia),2) srednia
from studenci where imiona like '%a' and kierunek like 'MATEMATYKA'
group by rok,stopien,gr_dziekan;
-- 14
select kierunek,rok,min(data_urodzenia) Najmlodszy,max(data_urodzenia) Najstarszy,
trunc(months_between(max(data_urodzenia),min(data_urodzenia))) roznica
from studenci 
where stopien=1 and lower(tryb) like 'stacjonarny'
group by rok,kierunek
having trunc(months_between(max(data_urodzenia),min(data_urodzenia)))>=150;
--zad 15
select extract(year from czas), to_char (czas,'day'),
count(*), count (id_gatunku)
from rejestry 
where mod(extract(day from czas),2)=0
group by extract(year from czas), to_char(czas,'day') 
order by 3 desc,4 desc;
--zad 16
select wlasciciel,nazwisko,imie,count(*) as "Liczba Pojazdow",count(distinct Marka) as "liczba Marek"
from Pojazdy join Kierowcy on(wlasciciel=id_kierowcy)
where typ like 'samochod ciezarowy'
group by wlasciciel,nazwisko,imie
having count(*) between 5 and 15
order by 4 desc;
--zad 17
select id_dzialu,nazwa,round(avg(placa),2)as "Srednia Placa" 
from pracownicy left join Dzialy using(id_dzialu)
where data_zwol is null or data_zwol>=sysdate
group by id_dzialu,nazwa;
--zad 18
select adres,count(*) "liczba pracownikow", count(koszt_ubezpieczenia) "Lista ubezpiecoznych",
sum(placa+dod_funkcyjny)*12 "Koszty pracownicze"
from pracownicy join dzialy using(id_dzialu)
group by adres;
--zad 19
select st.stanowisko, count(nr_akt) "Liczba pracownikow",
trunc(avg(placa+placa+dod_staz*0.1+nvl(pr.dod_funkcyjny,0)-nvl(koszt_ubezpieczenia,0))) srednia_pensja,
trunc(min(placa+placa+dod_staz*0.1+nvl(pr.dod_funkcyjny,0)-nvl(koszt_ubezpieczenia,0))) min_pensja,
trunc(max(placa+placa+dod_staz*0.1+nvl(pr.dod_funkcyjny,0)-nvl(koszt_ubezpieczenia,0))) maks_pensja
from pracownicy pr right join stanowiska st on(pr.stanowisko=st.stanowisko)
where data_zwol is null or data_zwol>=sysdate
group by st.Stanowisko;
--zad 20
select decode(id_gatunku,null,'brak',id_gatunku) ID_Gatunku,
nvl(nazwa,'brak polowu'),count(*) Sztuk,nvl(sum(waga),0) Laczana_waga, 
nvl(trunc(avg(waga),2),0) Srednia_waga,
nvl(trunc(avg(dlugosc),2),0) Srednia_dlugosc
from rejestry left join gatunki using(id_gatunku)
group by id_gatunku,nazwa;
--zad 21
select id_lowiska, nazwa, count(*) as "liczba polowów", 
count(id_gatunku)  as "Liczba ryb", count(distinct id_wedkarza)  as "liczba wedkarzy"
from rejestry natural join lowiska lowis
where czas between timestamp '2016-03-11 15:15:00' 
and timestamp '2016-03-11 15:15:00' +  interval '2' year +interval '21 21:21:21' day(2) to second
GROUP by id_lowiska,nazwa
having count(*)>4 and count(*)-count(id_gatunku)>=2;
--zad 22
select rok,id_okregu,count(id_licencji) as "liczba licencji",count(distinct (id_wedkarza)) Liczba_wedkarzy
from okregi join oplaty using(id_okregu) left join Licencje using(rok,id_okregu)
group by rok,id_okregu;
--zad 23
select id_kierowcy, nazwisko, imie, count(nr_rejestr) "liczba Pojazdow",count(distinct marka) "liczba Marek"
from pojazdy right join kierowcy on (wlasciciel=id_kierowcy)
group by id_kierowcy, nazwisko, imie
having count(nr_rejestr)=0 or (count(*)=3 and count(distinct marka)=3);
--zad 24
select nazwa,rekord_waga,max(waga), trunc(100*max(waga)/rekord_waga,2)
from rejestry right join gatunki using (id_gatunku)
group by nazwa,rekord_waga
having 100*max(nvl(waga,0))/rekord_waga>25 or (max(nvl(waga,0))/rekord_waga)*100=0;