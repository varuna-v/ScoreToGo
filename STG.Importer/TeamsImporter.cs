using STG.DataAccess.Raven;
using System.Collections.Generic;
using STG.Domain.Models;
using System;

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
                    UniqueId = Guid.NewGuid(), 
                    Players  =  new List<Player>()
                    {
                        {new Player() {UniqueId = Guid.NewGuid(), ShirtNumber = 1, Name = "Alice Walton", RegistrationNumber = 5537}},
                        {new Player() {UniqueId = Guid.NewGuid(), ShirtNumber = 2, Name = "Agnieszka Gajek", RegistrationNumber = 8616}},
                        {new Player() {UniqueId = Guid.NewGuid(), ShirtNumber = 3, Name = "Paschalia Paschali", RegistrationNumber = 6501}},
                        {new Player() {UniqueId = Guid.NewGuid(), ShirtNumber = 4, Name = "Maria Mytilinaiou", RegistrationNumber = 8307}},
                        {new Player() {UniqueId = Guid.NewGuid(), ShirtNumber = 5, Name = "Lucie Pocinkova", RegistrationNumber = 7552}},
                        {new Player() {UniqueId = Guid.NewGuid(), ShirtNumber = 6, Name = "Elitsa Gosheva", RegistrationNumber = 7584}},
                        {new Player() {UniqueId = Guid.NewGuid(), ShirtNumber = 7, Name = "Lito Vera Fouki", RegistrationNumber = 7791}},
                        {new Player() {UniqueId = Guid.NewGuid(), ShirtNumber = 8, Name = "Carmen Soggia", RegistrationNumber = 8409}},
                        {new Player() {UniqueId = Guid.NewGuid(), ShirtNumber = 9, Name = "Alice Lanzotti", RegistrationNumber = 8493}},
                        {new Player() {UniqueId = Guid.NewGuid(), ShirtNumber = 10, Name = "Silvia Lambiase", RegistrationNumber = 8502}},
                        {new Player() {UniqueId = Guid.NewGuid(), ShirtNumber = 11, Name = "Jasmine Mills", RegistrationNumber = 8619}}
                    }
                }},
                {
                    new Team() 
                    {
                        Code = "MM2", 
                        Colour = "Yellow", 
                        Name = "Manchester Marvels 2", 
                        UniqueId = Guid.NewGuid(), 
                        Players  =  new List<Player>()
                        {
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 3,  Name = "Varuna Venkatesh", RegistrationNumber = 7579}},
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 2,  Name = "Kathleen Nolan", RegistrationNumber = 409}},
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 1,  Name = "Oana Claudia Ionascu", RegistrationNumber = 8309}},
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 4,  Name = "Laura Davies", RegistrationNumber = 8304}},
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 5,  Name = "Jennifer Hyde", RegistrationNumber = 7582}},
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 6,  Name = "Philippa Slinger", RegistrationNumber = 7583}},
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 7,  Name = "Sian Godwyn", RegistrationNumber = 8305}},
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 8,  Name = "Angela Leo", RegistrationNumber = 7686}},
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 9,  Name = "Urszula Uryszek", RegistrationNumber = 8302}},
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 10, Name = "Amelie Pentecouteau", RegistrationNumber = 8410}},
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 11, Name = "Patricia Penalver", RegistrationNumber = 8749}},
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 12,Name = "Susi Caldwell", RegistrationNumber = 8620}},
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 13,Name = "Katarzyna Mirgos", RegistrationNumber = 8652}},
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 14,Name = "Eve Tollenaar", RegistrationNumber = 8750}},
                            {new Player() { UniqueId = Guid.NewGuid(), ShirtNumber = 15, Name = "Alice Walton", RegistrationNumber = 5537}}
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
