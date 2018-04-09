using _06.Twitter;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using Moq;
using _06.Twitter.Contracts;

namespace UnitTests
{
    [TestFixture]
    class TwitterTests
    {
        [Test]
        [TestCase("I am message")]
        [TestCase("Next message will consist only of numbers")]
        [TestCase("123123")]
        [TestCase("I will test constructor")]
        [TestCase("Българско съобщение")]
        [TestCase("I will consist special chars: \\")]
        public void TestIfMessageIsCorrectlyCreated(string messageText)
        {
            var message = new Message(messageText);

            var internalMessageText = (string)typeof(Message)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .First(p => p.PropertyType == typeof(string))
                .GetValue(message);

            Assert.That(internalMessageText, Is.EqualTo(messageText));
        }

        [Test]
        [TestCase("I am message")]
        [TestCase("Next message will consist only of numbers")]
        [TestCase("123123")]
        [TestCase("I will test constructor")]
        [TestCase("Българско съобщение")]
        [TestCase("I will consist special chars: \\")]
        public void TestRetrieveMessageMethodValid(string messageText)
        {
            var message = new Message(messageText);

            Assert.That(message.RetrieveMessage(), Is.EqualTo(messageText));
        }

        [Test]
        [TestCase(null)]
        [TestCase("       ")]
        public void TestInvalidMessageRetrieve(string messageText)
        {
            var message = new Message(messageText);

            Assert.That(() => message.RetrieveMessage(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase("I am message")]
        [TestCase("Next message will consist only of numbers")]
        [TestCase("123123")]
        [TestCase("I will test constructor")]
        [TestCase("Българско съобщение")]
        [TestCase("I will consist special chars: \\")]
        public void TestSuccessfullMessageReceivment(string messageText)
        {
            var fakeMessage = new Mock<ITweet>();
            fakeMessage.Setup(m => m.RetrieveMessage())
                .Returns(messageText);
            var fakeServer = new Mock<IServer>();
            fakeServer.Setup(s => s.ReceiveMessage(fakeMessage.Object))
                .Returns(true);

            var expectedValue = true;

            var microwaveOven = new MicrowaveOven(fakeServer.Object);
            bool actualValue = microwaveOven.ReceiveMessage(fakeMessage.Object);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        [TestCase("I am message")]
        [TestCase("Next message will consist only of numbers")]
        [TestCase("123123")]
        [TestCase("I will test constructor")]
        [TestCase("Българско съобщение")]
        [TestCase("I will consist special chars: \\")]
        public void TestInvalidMessageReceivment(string messageText)
        {
            var fakeMessage = new Mock<ITweet>();
            fakeMessage.Setup(m => m.RetrieveMessage())
                .Returns(messageText);
            var fakeServer = new Mock<IServer>();
            fakeServer.Setup(s => s.ReceiveMessage(fakeMessage.Object))
                .Returns(false);

            var expectedValue = false;

            var microwaveOven = new MicrowaveOven(fakeServer.Object);
            bool actualValue = microwaveOven.ReceiveMessage(fakeMessage.Object);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
