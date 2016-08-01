namespace Santase.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Logic.Cards;
    using Logic;

    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void DeckShouldInitializeProperly()
        {
            var deck = new Deck();
            Assert.IsNotNull(deck);
        }

        [TestMethod]
        public void DeckShouldInitializeTrumpCardProperly()
        {
            var deck = new Deck();
            Assert.IsNotNull(deck.TrumpCard);
        }

        [TestMethod]
        [ExpectedException(typeof(InternalGameException))]
        public void GetNextCardShouldThrowsAnException()
        {
            var deck = new Deck();

            while (true)
            {
                deck.GetNextCard();
            }
        }

        [TestMethod]
        public void ChangeTrumpCardShouldChangesCorrectly()
        {
            var deck = new Deck();
            var card = new Card(CardSuit.Diamond, CardType.Queen);
            deck.ChangeTrumpCard(card);
            Assert.IsTrue(deck.TrumpCard.Equals(card));
        }

        [TestMethod]
        public void GetNextCardShouldReturnsValidcard()
        {
            var deck = new Deck();
            Assert.IsTrue(typeof(Card) == deck.GetNextCard().GetType());
        }
    }
}
