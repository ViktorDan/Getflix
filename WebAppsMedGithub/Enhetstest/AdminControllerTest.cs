using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using WebAppsMedGithub.Controllers;
using DAL;
using WebAppsMedGithub.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Web.Mvc;

namespace Enhetstest
{
    [TestClass]
    public class AdminControllerTest
    {

        [TestMethod]
        public void AdminKunder()
        {
            // Arrange

            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));

            var forventetResultat = new List<dbKunder>();
            var kunde = new dbKunder()
            {
                Id = 1,
                Fornavn = "Henrik",
                Etternavn = "Karlsen",
                Adresse = "Kirkeveien 11",
                Postnr = 1234,
                Tlf = 12345678,
            };
            forventetResultat.Add(kunde);
            forventetResultat.Add(kunde);
            forventetResultat.Add(kunde);

            // Act

            var actionResult = (ViewResult)controller.AdminKunder();
            var resultat = (List<dbKunder>)actionResult.Model;

            // Assert

            Assert.AreEqual(actionResult.ViewName, "");
            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].Id, resultat[i].Id);
                Assert.AreEqual(forventetResultat[i].Fornavn, resultat[i].Fornavn);
                Assert.AreEqual(forventetResultat[i].Etternavn, resultat[i].Etternavn);
                Assert.AreEqual(forventetResultat[i].Adresse, resultat[i].Adresse);
                Assert.AreEqual(forventetResultat[i].Postnr, resultat[i].Postnr);
                Assert.AreEqual(forventetResultat[i].Tlf, resultat[i].Tlf);
            }
        }

        [TestMethod]
        public void AdminFilm()
        {
            // Arrange

            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            var forventetResultat = new List<Filmer>();
            var film = new Filmer()
            {
                FId = 1,
                Navn = "IT",
                Aar = 2017,
                Lengde = 110,
                Pris = 160,
                Sjanger = "Skrekk",
                Bilde = "IT.jpg",
            };
            forventetResultat.Add(film);
            forventetResultat.Add(film);
            forventetResultat.Add(film);

            // Act

            var actionResult = (ViewResult)controller.AdminFilm();
            var resultat = (List<Filmer>)actionResult.Model;

            // Assert

            Assert.AreEqual(actionResult.ViewName, "");
            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].FId, resultat[i].FId);
                Assert.AreEqual(forventetResultat[i].Navn, resultat[i].Navn);
                Assert.AreEqual(forventetResultat[i].Aar, resultat[i].Aar);
                Assert.AreEqual(forventetResultat[i].Lengde, resultat[i].Lengde);
                Assert.AreEqual(forventetResultat[i].Pris, resultat[i].Pris);
                Assert.AreEqual(forventetResultat[i].Sjanger, resultat[i].Sjanger);
                Assert.AreEqual(forventetResultat[i].Bilde, resultat[i].Bilde);
            }
        }

        [TestMethod]
        public void AdminBestilling()
        {
            // Arrange

            var controller = new AdminController(new AdminBLL(new AdminRepositoryStub()));
            var forventetResultat = new List<Bestillinger>();
            var bestilling = new Bestillinger()
            {
                BId = 1,
                Brukernavn = "Bruker1",
                FId = 1,
                dato = DateTime.Today,
            };
            forventetResultat.Add(bestilling);
            forventetResultat.Add(bestilling);
            forventetResultat.Add(bestilling);

            // Act

            var actionResult = (ViewResult)controller.AdminBestilling();
            var resultat = (List<Bestillinger>)actionResult.Model;

            // Assert

            Assert.AreEqual(actionResult.ViewName, "");
            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].FId, resultat[i].FId);
                Assert.AreEqual(forventetResultat[i].Brukernavn, resultat[i].Brukernavn);
                Assert.AreEqual(forventetResultat[i].FId, resultat[i].FId);
                Assert.AreEqual(forventetResultat[i].dato, resultat[i].dato);
            }
        }

        [TestMethod]
        public void EndreKunde()
        {
            // Arrange
            var forventetResultat = true;
            var AdminRepositoryStub = new AdminRepositoryStub();

            // Act
            var resultat = AdminRepositoryStub.EndreKunde(1, "bruker", "Hans", "Gruber", "Skurkeveien 1", 1313, 99119911);

            // Assert
            Assert.IsTrue(resultat == forventetResultat);
        }

        [TestMethod]
        public void SlettKundeRiktig()
        {
            // Arrange
            var forventetResultat = true;
            var AdminRepositoryStub = new AdminRepositoryStub();
            // Act
            var resultat = AdminRepositoryStub.SlettKunde(1);
            // Assert
            Assert.AreEqual(forventetResultat, resultat);
        }

        [TestMethod]
        public void SlettKundeFeil()
        {
            // Arrange
            var forventetResultat = false;
            var AdminRepositoryStub = new AdminRepositoryStub();
            // Act
            var resultat = AdminRepositoryStub.SlettFilm(0);
            // Assert
            Assert.AreEqual(forventetResultat, resultat);
        }

        [TestMethod]
        public void SlettFilmRiktig(int id)
        {
            // Arrange
            var forventetResultat = true;
            var AdminRepositoryStub = new AdminRepositoryStub();
            // Act
            var resultat = AdminRepositoryStub.SlettFilm(1);

            // Assert
            Assert.IsTrue(forventetResultat == resultat);
        }

        [TestMethod]
        public void SlettFilmFeil(int id)
        {
            // Arrange
            var forventetResultat = false;
            var AdminRepositoryStub = new AdminRepositoryStub();

            // Act
            var resultat = AdminRepositoryStub.SlettFilm(0);

            // Assert
            Assert.AreEqual(forventetResultat, resultat);
        }

        [TestMethod]
        public void SlettBestillingRiktig(int id)
        {
            // Arrange
            var forventetResultat = true;
            var AdminRepositoryStub = new AdminRepositoryStub();
            // Act
            var resultat = AdminRepositoryStub.SlettBestilling(1);
            // Assert
            Assert.AreEqual(forventetResultat, resultat);
        }

        [TestMethod]
        public void SlettBestillingFeil(int id)
        {
            // Arrange
            var forventetResultat = false;
            var AdminRepositoryStub = new AdminRepositoryStub();
            // Act
            var resultat = AdminRepositoryStub.SlettBestilling(0);
            // Assert
            Assert.AreEqual(forventetResultat, resultat);
        }
    }
}
