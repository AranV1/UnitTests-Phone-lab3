using ClassLibrary;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace TestProjectPhone
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Konstruktor_Dane_Poprawne_OK()
        {
            //Arrange
            var wlasciciel = "Kowalski";
            var numer = "123456789";

            //Act
            var telefon = new Phone(wlasciciel, numer);
            //Assert
            Assert.AreEqual(wlasciciel, telefon.Owner);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Konstruktor_ZaKrotkiNumerTelefonu_ArgumentException()
        {
            //Arrange
            var wlasciciel = "Kowalski";
            var numer = "12345678";
            //Act
            var telefon = new Phone(wlasciciel,numer); 
            //Assert
            //Assert.ThrowsException<ArgumentException>(() => new Phone(wlasciciel, numer));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Konstruktor_NieKazdyZnakToCyfra()
        {
            //Arrange
            var wlasciciel = "Kowalski";
            var numer = "12345678a";
            //Act
            var telefon = new Phone(wlasciciel, numer);
            //Assert
            //Assert.ThrowsException<ArgumentException>(() => new Phone(wlasciciel, numer));
        }

        [TestMethod]
        public void WlasciwoscOwnerNullorEmpty()
        {
            //Arrange
            var wlasciciel = "";
            var numer = "123456789";
            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => new Phone(wlasciciel, numer));
        }

        [TestMethod]
        public void TestPojemosciBookCapacity()
        {
            var phone = new Phone("Kowalski", "123456789");
            Assert.AreEqual(100, phone.PhoneBookCapacity);
        }

        [TestMethod]
        public void WlasciwoscPhoneNumberNullorEmpty()
        {
            //Arrange
            var wlasciciel = "Kowalski";
            var numer = "";
            //Act
            //Assert
            Assert.ThrowsException<ArgumentException>(() => new Phone(wlasciciel, numer));
        }

        [TestMethod]
        public void WlasciwoscPhoneNumberPoprawneDane()
        {
            //Arrange
            var wlasciciel = "Kowalski";
            var numer = "123456789";
            //Act
            var telefon = new Phone(wlasciciel, numer);
            //Assert
            Assert.AreEqual(numer, telefon.PhoneNumber);
        }

        [TestMethod]
        public void WlasciwoscphoneBookCount()
        {
            //Arrange
            var wlasciciel = "Kowalski";
            var numer = "123456789";
            //Act
            var telefon = new Phone(wlasciciel, numer);
            //Assert
            Assert.AreEqual(0, telefon.Count);
        }

        [TestMethod]
        public void DodanieKontaktu()
        {
            //Arrange
            var wlasciciel = "Kowalski";
            var numer = "123456789";
            //Act
            var telefon = new Phone(wlasciciel, numer);
            telefon.AddContact("Kowalski", "123456789");
            //Assert
            Assert.AreEqual(1, telefon.Count);
        }

        [TestMethod]
        public void DodanieKontaktuDoPelnejKsiazki()
        {
            //Arrange
            var wlasciciel = "Kowalski";
            var numer = "123456789";
            //Act
            var telefon = new Phone(wlasciciel, numer);
            for (int i = 0; i < 100; i++)
            {
                telefon.AddContact($"Kowa{i}lski", "123456789");
            }
            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => telefon.AddContact("Kowalski", "123456789"));
        }

        [TestMethod]
        public void DodanieKontaktuZTakaSamaNazwa()
        {
            //Arrange
            var wlasciciel = "Kowalski";
            var numer = "123456789";
            //Act
            var telefon = new Phone(wlasciciel, numer);
            telefon.AddContact("Kowalski", "123456789");
            //Assert
            Assert.IsFalse(telefon.AddContact("Kowalski", "123456789"));
        }

        [TestMethod]
        public void DodanieKontaktuZTakaSamaNazwaInnyNumer()
        {
            //Arrange
            var wlasciciel = "Kowalski";
            var numer = "123456789";
            //Act
            var telefon = new Phone(wlasciciel, numer);
            telefon.AddContact("Kowalski", "123456789");
            //Assert
            Assert.IsFalse(telefon.AddContact("Kowalski", "123456788"));
        }

        [TestMethod]
        public void DodanieKontaktuZInnaNazwaTakiSamNumer()
        {
            //Arrange
            var wlasciciel = "Kowalski";
            var numer = "123456789";
            //Act
            var telefon = new Phone(wlasciciel, numer);
            telefon.AddContact("Kowalski", "123456789");
            //Assert
            Assert.IsTrue(telefon.AddContact("Kowalski1", "123456789"));
        }

        [TestMethod]
        public void DodanieKontaktuZInnaNazwaInnyNumer()
        {
            //Arrange
            var wlasciciel = "Kowalski";
            var numer = "123456789";
            //Act
            var telefon = new Phone(wlasciciel, numer);
            telefon.AddContact("Kowalski", "123456789");
            //Assert
            Assert.IsTrue(telefon.AddContact("Kowalski1", "123456788"));
        }

        [TestMethod]
        public void DzwonienieDoOsobyWKsiazce()
        {
            //Arrange
            var wlasciciel = "Kowalski";
            var numer = "123456789";
            //Act
            var telefon = new Phone(wlasciciel, numer);
            telefon.AddContact("Kowalski", "123456789");
            //Assert
            Assert.AreEqual($"Calling {numer} ({wlasciciel}) ...", telefon.Call("Kowalski"));
        }

        [TestMethod]
        public void DzwonienieDoOsobyNieWKsiazce()
        {
            //Arrange
            var wlasciciel = "Kowalski";
            var numer = "123456789";
            //Act
            var telefon = new Phone(wlasciciel, numer);
            //Assert
            Assert.ThrowsException<InvalidOperationException>(() => telefon.Call("Kowalski"));
        }

    }
}