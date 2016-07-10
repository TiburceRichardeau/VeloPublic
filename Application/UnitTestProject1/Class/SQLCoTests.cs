using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VeloPublic.Tests
{
    [TestClass()]
    public class SQLCoTests
    {
        /// <summary>
        /// Test unitaire qui vérifie si la connexion SQL est bien faite
        /// <author>Tiburce Richardeau</author>
        /// </summary>
        [TestMethod()]
        public void connexionTest()
        {
            SQLCo co = new SQLCo("localhost", "userVeloPublic", "userVeloPublic", "veloinfospublic", "utf8");
            bool result = co.Connexion();
            bool attendue = true;
            Assert.AreEqual(attendue, result);
        }

        /// <summary>
        /// Test unitaire qui vérifie si la déconecxion est bien faite
        /// <author>Tiburce Richardeau</author>
        /// </summary>
        [TestMethod()]
        public void deconnexionTest()
        {
            SQLCo co = new SQLCo("localhost", "userVeloPublic", "userVeloPublic", "veloinfospublic", "utf8");
            co.Connexion();
            bool result = co.Deconnexion();
            bool attendue = true;
            Assert.AreEqual(attendue, result);
        }
    }
}