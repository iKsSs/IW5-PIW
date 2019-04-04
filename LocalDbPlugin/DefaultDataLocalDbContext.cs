﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using Common.Models;

namespace Data
{
    public class DefaultDataLocalDbContext : DropCreateDatabaseIfModelChanges<LocalDbContext>
    {
        protected override void Seed(LocalDbContext context)
        {
            //Insert default data to database
            var genres = new List<string>
            {
                "Akční",
                "Animovaný",
                "Dobrodružný",
                "Dokumentární",
                "Drama",
                "Erotický",
                "Experimentální",
                "Fantasy",
                "Film-Noir",
                "Historický",
                "Horor",
                "Hudební",
                "IMAX",
                "Katastrofický",
                "Komedie",
                "Krátkometrážní",
                "Krimi",
                "Loutkový",
                "Muzikál",
                "Mysteriózní",
                "Podobenství",
                "Poetický",
                "Pohádka",
                "Povídkový",
                "Psychologický",
                "Publicistický",
                "Reality-TV",
                "Road movie",
                "Rodinný",
                "Romantický",
                "Sci-Fi",
                "Soutěžní",
                "Sportovní",
                "Talk-show",
                "Taneční",
                "Telenovela",
                "Thriller",
                "Válečný",
                "Western",
                "Životopisný"
            };
            var countries = new List<string>
            {
                "Afghánistán",
                "Albánie",
                "Alžírsko",
                "Andorra",
                "Angola",
                "Antigua a Barbuda",
                "Argentina",
                "Arménie",
                "Aruba",
                "Austrálie",
                "Ázerbájdžán",
                "Bahamy",
                "Bahrajn",
                "Bangladéš",
                "Barbados",
                "Belgie",
                "Belize",
                "Bělorusko",
                "Benin",
                "Bhútán",
                "Bolívie",
                "Bosna a Hercegovina",
                "Botswana",
                "Brazílie",
                "Brunej",
                "Bulharsko",
                "Burkina Faso",
                "Burundi",
                "Čad",
                "Černá Hora",
                "Česko",
                "Československo",
                "Čína",
                "Dánsko",
                "Demokratická republika Kongo",
                "Dominika",
                "Dominikánská republika",
                "Džibutsko",
                "Egypt",
                "Ekvádor",
                "Eritrea",
                "Estonsko",
                "Etiopie",
                "Faerské ostrovy",
                "Federativní státy Mikronésie",
                "Fed. rep. Jugoslávie",
                "Fidži",
                "Filipíny",
                "Finsko",
                "Francie",
                "Francouzská Polynésie",
                "Gabon",
                "Gambie",
                "Ghana",
                "Grenada",
                "Grónsko",
                "Gruzie",
                "Guadeloupe",
                "Guatemala",
                "Guinea",
                "Guinea-Bissau",
                "Guyana",
                "Haiti",
                "Honduras",
                "Hong Kong",
                "Chile",
                "Chorvatsko",
                "Indie",
                "Indonésie",
                "Irák",
                "Írán",
                "Irsko",
                "Island",
                "Itálie",
                "Izrael",
                "Jamajka",
                "Japonsko",
                "Jemen",
                "Jihoafrická republika",
                "Jižní Korea",
                "Jordánsko",
                "Jugoslávie",
                "Kambodža",
                "Kamerun",
                "Kanada",
                "Kapverdy",
                "Katar",
                "Kazachstán",
                "Keňa",
                "Kiribati",
                "Kolumbie",
                "Komory",
                "Kongo",
                "Korea",
                "Kosovo",
                "Kostarika",
                "Kréta",
                "Kuba",
                "Kuvajt",
                "Kypr",
                "Kyrgyzstán",
                "Laos",
                "Lesotho",
                "Libanon",
                "Libérie",
                "Libye",
                "Lichtenštejnsko",
                "Litva",
                "Lotyšsko",
                "Lucembursko",
                "Macao",
                "Madagaskar",
                "Maďarsko",
                "Makedonie",
                "Malajsie",
                "Malawi",
                "Maledivy",
                "Mali",
                "Malta",
                "Maroko",
                "Marshallovy ostrovy",
                "Martinik",
                "Mauricius",
                "Mauritánie",
                "Mayotte",
                "Mexiko",
                "Moldavsko",
                "Monako",
                "Mongolsko",
                "Mosambik",
                "Myanmar",
                "Namibie",
                "Nauru",
                "Německá říše",
                "Německo",
                "Nepál",
                "Niger",
                "Nigérie",
                "Nikaragua",
                "Nizozemsko",
                "Norsko",
                "Nová Kaledonie",
                "Nový Zéland",
                "Omán",
                "Pákistán",
                "Palau",
                "Palestina",
                "Panama",
                "Papua-Nová Guinea",
                "Paraguay",
                "Peru",
                "Pobřeží slonoviny",
                "Polsko",
                "Portoriko",
                "Portugalsko",
                "Protektorát Čechy a Morava",
                "Rakouské císařství",
                "Rakousko",
                "Rakousko-Uhersko",
                "Rovníková Guinea",
                "Rumunsko",
                "Ruské impérium",
                "Rusko",
                "Rwanda",
                "Řecko",
                "Saint-Pierre a Miquelon",
                "Salvador",
                "Samoa",
                "San Marino",
                "Saúdská Arábie",
                "Senegal",
                "Severní Korea",
                "Seychely",
                "Sierra Leone",
                "Singapur",
                "Slovensko",
                "Slovenský stát",
                "Slovinsko",
                "Somálsko",
                "Sovětský svaz",
                "Spojené arabské emiráty",
                "Srbsko",
                "Srbsko a Černá Hora",
                "Středoafrická republika",
                "Súdán",
                "Surinam",
                "Svatá Lucie",
                "Svatý Kryštof a Nevis",
                "Svatý Tomáš a Princův ostrov",
                "Svatý Vincenc a Grenadiny",
                "Svazijsko",
                "Sýrie",
                "Šalamounovy ostrovy",
                "Španělsko",
                "Šrí Lanka",
                "Švédsko",
                "Švédsko-norská unie",
                "Švýcarsko",
                "Tádžikistán",
                "Tanzanie",
                "Thajsko",
                "Tchaj-wan",
                "Tibet",
                "Togo",
                "Tonga",
                "Trinidad a Tobago",
                "Tunisko",
                "Turecko",
                "Turkmenistán",
                "Tuvalu",
                "Uganda",
                "Ukrajina",
                "Uruguay",
                "USA",
                "Uzbekistán",
                "Vanuatu",
                "Vatikán",
                "Velká Británie",
                "Venezuela",
                "Vietnam",
                "Východní Německo",
                "Východní Timor",
                "Wallis a Futuna",
                "Zambie",
                "Západní Německo",
                "Zimbabwe"
            };

            genres.ForEach(t => context.Genres.Add(new Genre
            {
                Name = t
            }));
            countries.ForEach(t => context.Countries.Add(new Country
            {
                Name = t
            }));
            context.SaveChanges();
        }
    }
}