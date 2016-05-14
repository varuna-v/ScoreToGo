using STG.DataAccess.AccessObjects.Raven;
using System.Collections.Generic;
using STG.Domain.Models;

namespace STG.Importer
{
    public class TeamsImporter
    {
        private List<Team> Teams = new List<Team>()
        {
            {
                new Team() 
                {
                    Code = "MM1", 
                    Colour = "Black", 
                    Name = "Manchester Marvels 1", 
                    Id = 1, 
                    Players  =  new List<Player>()
                    {
                        {new Player() {Id = 1, ShirtNumber = 1, Name = "Alice Walton", RegistrationNumber = 5537}},
                        {new Player() {Id = 2, ShirtNumber = 2, Name = "Agnieszka Gajek", RegistrationNumber = 8616}},
                        {new Player() {Id = 3, ShirtNumber = 3, Name = "Paschalia Paschali", RegistrationNumber = 6501}},
                        {new Player() {Id = 4, ShirtNumber = 4, Name = "Maria Mytilinaiou", RegistrationNumber = 8307}},
                        {new Player() {Id = 5, ShirtNumber = 5, Name = "Lucie Pocinkova", RegistrationNumber = 7552}},
                        {new Player() {Id = 6, ShirtNumber = 6, Name = "Elitsa Gosheva", RegistrationNumber = 7584}},
                        {new Player() {Id = 7, ShirtNumber = 7, Name = "Lito Vera Fouki", RegistrationNumber = 7791}},
                        {new Player() {Id = 8, ShirtNumber = 8, Name = "Carmen Soggia", RegistrationNumber = 8409}},
                        {new Player() {Id = 9, ShirtNumber = 9, Name = "Alice Lanzotti", RegistrationNumber = 8493}},
                        {new Player() {Id = 10, ShirtNumber = 10, Name = "Silvia Lambiase", RegistrationNumber = 8502}},
                        {new Player() {Id = 11, ShirtNumber = 11, Name = "Jasmine Mills", RegistrationNumber = 8619}}
                    }
                }},
                {
                    new Team() 
                    {
                        Code = "MM2", 
                        Colour = "Yellow", 
                        Name = "Manchester Marvels 2", 
                        Id = 2, 
                        Players  =  new List<Player>()
                        {
                            {new Player() { Id = 12, ShirtNumber = 3,  Name = "Varuna Venkatesh", RegistrationNumber = 7579}},
                            {new Player() { Id = 13, ShirtNumber = 2,  Name = "Kathleen Nolan", RegistrationNumber = 409}},
                            {new Player() { Id = 14, ShirtNumber = 1,  Name = "Oana Claudia Ionascu", RegistrationNumber = 8309}},
                            {new Player() { Id = 15, ShirtNumber = 4,  Name = "Laura Davies", RegistrationNumber = 8304}},
                            {new Player() { Id = 16, ShirtNumber = 5,  Name = "Jennifer Hyde", RegistrationNumber = 7582}},
                            {new Player() { Id = 17, ShirtNumber = 6,  Name = "Philippa Slinger", RegistrationNumber = 7583}},
                            {new Player() { Id = 18, ShirtNumber = 7,  Name = "Sian Godwyn", RegistrationNumber = 8305}},
                            {new Player() { Id = 19, ShirtNumber = 8,  Name = "Angela Leo", RegistrationNumber = 7686}},
                            {new Player() { Id = 20, ShirtNumber = 9,  Name = "Urszula Uryszek", RegistrationNumber = 8302}},
                            {new Player() { Id = 21, ShirtNumber = 10, Name = "Amelie Pentecouteau", RegistrationNumber = 8410}},
                            {new Player() { Id = 22, ShirtNumber = 11, Name = "Patricia Penalver", RegistrationNumber = 8749}},
                            {new Player() { Id = 23, ShirtNumber = 12,Name = "Susi Caldwell", RegistrationNumber = 8620}},
                            {new Player() { Id = 24, ShirtNumber = 13,Name = "Katarzyna Mirgos", RegistrationNumber = 8652}},
                            {new Player() { Id = 25, ShirtNumber = 14,Name = "Eve Tollenaar", RegistrationNumber = 8750}},
                            {new Player() { Id = 26, ShirtNumber = 15, Name = "Alice Walton", RegistrationNumber = 5537}}
                        }
                    }

            }
        };

        public void Import()
        {
            var dataAccess = new RavenDataAccess();
            foreach (var team in Teams)
                dataAccess.Save(team);

        }

    }
}
